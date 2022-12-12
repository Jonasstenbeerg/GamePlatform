using GamePlatform.Interfaces;
using GamePlatform.Models;

namespace GamePlatform.GamesTypes
{
    internal class MooType : IGameType
    {
        public GuessResult ConfigureFormatGuessResult(GuessResult result)
        {
            return result;
        }

        public int ConfigureSetDigitsToGuess()
        {
            return Tools.Helpers.GetFourRandomNumbers(7, true);
        }
    }
}
