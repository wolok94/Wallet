using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Portfel
{
    public class Encrypter
    {
        public static string Encrypt(string value)
        {
            try
            {
                byte[] oByte = new byte[value.Length];
                oByte = System.Text.Encoding.UTF8.GetBytes(value);
                string EncodedData = "25" + Convert.ToBase64String(oByte);
                return EncodedData;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public static string Decrypt(string value)
        {
            try
            {

                System.Text.UTF8Encoding oUTF8Encoding = new System.Text.UTF8Encoding();
                System.Text.Decoder oDecoder = oUTF8Encoding.GetDecoder();
                byte[] oBytes = Convert.FromBase64String(value);
                int CharCount = oDecoder.GetCharCount(oBytes, 0 ,oBytes.Length);
                char[] decodedChar = new char[CharCount];
                oDecoder.GetChars(oBytes, 0, oBytes.Length, decodedChar, 0);
                string decodedData = new string(decodedChar);
                return decodedData;
            }catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}