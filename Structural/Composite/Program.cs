namespace Composite;

class Program
{
    static void Main(string[] args)
    {
        var boss = new Manager(1000, "Boss");
        var manager = new Manager(500, "Manager");
        var employee = new Employee(100, "Employee");
        manager.Add(employee);
        boss.Add(manager);
        Console.WriteLine(boss.GetTotalSalary()); 
        boss.PrintStructure(1);
        
    }
}

public abstract class EmployeeComponent
{
    public abstract int GetTotalSalary();

    public abstract void PrintStructure(int depth);

}

public class Employee: EmployeeComponent
{
    private readonly int _salary;
    private readonly string _name;

    public Employee(int salary, string name)
    {
        _salary = salary;
        _name = name;
    }

    public override int GetTotalSalary()
    {
        return _salary;
    }

    public override void PrintStructure(int depth)
    {
        Console.WriteLine($"{new string('-', depth)} {_name} - {_salary}");
    }
}

public class Manager : EmployeeComponent
{
    private readonly List<EmployeeComponent> _employeeComponents = [];
    private readonly int _salary;
    private readonly string _name;

    public Manager(int salary, string name)
    {
        _salary = salary;
        _name = name;
    }


    public override int GetTotalSalary()
    {
        return _salary + _employeeComponents.Sum(employeeComponent => employeeComponent.GetTotalSalary());
    }

    public override void PrintStructure(int depth)
    {
        Console.WriteLine($"{new string('-', depth)} {_name} - {_salary}");
        foreach (var employeeComponent in _employeeComponents)
        {
            employeeComponent.PrintStructure(depth + 1);
        }
    }

    public void Add(EmployeeComponent employeeComponent)
    {
        _employeeComponents.Add(employeeComponent);
    }
}