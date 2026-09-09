namespace Bridge;

class Program
{
    static void Main(string[] args)
    {
        Report report = new AccountantReport(new JsonExporter(), 1000);
        report.Publish();
    }
}

public abstract class Report
{
    private readonly IExport _export;

    protected Report(IExport export)
    {
        _export = export;
    }

    protected abstract string GenerateContent();

    public void Publish()
    {
        var content = GenerateContent();
        _export.Export(content);
    }
}

public interface IExport
{
    public void Export(string report);
}

public class JsonExporter: IExport
{
    public void Export(string report)
    {
        Console.WriteLine($"Exporting {report} to JSON...");
    }
}

public class PdfExporter: IExport
{
    public void Export(string report)
    {
        Console.WriteLine($"Exporting {report} to PDF...");
    }
}

public class ExcelExporter: IExport
{
    public void Export(string report)
    {
        Console.WriteLine($"Exporting {report} to EXCEL...");
    }
}

public class CsvExporter: IExport
{
    public void Export(string report)
    {
        Console.WriteLine($"Exporting {report} to CSV...");
    }
}

public class AccountantReport: Report
{
    private readonly decimal _totalIncome;
    public AccountantReport(IExport export, decimal totalIncome) : base(export)
    {
        _totalIncome = totalIncome;
    }

    protected override string GenerateContent()
    {
        return $"Total Income: {_totalIncome}";
    }
}

public class SalesReport: Report
{
    private readonly decimal _totalSales;
    public SalesReport(IExport export, decimal totalSales) : base(export)
    {
        _totalSales = totalSales;
    }

    protected override string GenerateContent()
    {
        return $"Total Sales: {_totalSales}";
    }
}

public class InventoryReport: Report{
    
    private readonly int _itemCount;
    public InventoryReport(IExport export, int itemCount) : base(export)
    {
        _itemCount = itemCount;
    }

    protected override string GenerateContent()
    {
        return $"Total Items: {_itemCount}";
    }
}