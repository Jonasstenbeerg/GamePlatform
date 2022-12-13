using GamePlatform.Interfaces;
using GamePlatform.Tools;
using GamePlatform.Models;

namespace GamePlatform.GameTypes
{
    internal class MastermindType : IGameType
    {
        private NumberGenerator _numberGenerator = new(7, false);

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

        public string ConfigureSetDigitsToGuess()
        {
            return _numberGenerator.GetFourRandomNumbers();
        }
    }
}
