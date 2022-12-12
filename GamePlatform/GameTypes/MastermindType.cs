using GamePlatform.Interfaces;

namespace GamePlatform.GameTypes
{
    internal class MastermindType : IGameType
    {
        public int ConfigureSetDigitsToGuess()
        {
            return Tools.Helpers.GetFourRandomNumbers(7);
        }
    }
}
