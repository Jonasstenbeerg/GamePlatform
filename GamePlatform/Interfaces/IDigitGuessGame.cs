public interface IDigitGuessGame
{
    string? PlayerName { get; }
    int GuessCounter { get; }
    string? CurrentGuess { get; }
    string? DigitsToGuess { get; }
    string? GameTitle { get; }
    public void SetCurrentGuess(string guess);
    public void SetPlayerName(string? playerName);
    public void SetDigitsToGuess();
    public void IncrementGuessCounter();
    public void ResetGuessCounter();
    public string GetGuessResult();
}
