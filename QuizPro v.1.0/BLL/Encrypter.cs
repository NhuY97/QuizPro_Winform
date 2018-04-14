using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace QuizPro_v._1._0
{
    // mã hóa câu hỏi bằng giải thuật MD5
    public static class Encrypter
    {
        static readonly string hash = "y@zenny";
        public static string Encrypt(string pwd)
        {
            byte[] buffer = UTF8Encoding.UTF8.GetBytes(pwd);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB,Padding=PaddingMode.PKCS7})
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] result = transform.TransformFinalBlock(buffer, 0, buffer.Length);
                    return Convert.ToBase64String(result, 0, result.Length);
                }
            }
        }

        public static string Decrypt(string pwd)
        {
            byte[] buffer = Convert.FromBase64String(pwd);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] result = transform.TransformFinalBlock(buffer, 0, buffer.Length);
                    return UTF8Encoding.UTF8.GetString(result);
                }
            }
        }

    }
}
