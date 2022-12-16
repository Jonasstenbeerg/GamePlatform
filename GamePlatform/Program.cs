using GamePlatform.Controllers;
using GamePlatform.Data;
using GamePlatform.GameTypes;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;
using GamePlatform.Tools;

INumberGenerator MooNumberGenerator = new NumberGenerator(10, true);
INumberGenerator MastermindNumberGenerator = new NumberGenerator(7, false);

List<IDigitGuessGame> games = new()
{
    new Game(new MooType(MooNumberGenerator), "Moo"),
    new Game(new MastermindType(MastermindNumberGenerator), "Mastermind")
};

ITerminator terminator = new Terminator();      //For unit testing
IIO iO = new IO();                              //For unit testing
IFileManager filemanager = new FileManager();   //For unit testing

IUI uI = new ConsoleUI(terminator, iO);
IDataAccess dataAccess = new DataAccess("scoreboard.txt", filemanager);
IGameController gameController = new GameController(uI, dataAccess);

LauncherController launcher = new(gameController, uI);
launcher.ChooseGameFromList(games);