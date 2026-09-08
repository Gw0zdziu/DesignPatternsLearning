namespace Singleton;

class Program
{
    static void Main(string[] args)
    {
        var logger = Logger.GetInstance();
        logger.Log("Hello World");
        logger.Log("Hello World 2");
        logger.Log("Hello World 3");
        logger.PrintMessages();
    }
}

public class Logger
{
    private static  Logger _logger;
    private static readonly object padlock = new object();
    private List<string> _messages = [];
    
    private Logger() { }
    
    public static Logger GetInstance()
    {
        lock (padlock)
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }
            return _logger;
        }
    }
    
    public void Log(string message)
    {
        _messages.Add(message);
    }

    public void PrintMessages()
    {
        foreach (var message in _messages)
        {
            Console.WriteLine(message);
        }
    }
}