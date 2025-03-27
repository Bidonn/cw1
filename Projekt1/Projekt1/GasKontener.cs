using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class GasKontener : Kontener, IHazardNotifier
    {
        double ATM;

        public GasKontener(double mass, double height, double conMass, double maxLoad, double depth, double aTM) : base(mass, height, conMass, maxLoad, depth) //Kontenery przechowujące gaz przechowują dodatkową informacje na temat ciśnienia (w atmosferach)
        {
            SerialNumber = "KON-G-" + idCounter++;
            ATM = aTM; //zakładam, że ciśnienie w kontenerze się nie zmieni, nawet przy wyładowanym kontenerze, nie rozumiem tego pola
        }

        public void NotifyHazard() //Powinien zaimplementować interfejs IHazardNotifier, nigdzie nie używamy tego
        {
            Console.WriteLine("Warning, dangerous operation!");
            Console.WriteLine("Container number: " + SerialNumber);
        }

        public override void Unload()
        {
            Mass = Mass * 0.05;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nAtmosphere: {ATM} atm";
        }
    }
}
