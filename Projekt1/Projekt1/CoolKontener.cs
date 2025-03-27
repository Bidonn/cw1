using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class CoolKontener : Kontener
    {
        Product? typeStored = null; //nullable
        double temperature { get; set; } //Temperatury kontenera nie może być niższa niż temperatura wymagana przez dany rodzaj produktu.
        //Osobiście wydaje mi się, że to błąd, temperatura nie powinna być wyższa niż, ale stosuje się do tego co w pdf'ie
        public CoolKontener(double mass, double height, double conMass, double maxLoad, double depth, Product? typeStored, double temperature) : base(mass, height, conMass, maxLoad, depth)
        {
            SerialNumber = "KON-C-" + idCounter++;
            this.typeStored = typeStored;
            this.temperature = temperature;
        }

        public void Load(double load, Product type)
        {
            if (typeStored == null)
                typeStored = type;
            else if (typeStored != type)
            {
                Console.WriteLine("Inny typ produktu jest obecnie przechowywany: " +typeStored.ToString()+"\nWyładuj najpierw kontener aby zmienić typ produktu.");
                return;
            }
            if (temperature < ProductData.getTemperature(type))
                Console.WriteLine("Zmieniono temperature w kontenerze, na minimalną akceptowalną");
            base.Load(load);
        }
        public override void Unload()
        {
            typeStored = null;
            base.Unload();
        }
    }
}
