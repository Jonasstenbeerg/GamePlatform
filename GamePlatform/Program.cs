using GamePlatform.Controllers;
using GamePlatform.Data;
using GamePlatform.GameTypes;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;
using GamePlatform.Tools;

List<Game> gameList = new()
{
    new Game(new MooType(), "Moo"),
    new Game(new MastermindType(), "Mastermind")
};

ITerminator terminator = new Terminator();      //För tester
IIO iO = new IO();                              //För tester
IFilemanager filemanager = new Filemanager();   //För tester

IUI uI = new ConsoleUI(terminator, iO);
IDataAccess dataAccess = new DataAccess("scoreboard.txt", filemanager);
IGameController gameController = new GameController(uI, dataAccess);

LauncherController launcher = new(gameController, uI);
launcher.ChooseGameFromList(gameList);












