using System;

public class Program
{
    public static void Main(string[] args)
    {
        RehberIslemleri rehberIslemleri = new RehberIslemleri();
        KonsolArayuz konsolArayuz = new KonsolArayuz(rehberIslemleri);
        konsolArayuz.Menu();
    }
}
