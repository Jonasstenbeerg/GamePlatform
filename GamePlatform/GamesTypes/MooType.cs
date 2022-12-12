using GamePlatform.Interfaces;

namespace GamePlatform.GamesTypes
{
    internal class MooType : IGameType
    {
        public int ConfigureSetDigitsToGuess()
        {
            return Tools.Helpers.GetFourRandomNumbers(7, true);
        }
    }
}
