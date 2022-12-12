using GamePlatform.Interfaces;
using GamePlatform.Helpers;
using GamePlatform.Tools;
using GamePlatform.Models;

namespace GamePlatform.Games
{
    internal class MastermindType : IGameType
    {
        public GuessResult ConfigureFormatGuessResult(GuessResult result)
        {
            if (result.CowCounter + result.BullsCounter > 4)
            {
                int cowsToRemove = (result.CowCounter + result.BullsCounter) - 4;
                result = new GuessResult(result.CowCounter-cowsToRemove,result.BullsCounter);
            }

            return result;
        }

        public int ConfigureSetDigitsToGuess()
        {
            return Tools.Helpers.GetFourRandomNumbers(7);
        }
    }
}
