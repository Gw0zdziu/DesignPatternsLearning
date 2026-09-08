namespace Prototype;

class Program
{
    static void Main(string[] args)
    {
        var npcGame = new UnitNpcGame("Test", 100, 1);
        var npcGame2 = npcGame.Clone();
    }
}

public interface IPrototype
{
    public IPrototype Clone();
}

public class UnitNpcGame : IPrototype
{
    private string _name;
    private int _level;
    private int _health;

    public UnitNpcGame(string name, int health, int level)
    {
        _name = name;
        _health = health;
        _level = level;
    }


    public IPrototype Clone()
    {
        var newNpcGame = new UnitNpcGame(_name, _health, _level);
        return newNpcGame;
    }
    public override string ToString()
    {
        return $"{_name} {_level} {_health}";
    }
    
}