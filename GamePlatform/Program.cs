using GamePlatform.Controllers;
using GamePlatform.Data;
using GamePlatform.GameTypes;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;
using GamePlatform.Tools;

List<Game> games = new()
{
    new Game(new MooType(), "Moo"),
    new Game(new MastermindType(), "Mastermind")
};

ITerminator terminator = new Terminator();      //For unit testing
IIO iO = new IO();                              //For unit testing
IFilemanager filemanager = new Filemanager();   //For unit testing

IUI uI = new ConsoleUI(terminator, iO);
IDataAccess dataAccess = new DataAccess("scoreboard.txt", filemanager);
IGameController gameController = new GameController(uI, dataAccess);

LauncherController launcher = new(gameController, uI);
launcher.ChooseGameFromList(games);