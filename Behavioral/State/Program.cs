namespace State;

class Program
{
    static void Main(string[] args)
    {
        var machine = new VendingMachine();

        machine.InsertCoin();

        Console.WriteLine(machine.GetBalance());

        machine.SelectProduct();

        machine.DispenseProduct();

        Console.WriteLine(machine.GetBalance());
    }
}

public class VendingMachine
{
    private IState _currentState;
    private decimal Balance { get; set; } = 0m;
    
    public VendingMachine()
    {
        _currentState = new NoCoinState();
    }

    public void ChangeState(IState state)
    {
        _currentState = state;
    }

    public void IncreaseBalance(decimal amount)
    {
        Balance += amount;
    }
    
    public void CashBack(decimal amount)
    {
        Balance  -= amount;
    }

    public decimal GetBalance()
    {
        return Balance;
    }
    
    public void ClearBalance()
    {
        Balance = 0m;
    }
    
    public void InsertCoin() => _currentState.InsertCoin(this);
    public void SelectProduct() => _currentState.SelectProduct(this);
    public void DispenseProduct() => _currentState.DispenseProduct(this);
    public void CancelTransaction() => _currentState.CancelTransaction(this);
}

public interface IState
{
    public void InsertCoin(VendingMachine vendingMachine);
    public void SelectProduct(VendingMachine vendingMachine);
    public void DispenseProduct(VendingMachine vendingMachine);
    public void CancelTransaction(VendingMachine vendingMachine);
}



public class Dispensing: IState
{
    public void InsertCoin(VendingMachine vendingMachine)
    {
        return;
    }

    public void SelectProduct(VendingMachine vendingMachine)
    {
        return;
    }

    public void DispenseProduct(VendingMachine vendingMachine)
    {
        vendingMachine.ChangeState(new NoCoinState());
        vendingMachine.ClearBalance();
    }

    public void CancelTransaction(VendingMachine vendingMachine)
    {
        return;
    }
}

public class HasCoinState: IState
{
    public void InsertCoin(VendingMachine vendingMachine)
    {
        vendingMachine.IncreaseBalance(10);
    }

    public void SelectProduct(VendingMachine vendingMachine)
    {
        vendingMachine.ChangeState(new Dispensing());
    }

    public void DispenseProduct(VendingMachine vendingMachine)
    {
        return;
    }

    public void CancelTransaction(VendingMachine vendingMachine)
    {
        vendingMachine.CashBack(10);
        vendingMachine.ChangeState(new NoCoinState());
    }
}

public class NoCoinState: IState
{
    public void InsertCoin(VendingMachine vendingMachine)
    {
        vendingMachine.IncreaseBalance(10);
        vendingMachine.ChangeState(new HasCoinState());
    }

    public void SelectProduct(VendingMachine vendingMachine)
    {
        Console.WriteLine("Insert Coin First");
    }

    public void DispenseProduct(VendingMachine vendingMachine)
    {
       return;
    }

    public void CancelTransaction(VendingMachine vendingMachine)
    {
        return;
    }
}