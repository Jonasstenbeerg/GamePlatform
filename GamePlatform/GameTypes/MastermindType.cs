using GamePlatform.Interfaces;
using GamePlatform.Models;

namespace GamePlatform.GameTypes
{
    internal class MastermindType : IGameType
    {
        private readonly INumberGenerator _numberGenerator;

        public MastermindType(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }
    
        public GuessResultData FormatGuessResult(GuessResultData result)
        {
            const int MaxBullsAndCows = 4;

            if (result.CowCounter + result.BullsCounter > MaxBullsAndCows)
            {
                int cowsToRemove = (result.CowCounter + result.BullsCounter) - MaxBullsAndCows;
                result = new GuessResultData(result.CowCounter - cowsToRemove, result.BullsCounter);
            }

            return result;
        }

        public string ConfigureSetDigitsToGuess()
        {
            return _numberGenerator.GetRandomDigits();
        }
    }
}