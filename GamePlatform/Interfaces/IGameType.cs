using GamePlatform.Models;

namespace GamePlatform.Interfaces
{
    public interface IGameType
    {
        public int ConfigureSetDigitsToGuess();

        public GuessResult ConfigureFormatGuessResult(GuessResult result);
    }
}
