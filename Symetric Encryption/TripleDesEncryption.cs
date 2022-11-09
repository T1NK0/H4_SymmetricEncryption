using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Symetric_Encryption
{
    class TripleDesEncryption
    {
        /// <summary>
        /// Based on example from:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-6.0
        /// </summary>
        /// <param name="plainText">Text to encrypt</param>
        /// <param name="Key">Key word for encoding</param>
        /// <param name="IV"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (SymmetricAlgorithm mySymetricAlgorithm = TripleDES.Create())
            {
                mySymetricAlgorithm.Key = Key;
                mySymetricAlgorithm.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = mySymetricAlgorithm.CreateEncryptor(mySymetricAlgorithm.Key, mySymetricAlgorithm.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        /// <summary>
        /// Based on example from:
        /// https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=net-6.0
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Rijndael object
            // with the specified key and IV.
            using (SymmetricAlgorithm mySymetricAlgorithm = TripleDES.Create())
            {
                mySymetricAlgorithm.Key = Key;
                mySymetricAlgorithm.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = mySymetricAlgorithm.CreateDecryptor(mySymetricAlgorithm.Key, mySymetricAlgorithm.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
