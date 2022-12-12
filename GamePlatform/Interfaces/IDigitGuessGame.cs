public interface IDigitGuessGame
{
    string? PlayerName { get; }
    int GuessCounter { get; }
    int CurrentGuess { get; }
    int DigitsToGuess { get; }
    public void SetCurrentGuess(int digitGuess);
    public void SetPlayerName(string? playerName);
    public void SetDigitsToGuess();
    public void IncrementGuessCounter();
    public void ResetGuessCounter();
    public string GetGuessResult();
}
