using System.Linq.Expressions;

namespace Projekt1;

public abstract class Kontener
{
    public static int idCounter = 0;
    public double Mass { get; set; } //Masę ładunku (w kilogramach
    public double Height { get; set; } //Wysokość (w centymetrach
    public double ConMass { get; set; } //masa kontenera bez ładunku
    public double Depth { get; set; } //Głębokość (w centymetrach)
    public double MaxLoad { get; set; } //Numer seryjny
    public string SerialNumber { get; set; } //Maksymalna ładowność danego kontenera w kilogramach

    public Kontener(double mass, double height, double conMass, double maxLoad, double depth)
    {
        Mass = mass;
        Height = height;
        ConMass = conMass;
        MaxLoad = maxLoad;
        Depth = depth;
    }

    public virtual void Unload() //Opróżnienie ładunku
    {
        Mass = 0;
    }
    public string getSerialNumber()
    {
        return SerialNumber;
    }
    public virtual void Load(double load) //Załadowanie kontenera daną masą ładunku
    {
        try
        {
            Mass += load;
            if(Mass > MaxLoad)
                throw new OverfillException("Load overflow"); //Jeśli masa ładunku jest większa niż pojemność danego kontenera powinniśmy wyrzucić błąd OverfillException
        }
        catch (Exception e)
        {
            Mass -= load;
            Console.WriteLine(e);
        }
    }

    public override string ToString()
    {
        return $"Serial Number: {SerialNumber}\n" +
               $"Mass (ładunek): {Mass} kg\n" +
               $"Container Mass (bez ładunku): {ConMass} kg\n" +
               $"Max Load: {MaxLoad} kg\n" +
               $"Height: {Height} cm\n" +
               $"Depth: {Depth} cm";
    }
}