using Symetric_Encryption;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

SymmetricAlgorithm mySymetricAlgorithm;
//AesEncryption aesEncryption = new AesEncryption();
//TripleDesEncryption tripleDesEncryption = new TripleDesEncryption();
Logic logic = new Logic();
Stopwatch timer = new Stopwatch();


//string key = "vfNhx4fub1WeMnyaAmcvzw==";
string key = "";
//string iv = "1rZP/rpVONgvZlleknD6zw==";
string iv = "";

byte[] keyAsByteArray;
byte[] ivAsByteArray;
byte[] encrypted;
byte[] userGeneratedKeyAsByteArray;
byte[] userGenerateIvAsByteArray;
int userGeneratedKey;
int userGenerateIv;
string message = "";
string decrypted = "";
string cipherMode = "";
string cipherModeChoice = "";
string encryptionChoice = "";

Console.WriteLine("Choose a cipher, by pressing 1, 2 or 3\n" +
    "1. TrippleDes\n" +
    "2. AES");
string cipher = Console.ReadLine();


switch (cipher)
{
    case "1":
        encryptionChoice = "TrippleDes";
        break;
    case "2":
        encryptionChoice = "AES";
        break;
    default:
        break;
}

Console.WriteLine("write a text to encrypt:");
message = Console.ReadLine();

Console.WriteLine("create a key");
userGeneratedKey = Convert.ToInt32(Console.ReadLine());
userGeneratedKeyAsByteArray = logic.CreateKeyWithUserInput(userGeneratedKey);

Console.WriteLine(logic.MyStringBuilder(userGeneratedKeyAsByteArray));

Console.WriteLine("create a iv");
userGenerateIv = Convert.ToInt32(Console.ReadLine());
userGenerateIvAsByteArray = logic.CreateKeyWithUserInput(userGenerateIv);
Console.WriteLine(logic.MyStringBuilder(userGeneratedKeyAsByteArray));

Console.WriteLine("choose ciphermode\n" +
    "1. cbc\n" +
    "2. ecb");
cipherModeChoice = Console.ReadLine();

switch (cipherModeChoice)
{
    case "1":
        cipherMode = "cbc";
        break;
    case "2":
        cipherMode = "ecb";
        break;
    default:
        break;
}

//string longpredefinedmessage = "lorem ipsum dolor sit amet, consectetur adipiscing elit. praesent sollicitudin sapien at elit rutrum tempus. proin porttitor nisl nulla, sit amet egestas sapien dapibus eget. curabitur vitae ligula ex. lorem ipsum dolor sit amet, consectetur adipiscing elit. donec ac augue non tortor blandit eleifend a a purus. in quis justo ex. sed tristique sapien vel metus scelerisque semper. morbi eget libero augue. duis malesuada dolor et justo aliquet, sed dictum mi ornare. nulla sodales, ligula vel congue semper, ipsum erat vehicula purus, sit amet dapibus dolor ipsum ac dolor. fusce luctus nisi finibus, imperdiet dui quis, ultricies odio. maecenas in rutrum justo. donec placerat tellus a ipsum sollicitudin, vitae vehicula libero interdum. duis imperdiet elit vitae quam tempus facilisis. donec quis dolor lacus. nunc vestibulum leo massa, a eleifend orci venenatis id. etiam hendrerit dignissim porttitor. praesent finibus quam quis libero cursus, eu fringilla erat tempor. interdum et malesuada fames ac ante ipsum primis in faucibus. aenean nunc tellus, condimentum vel lacus eget, varius bibendum est. nulla posuere, ante porttitor imperdiet maximus, orci nibh efficitur ex, nec mollis nisi elit et neque. nunc dapibus, tortor id commodo faucibus, nibh sapien semper erat, sed fermentum libero turpis quis tellus. vivamus id felis sapien. maecenas vel neque ultricies, aliquam nisl eu, pharetra eros. pellentesque congue, libero in consectetur commodo, lectus augue porttitor eros, quis sagittis nibh erat a risus. cras rutrum ipsum sed arcu faucibus egestas at ut dui. pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. suspendisse potenti. praesent pellentesque quam vel magna tincidunt tempus. in rhoncus tellus id lectus pellentesque placerat. proin sed scelerisque risus, id condimentum tellus. in laoreet consequat metus, vel dignissim magna volutpat commodo. duis elementum tortor dolor, id lobortis ligula volutpat vel. nullam vel nulla sit amet sem ultrices lacinia vitae at lorem. phasellus dignissim augue et volutpat tincidunt. morbi eget arcu et augue feugiat rhoncus at at lorem. morbi blandit eget lectus at sollicitudin. donec luctus a turpis vel egestas. pellentesque at leo ultrices, sagittis sem at, suscipit felis. fusce iaculis tempor leo. sed molestie pellentesque ex. quisque gravida placerat est quis aliquet. mauris vitae sem ante. aliquam fermentum, purus ac accumsan tincidunt, quam tellus porttitor nisi, eu malesuada enim metus et justo. nullam ac ante sollicitudin, eleifend metus eget, tempor nisl. pellentesque porta odio vitae nunc congue vehicula. aenean mattis magna est, quis sodales felis vulputate in. vestibulum eu tristique justo, sed tincidunt nibh. sed accumsan enim in urna mattis, a condimentum nulla suscipit. nulla vel dui erat. sed vestibulum neque et lectus imperdiet maximus. cras bibendum nulla in erat sagittis scelerisque eget quis ex. quisque sollicitudin metus rutrum posuere suscipit. pellentesque dapibus est tellus, ut viverra nunc tempus eget. nulla ullamcorper in turpis vel scelerisque. aliquam tempus scelerisque quam vel molestie. phasellus commodo dignissim quam in pellentesque. suspendisse semper, ipsum vel malesuada viverra, ante nunc mollis odio, eget tincidunt felis nunc et sem. cras mollis ac sem nec aliquam. mauris tempus urna ut diam pellentesque, at efficitur tellus molestie. nullam suscipit ipsum est, eu eleifend dolor tempus vel. maecenas a nulla ut erat fringilla egestas. nam nec venenatis ligula, ac lacinia diam. aenean rhoncus semper ex laoreet iaculis. aliquam sit amet molestie arcu. vivamus eleifend congue eros, nec efficitur urna porta et. in hac habitasse platea dictumst. nam at nunc non augue vestibulum pellentesque nec id nunc. in tempor leo vitae sagittis dapibus. etiam euismod tempor lorem ut dignissim. pellentesque vitae neque et lacus hendrerit feugiat. in hac habitasse platea dictumst. suspendisse vitae metus laoreet, porta massa id, eleifend metus. lorem ipsum dolor sit amet, consectetur adipiscing elit. vivamus sodales porta iaculis. ut at nibh nisl. duis ac ipsum ac neque placerat maximus. ut hendrerit arcu nunc, sed mattis mi tempor vestibulum. etiam erat felis, dictum ut magna eu, tempor pharetra diam. integer ac neque malesuada, sodales mi id, porttitor tortor. suspendisse eu porta mi. interdum et malesuada fames ac ante ipsum primis in faucibus. pellentesque ornare porttitor tellus, sit amet aliquet lorem. cras euismod nibh vitae mi consequat, ac suscipit tortor consequat. vivamus at gravida felis. phasellus convallis, lorem eget eleifend congue, libero massa gravida dolor, ac auctor velit massa eu ante. proin at erat ultrices, scelerisque ipsum quis, aliquet massa. duis fermentum varius lorem, vel rhoncus lectus venenatis nec. integer dapibus pretium purus, fermentum dignissim leo sodales vitae. pellentesque in lacus porttitor, posuere felis vel, venenatis sem. aenean scelerisque convallis sem, in consectetur velit hendrerit sit amet. donec semper finibus ante, eget pharetra quam dignissim id. suspendisse id tellus metus. aliquam augue diam, auctor ut iaculis ac, convallis nec enim. vivamus tincidunt ipsum libero, quis convallis justo tempus non. vivamus posuere tristique dui sit amet tempor. morbi eget magna turpis. in hac habitasse platea dictumst. nam ullamcorper elementum sapien. cras eleifend hendrerit dui, et accumsan felis convallis id. nunc quis consectetur tellus. curabitur facilisis turpis et sapien congue faucibus. morbi sagittis quam molestie, ornare justo at, efficitur urna. sed mollis elit purus, et pellentesque tellus hendrerit in. nunc volutpat tellus augue, at vestibulum sapien viverra nec. aliquam turpis velit, tempor in mi ut, convallis tristique dui. proin molestie enim eu tortor maximus, a ultricies tortor imperdiet. sed sit amet interdum nisl, at lacinia neque. vivamus hendrerit, sapien nec gravida mattis, lorem magna sodales purus, laoreet finibus magna dolor a sapien. quisque vestibulum sodales justo. phasellus tincidunt tincidunt turpis, vel bibendum enim placerat id. vivamus imperdiet enim quis dui condimentum, ut malesuada diam placerat. nulla sagittis, nisi eu sollicitudin ullamcorper, orci libero faucibus neque, nec interdum magna massa et ligula. mauris semper a libero laoreet tincidunt. nam id purus blandit tortor fringilla mollis. vivamus ornare nibh fringilla, scelerisque quam consectetur, bibendum enim. sed lacinia arcu libero, gravida hendrerit lacus faucibus vel. pellentesque faucibus turpis eu felis ultricies aliquet. pellentesque eget pellentesque neque, ut pharetra nulla. sed finibus, urna in ultrices tincidunt, lacus nibh congue est, vel porttitor nunc turpis eget risus. aenean facilisis ex dui, non suscipit dolor tincidunt in. vivamus efficitur justo sed pretium feugiat. ut tempor eros volutpat neque tristique, in facilisis velit interdum. fusce eu ligula ut lorem sagittis placerat. fusce accumsan sem elementum mollis finibus. nunc et lobortis dolor. duis bibendum malesuada quam. sed turpis purus, lobortis sit amet porta pellentesque, semper vel dolor. phasellus fermentum luctus arcu, sit amet cursus quam accumsan id. nunc justo ipsum, pulvinar at maximus et, eleifend sit amet magna. nullam posuere diam sed euismod varius. nunc faucibus tortor et justo consequat, eget vestibulum dui fermentum. sed tempus sem ac orci feugiat pulvinar. nam id eros ac tellus suscipit placerat at eget orci. in non arcu sagittis quam fringilla ultrices ac ac metus. ut sit amet pellentesque nibh. phasellus nec tincidunt arcu. integer ullamcorper vitae dolor eu viverra. nunc gravida, elit non efficitur placerat, ex orci lobortis mi, ut efficitur mi tellus nec lectus. donec fringilla in turpis eu vestibulum. interdum et malesuada fames ac ante ipsum primis in faucibus. aenean convallis, metus eget euismod vulputate, orci nisi sollicitudin arcu, a malesuada diam lacus at magna. donec vel eros eu risus eleifend porta. morbi euismod egestas placerat. sed at viverra orci. donec dictum vitae mi ullamcorper elementum. nunc ut dolor vitae nunc lobortis dictum. donec hendrerit enim et interdum vehicula. cras quis magna convallis, lacinia odio molestie, interdum enim. phasellus gravida tempor magna sed aliquam. sed felis nisl, elementum sed egestas non, vestibulum eu mi. vestibulum lacinia est ac odio ullamcorper mattis. praesent interdum elit sed lectus sollicitudin ultricies. interdum et malesuada fames ac ante ipsum primis in faucibus. in interdum bibendum massa, et iaculis mauris fringilla ac. maecenas eu imperdiet lacus. phasellus fringilla turpis in massa hendrerit euismod. sed libero felis, rutrum nec velit sed, commodo semper lectus. aenean blandit non velit id mollis. suspendisse ac dolor tellus. donec tristique posuere enim, sit amet convallis purus dapibus sed. integer nec felis fringilla lacus tincidunt consectetur eget eu lacus. nulla laoreet, nisi in sagittis ullamcorper, ante turpis fermentum mauris, nec pulvinar ipsum nisi ut lacus. maecenas metus felis, posuere id enim at, fermentum dictum ligula. vestibulum pellentesque, lacus non rhoncus blandit, est est tempor arcu, at fermentum massa lacus id ex. cras pulvinar sem eu fringilla mattis. etiam purus arcu, cursus non tempor ut, varius ac ligula. sed neque tortor, cursus vitae augue nec, faucibus maximus ante. vestibulum quis diam vestibulum neque dictum ullamcorper. vivamus efficitur dui ac elit efficitur pulvinar. sed nec ultrices libero, sed pulvinar sem. aliquam fermentum pellentesque congue. ut ac efficitur ligula, sed sodales mauris. integer euismod pulvinar eros vehicula sagittis. cras quis lectus nisl. sed dui justo, ullamcorper a laoreet eget, tempus at velit. proin accumsan, quam eget tempus egestas, tortor est molestie risus, non commodo nibh eros in enim. sed ultricies, justo ac varius porttitor, lectus justo ullamcorper turpis, sit amet placerat felis odio eu dolor. etiam posuere turpis placerat felis interdum, vel tincidunt diam cursus. nullam mollis elit nec elementum scelerisque. integer et porttitor nisi. praesent viverra dolor nec scelerisque pretium. sed venenatis velit et ante pulvinar, sit amet finibus tellus ullamcorper. morbi sit amet mattis lorem. etiam sodales eros a tincidunt euismod. suspendisse ac congue libero. sed fermentum neque at erat mattis, in maximus nibh rutrum. in ut tellus sed erat varius tristique. curabitur ut maximus massa. donec ullamcorper cursus ullamcorper. duis eu mattis nulla. lorem ipsum dolor sit amet, consectetur adipiscing elit. aenean eu quam diam. donec luctus dolor augue, nec tempor nulla mollis eu. in odio tortor, aliquet a tincidunt sodales, aliquam a felis. duis mattis urna a felis pellentesque bibendum. aenean suscipit ante urna, sed tempus lectus mattis eget. suspendisse ac justo et velit vehicula volutpat. proin eu pellentesque orci. praesent eu pharetra turpis, eu sagittis lacus. donec dapibus dolor vitae tortor scelerisque consectetur. morbi dictum, orci at vulputate interdum, purus leo dapibus tortor, id dignissim dolor elit et ligula. integer vehicula non nibh ac rhoncus. lorem ipsum dolor sit amet, consectetur adipiscing elit. ut mattis condimentum dolor et mollis. mauris sodales enim ut est tempus blandit. morbi blandit mattis eros, non aliquam sem tincidunt eget. nullam porta aliquet erat vel malesuada. donec et dignissim est. nam sit amet malesuada lorem, et vulputate dolor. donec scelerisque purus id euismod volutpat. vestibulum at ultrices arcu, et scelerisque urna. vestibulum molestie et dui sit amet porttitor. integer arcu neque, posuere nec porta eu, ullamcorper sed nunc. sed mollis mi lectus, commodo aliquam est sollicitudin in. pellentesque ut vestibulum augue. vivamus ut odio porttitor, molestie ante nec, viverra ligula. donec dapibus dui ligula, vel pretium erat tempor eget. morbi in dapibus erat. nunc nec arcu lorem. curabitur id semper augue, eu consectetur ipsum. proin eget nunc efficitur, volutpat lectus dapibus, dignissim neque. aenean non nunc ultrices, efficitur odio ac, scelerisque orci. vestibulum pulvinar fringilla vehicula. ut leo arcu, auctor vitae est ac, aliquam aliquet est. in tincidunt sapien porta lacus vulputate pharetra. pellentesque eu erat non urna laoreet auctor. donec non sodales felis. mauris interdum eget lorem in vehicula. quisque pharetra est sit amet nisi placerat mollis. phasellus gravida quam nunc, ac efficitur libero laoreet eu. morbi tempus lobortis neque et gravida. maecenas egestas pretium luctus. nam ac ligula turpis.";
//byte[] encrypted = encryption.encryptstringtobytes(longpredefinedmessage, keyasbytearray, ivasbytearray);

timer.Start();
encrypted = logic.EncryptStringToBytes(encryptionChoice, message, userGeneratedKeyAsByteArray, userGenerateIvAsByteArray, cipherMode);
//encrypted = aesencryption.aesencryptstringtobytes(message, keyasbytearray, ivasbytearray);
timer.Stop();

Console.WriteLine("time used to encrypt: " + timer.Elapsed.TotalMilliseconds + " miliseconds");

decrypted = logic.DecryptStringFromBytes(encryptionChoice, encrypted, userGeneratedKeyAsByteArray, userGenerateIvAsByteArray, cipherMode);
//decrypted = aesencryption.aesdecryptstringfrombytes(encrypted, keyasbytearray, ivasbytearray);


Console.WriteLine("\n" + "encrypted:\n" + logic.MyStringBuilder(encrypted));
Console.WriteLine("\n" + "decrypted:\n" + decrypted);


Console.WriteLine("\nProgram finished");

Console.ReadLine();
