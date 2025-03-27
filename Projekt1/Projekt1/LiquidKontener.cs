using System.Reflection.Metadata.Ecma335;

namespace Projekt1;

public class LiquidKontener : Kontener, IHazardNotifier //Kontenery tego typu powinny implementowa� interfejs IHazardNotifier
{
    protected bool HazardousContent { get; set; }
    public LiquidKontener(double mass, double height, double conMass, double depth, double maxLoad, bool hazard) : base(mass, height, conMass,
        maxLoad, depth)
    {
        SerialNumber = "KON-L-" + idCounter++;
        HazardousContent = hazard;
    }

    public void setHazardousContent(bool hazardousContent)
    {
        HazardousContent = hazardousContent;
    }
    public void NotifyHazard()
    {
        Console.WriteLine("Warning, dangerous operation!");
        Console.WriteLine("Container number: "+SerialNumber);
    }

    public void Load(double load, bool isHazardous)
    {
        HazardousContent = isHazardous;
        if ((load+this.Mass)/this.MaxLoad > 0.5 && HazardousContent) //Je�li kontener przechowuje niebezpieczny �adunek - mo�emy go wype�ni� jedynie do 50% pojemno�ci
        {
            NotifyHazard();
        }
        else if((load + this.Mass) / this.MaxLoad > 0.9) //W innym wypadku mo�emy go wype�ni� do 90% jego pojemno�ci
        {
            NotifyHazard();
        }
        //Je�li naruszymy dowoln� z opisanych regu� - powinni�my zg�osi� informacje o pr�bie wykonania niebezpiecznej operacji.
        base.Load(load);
    }
    public override string ToString()
    {
        return base.ToString() + $"\nHazardous Content: {HazardousContent}";
    }

}