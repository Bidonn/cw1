using System.Collections;

namespace Projekt1;

class Program
{
    static void Main(string[] args)
    {
        Kontenerowiec k1 = new Kontenerowiec(20, 80, 2000);


        //Stworzenie kontenera danego typu
        LiquidKontener l = new LiquidKontener(4000, 250, 300, 5000, 5000, false);
        GasKontener g = new GasKontener(4000, 250, 300, 5000, 5000, 3.0);
        CoolKontener c = new CoolKontener(4000, 250, 300, 5000, 5000, null, 0);
        //Załadowanie ładunku do danego kontenera
        l.Load(1000, true);
        g.Load(1000);
        c.Load(1000, Product.Bananas);
        //Załadowanie kontenera na statek
        k1 = new Kontenerowiec(20, 80, 2000);
        k1.DodajKontener(l);
        k1.DodajKontener(g);
        k1.DodajKontener(c);
        //Załadowanie listy kontenerów na statek

        List<Kontener> kon = new List<Kontener>();

        for (int i = 0; i < 81; i++)
        {
            kon.Add(new LiquidKontener(4000, 250, 300, 5000, 5000, false));
            k1.DodajKontener(kon[i]);
        }
        //Usunięcie kontenera ze statku
        k1.DeleteKontener(1);
        k1.DeleteKontener("losowy numer seryjny, nic nie usunie");
        //Rozładowanie kontenera
        Kontener kk1 = k1.Unload(1);
        Kontener? kk2 = k1.Unload("losowy numer seryjny, nic nie zostanie przypisane, będzie null");
        Console.WriteLine("kon1\n"+kk1);
        Console.WriteLine("kon2\n"+kk2);
        //Zastąpienie kontenera na statku o danym numerze innym kontenerem
        Kontener kontenerAlboNull = k1.SwapKontener(new GasKontener(1000,2.5, 300,4000,5000,3.0),"KON-L-10");
        if (kontenerAlboNull == null)
        {
            Console.WriteLine("Nie było takiego kontenera");
        }
        else Console.WriteLine(kontenerAlboNull);
        //Możliwość przeniesienie kontenera między dwoma statkami
        //można zrobić za pomocą SwapKontener

        //Wypisanie informacji o danym kontenerze
        Console.WriteLine(l);
        Console.WriteLine(g);
        Console.WriteLine(c);
        //Wypisanie informacji o danym statku i jego ładunku
        Console.WriteLine(k1);
        //k1.DisplayAllKontainersInfo(); //wyświetla info o wszystkich kontenerach na kontenerowcu

    }
}