using GamePlatform.Interfaces;
using GamePlatform.Models;
using GamePlatform.Tools;
using System.Globalization;

namespace GamePlatform.Controllers
{
    public class GameController : IGameController
    {
        private readonly IUI _ui;
        private IDigitGuessGame? _currentGame;
        private readonly IDataAccess _dataAccess;
        private bool _continueGame;
        public GameController(IUI ui, IDataAccess dataAccess)
        {
            _ui = ui;
            _dataAccess = dataAccess;
        }

        public void RunGame(IDigitGuessGame game)
        {
            SetCurrentGame(game);
            CreateNewPlayer();

            do
            {
                CreateNewGame();

                do
                {
                    MakeGuess();
                    VerifyGuess();
                }
                while (_currentGame!.CurrentGuess != _currentGame.DigitsToGuess);

                HandleSave();
                ShowAllPlayersScore();
                _continueGame = AskToContinue();

            } while (_continueGame);

            _ui.Exit();
        }

        private void SetCurrentGame(IDigitGuessGame game)
        {
            _currentGame = game;
        }
        private void ShowAllPlayersScore()
        {
            List<Player> allPlayerStats = _dataAccess.GetAllPlayers();
            GeneratePlayersResult(allPlayerStats);
        }

        private void VerifyGuess()
        {
            GuessResult result = _currentGame!.GetGuessResult();
            _ui.PrintString($"{result}\n");
        }

        private void MakeGuess()
        {
            string guess = _ui.GetString();

            HandleGuess(guess);
        }

        private void CreateNewGame()
        {
            _currentGame!.ResetGuessCounter();
            _currentGame.SetDigitsToGuess();
            _ui.PrintString("New game:\n");
            _ui.PrintString($"For practice, number is: {_currentGame.DigitsToGuess}\n");
        }

        private void CreateNewPlayer()
        {
            _ui.PrintString("Enter your username: \n");
            string playerName = _ui.GetString();
            _currentGame!.SetPlayerName(playerName);
        }

        private void HandleGuess(string guess)
        {
            _currentGame!.IncrementGuessCounter();
            _currentGame.SetCurrentGuess(guess);
            if (_currentGame.GuessCounter != 1) _ui.PrintString(guess.ToString());
        }

        private bool AskToContinue()
        {
            _ui.PrintString($"\nCorrect, it took {_currentGame!.GuessCounter} guesses\nContinue?");
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
            Player currentPlayer = new Player()
            {
                Name = _currentGame!.PlayerName,
                TotalGuesses = _currentGame.GuessCounter,

            };

            _dataAccess.SavePlayer(currentPlayer);
        }
    }
}