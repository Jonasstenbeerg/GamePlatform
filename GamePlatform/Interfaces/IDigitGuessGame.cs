using GamePlatform.Interfaces;

public interface IDigitGuessGame
{
    public void RegisterPlayer(IUI ui);
    public void SetupDigitsToGuess();
    public void MakeGuess(IUI ui);
    public bool IsGuessWrong();
    public void VerifyLastGuess(IUI ui);
    public void PrintScoreboard(IUI ui);
    public void SaveGameResult();
    public bool WantsToContinue(IUI uI);
    public void DisplayStringToGuess(IUI uI);
}
