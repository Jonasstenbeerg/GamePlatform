using GamePlatform.Games;
using GamePlatform.Helpers;
using GamePlatform.Interfaces;
using static System.Net.Mime.MediaTypeNames;

ITerminator terminator = new Terminator();
IIO iOHandler = new IO();

IUI ui = new ConsoleUI(terminator,iOHandler);

IDigitGuessGame guessGame = new MooGame();

GameController controller = new(ui, guessGame);

controller.RunGame();

