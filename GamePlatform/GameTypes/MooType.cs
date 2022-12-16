using GamePlatform.Interfaces;
using GamePlatform.Models;
using GamePlatform.Tools;

namespace GamePlatform.GameTypes
{
    internal class MooType : IGameType
    {
        private readonly NumberGenerator _numberGenerator = new(10, true);

        public GuessResult FormatGuessResult(GuessResult result)
        {
            return result;
        }

        public string ConfigureSetDigitsToGuess()
        {
            return _numberGenerator.GetFourRandomNumbers();
        }
    }
}