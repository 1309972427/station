using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Camera
{
    class TcpConnection
    {
        public event DataHandler OnPacketReceived;

        public bool IsConnected { get { return _isConnected; } }

        public TcpConnection(string serverIp, int serverPort)
        {
            this.serialServerIp = serverIp;
            this.serialServerPort = serverPort;
        }

        public async Task<bool> Open()
        {
            if (_isConnected)
            {
                return false;
            }

            try
            {
                _tcp = new TcpClient();
                await _tcp.ConnectAsync(IPAddress.Parse(serialServerIp), serialServerPort);

                DoReceive(_tcp.GetStream());
                //_receiveTask = new Task(DoReceive);
                //_receiveTask.Start();
            }
            catch (Exception ex)
            {
                _tcp = null;
                throw ex;
            }

            _isConnected = true;
            return true;
        }

        public bool Close()
        {
            if (!_isConnected)
            {
                return false;
            }

            try
            {
                _tcp.Close();
                _tcp = null;
            }
            catch
            {
                return false;
            }

            _isConnected = false;
            return true;
        }

        public async Task<bool> SendData(byte[] packet, int count)
        {

            byte[] modbusTcpPacket = new byte[count + 6];
            int i = 0;
            modbusTcpPacket[i++] = 0;
            modbusTcpPacket[i++] = 0;
            modbusTcpPacket[i++] = 0;
            modbusTcpPacket[i++] = 0;
            modbusTcpPacket[i++] = (byte)((count >> 8) & 0xff);
            modbusTcpPacket[i++] = (byte)(count & 0xff);
            packet.CopyTo(modbusTcpPacket, 6);

            int n = 3;
            while (n-- > 0)
            {
                await Open();
                try
                {
                    NetworkStream stream = _tcp.GetStream();
                    await stream.WriteAsync(modbusTcpPacket, 0, count + 6);
                    await stream.FlushAsync();
                    break;
                }
                catch
                {
                    Close();
                }
            }

            if (n == -1)
                return false;

            return true;
        }

        // Backup
        //public async Task<bool> SendData(byte[] packet, int count)
        //{
        //    if (!_isConnected)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        byte[] modbusTcpPacket = new byte[count + 6];
        //        int i = 0;
        //        modbusTcpPacket[i++] = 0;
        //        modbusTcpPacket[i++] = 0;
        //        modbusTcpPacket[i++] = 0;
        //        modbusTcpPacket[i++] = 0;
        //        modbusTcpPacket[i++] = (byte)((count >> 8) & 0xff);
        //        modbusTcpPacket[i++] = (byte)(count & 0xff);
        //        packet.CopyTo(modbusTcpPacket, 6);

        //        NetworkStream stream = _tcp.GetStream();
        //        //stream.Write(modbusTcpPacket, 0, count + 6);

        //        await stream.WriteAsync(modbusTcpPacket, 0, count + 6);

        //        await stream.FlushAsync();
        //    }
        //    catch
        //    {
        //        return false;

        //    }

        //    return true;
        //}

        private void DoReceive(NetworkStream stream)
        {
            Byte[] buffer = new Byte[1024];

            AsyncCallback callback = null;
            callback = new AsyncCallback(result =>
            {
                try
                {
                    int numOfBytesRead = stream.EndRead(result);
                    if (numOfBytesRead > 0)
                    {
                        byte[] packet = GetPacket(buffer.Take(numOfBytesRead).ToArray());
                        if (packet != null)
                        {
                            OnPacketReceived(packet);
                        }
                        stream.BeginRead(buffer, 0, buffer.Length, callback, null);
                    }
                }
                catch
                {
                }
            });

            try
            {
                stream.BeginRead(buffer, 0, buffer.Length, callback, null);
            }
            catch
            {
            }
        }

        // Backup
        //private void DoReceive()
        //{
        //    NetworkStream stream = _tcp.GetStream();
        //    byte[] buffer = new byte[1024];

        //    while (_isConnected)
        //    {
        //        try
        //        {
        //            int numOfBytesRead = stream.Read(buffer, 0, buffer.Length);

        //            if (numOfBytesRead > 0)
        //            {
        //                byte[] packet = GetPacket(buffer.Take(numOfBytesRead).ToArray());
        //                if (packet != null)
        //                {
        //                    OnPacketReceived(packet);
        //                }
        //            }
        //        }
        //        catch
        //        {

        //        }
        //    }
        //}

        private byte[] GetPacket(byte[] data)
        {
            if (data.Length < 9)
                return null;
            if (data[0] != 0 || data[1] != 0 || data[2] != 0 || data[3] != 0)
                return null;
            int len = 0;
            len |= (int)data[4] << 0xff;
            len |= data[5];
            if (len + 6 > data.Length)
                return null;
            return data.Skip(6).Take(len).ToArray();
        }

        private int MakeRandomPort()
        {
            return new Random().Next(2049, 60000);
        }

        private string serialServerIp = string.Empty;
        private int serialServerPort = 0;
        //private Task _receiveTask = null;
        private bool _isConnected;
        private TcpClient _tcp = null;
    }

    delegate void DataHandler(byte[] data);
}
