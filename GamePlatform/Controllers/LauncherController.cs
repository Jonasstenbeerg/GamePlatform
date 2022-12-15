using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;
using GamePlatform.Tools;

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

        public void ChooseGameFromList(List<Game> gameList)
        {
            while (true)
            {
                _uI.PrintString("Please choose a game by typing the exact name of it.");
                DisplayGameOptions(gameList, _uI);
                var input = _uI.GetString();
                var chosenGame = gameList.FirstOrDefault(game => game.GameTitle == input);

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
        }

        private static void DisplayGameOptions(List<Game> gameList, IUI ui)
        {
            foreach (var game in gameList)
            {
                ui.PrintString($"{game.GameTitle}");
            }
        }
    }
}