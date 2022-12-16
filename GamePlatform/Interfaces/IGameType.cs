using GamePlatform.Models;

namespace GamePlatform.Interfaces
{
    public interface IGameType
    {
        public string ConfigureSetDigitsToGuess();
        public GuessResult FormatGuessResult(GuessResult result);
    }
}