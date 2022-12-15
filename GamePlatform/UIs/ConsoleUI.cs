using GamePlatform.Interfaces;

public class ConsoleUI : IUI
{
    private readonly ITerminator _terminator;
    private readonly IIO _iO;

    public ConsoleUI(ITerminator terminator, IIO iO)
    {
        _terminator = terminator;
        _iO = iO;
    }

    public void Exit()
    {
        _terminator.TerminateProgram();
    }

    public void Clear()
    {
        Console.Clear();
    }

    public string GetString()
    {
        string? input;

        do
        {
            input = _iO.ReturnUserInput();

        } while (string.IsNullOrEmpty(input));
        return input!;
    }

    public void PrintString(string input)
    {
        _iO.HandleUserInput(input);
    }
}