Console.ForegroundColor = ConsoleColor.Yellow;

string sentence = "Antik kentte keşif yaparken, hayatta kalmak için gerekli malzemeleri toplayarak antik tanrıların gücünü elde etmek için mücadele edeceksiniz. Ormana gidecek, anahtarları ve şifreleri bulacaksınız. Para kazanmak ve silahlar satın almak için düşmanları alt edeceksiniz. Mekanlar arasında teleportasyon yaparak ilerleyeceksiniz. Hedefiniz, antik tanrıların gücüne ulaşmak ve tüm dünyayı kontrol etmek. Kendinizi geliştirdikçe ve malzemeler topladıkça, zorlu düşmanlara karşı daha güçlü hale geleceksiniz. Oyunun sonunda, başarılarınızı ve yeteneklerinizi sergileyerek tüm dünyanın en iyi oyuncusu olabilirsiniz.";

foreach (char c in sentence)
{
    Console.Write(c);
    Thread.Sleep(50); // her karakter arasında 50 milisaniye bekleyin
}
Console.Clear();
Console.ForegroundColor= ConsoleColor.Green;
Console.WriteLine("Başarılar dileriz!");
Console.ReadLine();