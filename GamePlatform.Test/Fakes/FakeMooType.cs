using GamePlatform.Interfaces;
using GamePlatform.Models;

namespace GamePlatform.Test.Fakes
{
    public class FakeMooType : IGameType
    {
        private readonly string _digitsToGuess;

        public FakeMooType(string digitsToGuess)
        {
            _digitsToGuess = digitsToGuess;
        }

        public GuessResultData FormatGuessResult(GuessResultData result)
        {
            return result;
        }

        public string ConfigureSetDigitsToGuess()
        {
            return _digitsToGuess;
        }
    }
}