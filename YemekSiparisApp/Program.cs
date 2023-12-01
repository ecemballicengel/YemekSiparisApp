namespace YemekSiparisApp
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Bir YemekSiparisSistemi gelistireceksiniz.
            //Yemek Class imiz olacak bu base class olacak. AnaYemek, Tatli ve Icecek adinda devired classlar olacak.
            //Restoran yemeklerin listesini tutan ve kullanicidan siparis alan class.
            //Yemek classinda Adi ve Fiyati ozellikleri olacak.
            //YemekBilgisiYazdir metodu olacak.


            //Restoran clasinda yemekListesi, yemekEkle metodu ve menuyuGoster metodu olacak. Menuyu goster metodu yemek clasindaki YemekBilgisiniYAzdir metodunu tetikleyecek.
            //Sipariş al metodu yine restoran clas'ında olacak ve kullanıcıdan seçilen yemeği girmesini isteyecek.Eğer o yemek menulerin içerisinde varsa siparişin içeriğinde sipariş adı ve toplam tutarı yazdıracak.Eğer yoksa üzgünüz menümüzde böyle bir yemek yoktur diyeceğiz.

            //Tatlı classı içecek classı ve ana yemek classları yemek classından intheritance alacaklar ve yemek bilgisi yazdır metotlarını override edecekler.(Ana Yemek-Bla bla Fiyat-Bla bla) (İçecek: Adı bla bla fiyatı bla bla)

            List<Yemek> yemek= new List<Yemek>()
            {
                new AnaYemek("Musakka", 160),
                new AnaYemek("Kaburga Dolma",400),
                new AnaYemek("Taze Fasulye", 120),
                
                new Tatli("Profiterol",150),
                new Tatli("Baklava",275),
                new Tatli("Firin sutlac", 880),

                new Icecek("cola",40),
                new Icecek("Ayran",20),
                new Icecek("Su", 10),
            };


          

            Restoran restoran = new Restoran();
            restoran.YemekEkle(yemek);

            Console.WriteLine("Menu:");
            restoran.MenuyuGoster();

            restoran.SiparisAl();

        }
    }
    public class Yemek //base Class
    {
        public string Adi { get; set; }

        public decimal Fiyati { get; set;  }

        public Yemek(string adi, decimal fiyat)
        {
            Adi = adi;
            Fiyati = fiyat;
        }

        public virtual void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Yemek Adı: {Adi}, Fiyatı: {Fiyati}");
        }
    }
    public class AnaYemek: Yemek
    {
        public AnaYemek(string adi, decimal fiyati) : base(adi, fiyati)
        {
        }

        public override void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Ana Yemek: {Adi}, Fiyatı: {Fiyati}");
        }
    } 

    public class Tatli: Yemek
    {
        public Tatli(string adi, decimal fiyati) : base(adi, fiyati)
        {

        }
        public override void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Tatli: {Adi}, Fiyatı: {Fiyati}");
        }

    }

    public class Icecek: Yemek
    {
        public Icecek(string adi, decimal fiyati) : base(adi, fiyati)
        {
           
        }

        public override void YemekBilgisiYazdir()
        {
            Console.WriteLine($"Icecek: {Adi}, Fiyatı: {Fiyati}");
        }

    }

    public class Restoran
    {
        List<Yemek> yemekList= new List<Yemek>();

        public void YemekEkle(List<Yemek> menu)
        {
            yemekList.AddRange(menu);
        }

        public void MenuyuGoster()
        {
            foreach (var yemek in yemekList)
            {
                yemek.YemekBilgisiYazdir();
                Console.WriteLine("***********");
            }
        }

        public void SiparisAl()
        {
            List<Yemek> siparisListesi = new List<Yemek>();
            while (true)
            {
                Console.WriteLine("Siparis vermek istiyor musunuz? (evet/hayir)");
                string cevap = Console.ReadLine().ToLower();
                if (cevap.Equals("evet"))
                {
                    Console.Write("Sipariş vermek istediğiniz yemeğin adını girin: ");
                    string siparisAdi = Console.ReadLine();

                    var yemek = yemekList.FirstOrDefault(yemek => yemek.Adi.Equals(siparisAdi));

                    if (yemek != null)
                    {
                       siparisListesi.Add(yemek);
                    }
                    else
                    {
                        Console.WriteLine("Üzgünüz, menümüzde böyle bir yemek bulunmamaktadır.");
                    }
                }
                else if(cevap.Equals("hayir"))
                {
                    decimal toplamTutar = 0;
                    Console.WriteLine("Yemek Faturasi");
                    foreach (var siparis in siparisListesi)
                    {
                        toplamTutar += siparis.Fiyati;
                        Console.WriteLine($"Urun Adi: {siparis.Adi} , Fiyat {siparis.Fiyati} TL");
                    }
                    Console.WriteLine($"Toplam Fiyat: {toplamTutar} TL");
                    break;
                }
                else
                {
                    Console.WriteLine("Komutu dogru giriniz!");
                }
            }
        }
    }

    
    
 }
