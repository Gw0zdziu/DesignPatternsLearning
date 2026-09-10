namespace Observer;

class Program
{
    static void Main(string[] args)
    {
        var stock = new Stock();
        var investor1 = new Investor {Id = "1"};
        var investor2 = new Investor {Id = "2"};
        stock.Subscribe(investor1);
        stock.Subscribe(investor2);
        stock.Notify("Stock price increased");
        stock.Unsubscribe(investor1);
        stock.Notify("Stock price decreased");
        
    }
}

public interface ISubject
{
    public void Subscribe(IObserver observer);
    public void Unsubscribe(IObserver observer);
    public void Notify(string message);
}

public class Stock : ISubject
{
    private readonly Dictionary<string, IObserver> _observers = new();

    public void Subscribe(IObserver observer)
    {
        _observers.TryAdd(observer.Id, observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        _observers.Remove(observer.Id);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Value.FetchUpdate(message);
        }
    }
}

public interface IObserver
{
    public string Id{ get; set;}
    public void FetchUpdate(string message);

}

public class Investor : IObserver
{
    public string Id{ get; set;}
    public void FetchUpdate(string message)
    {
        Console.WriteLine($"Investor {Id} fetching update: {message}");
    }
}