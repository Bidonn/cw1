using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1
{
    internal class Kontenerowiec
    {
        public List<Kontener> kontenery = new List<Kontener>();
        public double maxSpeed = 0; //w węzłach
        public double maxSize = 0;
        public double maxWeigth = 0; //w tonach

        public Kontenerowiec(double maxSpeed, double maxSize, double maxWeith)
        {
            this.maxSpeed = maxSpeed;
            this.maxSize = maxSize;
            this.maxWeigth = maxWeith;
        }

        public double CalcCurrentWeight()
        {
            double currentWight = 0; //kg
            foreach (Kontener k in kontenery)
            {
                currentWight += k.Mass;
            }
            return currentWight/1000; //tony
        }
        public void DodajKontener(Kontener kontener)
        {
            double currentWight = 0; //kg
            foreach (Kontener k in kontenery)
            {
               currentWight += k.Mass;
            }
            if (currentWight + kontener.Mass > maxWeigth * 1000)
            {
                Console.WriteLine("Overweight!");
                return;
            } 
            if(kontenery.Count+1 > maxSize)
            {
                Console.WriteLine("Maksymalna ilość miejsca została przekroczona, nie załadowano nowego kontenera na statek...");
                return;
            }

            kontenery.Add(kontener);
        }

        public void DodajKontener(List<Kontener> kontener)
        {
            foreach (Kontener k in kontener)
                DodajKontener(k);

        }
        public Kontener? Unload(int indexKontener) //wyłuj kontener, załadowany jako indexowy
        {
            if (indexKontener > kontenery.Count())
            {
                Console.WriteLine("Nie ma takiego kontenera");
                return null;
            }
            Kontener kon = kontenery[indexKontener];
            kontenery.RemoveAt(indexKontener);
            return kon;
        }
        public Kontener? Unload(string numerSer) //wyłuj kontener, załadowany jako indexowy
        {
            foreach (Kontener k in kontenery)
            {
                if (numerSer.Equals(k.SerialNumber))
                    {
                    kontenery.Remove(k);
                    return k;
                    }
                } 
           return null;
        }
        public void DeleteKontener(int indexKontener)
        {
            Unload(indexKontener);
        }
        public void DeleteKontener(string numerSer)
        {
            Unload(numerSer);
        }
        public Kontener? SwapKontener(Kontener kontener, string nrSer)
        {
            for (int i = 0; i < kontenery.Count; i++)
            {
                if(kontenery[i].SerialNumber.Equals(nrSer))
                {
                    Kontener tmp = kontenery[i];
                    kontenery[i] = kontener;
                    return tmp;
                }
            }
            return null;
        }

        public void DisplayAllKontainersInfo()
        {
            foreach(var k in kontenery)
            {
                if(k is LiquidKontener l)
                    Console.WriteLine(l);
                if(k is GasKontener g)
                    Console.WriteLine(g);
                if(k is CoolKontener c)
                    Console.WriteLine(c);
            }
        }
        public override string ToString()
        {
            return $"Max speed: {maxSpeed} knots\nMax Container Count: {maxSize}\nCurretn Container Count: {kontenery.Count()}\nMax Weight: {maxWeigth} tons\nCurrent Weight: {CalcCurrentWeight()} tons";
        }            
    }                
}
