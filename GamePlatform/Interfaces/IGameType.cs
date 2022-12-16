using GamePlatform.Models;

namespace GamePlatform.Interfaces
{
    public interface IGameType
    {
        public string ConfigureSetDigitsToGuess();
         public GuessResultData FormatGuessResult(GuessResultData result);
    }
}