using GamePlatform.Data;
using GamePlatform.Interfaces;

public class GameController
{
    private readonly IUI _ui;
    private readonly IDigitGuessGame _game;
    private readonly IContext _context;
    public GameController(IUI ui, IDigitGuessGame digitGuessGame)
    {
        _ui = ui;
        _game = digitGuessGame;
        _context = Context.GetInstance()!;
    }

    public void RunGame()
    {
        _ui.PrintString("Enter your username: \n");
        var playerName = _ui.GetString();
        bool continueGame;

        do
        {
            _game.ResetGuessCounter();
            var digitsToGuess = _game.SetupDigitsToGuess();
            _ui.PrintString("New game:\n");
            _ui.PrintString($"For practice, number is: {digitsToGuess}\n");
            string guess;
            

            do
            {
                
                guess = _ui.GetString();
                _game.IncrementGuessCounter();
                HandleGuess(guess);
                var result = _game.GetGuessResult(guess,digitsToGuess);
                _ui.PrintString($"{result}\n");
            }
            while (guess != digitsToGuess);

            
            HandleSave(_context,playerName);
            var scoreboard = _context.GetScoreboard();
            HandleScoreboard(scoreboard);
            _ui.PrintString($"\nCorrect, it took {_game.GuessCounter} guesses\nContinue?");
            continueGame = AskToContinue();

        } while (continueGame);

        _ui.Exit();
    }

    private void HandleGuess(string guess)
    {
        if (_game.GuessCounter != 1) _ui.PrintString(guess);
    }

    private bool AskToContinue()
    {
        return _ui.GetString()[0] != 'n';
    }

    private void HandleScoreboard(List<PlayerData> scoreboard)
    {
        _ui.PrintString("Player   games average");
        foreach(var player in scoreboard)
        {
            _ui.PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}",
               player.Name, 
               player.NumberOfGames, 
               player.GetAverageGuesses()));
        }
    }

    private void HandleSave(IContext db, string playerName)
    {
        db.SavePlayerDataToScoreboard(playerName, _game.GuessCounter);
    }

    
}
