using System.Reflection.Metadata.Ecma335;

namespace Projekt1;

public class LiquidKontener : Kontener, IHazardNotifier //Kontenery tego typu powinny implementowaæ interfejs IHazardNotifier
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
        if ((load+this.Mass)/this.MaxLoad > 0.5 && HazardousContent) //Jeœli kontener przechowuje niebezpieczny ³adunek - mo¿emy go wype³niæ jedynie do 50% pojemnoœci
        {
            NotifyHazard();
        }
        else if((load + this.Mass) / this.MaxLoad > 0.9) //W innym wypadku mo¿emy go wype³niæ do 90% jego pojemnoœci
        {
            NotifyHazard();
        }
        //Jeœli naruszymy dowoln¹ z opisanych regu³ - powinniœmy zg³osiæ informacje o próbie wykonania niebezpiecznej operacji.
        base.Load(load);
    }
    public override string ToString()
    {
        return base.ToString() + $"\nHazardous Content: {HazardousContent}";
    }

}