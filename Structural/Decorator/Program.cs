namespace Decorator;

class Program
{
    static void Main(string[] args)
    {
        ITicket ticket = new BaggageDecorator(new BaggageDecorator(new BasicTicket()));
        Console.WriteLine(ticket.GetPrice());
        Console.WriteLine(ticket.GetDescription());
    }
}

public interface ITicket
{
    public decimal GetPrice();
    public string GetDescription();
}

public class BasicTicket: ITicket
{
    
    public decimal GetPrice()
    {
       return 100;
    }

    public string GetDescription()
    {
        return "Basic Ticket";
    }
}

public abstract class TicketDecorator : ITicket
{
    protected readonly ITicket _ticket;

    protected TicketDecorator(ITicket ticket)
    {
        _ticket = ticket;
    }

    public abstract decimal GetPrice();

    public abstract string GetDescription();
}

public class BaggageDecorator: TicketDecorator
{


    public BaggageDecorator(ITicket ticket) : base(ticket)
    {
    }

    public override decimal GetPrice()
    {
        return _ticket.GetPrice() + 50;
    }

    public override string GetDescription()
    {
        return $"{_ticket.GetDescription()} + Baggage";
    }
}

