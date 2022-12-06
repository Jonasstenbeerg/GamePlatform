﻿using GamePlatform.Data;
using GamePlatform.Games;
using GamePlatform.Helpers;
using GamePlatform.Interfaces;

ITerminator terminator = new Terminator();
IIO iOHandler = new IO();
IFilemanager filemanager = new Filemanager();

IDataAccess context = new DataAccess("scoreboard.txt",filemanager);

IUI ui = new ConsoleUI(terminator, iOHandler);

IDigitGuessGame guessGame = new MooGame();

GameController controller = new(ui, guessGame, context);

controller.RunGame();

