using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;

namespace GamePlatform.Controllers
{
    public class LauncherController
    {
        private readonly IGameController _gameController;
        private readonly IUI _uI;

        public LauncherController(IGameController gameController, IUI uI)
        {
            _gameController = gameController;
            _uI = uI;
        }

        public void ChooseGameFromList(List<IDigitGuessGame> games)
        {
            while (true)
            {
                _uI.PrintString("Please choose a game by typing the exact name of it.");
                DisplayGameOptions(games, _uI);
                var input = _uI.GetString();
                var chosenGame = games.FirstOrDefault(game => game.Title == input);

                HandleChosenGame(chosenGame);
            }
        }

        private void HandleChosenGame(IDigitGuessGame? chosenGame)
        {
            if (chosenGame == null)
            {
                _uI.Clear();
                _uI.PrintString("Input didn't match any games, please try again!\n");
            }
            else
            {
                _uI.Clear();
                _gameController.RunGame(chosenGame);
            }
        }

        private void DisplayGameOptions(List<IDigitGuessGame> games, IUI ui)
        {
            foreach (var game in games)
            {
                ui.PrintString($"{game.Title}");
            }
        }
    }
}