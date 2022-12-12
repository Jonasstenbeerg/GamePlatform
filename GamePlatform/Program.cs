using GamePlatform.Controllers;
using GamePlatform.GameTypes;
using GamePlatform.TemplateClasses;

List<Game> gameList = new()
{
    new Game(new MooType(), "Moo"),
    new Game(new MastermindType(), "Mastermind")
};

LauncherController launcher = new();
launcher.ChooseGame(gameList);












