using GamePlatform.Interfaces;
using GamePlatform.Tools;

public class GameController : IGameController
{
    private readonly IUI _ui;
    private readonly IDigitGuessGame _game;
    private readonly IDataAccess _dataAccess;
    private bool _continueGame;
    public GameController(IUI ui, IDigitGuessGame digitGuessGame, IDataAccess dataAccess)
    {
        _ui = ui;
        _game = digitGuessGame;
        _dataAccess = dataAccess;
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
        var allPlayerStats = _dataAccess.GetAllPlayers();
        GeneratePlayersResult(allPlayerStats);
    }

    private void VerifyGuess()
    {
        var result = _game.GetGuessResult();
        _ui.PrintString($"{Helpers.GuessResultToString(result)}\n");
    }

    private void MakeGuess()
    {
        string guess = "";
        int _result;
        do
        {
            if(guess != "") _ui.PrintString("Wrong input! only numbers");
           
            guess = _ui.GetString();
            
        } while (!int.TryParse(guess, out _result));
       
        HandleGuess(_result);
    }

    private void CreateNewGame()
    {
        _game.ResetGuessCounter();
        _game.SetDigitsToGuess();
        _ui.PrintString("New game:\n");
        _ui.PrintString($"For practice, number is: {_game.DigitsToGuess}\n");
    }

    private void CreateNewPlayer()
    {
        _ui.PrintString("Enter your username: \n");
        var playerName = _ui.GetString();
        _game.SetPlayerName(playerName);
    }

    private void HandleGuess(int guess)
    {
        _game.IncrementGuessCounter();
        _game.SetCurrentGuess(guess);
        if (_game.GuessCounter != 1) _ui.PrintString(guess.ToString());
    }

    private bool AskToContinue()
    {
        _ui.PrintString($"\nCorrect, it took {_game.GuessCounter} guesses\nContinue?");
        return _ui.GetString()[0] != 'n';
    }

    private void GeneratePlayersResult(List<Player> players)
    {
        _ui.PrintString("Player   games average");
        List<Player> distinctPlayers = players.GetDistinctPlayers();

        foreach (var player in distinctPlayers.OrderBy(player => player.AverageGuesses))
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

        _dataAccess.SavePlayer(currentPlayer);
    }
}
