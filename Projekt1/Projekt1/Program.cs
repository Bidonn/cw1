using System.Collections;

namespace Projekt1;

class Program
{
    static void Main(string[] args)
    {
        Kontenerowiec k1 = new Kontenerowiec(20, 80, 2000);

        List<Kontener> kon = new List<Kontener>();

        for (int i = 0; i < 81; i++)
        {
            kon.Add(new LiquidKontener(4000, 250, 300, 5000, 5000, false));
            k1.DodajKontener(kon[i]);
        }
        Console.WriteLine();
        Console.ReadLine();
    }
}