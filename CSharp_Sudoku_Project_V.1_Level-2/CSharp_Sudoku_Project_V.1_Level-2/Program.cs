
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

#region LEVEL 2
//-----------------------------------------------------
const int N = 6;
// Oyun Alanı 6x6 olacak ve bu sayı hiç değişmez

int[,] cozumMatrisi = new int[N, N];
// Çözüm Matrisi : Oyunun Eksiksiz Değişmez Kontrolünü Sağlayacak

int[,] oyunMatrisi = new int[N, N];
// Kullanıcının Gördüğü ve Doldurduğu tablodur.

CozumUret(cozumMatrisi);
// 6x6 lık doğru çözümü Otomatik doldur ( 1 - 6 satır / sütun tekrarı yok)

OyunMatrisiOlustur(cozumMatrisi, oyunMatrisi);
// Çözümü Oyun Alanına Kopyalar

BoslukBirak(oyunMatrisi, 18);
// Oyun Alanına Rastgele 18 hücreyi boş yapar (puzzle hissi)

while (true)
// Oyun bitene kadar sürekli çalışacak döngü.
{
    Console.Clear();
    TahtayaCiz(oyunMatrisi);

    if (TamamlandiMi(oyunMatrisi, cozumMatrisi))
    {
        Console.WriteLine("Level 2'yi Tamamladın !");
        break;
    }

    KullaniciGirdisiAl(oyunMatrisi);
}

//---------------- ÇÖZÜM MATRİSİ ----------------
static void CozumUret(int[,] cozum)
{
    int N = cozum.GetLength(0);

    for (int r = 0; r < N; r++)
        for (int c = 0; c < N; c++)
            cozum[r, c] = (r * 2 + r / 3 + c) % N + 1;

    /*
      6x6 için geçerli Latin Square üretir
      Satır + sütun + kaydırma mantığı
    */
}

static void OyunMatrisiOlustur(int[,] cozum, int[,] oyun)
{
    int N = cozum.GetLength(0);

    for (int r = 0; r < N; r++)
        for (int c = 0; c < N; c++)
            oyun[r, c] = cozum[r, c];
}

static void BoslukBirak(int[,] oyun, int boslukSayisi)
{
    Random rnd = new Random();
    int N = oyun.GetLength(0);

    while (boslukSayisi > 0)
    {
        int r = rnd.Next(N);
        int c = rnd.Next(N);

        if (oyun[r, c] != 0)
        {
            oyun[r, c] = 0;
            boslukSayisi--;
        }
    }
}

static void TahtayaCiz(int[,] oyun)
{
    int N = oyun.GetLength(0);

    for (int r = 0; r < N; r++)
    {
        if (r % 2 == 0)
            Console.WriteLine("+---+---+---+----+");

        for (int c = 0; c < N; c++)
        {
            if (c % 3 == 0)
                Console.Write("||");

            Console.Write(oyun[r, c] == 0 ? "_ " : oyun[r, c] + " ");
        }
        Console.WriteLine("||");
    }
    Console.WriteLine("+---+---+---+----+");
}

static void KullaniciGirdisiAl(int[,] oyun)
{
    int N = oyun.GetLength(0);

    Console.Write("Satır (1-6): ");
    int r = int.Parse(Console.ReadLine()) - 1;

    Console.Write("Sütun (1-6): ");
    int c = int.Parse(Console.ReadLine()) - 1;

    Console.Write("Değer (1-6): ");
    int v = int.Parse(Console.ReadLine());

    if (r < 0 || r >= N || c < 0 || c >= N || v < 1 || v > N)
        return;

    if (oyun[r, c] != 0)
        return;

    // Satır kontrolü
    for (int i = 0; i < N; i++)
        if (oyun[r, i] == v)
            return;

    // Sütun kontrolü
    for (int i = 0; i < N; i++)
        if (oyun[i, c] == v)
            return;

    // 2x3 KUTU KONTROLÜ (LEVEL 2 farkı)
    int boxRow = (r / 2) * 2;
    int boxCol = (c / 3) * 3;

    for (int i = 0; i < 2; i++)
        for (int j = 0; j < 3; j++)
            if (oyun[boxRow + i, boxCol + j] == v)
                return;

    oyun[r, c] = v;
}

static bool TamamlandiMi(int[,] oyun, int[,] cozum)
{
    int N = oyun.GetLength(0);

    for (int r = 0; r < N; r++)
        for (int c = 0; c < N; c++)
            if (oyun[r, c] != cozum[r, c])
                return false;

    return true;
}
#endregion
