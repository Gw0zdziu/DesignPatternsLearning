namespace ChainOfResponsibility;

class Program
{
    static void Main(string[] args)
    {
       var consultant = new Consultant();
       var manager = new Manager();
       var director = new Director();
       consultant.setNext(manager);
       manager.setNext(director);
       consultant.Handle("Consultant", 100);
    }
}

public interface IHandler
{
    void setNext(IHandler handler);
    void Handle(string request, decimal amount);}

public class Consultant: IHandler
{
    private IHandler _next;
    
    public void setNext(IHandler handler)
    {
        _next = handler;
    }

    public void Handle(string request, decimal amount)
    {
        if (amount <= 1000)
        {
            Console.WriteLine("Consultant handled the request");
        }
        else if (_next != null)
        {
            _next.Handle(request, amount);
        }
        else
        {
            Console.WriteLine("No one could handle this request");
        }
    }
}

public class Manager: IHandler
{
    private IHandler _next;
    public void setNext(IHandler handler)
    {
        _next = handler;
    }

    public void Handle(string request, decimal amount)
    {
        if (amount <= 5000)
        {
            Console.WriteLine("Manager handled the request");
        }
        else if (_next != null)
        {
            _next.Handle(request, amount);
        }
        else
        {
            Console.WriteLine("No one could handle this request");
        }
    }
}

public class Director: IHandler
{
    private IHandler _next;
    public void setNext(IHandler handler)
    {
        _next = handler;
    }

    public void Handle(string request, decimal amount)
    {
        if (amount <= 10000)
        {
            Console.WriteLine("Director handled the request");
        }
        else if (_next != null)
        {
            _next.Handle(request, amount);
        }
        else
        {
            Console.WriteLine("No one could handle this request");
        }
    }
}