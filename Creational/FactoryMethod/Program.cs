
namespace FactoryMethod;

class Program
{
    static void Main(string[] args)
    {
        DocumentFactory factory = new InvoiceFactory();
        factory.ProcessDocument();
    }
}

public abstract class Document
{
    public virtual void PrintDocument()
    {
        Console.WriteLine($"Created {GetType().Name}");
    }
}

public class Invoice: Document
{
}

public class Agreement : Document
{
    
}

public class Report : Document
{
    
}

public abstract class DocumentFactory
{
    protected abstract Document CreateDocument();
    public void ProcessDocument()
    {
        var document = CreateDocument();
        document.PrintDocument();
    }
}

public class InvoiceFactory: DocumentFactory
{
    protected override Document CreateDocument()
    {
        return new Invoice();
    }
}

public class AgreementFactory : DocumentFactory
{
    protected override Document CreateDocument()
    {
        return new Agreement();
    }
}

public class ReportFactory : DocumentFactory{
    protected override Document CreateDocument()
    {
        return new Report();
    }
}

