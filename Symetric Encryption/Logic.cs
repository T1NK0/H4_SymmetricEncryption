using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Symetric_Encryption
{
    public class Logic
    {
        public byte[] CreateKeyWithUserInput(int length)
        {
            //Generate a cryptographic random number
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[length];
            rng.GetBytes(buff);

            return buff;
        }

        public string MyStringBuilder(byte[] input)
        {
            //Use a string builder to assemble the bytes to a string with text format instead of hexadecimal
            StringBuilder sb = new StringBuilder();
            foreach (byte b in input)
            {
                //ToString("x2") is to format hexadecimal to text
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }
}
