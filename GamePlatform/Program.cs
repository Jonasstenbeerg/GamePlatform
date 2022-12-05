using GamePlatform.Data;
using GamePlatform.Games;
using GamePlatform.Helpers;
using GamePlatform.Interfaces;

ITerminator terminator = new Terminator();
IIO iOHandler = new IO();
IDataAccess context = new DataAccess("scoreboard.txt");

IUI ui = new ConsoleUI(terminator, iOHandler);

IDigitGuessGame guessGame = new MooGame();

GameController controller = new(ui, guessGame, context);

controller.RunGame();

