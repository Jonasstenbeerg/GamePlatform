using GamePlatform.Data;
using GamePlatform.Games;
using GamePlatform.GamesTypes;
using GamePlatform.Helpers;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;

//För att skapa ett nytt spel lägg till en ny instance av game i Dictionaryn med givet namn och typ av spel
Dictionary<string, Game> GameList = new Dictionary<string, Game>() { { "Moogame", new Game(new MooType()) }, { "Mastermind", new Game(new MastermindType()) } }; 


ITerminator terminator = new Terminator();  //För att hantera tester
IIO iOHandler = new IO();                   //För att hantera tester
IFilemanager filemanager = new Filemanager(); //För att hantera tester


IUI ui = new ConsoleUI(terminator, iOHandler);
IDataAccess dataAccess = new DataAccess("scoreboard.txt", filemanager);


while (true)
{
    ui.PrintString("please choose a game by typing the exact name of it");

	foreach (var game in GameList)
	{
		ui.PrintString($"{game.Key}");
	}

	var input = ui.GetString();

	var chosenGame = GameList.FirstOrDefault(game => game.Key == input).Value;


    if (chosenGame == null)
    {
        ui.PrintString("Wrong input!!!");
    }
	else
	{
        GameController controller = new(ui, chosenGame, dataAccess);

        controller.RunGame();
    }
}












