using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Symetric_Encryption
{
    class AesEncryption
    {

        public byte[] AesEncryptStringToBytes(string plainText, byte[] Key, byte[] IV, string cipherMode)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");            
            if (cipherMode == null || cipherMode.Length <= 0)
                throw new ArgumentNullException("cipherMode");

            byte[] encrypted;
            // Create an AES object
            // with the specified key and IV.
            using (SymmetricAlgorithm mySymetricAlgorithm = Aes.Create())
            {
                mySymetricAlgorithm.Key = Key;
                mySymetricAlgorithm.IV = IV;
                if (cipherMode == "CBC")
                {
                    mySymetricAlgorithm.Mode = CipherMode.CBC;
                }
                else if (cipherMode == "ECB")
                {
                    mySymetricAlgorithm.Mode = CipherMode.ECB;
                }
                mySymetricAlgorithm.Padding = PaddingMode.PKCS7;

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

        public string AesDecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV, string cipherMode)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            if (cipherMode == null || cipherMode.Length <= 0)
                throw new ArgumentNullException("cipherMode");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an AES object
            // with the specified key and IV.
            using (SymmetricAlgorithm mySymetricAlgorithm = Aes.Create())
            {
                mySymetricAlgorithm.Key = Key;
                mySymetricAlgorithm.IV = IV;
                if (cipherMode == "CBC")
                {
                    mySymetricAlgorithm.Mode = CipherMode.CBC;
                }
                else if (cipherMode == "ECB")
                {
                    mySymetricAlgorithm.Mode = CipherMode.ECB;
                }
                mySymetricAlgorithm.Padding = PaddingMode.PKCS7;

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
