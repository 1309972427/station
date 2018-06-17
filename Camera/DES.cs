using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Camera
{
   public static class DES
    {
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="str">需要进行DES加密的字符串</param>
        /// <param name="key">加密的密钥</param>
        /// <returns></returns>
        public static string Encode(string str, string key)
        {

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Key = Encoding.UTF8.GetBytes(key);
            provider.IV = Encoding.UTF8.GetBytes(key);


            byte[] bytes = Encoding.GetEncoding("UTF-8").GetBytes(str);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            StringBuilder builder = new StringBuilder();
            foreach (byte num in stream.ToArray())
            {
                builder.AppendFormat("{0:X2}", num);
            }
            stream.Close();
            return builder.ToString();
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="strDecryptString">需要进行DES解密的字符串</param>
        /// <param name="key">解密的密钥</param>
        /// <returns></returns>
        public static string Decode(string strDecryptString, string key)
        {
            string retValue = "";
            try
            {
                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                provider.Key = Encoding.UTF8.GetBytes(key);
                provider.IV = Encoding.UTF8.GetBytes(key);
                byte[] inputByteArray = new byte[strDecryptString.Length / 2];
                for (int i = 0; i < strDecryptString.Length / 2; i++)
                {
                    int x = (Convert.ToInt32(strDecryptString.Substring(i * 2, 2), 16));
                    inputByteArray[i] = (byte)x;
                }
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, provider.CreateDecryptor(), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                retValue = Encoding.UTF8.GetString(mStream.ToArray()).TrimEnd('\0');
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
            return retValue;
        }

    }
}
