namespace Facade;

class Program
{
    static void Main(string[] args)
    {
        var orderFacade = new OrderFacade();
        orderFacade.PlaceOrder();
    }
}

public class OrderFacade
{
    private readonly Warehouse _warehouse = new Warehouse();
    private readonly Payment _payment = new Payment();
    private readonly Courier _courier = new Courier();

    public void PlaceOrder()
    {
        _warehouse.StoreOrder();
        _payment.ProcessPayment();
        _courier.DeliverOrder();
    }
}

internal class Courier
{
    public void DeliverOrder()
    {
        
    }
}

internal class Payment
{
    public void ProcessPayment()
    {
        
    }
}

internal class Warehouse
{
    public void StoreOrder()
    {
        
    }
}