using GamePlatform.Games;
using GamePlatform.Interfaces;
using static System.Net.Mime.MediaTypeNames;

IUI ui = new ConsoleIO();

IDigitGuessGame guessGame = new MooGame();

GameController controller = new(ui, guessGame);

controller.RunGame();

