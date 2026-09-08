namespace AbstractFactory;

class Program
{
    static void Main(string[] args)
    {
       IThemeFactory factory = new LightThemeFactory();
       factory.CreateButton().Render();
       factory.CreateCheckbox().Render();
       factory.CreateInput().Render();
    }
}

public interface IThemeFactory
{
    public IButton CreateButton();
    public ICheckbox CreateCheckbox();
    public IInput CreateInput();
}

public class DarkThemeFactory: IThemeFactory
{
    public IButton CreateButton()
    {
        return new DarkButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new DarkCheckbox();
    }

    public IInput CreateInput()
    {
        return new DarkInput();
    }
}

public class LightThemeFactory: IThemeFactory
{
    public IButton CreateButton()
    {
        return new LightButton();
    }

    public ICheckbox CreateCheckbox()
    {
        return new LightCheckbox();
    }

    public IInput CreateInput()
    {
        return new LightInput();
    }
}

public interface IButton
{
    public void Render();
}

public class LightButton: IButton
{
    public void Render()
    {
        Console.WriteLine("Light Button");
    }
}

public class DarkButton: IButton
{
    public void Render()
    {
        Console.WriteLine("Dark Button");
    }
}

public interface ICheckbox
{
    public void Render();
}

public class DarkCheckbox: ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Dark Checkbox");
    }
}

public class LightCheckbox: ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Light Checkbox");
    }
}

public interface IInput
{
    public void Render();
}

public class DarkInput: IInput
{
    public void Render()
    {
        Console.WriteLine("Dark Input");
    }
}

public class LightInput: IInput
{
    public void Render()
    {
        Console.WriteLine("Light Input");
    }
}