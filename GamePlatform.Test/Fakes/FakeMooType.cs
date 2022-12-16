using GamePlatform.Interfaces;
using GamePlatform.Models;

namespace GamePlatform.Test.Fakes
{
    internal class FakeMooType : IGameType
    {
        private readonly string _digitsToGuess;

        public FakeMooType(string digitsToGuess)
        {
            _digitsToGuess = digitsToGuess;
        }

        public GuessResult FormatGuessResult(GuessResult result)
        {
            return result;
        }

        public string ConfigureSetDigitsToGuess()
        {
            return _digitsToGuess;
        }
    }
}