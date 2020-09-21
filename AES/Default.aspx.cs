using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

namespace AES
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CodeDechiffre.Text = Decrypt(DownloadString("http://aes/chiffrer.php"), "e835529c2a196ee1026d6c1a7d77f28c");
            //CodeDechiffre.Text = DownloadString("http://aes/chiffrer.php");
        }
        public String Decrypt(String text, String key)
        {
            //decode cipher text from base64
            byte[] cipher = Convert.FromBase64String(text);
            //get key bytes
            byte[] btkey = Encoding.ASCII.GetBytes(key);

            //init AES 256
            RijndaelManaged aes256 = new RijndaelManaged
            {
                Mode = CipherMode.ECB,
                Padding = PaddingMode.Zeros,
        };

            //decrypt
            ICryptoTransform decryptor = aes256.CreateDecryptor(btkey, null);
            MemoryStream ms = new MemoryStream(cipher);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            byte[] plain = new byte[cipher.Length];
            int decryptcount = cs.Read(plain, 0, plain.Length);

            ms.Close();
            cs.Close();

            //return plaintext in String
            return Encoding.UTF8.GetString(plain, 0, decryptcount);
        }

        public static string DownloadString(string address)
        {
            WebClient client = new WebClient();
            string reply = client.DownloadString(address);

            return reply;
        }

    }
}