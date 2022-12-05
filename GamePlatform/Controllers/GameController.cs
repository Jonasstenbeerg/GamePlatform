using GamePlatform.Data;
using GamePlatform.Interfaces;
using System.Reflection.Metadata;

public class GameController
{
    private readonly IUI _ui;
    private readonly IDigitGuessGame _game;
    private readonly IDataAccess _context;
    private bool _continueGame;
    public GameController(IUI ui, IDigitGuessGame digitGuessGame, IDataAccess context)
    {
        _ui = ui;
        _game = digitGuessGame;
        _context = context;
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

            HandleSave();
            ShowAllPlayersScore();
            _continueGame = AskToContinue();

        } while (_continueGame);

        _ui.Exit();
    }

    private void ShowAllPlayersScore()
    {
        var allPlayerStats = _context.GetAllPlayers();
        allPlayerStats.OrderBy(player => player.AverageGuesses);
        GenerateScoreboard(allPlayerStats);
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

        var player = _context.GetPlayerOnName(playerName);

        if (player == null)
        {
            _context.PostPlayer(playerName);
        }
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

    private void GenerateScoreboard(List<Player> scoreboard)
    {
        _ui.PrintString("Player   games average");
        foreach(var player in scoreboard)
        {
            
            _ui.PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}",
               player.Name, 
               player.NumberOfGames, 
               player.AverageGuesses));
        }
    }

    private void HandleSave()
    {
        var currentPlayer = new Player()
        {
            Name = _game.PlayerName,
            TotalGuesses = _game.GuessCounter,

        };

        _context.PutPlayer(currentPlayer);
    }

    
}
