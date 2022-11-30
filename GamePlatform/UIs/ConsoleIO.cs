using GamePlatform.Interfaces;

class ConsoleIO : IUI
{
    public void Exit()
    {
        Environment.Exit(0);
    }

    public string GetString()
    {
        string? input;

        do
        {
            input = Console.ReadLine();

        } while (string.IsNullOrEmpty(input));
        return input!;
    }

    public void PrintString(string input)
    {
        Console.WriteLine(input);
    }
}
