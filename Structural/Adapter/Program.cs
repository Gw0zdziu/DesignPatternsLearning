namespace Adapter;

class Program
{
    static void Main(string[] args)
    {
        IPaymentGateway paypalAdapter = new BankTransferAdapter(new BankTransfer());
       paypalAdapter.Pay(100);
    }
}

public interface IBankTransfer
{
    public void MakeOldPayment(decimal amount);
}

public class BankTransfer : IBankTransfer
{
    public void MakeOldPayment(decimal amount)
    {
        Console.WriteLine($"Make old payment with bank transfer {amount}");
    }
}

public interface IPaymentGateway
{
    public void Pay(decimal amount);
}

public class BankTransferAdapter : IPaymentGateway
{
    private readonly IBankTransfer _bankTransfer;

    public BankTransferAdapter(IBankTransfer bankTransfer)
    {
        _bankTransfer = bankTransfer;
    }

    public void Pay(decimal amount)
    {
        _bankTransfer.MakeOldPayment(amount);
    }
}



