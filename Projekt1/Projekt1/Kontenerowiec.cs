using System;
using System.Collections.Generic;
using System.Linq;
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

        public void DodajKontener(Kontener kontener)
        {
            float currentWight = 0; //kg
            foreach (Kontener k in kontenery)
            {
                k.Mass += currentWight;
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
                DodajKontener(kontener);

        }
    }
}
