using GamePlatform.Data;
using GamePlatform.Interfaces;
using System.Reflection.Metadata;

public class GameController
{
    private readonly IUI _ui;
    private readonly IDigitGuessGame _game;
    private readonly IContext _context;
    private bool _continueGame;
    public GameController(IUI ui, IDigitGuessGame digitGuessGame)
    {
        _ui = ui;
        _game = digitGuessGame;
        _context = Context.GetInstance()!;
    }

    public void RunGame()
    {
        CreateNewPlayer();

        do
        {
            CreateNewGame();

            do
            {
                MakeGuess();
                VerifyGuess();
            }
            while (_game.CurrentGuess != _game.DigitsToGuess);

            HandleSave(_context,_game.PlayerName!);
            ShowAllPlayersScore();
            _continueGame = AskToContinue();

        } while (_continueGame);

        _ui.Exit();
    }

    private void ShowAllPlayersScore()
    {
        var scoreboard = _context.GetScoreboard();
        HandleScoreboard(scoreboard);
    }

    private void VerifyGuess()
    {
        var result = _game.GetGuessResult();
        _ui.PrintString($"{result}\n");
    }

    private void MakeGuess()
    {
        var guess = _ui.GetString();
        HandleGuess(guess);
    }

    private void CreateNewGame()
    {
        _game.ResetGuessCounter();
        _game.SetupDigitsToGuess();
        _ui.PrintString("New game:\n");
        _ui.PrintString($"For practice, number is: {_game.DigitsToGuess}\n");
    }

    private void CreateNewPlayer()
    {
        _ui.PrintString("Enter your username: \n");
        var playerName = _ui.GetString();
        _game.SetPlayerName(playerName);
    }

    private void HandleGuess(string guess)
    {
        _game.IncrementGuessCounter();
        _game.SetCurrentGuess(guess);
        if (_game.GuessCounter != 1) _ui.PrintString(guess);
    }

    private bool AskToContinue()
    {
        _ui.PrintString($"\nCorrect, it took {_game.GuessCounter} guesses\nContinue?");
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
