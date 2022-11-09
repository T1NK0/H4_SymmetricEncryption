﻿using Symetric_Encryption;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

SymmetricAlgorithm mySymetricAlgorithm;
AesEncryption aesEncryption = new AesEncryption();
TripleDesEncryption tripleDesEncryption = new TripleDesEncryption();
Logic logic = new Logic();
Stopwatch timer = new Stopwatch();


//string key = "vfNhx4fub1WeMnyaAmcvzw==";
string key = "";
//string iv = "1rZP/rpVONgvZlleknD6zw==";
string iv = "";

string message = "";
byte[] keyAsByteArray;
byte[] ivAsByteArray;
byte[] encrypted;
byte[] userGeneratedKeyAsByteArray;
byte[] userGenerateIvAsByteArray;
int userGeneratedKey;
int userGenerateIv;
string decrypted = "";
string cipherMode = "";
string cipherModeChoice = "";

Console.WriteLine("Choose a cipher, by pressing 1, 2 or 3\n" +
    "1. TrippleDes\n" +
    "2. AES");

string cipher = Console.ReadLine();


switch (cipher)
{
    case "1":
        mySymetricAlgorithm = TripleDES.Create();
        Console.WriteLine("Write a text to encrypt:");
        message = Console.ReadLine();

        Console.WriteLine("Create a key with lengths 16");
        userGeneratedKey = Convert.ToInt32(Console.ReadLine());
        userGeneratedKeyAsByteArray = logic.CreateKeyWithUserInput(userGeneratedKey);
        Console.WriteLine(logic.MyStringBuilder(userGeneratedKeyAsByteArray));

        Console.WriteLine("Create a IV 8");
        userGenerateIv = Convert.ToInt32(Console.ReadLine());
        userGenerateIvAsByteArray = logic.CreateKeyWithUserInput(userGenerateIv);
        Console.WriteLine(logic.MyStringBuilder(userGenerateIvAsByteArray));

        Console.WriteLine("Choose CipherMode\n" +
            "1. CBC\n" +
            "2. ECB");
        cipherModeChoice = Console.ReadLine();

        switch (cipherModeChoice)
        {
            case "1":
                cipherMode = "CBC";
                break;
            case "2":
                cipherMode = "ECB";
                break;
            default:
                break;
        }
        timer.Start();
        encrypted = tripleDesEncryption.EncryptStringToBytes(message, userGeneratedKeyAsByteArray, userGenerateIvAsByteArray, cipherMode);
        timer.Stop();

        Console.WriteLine("Time used to encrypt: " + timer.Elapsed.TotalMilliseconds + "miliseconds");
        decrypted = tripleDesEncryption.DecryptStringFromBytes(encrypted, userGeneratedKeyAsByteArray, userGenerateIvAsByteArray, cipherMode);

        Console.WriteLine("\n" + "Encrypted:\n" + logic.MyStringBuilder(encrypted));
        Console.WriteLine("\n" + "Decrypted:\n" + decrypted);
        break;
    case "2":
        mySymetricAlgorithm = Aes.Create();

        Console.WriteLine("Write a text to encrypt:");
        message = Console.ReadLine();

        Console.WriteLine("Create a key with lengths 32");
        userGeneratedKey = Convert.ToInt32(Console.ReadLine());
        userGeneratedKeyAsByteArray = logic.CreateKeyWithUserInput(userGeneratedKey);

        Console.WriteLine(logic.MyStringBuilder(userGeneratedKeyAsByteArray));

        Console.WriteLine("Create a IV 16");
        userGenerateIv = Convert.ToInt32(Console.ReadLine());
        userGenerateIvAsByteArray = logic.CreateKeyWithUserInput(userGenerateIv);
        Console.WriteLine(logic.MyStringBuilder(userGenerateIvAsByteArray));

        Console.WriteLine("Choose CipherMode\n"+
            "1. CBC\n" +
            "2. ECB");
        cipherModeChoice = Console.ReadLine();

        switch (cipherModeChoice)
        {
            case"1":
                 cipherMode = "CBC";
                break;
            case "2":
                cipherMode = "ECB";
                break;
            default:
                break;
        }

        //string longPreDefinedMessage = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent sollicitudin sapien at elit rutrum tempus. Proin porttitor nisl nulla, sit amet egestas sapien dapibus eget. Curabitur vitae ligula ex. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec ac augue non tortor blandit eleifend a a purus. In quis justo ex. Sed tristique sapien vel metus scelerisque semper. Morbi eget libero augue. Duis malesuada dolor et justo aliquet, sed dictum mi ornare. Nulla sodales, ligula vel congue semper, ipsum erat vehicula purus, sit amet dapibus dolor ipsum ac dolor. Fusce luctus nisi finibus, imperdiet dui quis, ultricies odio. Maecenas in rutrum justo. Donec placerat tellus a ipsum sollicitudin, vitae vehicula libero interdum. Duis imperdiet elit vitae quam tempus facilisis. Donec quis dolor lacus. Nunc vestibulum leo massa, a eleifend orci venenatis id. Etiam hendrerit dignissim porttitor. Praesent finibus quam quis libero cursus, eu fringilla erat tempor. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean nunc tellus, condimentum vel lacus eget, varius bibendum est. Nulla posuere, ante porttitor imperdiet maximus, orci nibh efficitur ex, nec mollis nisi elit et neque. Nunc dapibus, tortor id commodo faucibus, nibh sapien semper erat, sed fermentum libero turpis quis tellus. Vivamus id felis sapien. Maecenas vel neque ultricies, aliquam nisl eu, pharetra eros. Pellentesque congue, libero in consectetur commodo, lectus augue porttitor eros, quis sagittis nibh erat a risus. Cras rutrum ipsum sed arcu faucibus egestas at ut dui. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Suspendisse potenti. Praesent pellentesque quam vel magna tincidunt tempus. In rhoncus tellus id lectus pellentesque placerat. Proin sed scelerisque risus, id condimentum tellus. In laoreet consequat metus, vel dignissim magna volutpat commodo. Duis elementum tortor dolor, id lobortis ligula volutpat vel. Nullam vel nulla sit amet sem ultrices lacinia vitae at lorem. Phasellus dignissim augue et volutpat tincidunt. Morbi eget arcu et augue feugiat rhoncus at at lorem. Morbi blandit eget lectus at sollicitudin. Donec luctus a turpis vel egestas. Pellentesque at leo ultrices, sagittis sem at, suscipit felis. Fusce iaculis tempor leo. Sed molestie pellentesque ex. Quisque gravida placerat est quis aliquet. Mauris vitae sem ante. Aliquam fermentum, purus ac accumsan tincidunt, quam tellus porttitor nisi, eu malesuada enim metus et justo. Nullam ac ante sollicitudin, eleifend metus eget, tempor nisl. Pellentesque porta odio vitae nunc congue vehicula. Aenean mattis magna est, quis sodales felis vulputate in. Vestibulum eu tristique justo, sed tincidunt nibh. Sed accumsan enim in urna mattis, a condimentum nulla suscipit. Nulla vel dui erat. Sed vestibulum neque et lectus imperdiet maximus. Cras bibendum nulla in erat sagittis scelerisque eget quis ex. Quisque sollicitudin metus rutrum posuere suscipit. Pellentesque dapibus est tellus, ut viverra nunc tempus eget. Nulla ullamcorper in turpis vel scelerisque. Aliquam tempus scelerisque quam vel molestie. Phasellus commodo dignissim quam in pellentesque. Suspendisse semper, ipsum vel malesuada viverra, ante nunc mollis odio, eget tincidunt felis nunc et sem. Cras mollis ac sem nec aliquam. Mauris tempus urna ut diam pellentesque, at efficitur tellus molestie. Nullam suscipit ipsum est, eu eleifend dolor tempus vel. Maecenas a nulla ut erat fringilla egestas. Nam nec venenatis ligula, ac lacinia diam. Aenean rhoncus semper ex laoreet iaculis. Aliquam sit amet molestie arcu. Vivamus eleifend congue eros, nec efficitur urna porta et. In hac habitasse platea dictumst. Nam at nunc non augue vestibulum pellentesque nec id nunc. In tempor leo vitae sagittis dapibus. Etiam euismod tempor lorem ut dignissim. Pellentesque vitae neque et lacus hendrerit feugiat. In hac habitasse platea dictumst. Suspendisse vitae metus laoreet, porta massa id, eleifend metus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus sodales porta iaculis. Ut at nibh nisl. Duis ac ipsum ac neque placerat maximus. Ut hendrerit arcu nunc, sed mattis mi tempor vestibulum. Etiam erat felis, dictum ut magna eu, tempor pharetra diam. Integer ac neque malesuada, sodales mi id, porttitor tortor. Suspendisse eu porta mi. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque ornare porttitor tellus, sit amet aliquet lorem. Cras euismod nibh vitae mi consequat, ac suscipit tortor consequat. Vivamus at gravida felis. Phasellus convallis, lorem eget eleifend congue, libero massa gravida dolor, ac auctor velit massa eu ante. Proin at erat ultrices, scelerisque ipsum quis, aliquet massa. Duis fermentum varius lorem, vel rhoncus lectus venenatis nec. Integer dapibus pretium purus, fermentum dignissim leo sodales vitae. Pellentesque in lacus porttitor, posuere felis vel, venenatis sem. Aenean scelerisque convallis sem, in consectetur velit hendrerit sit amet. Donec semper finibus ante, eget pharetra quam dignissim id. Suspendisse id tellus metus. Aliquam augue diam, auctor ut iaculis ac, convallis nec enim. Vivamus tincidunt ipsum libero, quis convallis justo tempus non. Vivamus posuere tristique dui sit amet tempor. Morbi eget magna turpis. In hac habitasse platea dictumst. Nam ullamcorper elementum sapien. Cras eleifend hendrerit dui, et accumsan felis convallis id. Nunc quis consectetur tellus. Curabitur facilisis turpis et sapien congue faucibus. Morbi sagittis quam molestie, ornare justo at, efficitur urna. Sed mollis elit purus, et pellentesque tellus hendrerit in. Nunc volutpat tellus augue, at vestibulum sapien viverra nec. Aliquam turpis velit, tempor in mi ut, convallis tristique dui. Proin molestie enim eu tortor maximus, a ultricies tortor imperdiet. Sed sit amet interdum nisl, at lacinia neque. Vivamus hendrerit, sapien nec gravida mattis, lorem magna sodales purus, laoreet finibus magna dolor a sapien. Quisque vestibulum sodales justo. Phasellus tincidunt tincidunt turpis, vel bibendum enim placerat id. Vivamus imperdiet enim quis dui condimentum, ut malesuada diam placerat. Nulla sagittis, nisi eu sollicitudin ullamcorper, orci libero faucibus neque, nec interdum magna massa et ligula. Mauris semper a libero laoreet tincidunt. Nam id purus blandit tortor fringilla mollis. Vivamus ornare nibh fringilla, scelerisque quam consectetur, bibendum enim. Sed lacinia arcu libero, gravida hendrerit lacus faucibus vel. Pellentesque faucibus turpis eu felis ultricies aliquet. Pellentesque eget pellentesque neque, ut pharetra nulla. Sed finibus, urna in ultrices tincidunt, lacus nibh congue est, vel porttitor nunc turpis eget risus. Aenean facilisis ex dui, non suscipit dolor tincidunt in. Vivamus efficitur justo sed pretium feugiat. Ut tempor eros volutpat neque tristique, in facilisis velit interdum. Fusce eu ligula ut lorem sagittis placerat. Fusce accumsan sem elementum mollis finibus. Nunc et lobortis dolor. Duis bibendum malesuada quam. Sed turpis purus, lobortis sit amet porta pellentesque, semper vel dolor. Phasellus fermentum luctus arcu, sit amet cursus quam accumsan id. Nunc justo ipsum, pulvinar at maximus et, eleifend sit amet magna. Nullam posuere diam sed euismod varius. Nunc faucibus tortor et justo consequat, eget vestibulum dui fermentum. Sed tempus sem ac orci feugiat pulvinar. Nam id eros ac tellus suscipit placerat at eget orci. In non arcu sagittis quam fringilla ultrices ac ac metus. Ut sit amet pellentesque nibh. Phasellus nec tincidunt arcu. Integer ullamcorper vitae dolor eu viverra. Nunc gravida, elit non efficitur placerat, ex orci lobortis mi, ut efficitur mi tellus nec lectus. Donec fringilla in turpis eu vestibulum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Aenean convallis, metus eget euismod vulputate, orci nisi sollicitudin arcu, a malesuada diam lacus at magna. Donec vel eros eu risus eleifend porta. Morbi euismod egestas placerat. Sed at viverra orci. Donec dictum vitae mi ullamcorper elementum. Nunc ut dolor vitae nunc lobortis dictum. Donec hendrerit enim et interdum vehicula. Cras quis magna convallis, lacinia odio molestie, interdum enim. Phasellus gravida tempor magna sed aliquam. Sed felis nisl, elementum sed egestas non, vestibulum eu mi. Vestibulum lacinia est ac odio ullamcorper mattis. Praesent interdum elit sed lectus sollicitudin ultricies. Interdum et malesuada fames ac ante ipsum primis in faucibus. In interdum bibendum massa, et iaculis mauris fringilla ac. Maecenas eu imperdiet lacus. Phasellus fringilla turpis in massa hendrerit euismod. Sed libero felis, rutrum nec velit sed, commodo semper lectus. Aenean blandit non velit id mollis. Suspendisse ac dolor tellus. Donec tristique posuere enim, sit amet convallis purus dapibus sed. Integer nec felis fringilla lacus tincidunt consectetur eget eu lacus. Nulla laoreet, nisi in sagittis ullamcorper, ante turpis fermentum mauris, nec pulvinar ipsum nisi ut lacus. Maecenas metus felis, posuere id enim at, fermentum dictum ligula. Vestibulum pellentesque, lacus non rhoncus blandit, est est tempor arcu, at fermentum massa lacus id ex. Cras pulvinar sem eu fringilla mattis. Etiam purus arcu, cursus non tempor ut, varius ac ligula. Sed neque tortor, cursus vitae augue nec, faucibus maximus ante. Vestibulum quis diam vestibulum neque dictum ullamcorper. Vivamus efficitur dui ac elit efficitur pulvinar. Sed nec ultrices libero, sed pulvinar sem. Aliquam fermentum pellentesque congue. Ut ac efficitur ligula, sed sodales mauris. Integer euismod pulvinar eros vehicula sagittis. Cras quis lectus nisl. Sed dui justo, ullamcorper a laoreet eget, tempus at velit. Proin accumsan, quam eget tempus egestas, tortor est molestie risus, non commodo nibh eros in enim. Sed ultricies, justo ac varius porttitor, lectus justo ullamcorper turpis, sit amet placerat felis odio eu dolor. Etiam posuere turpis placerat felis interdum, vel tincidunt diam cursus. Nullam mollis elit nec elementum scelerisque. Integer et porttitor nisi. Praesent viverra dolor nec scelerisque pretium. Sed venenatis velit et ante pulvinar, sit amet finibus tellus ullamcorper. Morbi sit amet mattis lorem. Etiam sodales eros a tincidunt euismod. Suspendisse ac congue libero. Sed fermentum neque at erat mattis, in maximus nibh rutrum. In ut tellus sed erat varius tristique. Curabitur ut maximus massa. Donec ullamcorper cursus ullamcorper. Duis eu mattis nulla. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean eu quam diam. Donec luctus dolor augue, nec tempor nulla mollis eu. In odio tortor, aliquet a tincidunt sodales, aliquam a felis. Duis mattis urna a felis pellentesque bibendum. Aenean suscipit ante urna, sed tempus lectus mattis eget. Suspendisse ac justo et velit vehicula volutpat. Proin eu pellentesque orci. Praesent eu pharetra turpis, eu sagittis lacus. Donec dapibus dolor vitae tortor scelerisque consectetur. Morbi dictum, orci at vulputate interdum, purus leo dapibus tortor, id dignissim dolor elit et ligula. Integer vehicula non nibh ac rhoncus. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut mattis condimentum dolor et mollis. Mauris sodales enim ut est tempus blandit. Morbi blandit mattis eros, non aliquam sem tincidunt eget. Nullam porta aliquet erat vel malesuada. Donec et dignissim est. Nam sit amet malesuada lorem, et vulputate dolor. Donec scelerisque purus id euismod volutpat. Vestibulum at ultrices arcu, et scelerisque urna. Vestibulum molestie et dui sit amet porttitor. Integer arcu neque, posuere nec porta eu, ullamcorper sed nunc. Sed mollis mi lectus, commodo aliquam est sollicitudin in. Pellentesque ut vestibulum augue. Vivamus ut odio porttitor, molestie ante nec, viverra ligula. Donec dapibus dui ligula, vel pretium erat tempor eget. Morbi in dapibus erat. Nunc nec arcu lorem. Curabitur id semper augue, eu consectetur ipsum. Proin eget nunc efficitur, volutpat lectus dapibus, dignissim neque. Aenean non nunc ultrices, efficitur odio ac, scelerisque orci. Vestibulum pulvinar fringilla vehicula. Ut leo arcu, auctor vitae est ac, aliquam aliquet est. In tincidunt sapien porta lacus vulputate pharetra. Pellentesque eu erat non urna laoreet auctor. Donec non sodales felis. Mauris interdum eget lorem in vehicula. Quisque pharetra est sit amet nisi placerat mollis. Phasellus gravida quam nunc, ac efficitur libero laoreet eu. Morbi tempus lobortis neque et gravida. Maecenas egestas pretium luctus. Nam ac ligula turpis.";
        //byte[] encrypted = encryption.EncryptStringToBytes(longPreDefinedMessage, keyAsByteArray, ivAsByteArray);

        timer.Start();
        encrypted = aesEncryption.AesEncryptStringToBytes(message, userGeneratedKeyAsByteArray, userGenerateIvAsByteArray, cipherMode);
        //encrypted = aesEncryption.AesEncryptStringToBytes(message, keyAsByteArray, ivAsByteArray);
        timer.Stop();

        Console.WriteLine("Time used to encrypt: " + timer.Elapsed.TotalMilliseconds + " miliseconds");

        decrypted = aesEncryption.AesDecryptStringFromBytes(encrypted, userGeneratedKeyAsByteArray, userGenerateIvAsByteArray, cipherMode);
        //decrypted = aesEncryption.AesDecryptStringFromBytes(encrypted, keyAsByteArray, ivAsByteArray);

        Console.WriteLine("\n" + "Encrypted:\n" + logic.MyStringBuilder(encrypted));
        Console.WriteLine("\n" + "Decrypted:\n" + decrypted);
        break;
    default:
        break;
}

Console.WriteLine("\nProgram finished");

Console.ReadLine();
