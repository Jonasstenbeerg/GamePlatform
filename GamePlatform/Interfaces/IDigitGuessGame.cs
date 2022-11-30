using GamePlatform.Interfaces;

public interface IDigitGuessGame
{
    int GuessCounter { get; }
    public string SetupDigitsToGuess();
    public void IncrementGuessCounter();
    public void ResetGuessCounter();
    public string GetGuessResult(string guess, string digitsToGuess);
}
