namespace Strategy;

class Program
{
    static void Main(string[] args)
    {
        CalculatorDiscount discount = new CalculatorDiscount(new DiscountPercent());
        Console.WriteLine(discount.Calculate(1000));
        discount.SetStrategy(new DiscountAmount());
        Console.WriteLine(discount.Calculate(1000));
    }
}

public interface ICalculatorStrategy
{
    public decimal Calculate(decimal amount);
}

public class DiscountPercent: ICalculatorStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount - (amount * (decimal)0.1);
    }
}

public class DiscountAmount: ICalculatorStrategy
{
    public decimal Calculate(decimal amount)
    {
        var price =  amount - 100;
        if (price < 0)
        {
            return 0;
        }
        return price;
    }
}

public class NoDiscount: ICalculatorStrategy
{
    public decimal Calculate(decimal amount)
    {
        return amount;
    }
}

public class CalculatorDiscount
{
    private ICalculatorStrategy _strategy;
    
    public CalculatorDiscount(ICalculatorStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ICalculatorStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public decimal Calculate(decimal amount)
    {
        return _strategy.Calculate(amount);
    }
}