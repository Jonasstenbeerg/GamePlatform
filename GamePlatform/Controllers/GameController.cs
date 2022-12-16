using GamePlatform.Interfaces;
using GamePlatform.Models;
using GamePlatform.Tools;

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
            const int numberOfBullsToWin = 4;
            SetCurrentGame(game);
            CreateNewPlayer();

            do
            {
                CreateNewGame();

                do
                {
                    MakeGuess();
                    ShowGuessResult();
                }
                while (_currentGame!.GetGuessResult().BullsCounter < numberOfBullsToWin);

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
            List<PlayerData> allPlayerStats = _dataAccess.GetAllPlayers();
            GeneratePlayersScore(allPlayerStats);
        }

        private void ShowGuessResult()
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
            //Comment out or remove next line to play real games!
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
            bool notFirstGuess = _currentGame!.GuessCounter != 1;
            if (notFirstGuess) _ui.PrintString(guess);
        }

        private bool AskToContinue()
        {
            _ui.PrintString($"\nCorrect, it took {_currentGame!.GuessCounter} guesses\nContinue?");
            bool wantsToContinue = _ui.GetString().FirstOrDefault() != 'n';
            return wantsToContinue;
        }

        private void GeneratePlayersScore(List<PlayerData> players)
        {
            _ui.PrintString("Player   Rounds  Average  Game");
            List<PlayerData> distinctPlayersByGame = players.GetDistinctPlayersForEachGame();

            foreach (var player in distinctPlayersByGame.OrderBy(player => player.AverageGuesses))
            {
                int gameTitleSpacing = 5 + player.CurrentGameTitle!.Length;

                _ui.PrintString(string.Format($"{{0,-9}}{{1,-1:D}}{{2,11:F2}}{{3,{gameTitleSpacing}}}",
                   player.Name,
                   player.NumberOfGames,
                   player.AverageGuesses,
                   player.CurrentGameTitle
                   ));
            }
        }

        private void HandleSave()
        {
            PlayerData currentPlayer = new()
            {
                Name = _currentGame!.PlayerName,
                TotalGuesses = _currentGame.GuessCounter,
                CurrentGameTitle = _currentGame.Title!
            };

            _dataAccess.SavePlayer(currentPlayer);
        }
    }
}