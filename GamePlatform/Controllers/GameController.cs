using GamePlatform.Interfaces;

public class GameController
{
    private readonly IUI _ui;
    private readonly IDigitGuessGame _game;

    public GameController(IUI ui, IDigitGuessGame digitGuessGame)
    {
        _ui = ui;
        _game = digitGuessGame;
    }

    public void RunGame()
    {
        _game.RegisterPlayer(_ui);

        do
        {
            _game.SetupDigitsToGuess();
            _ui.PrintString("New game:\n");
            //_game.DisplayStringToGuess(_ui);

            do
            {
                _game.MakeGuess(_ui);
                _game.VerifyLastGuess(_ui);
            }
            while (_game.IsGuessWrong());
            
            _game.SaveGameResult();
            _game.PrintScoreboard(_ui);

        } while (_game.WantsToContinue(_ui));

        _ui.Exit();
    }
}
