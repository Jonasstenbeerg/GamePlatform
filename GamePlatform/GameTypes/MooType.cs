using GamePlatform.Interfaces;

namespace GamePlatform.GameTypes
{
    internal class MooType : IGameType
    {
        public int ConfigureSetDigitsToGuess()
        {
            return Tools.Helpers.GetFourRandomNumbers(7, true);
        }
    }
}
