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
        //This method is  responsible for encoding the password
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


    }
}