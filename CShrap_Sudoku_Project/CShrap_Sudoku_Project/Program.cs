/* 
 ALGORİTMA

 A Oyun Alanı :
 * Hepsini 2 Boyutlu dizi olarak Düşün
 * int[,] grid
 BOYUT:
 * Level 1: 3x3
 * Level 2: 6x6
 * Level 3: 9x9
  
 //-------------------------------------------

 B Bu sayı buruaya Konabilir mi ?
 * Bir Kontol Fonksiyonu
 
 Fonksiyon Şunları Yapacak:
 * Aynı Sütunda mı ?
 * Aynı Satırda mı ?
 * Aynı alt karede mi ?
 Eğer üçü de temizse koyulabilir
 
//-------------------------------------------

C Rastgele Yerleştime Mantığı 
 * Bir Hücre Seç
 * 1 den n e kadar denenecek
 * Hiç biri olmazsa geri al (Backtracking)
 
 //------------------------------------------- 

LEVEL 1
+---+---+---+
| 1 | 2 | 3 |
+---+---+---+
| 2 | 3 | 1 |
+---+---+---+
| 3 | 1 | 2 |
+---+---+---+

Kurallar:
 * Grid: 3×3
 * Kullanılacak sayılar: 1, 2, 3
 * Aynı satırda aynı sayı olmaz
 * Aynı sütunda aynı sayı olmaz
 * Blok kuralı YOK (zaten 3×3 tek blok)
  
 Başlat:
 * N = 3
 * Kullanılacak Sayılar 1, 2, 3
 * Aynı Satırda Aynı Sayı Olmaz
 * Aynı Sütunda aynı sayı olmaz
 * Blok Kuralı yok zaten 3x3 
  
 Tablo Mantığı: 
 * Her Satırda 1 - 3 birer kez
 * Her Sütunda 1 - 3 birer kez
 * Satır ve Sütunda Kaydırmalı Yerleştirme
 * Satır 0 : 123
 * Satır 1 : 231
 * Satır 2 : 312



LEVEL 2 
+---+---+---+---+---+---+
| 4 | 3 | 2 || 1 | _ | 5 |
| 1 | 6 | 5 || _ | _ | 4 |
+---+---+---++---+---+---+
| 5 | 2 | 4 || 3 | 1 | 6 |
| 3 | 1 | 6 || 5 | 4 | 2 |
+---+---+---++---+---+---+
| 2 | 5 | 1 || 4 | 6 | 3 |
| 6 | 4 | 3 || 2 | 5 | 1 |
+---+---+---++---+---+---+

LEVEL 3
+---+---+---+---+---+---+---+---+---+
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
+---+---+---++---+---+---++---+---+---+
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
+---+---+---++---+---+---++---+---+---+
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
| _ | _ | _ || _ | _ | _ || _ | _ | _ |
+---+---+---++---+---+---++---+---+---+

 * 
 * 
 */

//LEVEL 1 3x3
#region LEVEL 1
//-----------------------------------------------------
const int N = 3;
// Oyun Alanı 3x3 olacak v bu sayı hiç değişmez

int[,] cozumMatrisi = new int[N, N];
// Çözüm Matrisi : Oyunun Eksiksiz Değişmez Kontrolünü Sağlayacak
//2 Boyutlu Tablo = int[,]
// 3 satır ve 3 sütun = [N, N]

int[,] oyunMatrisi = new int[N, N];
//Kullanıcının Gördüğü ve Doldurduğu tablodur.

CozumUret(cozumMatrisi);
// 3x3 lük doğru çözümü Otomatik doldur ( 1 - 3 satır / sütun tekrarı yok)

OyunMatrisiOlustur(cozumMatrisi, oyunMatrisi);
//Çözümü Oyun Alanına Kopyalar. Şuan birebir aynı birazdan boşluk açılacak

BoslukBirak(oyunMatrisi, 4);
//Oyun Alanına Rastgele 4 hücreyi boş ( _ ) yapar. Kullanıcı doldursun diye.

while (true)
// Oyun bitene kadar sürekli çalışacak döngü.
//Level tamamlanınca break ile çıkılacak.
{
    Console.Clear();
    // Ekranı Temizler her turda yeniden düzgün çizer

    TahtayaCiz(oyunMatrisi);
    // O anki oyun alanını konsola çizer sayılar ve _ ile

    if (TamamlandiMi(oyunMatrisi, cozumMatrisi))
    // Oyun Matrisi Çözüm Matrisi ile aynı mı
    {
        Console.WriteLine("Level 1' i Tamamladın !");
        //Aynıysa Level Bitti
        break;
        // Döngüden Çık
    }
    KullaniciGirdisiAl(oyunMatrisi);
    // Satır - Sütun - Değer Alır 
    //Satır Sütun kuralına geçerliyse yazar
    

}

// ÇÖZÜM MATRİSİ
static void CozumUret(int[,] cozum)
// geriye değer döndürmeyen void bir metot
// parametre olarak 2 boyutlu int dizisi aldı
{
    int N = cozum.GetLength(0);
    //Matrisin Satır Sayısını Aldı
    // 3x3 olduğu için  N = 3
    // Sabit Yazmak Yerine Dinamik Aldım 

    for (int r = 0; r < N; r++)
        // satırı dolaşan döngü r = 0, 1, 2

        for (int c = 0; c < N; c++)
            // sütunlardan oluşan döngü 

            cozum[r, c] = (r + c) % N + 1;
    //ÖNEMLİ SATIR 
    // r + c satır ve sütunun toplamı
    // % N taşmayı Önler (0-2 arası tutar)
    // sayıları 1 - 3 yapar

    /*
     Yani Sonuç
    1 2 3
    2 3 1
    3 1 2
    olur. 
    */
}

static void OyunMatrisiOlustur(int[,] cozum, int[,] oyun)
// Çözüm matrisini oyun matrisine koyalamak için
{

    int N = cozum.GetLength(0);
    // Boyutu 3 alıyor.

    for (int r = 0; r < N; r++)
        //Tüm Hücreleri Gezdi
        for (int c = 0; c < N; c++)
            // Tüm Hücreleri Gezdi

                oyun[r,c] = cozum[r,c];
               //Çözümde ne varsa aynen kopyaladı

}

static void BoslukBirak(int[,] oyun, int boslukSayisi)
    // Oyunda Kaç Hücrenin boş olacağını belirledi
{
    Random rnd = new Random();
    //Rastgele sayı üretmek için

    int N = oyun.GetLength(0);
    // Grid Boyutu (3)

    while (boslukSayisi > 0)
        // İstenen kadar boşluk bırakana kadar döndü
    {
        int r = rnd.Next(N);
        int c = rnd.Next(N);
        // 0-2 arasında rastgele satır ve sütun seçti

        if (oyun[r, c] != 0)
            // Hücre Zaten Boş Değilse diye
        {
            oyun[r, c] = 0;
            // hücreyi boş yaptım 0 = _

            boslukSayisi--;
            // Bir Boşluk Hakkını Azalttım

        }
    }
}

static void TahtayaCiz(int[,] oyun)
    // Oyun Alanını Konsola Çizmeye Başladı
{
    int N = oyun.GetLength(0);
    //Boyut (3)

    for (int r = 0; r < N; r++)
    //satır satır çizmesi için
    {
        Console.WriteLine("+---+---+---+");
        // üst çizgim


        for (int c = 0; c < N; c++)
        //Sütunları Dolaşsın
        {
            Console.Write("| ");
            // hücre başı çizgim

            Console.Write(oyun[r, c] == 0 ? "_ " : oyun[r,c] + " ");
            //eğer hücre 0 ise _ koy yavrum
            // değilse sayıyı yazdır 
        }
        Console.WriteLine("|");
        // Satır sonu çizgim
    }
    Console.WriteLine("+---+---+---+");
}

static void KullaniciGirdisiAl(int[,] oyun)
//Kullanıcının hamlesini aldım ve kontrol ettim 
{  
    int N = oyun.GetLength(0);
    // boyut 3

    Console.Write("Satır (1-3): ");
    int r = int.Parse(Console.ReadLine()) - 1;
    // kullanıcı 1-3 girer 
    // programım 0-2 ye çevirmesi için bele

    Console.Write("Sütun (1-3): ");
    int c = int.Parse(Console.ReadLine()) - 1;
    //Aynı mantık sütun için yaptım


    Console.Write("Değer (1-3): ");
    int v = int.Parse(Console.ReadLine());
    //Yazılmak istenen değer


    if (r < 0 || r >= N || c < 0 || c >= N || v < 1 || v > N)
        return;
    //Geçersiz Girişse hiç bir şey yapmadan çık


    // Dolu hücreye yazma
    if (oyun[r, c] != 0)
        return;
    // Dolu hücreye yazmasına izin vermez


    // Satır kontrolü
    for (int i = 0; i < N; i++)
        if (oyun[r, i] == v)
            return;
    //aynı sayırda aynı sayı var mı diye kontorol etmem gerek.


    // Sütun kontrolü
    for (int i = 0; i < N; i++)
        if (oyun[i, c] == v)
            return;
    //aynı sütun için..

    oyun[r, c] = v; // Geçerliyse yaz
    // Tüm Accsesi tamamladım sayıyı yaz
}

static bool TamamlandiMi(int[,] oyun, int[,] cozum)
    // Oyun Doğrulama Aksesi Bitti mi diye bakmalı
{
    int N = oyun.GetLength(0);
    for (int r = 0; r < N; r++)
        for (int c = 0; c < N; c++)
            //Tüm hücreleri dolaş 

                if (oyun[r,c] != cozum[r,c])
                return false;
              // Tek bir Hücre farklıysa bitmedi yanlış olur


    return true;
    // Hepsi aynıysa level tamam
}
#endregion
