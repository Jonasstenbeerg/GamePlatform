using GamePlatform.Interfaces;

public interface IDigitGuessGame
{
    string? PlayerName { get; }
    int GuessCounter { get; }
    string? CurrentGuess { get; }
    string? DigitsToGuess { get; }
    public void SetCurrentGuess(string guess);
    public void SetPlayerName(string? playerName);
    public void SetupDigitsToGuess();
    public void IncrementGuessCounter();
    public void ResetGuessCounter();
    public string GetGuessResult();
}
