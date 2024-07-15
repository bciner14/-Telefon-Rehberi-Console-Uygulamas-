using System;

public class KonsolArayuz
{
    private RehberIslemleri rehberIslemleri;

    public KonsolArayuz(RehberIslemleri rehber)
    {
        rehberIslemleri = rehber;
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncelleme");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");
            Console.WriteLine("(6) Çıkış");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    YeniNumaraKaydet();
                    break;
                case "2":
                    VarolanNumaraSil();
                    break;
                case "3":
                    VarolanNumaraGuncelle();
                    break;
                case "4":
                    RehberiListele();
                    break;
                case "5":
                    RehberdeArama();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyiniz.");
                    break;
            }
        }
    }

    private void YeniNumaraKaydet()
    {
        Console.Write("Lütfen isim giriniz: ");
        string isim = Console.ReadLine();
        Console.Write("Lütfen soyisim giriniz: ");
        string soyisim = Console.ReadLine();
        Console.Write("Lütfen telefon numarası giriniz: ");
        string telefon = Console.ReadLine();
        rehberIslemleri.YeniNumaraKaydet(new Kisi(isim, soyisim, telefon));
    }

    private void VarolanNumaraSil()
    {
        Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
        string isim = Console.ReadLine();
        if (!rehberIslemleri.NumaraSil(isim))
        {
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
            Console.WriteLine("* Yeniden denemek için      : (2)");
            string secim = Console.ReadLine();
            if (secim == "2")
            {
                VarolanNumaraSil();
            }
        }
    }

    private void VarolanNumaraGuncelle()
    {
        Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
        string isim = Console.ReadLine();
        if (!rehberIslemleri.NumaraGuncelle(isim, string.Empty))
        {
            Console.WriteLine("Aradığınız kriterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
            Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
            Console.WriteLine("* Yeniden denemek için              : (2)");
            string secim = Console.ReadLine();
            if (secim == "2")
            {
                VarolanNumaraGuncelle();
            }
        }
        else
        {
            Console.Write("Lütfen yeni telefon numarasını giriniz: ");
            string yeniTelefon = Console.ReadLine();
            rehberIslemleri.NumaraGuncelle(isim, yeniTelefon);
        }
    }

    private void RehberiListele()
    {
        Console.WriteLine("Rehberi hangi sırayla listelemek istersiniz?");
        Console.WriteLine("1: A-Z");
        Console.WriteLine("2: Z-A");
        string siralamaSecimi = Console.ReadLine();
        bool ascending = siralamaSecimi == "1";

        var rehber = rehberIslemleri.RehberiListele(ascending);
        Console.WriteLine("\nTelefon Rehberi");
        Console.WriteLine("**********************************************");
        foreach (var kisi in rehber)
        {
            Console.WriteLine(kisi);
        }
    }

    private void RehberdeArama()
    {
        Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
        Console.WriteLine("**********************************************");
        Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
        Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
        string aramaSecimi = Console.ReadLine();

        Console.Write("Lütfen arama kriterini giriniz: ");
        string kriter = Console.ReadLine();

        var aramaSonuclari = rehberIslemleri.RehberdeArama(kriter, aramaSecimi == "1");
        Console.WriteLine("\nArama Sonuçlarınız:");
        Console.WriteLine("**********************************************");
        foreach (var kisi in aramaSonuclari)
        {
            Console.WriteLine(kisi);
        }

        if (aramaSonuclari.Count == 0)
        {
            Console.WriteLine("Aradığınız kriterlere uygun veri bulunamadı.");
        }
    }
}
