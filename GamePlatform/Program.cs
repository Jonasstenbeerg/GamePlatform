using GamePlatform.Games;
using GamePlatform.Interfaces;

IUI ui = new ConsoleIO();

IDigitGuessGame guessGame = new MooGame();

GameController controller = new(ui, guessGame);

controller.RunGame();