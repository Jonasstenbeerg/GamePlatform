using GamePlatform.Data;
using GamePlatform.Games;
using GamePlatform.GamesTypes;
using GamePlatform.Helpers;
using GamePlatform.Interfaces;
using GamePlatform.TemplateClasses;

ITerminator terminator = new Terminator();
IIO iOHandler = new IO();
IFilemanager filemanager = new Filemanager();

IDataAccess context = new DataAccess("scoreboard.txt",filemanager);

IUI ui = new ConsoleUI(terminator, iOHandler);

Game guessGame = new Game(new MastermindGame());

GameController controller = new(ui, guessGame, context);

controller.RunGame();

