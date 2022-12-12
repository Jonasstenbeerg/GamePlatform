using GamePlatform.Data;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;

namespace GamePlatform.Controllers
{
    public class LauncherController
    {
        private readonly ITerminator _terminator;
        private readonly IIO _iOHandler;
        private readonly IFilemanager _filemanager;

        public LauncherController()
        {

        }
        public LauncherController(ITerminator terminator, IIO iOHandler, IFilemanager filemanager)
        {
            _terminator = terminator;   //For testing
            _iOHandler = iOHandler;     //For testing
            _filemanager = filemanager; //For testing
        }

        public void ChooseGame(List<Game> gameList)
        {
            IUI ui = new ConsoleUI(_terminator, _iOHandler);
            IDataAccess dataAccess = new DataAccess("scoreboard.txt", _filemanager);

            while (true)
            {
                ui.PrintString("Please choose a game by typing the exact name of it");

                DisplayGameOptions(gameList, ui);

                var input = ui.GetString();

                var chosenGame = gameList.FirstOrDefault(game => game.GameTitle == input);

                if (chosenGame == null)
                {
                    ui.PrintString("Wrong input!");
                }
                else
                {
                    GameController controller = new(ui, chosenGame, dataAccess);

                    controller.RunGame();
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
