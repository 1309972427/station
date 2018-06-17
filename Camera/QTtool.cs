using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Camera
{
    public class QTtool
    {
        static Random ra = new Random();
        public static int RandomInt(int maxvalue)
        {
            return ra.Next(maxvalue);

        }
        public static int RandomInt(int minvalue, int maxvalue)
        {
            return ra.Next(minvalue, maxvalue);

        }

        public static List<BroadCallInfo> GetCallBroadIP(string par)
        {
            string[] ss1 = par.Split(',');
            List<BroadCallInfo> result = new List<BroadCallInfo>();
            foreach (string s in ss1)
            {
                if (s.Trim().Length > 0)
                {
                    string[] ss2 = s.Split('|');
                    result.Add(new BroadCallInfo(ss2[0], ss2[1].Trim(), ss2[2]));

                }

            }

            return result;
        }
        static SoundPlayer player = new SoundPlayer();
        public static void playWavAudio(string path)
        {
            if (player.IsLoadCompleted)
                player.Stop();
            player.SoundLocation = path;
            player.Load();
            player.Play();
        }

        public static void playWavAudio(Stream io)
        {
            if (player.IsLoadCompleted)
                player.Stop();
            player.Stream = io;
            player.Load();
            player.Play();
        }

        public struct MicClientInfo
        {
            public const int 断线 = 0, 空闲 = 1, 直播 = 2, 拨号对讲 = 3;
            static string[] statusmap = new string[] { "断线", "空闲", "直播", "拨号对讲" };
            public string ID;
            public string IP;
            public string Status;
            public MicClientInfo(string ID, string IP, string status)
            {
                this.ID = ID;
                this.IP = IP;
                this.Status = statusmap[int.Parse(status)];

            }
            public string[] toStringArray()
            {
                return new string[] { ID, IP, Status };
            }
        }
        public static List<MicClientInfo> GetMicClientStatus(string info)
        {

            List<MicClientInfo> lsmc = new List<MicClientInfo>();
            string[] ls = info.Split(',');
            foreach (string s in ls)
            {
                string[] infos = s.Split('|');
                if (infos.Length == 3)
                    lsmc.Add(new MicClientInfo(infos[0], infos[1], infos[2]));
            }


            return lsmc;

        }
    }
    public struct BroadCallInfo
    {
        public string s_num;
        public int e_num;
        public string ip;
        public BroadCallInfo(string s_num, string ip, string e_num)
        {
            this.s_num = s_num; this.e_num = int.Parse(e_num);
            this.ip = ip;
        }

    }






}
