using System;
using System.Collections.Generic;
using System.Linq;

public class RehberIslemleri
{
    private List<Kisi> rehber;

    public RehberIslemleri()
    {
        rehber = new List<Kisi>();
        VarsayilanKisiler();
    }

    private void VarsayilanKisiler()
    {
        rehber.Add(new Kisi("Ahmet", "Yılmaz", "1234567890"));
        rehber.Add(new Kisi("Mehmet", "Öztürk", "0987654321"));
        rehber.Add(new Kisi("Ayşe", "Kara", "1122334455"));
        rehber.Add(new Kisi("Fatma", "Çelik", "2233445566"));
        rehber.Add(new Kisi("Ali", "Demir", "3344556677"));
    }

    public void YeniNumaraKaydet(Kisi yeniKisi)
    {
        rehber.Add(yeniKisi);
        Console.WriteLine($"{yeniKisi.Isim} {yeniKisi.Soyisim} numarası kaydedildi.");
    }

    public bool NumaraSil(string isim)
    {
        Kisi kisi = rehber.FirstOrDefault(k => k.Isim == isim || k.Soyisim == isim);
        if (kisi != null)
        {
            rehber.Remove(kisi);
            Console.WriteLine($"{kisi.Isim} {kisi.Soyisim} rehberden silindi.");
            return true;
        }
        return false;
    }

    public bool NumaraGuncelle(string isim, string yeniTelefon)
    {
        Kisi kisi = rehber.FirstOrDefault(k => k.Isim == isim || k.Soyisim == isim);
        if (kisi != null)
        {
            kisi.Telefon = yeniTelefon;
            Console.WriteLine($"{kisi.Isim} {kisi.Soyisim} numarası güncellendi.");
            return true;
        }
        return false;
    }

    public List<Kisi> RehberiListele(bool ascending = true)
    {
        return ascending ? rehber.OrderBy(k => k.Isim).ThenBy(k => k.Soyisim).ToList() : rehber.OrderByDescending(k => k.Isim).ThenByDescending(k => k.Soyisim).ToList();
    }

    public List<Kisi> RehberdeArama(string kriter, bool byName)
    {
        return byName ? rehber.Where(k => k.Isim == kriter || k.Soyisim == kriter).ToList() : rehber.Where(k => k.Telefon == kriter).ToList();
    }
}
