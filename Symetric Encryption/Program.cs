using Symetric_Encryption;
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("Choose a cipher, by pressing 1, 2 or 3\n" +
    "1. TrippleDes\n" +
    "2. AES\n");

string cipher = Console.ReadLine();

SymmetricAlgorithm mySymetricAlgorithm;

switch (cipher)
{
    case "1":
        mySymetricAlgorithm = TripleDES.Create();
        Console.WriteLine("TrippleDES encoding created");
        break;
    case "2":
        mySymetricAlgorithm = Aes.Create();
        Console.WriteLine("AES encoding created");
        break;
    default:
        break;
}

Console.WriteLine("Encoding created");

//CreateKey()

string key = "vfNhx4fub1WeMnyaAmcvzw==";
string iv = "1rZP/rpVONgvZlleknD6zw==";
//SymmetricAlgorithm mySymetricAlgorithm = Aes.Create();
//mySymetricAlgorithm.IV = Convert.FromBase64String(iv);
//mySymetricAlgorithm.Key = Convert.FromBase64String(key);
//mySymetricAlgorithm.KeySize = 128;
//mySymetricAlgorithm.Mode = CipherMode.CBC;
//mySymetricAlgorithm.Padding = PaddingMode.PKCS7;

string message = "Dette er en test! WOOHOO!";
//byte[] messageAsByteArray = Encoding.UTF8.GetBytes(message);
byte[] keyAsByteArray = Convert.FromBase64String(key);
byte[] ivAsByteArray = Convert.FromBase64String(iv);

AesEncryption aesEncryption = new AesEncryption();

byte[] encrypted = aesEncryption.AesEncryptStringToBytes(message, keyAsByteArray, ivAsByteArray);
string decrypted = aesEncryption.AesDecryptStringFromBytes(encrypted, keyAsByteArray, ivAsByteArray);

Console.WriteLine(MyStringBuilder(encrypted));
Console.WriteLine(decrypted);


//IV Skal være 16 eller 128 bit

//Mål krypteringshastighed på en tekst
//128bit 192bit 256bit key size

//For TrippleDes
//ECB ELLER CBC
//ElectronicCookBook is ECB
//CipherBlockChain is CBC


//byte[] Encrypt(byte[] message, byte[] key, byte[] iv)
byte[] Encrypt(byte[] message, SymmetricAlgorithm mySymetricAlgorithm)
{
    using (MemoryStream msEncrypt = new MemoryStream())
    {
        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, mySymetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
        {
            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(message);
            }

            return msEncrypt.ToArray();
        }
    }
}

string Decrypt(byte[] message, SymmetricAlgorithm mySymetricAlgorithm)
{
    using (MemoryStream msDecrypt = new MemoryStream())
    {
        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, mySymetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Read))
        {
            using (StreamReader swDecrypt = new StreamReader(csDecrypt))
            {
            return swDecrypt.ReadToEnd();
            }
        }
    }

    //byte[] plainText = new byte[message.Length];

    //using (MemoryStream ms = new MemoryStream())
    //{
    //    using (CryptoStream cs = new CryptoStream(ms, mySymetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
    //    {
    //        cs.Read(plainText, 0, message.Length);
    //        cs.FlushFinalBlock();

    //        return plainText.ToArray();
    //    }
    //}
}

byte[] CreateKeyWithUserInput(int length)
{
    //Generate a cryptographic random number
    RandomNumberGenerator rng = RandomNumberGenerator.Create();
    byte[] buff = new byte[length];
    return buff;
    //// Return a Base64 string representation of the random number
    //return Convert.ToBase64String(buff);
}

string CreateKey(int length)
{
    //Generate a cryptographic random number
    RandomNumberGenerator rng = RandomNumberGenerator.Create();
    byte[] buff = new byte[length];
    rng.GetBytes(buff);

    // Return a Base64 string representation of the random number
    return Convert.ToBase64String(buff);
}

string MyStringBuilder(byte[] input)
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

Console.ReadLine();
