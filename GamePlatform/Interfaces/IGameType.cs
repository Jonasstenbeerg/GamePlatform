using GamePlatform.Models;

namespace GamePlatform.Interfaces
{
    public interface IGameType
    {
        public string ConfigureSetDigitsToGuess();
        public GuessResult ConfigureFormatGuessResult(GuessResult result);
    }
}
