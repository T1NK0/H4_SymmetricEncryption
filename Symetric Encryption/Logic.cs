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
        //Method to encrypt the string to bytes
        public byte[] EncryptStringToBytes(string encryptionChoice, string plainText, byte[] Key, byte[] IV, string cipherMode)
        {
            // Check arguments if null or less than or equal 0.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            if (cipherMode == null || cipherMode.Length <= 0)
                throw new ArgumentNullException("cipherMode");

            //ByteArray we will return containing the result of the encryption.
            byte[] encrypted;

            //Create instance of Symmetric Algorithm called mySymetricAlgorithm and set to null se owe can create it on if later.
            SymmetricAlgorithm mySymetricAlgorithm = null;

            // Our encryption options based off the parameters from the method above.
            if (encryptionChoice == "TrippleDes")
            {
                mySymetricAlgorithm = TripleDES.Create();
            }
            else if (encryptionChoice == "AES")
            {
                mySymetricAlgorithm = Aes.Create();
            }

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
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        public string DecryptStringFromBytes(string encryptionChoice, byte[] cipherText, byte[] Key, byte[] IV, string cipherMode)
        {
            // Check arguments if null or less then or equal to 0.
            if (encryptionChoice == null || encryptionChoice.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            if (cipherMode == null || cipherMode.Length <= 0)
                throw new ArgumentNullException("cipherMode");

            //String we will return containing the result of the decryption.
            string plaintext = null;

            //Create instance of SymmetricAlgorithm called MySymetricAlgorithm.
            SymmetricAlgorithm mySymetricAlgorithm = null;

            //if to decide the encryption type to make.
            if (encryptionChoice == "TrippleDes")
            {
                mySymetricAlgorithm = TripleDES.Create();
            }
            else if (encryptionChoice == "AES")
            {
                mySymetricAlgorithm = Aes.Create();
            }

            //Key parameter of encryption.
            mySymetricAlgorithm.Key = Key;

            //IV (Can be seen as the salt of the encryption) parameter of the encryption.
            mySymetricAlgorithm.IV = IV;

            //If to decide CipherMode chosen.
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
                        // Read the decrypted bytes from the decrypting stream and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

        public byte[] CreateKeyWithUserInput(int length)
        {
            //Generate a cryptographic random number
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            //Byte array called buff taking in the length of the parameter from the method.
            byte[] buff = new byte[length];
            //Fill the byte array.
            rng.GetBytes(buff);

            //return the byte array.
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
