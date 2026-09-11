namespace Command;

class Program
{
    static void Main(string[] args)
    {
        var textEditor = new TextEditor();
        var writerControl = new WriterControl();
        writerControl.PressButton(new WriteText(textEditor, "Hello, "));
        writerControl.PressButton(new WriteText(textEditor, "my name is "));
        writerControl.PressButton(new WriteText(textEditor, " World"));
        writerControl.PressUndo();
        writerControl.PressUndo();
        Console.WriteLine(textEditor.GetText());
    }
}

public class WriterControl
{
    private readonly Stack<ICommand> _commandStack = new Stack<ICommand>();

    public void PressButton(ICommand command)
    {
        _commandStack.Push(command);
        command.Execute();
    }

    public void PressUndo()
    {
        if (_commandStack.Count > 0)
        {
            var command = _commandStack.Pop();
            command.Undo();
        }
    }
}

public class TextEditor
{
    private string _text;

    public void SetText(string text)
    {
        _text = text;
    }

    public string GetText()
    {
        return _text;
    }
    
    public void Write(string text)
    {
        _text += text;
        
    }
    
    public void Delete(int length)
    {
        _text = _text[..^length];
    }
}


public interface ICommand
{
    public void Execute();
    public void Undo();
}

public class WriteText : ICommand
{
    private readonly TextEditor _textEditor;
    private string _text;
    

    public WriteText(TextEditor textEditor, string text)
    {
        _textEditor = textEditor;
        _text = text;
    }


public void Execute()
    {
        _textEditor.Write(_text);
    }

    public void Undo()
    {
        _textEditor.Delete(_text.Length);
    }
}

