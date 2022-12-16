using GamePlatform.Interfaces;
using GamePlatform.Models;
using GamePlatform.Tools;

namespace GamePlatform.GameTypes
{
    internal class MooType : IGameType
    {
        private readonly INumberGenerator _numberGenerator;

        public MooType(INumberGenerator numberGenerator)
        {
            _numberGenerator = numberGenerator;
        }
    
        public GuessResultData FormatGuessResult(GuessResultData result)
        {
            return result;
        }

        public string ConfigureSetDigitsToGuess()
        {
            return _numberGenerator.GetRandomDigits();
        }
    }
}