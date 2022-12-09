using GamePlatform.Data;
using GamePlatform.GameTypes;
using GamePlatform.Tools;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;

//To create a new game, add a new instance of the game in the dictionary with the given name and type of game
Dictionary<string, Game> GameList = new Dictionary<string, Game>() { { "Moo", new Game(new MooType()) }, { "Mastermind", new Game(new MastermindType()) } };


ITerminator terminator = new Terminator();    //For testing
IIO iOHandler = new IO();                     //For testing
IFilemanager filemanager = new Filemanager(); //For testing


IUI ui = new ConsoleUI(terminator, iOHandler);
IDataAccess dataAccess = new DataAccess("scoreboard.txt", filemanager);


while (true)
{
    ui.PrintString("Please choose a game by typing the exact name of it");

    foreach (var game in GameList)
    {
        ui.PrintString($"{game.Key}");
    }

    var input = ui.GetString();

    var chosenGame = GameList.FirstOrDefault(game => game.Key == input).Value;


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












