namespace TemplateMethod;

class Program
{
    static void Main(string[] args)
    {
        Drink tea = new Tea();
        tea.PrepareDrink();
        Console.WriteLine("------------");
        Console.WriteLine("------------");
        Drink coffee = new Coffee();
        coffee.PrepareDrink();
    }
}

public abstract class Drink
{
    public void PrepareDrink()
    {
        BoilWater();
        MakeDrink();
        PourIntoCup();
        PourIntoMug();
    }
    protected virtual void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    protected virtual void PourIntoMug()
    {
        Console.WriteLine("Pouring into mug");   
    }
    
    protected abstract void MakeDrink();
    protected abstract void PourIntoCup();
}

public class Tea : Drink
{
    protected override void MakeDrink()
    {
        Console.WriteLine("Making tea");
    }

    protected override void PourIntoCup()
    {
        Console.WriteLine("Pouring tea into cup");  
    }
}

public class Coffee : Drink
{
    protected override void MakeDrink()
    {
        Console.WriteLine("Making coffee");
    }

    protected override void PourIntoCup()
    {
        Console.WriteLine("Pouring coffee into cup"); 
    }
}