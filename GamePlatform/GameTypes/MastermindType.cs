using GamePlatform.Interfaces;
using GamePlatform.Tools;
using GamePlatform.Models;

namespace GamePlatform.GameTypes
{
    internal class MastermindType : IGameType
    {
        public GuessResult ConfigureFormatGuessResult(GuessResult result)
        {
            const int MaxBullsAndCows = 4;
            if (result.CowCounter + result.BullsCounter > MaxBullsAndCows)
            {
                int cowsToRemove = (result.CowCounter + result.BullsCounter) - MaxBullsAndCows;
                result = new GuessResult(result.CowCounter-cowsToRemove,result.BullsCounter);
            }

            return result;
        }

        public int ConfigureSetDigitsToGuess()
        {
            return Helpers.GetFourRandomNumbers(7);
        }
    }
}
