using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Camera
{
    public static class Log
    {
        public static void log(string msg)
        {
            string filePath = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase+"Log";
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            string logPath = AppDomain.CurrentDomain.BaseDirectory + "Log\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
            try
            {
                using(StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine(DateTime.Now.ToString("yy-MM-dd  HH:mm:ss"));
                    sw.WriteLine( msg);
                    sw.WriteLine("**************************************************************************************************");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }catch(IOException e)
            {
                using (StreamWriter sw = File.AppendText(logPath))
                {
                    sw.WriteLine("时间" + DateTime.Now.ToString("yy-MM-dd HH:mm:ss"));
                    sw.WriteLine("异常" + e.Message);
                    sw.WriteLine("**************************************************************************************************");
                    sw.WriteLine();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();

                }
            }
        }
    }
}
