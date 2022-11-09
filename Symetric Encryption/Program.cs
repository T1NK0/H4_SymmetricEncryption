using System.Security.Cryptography;
using System.Text;

//Console.WriteLine("Choose a cipher, by pressing 1, 2 or 3\n" +
//    "1. DES\n" +
//    "2. TrippleDes\n" +
//    "3. AES\n");

//string cipher = Console.ReadLine();

string key = "vfNhx4fub1WeMnyaAmcvzw==";
string iv = "1rZP/rpVONgvZlleknD6zw==";

SymmetricAlgorithm mySymetricAlgorithm = Aes.Create();
mySymetricAlgorithm.IV = Convert.FromBase64String(iv);
mySymetricAlgorithm.Key = Convert.FromBase64String(key);
//mySymetricAlgorithm.KeySize = 256;

string message = "Dette er en test! WOOHOO!";
byte[] messageAsByteArray = Encoding.UTF8.GetBytes(message);
//byte[] keyAsByteArray = Encoding.UTF8.GetBytes(key);
//byte[] ivAsByteArray = Encoding.UTF8.GetBytes(iv);

string encryptedMessage = MyStringBuilder(Encrypt(messageAsByteArray, mySymetricAlgorithm));
string decryptedMessage = MyStringBuilder(Decrypt(Convert.FromBase64String(encryptedMessage), mySymetricAlgorithm));

Console.WriteLine(encryptedMessage);
Console.WriteLine(decryptedMessage);

//adc61e90530277325540bc099088a48bfc7999fb122cf6953e17d4ed35cd3f14

//Generate(cipher);

//void Generate(string cipher)
//{
//    switch (cipher)
//    {
//        case "1":
//            mySymetricAlgorithm = TripleDES.Create();
//            break;
//        case "2":
//            mySymetricAlgorithm = Aes.Create();
//            break;
//        default:
//            break;
//    }

//    mySymetricAlgorithm.GenerateIV();
//    mySymetricAlgorithm.GenerateKey();
//}

//Mål krypteringshastighed på en tekst
//128bit, 192bit, 256bit key size

//ECB ELLER CBC
//ElectronicCookBook = ECB
//


//byte[] Encrypt(byte[] message, byte[] key, byte[] iv)
byte[] Encrypt(byte[] message, SymmetricAlgorithm mySymetricAlgorithm)
{
    //mySymetricAlgorithm.Key = key;
    //mySymetricAlgorithm.IV = iv;
    using (MemoryStream ms = new MemoryStream())
    {
        using (CryptoStream cs = new CryptoStream(ms, mySymetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
        {
            cs.Write(message, 0, message.Length);
            cs.Close();

            return ms.ToArray();
        }
    }
}

byte[] Decrypt(byte[] message, SymmetricAlgorithm mySymetricAlgorithm)
{
    byte[] plainText = new byte[message.Length];
    //mySymetricAlgorithm.Key = key;
    //mySymetricAlgorithm.IV = iv;
    using (MemoryStream ms = new MemoryStream())
    {
        using (CryptoStream cs = new CryptoStream(ms, mySymetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
        {
            cs.Read(plainText, 0, message.Length);
            cs.Close();

            return plainText;
        }
    }
}

string CreateKey()
{
    //Generate a cryptographic random number.
    RandomNumberGenerator rng = RandomNumberGenerator.Create();
    byte[] buff = new byte[16];
    rng.GetBytes(buff);

    // Return a Base64 string representation of the random number.
    return Convert.ToBase64String(buff);
}

string MyStringBuilder(byte[] input)
{
    //Use a string builder to assemble the bytes to a string with text format, instead of hexadecimal.
    StringBuilder sb = new StringBuilder();
    foreach (byte b in input)
    {
        //ToString("x2") is to format hexadecimal to text.
        sb.Append(b.ToString("x2"));
    }

    return sb.ToString();
}

Console.ReadLine();
