namespace Builder;

class Program
{
    static void Main(string[] args)
    {
        Pizza pizzaBuilder = new PizzaBuilder()
            .AddCheese(true)
            .AddPepperoni(true)
            .AddSausage(false)
            .Build();
        pizzaBuilder.Print();

    }
}

public interface IPizzaBuilder
{
    public IPizzaBuilder AddCheese(bool addCheese);
    public IPizzaBuilder AddPepperoni(bool addPepperoni);
    public IPizzaBuilder AddSausage(bool addSausage);
    public Pizza Build();
    
}

public class PizzaBuilder : IPizzaBuilder
{
    private bool _withCheese = false;
    private bool _withPepperoni = false;
    private bool _withSausage = false;

    public IPizzaBuilder AddCheese(bool addCheese)
    {
        _withCheese = addCheese;
        return this;
    }

    public IPizzaBuilder AddPepperoni(bool addPepperoni)
    {
        _withPepperoni = addPepperoni;
        return this;
    }

    public IPizzaBuilder AddSausage(bool addSausage)
    {
        _withSausage = addSausage;
        return this;
    }

    public Pizza Build()
    {
        return new Pizza
        {
            WithCheese = _withCheese,
            WithPepperoni = _withPepperoni,
            WithSausage = _withSausage
        }; 
    }
}

public class Pizza
{
    public  bool WithCheese { get; init; }
    public  bool WithPepperoni { get; init; }
    public  bool WithSausage { get; init; }
    
    public void Print()
    {
        Console.WriteLine($"Pizza contains: {WithCheese} Cheese, {WithPepperoni} Pepperoni, {WithSausage} Sausage");
    }
}