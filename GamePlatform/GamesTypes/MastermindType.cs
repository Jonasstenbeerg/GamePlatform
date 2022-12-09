using GamePlatform.Interfaces;

namespace GamePlatform.Games
{
    internal class MastermindType : IGameType
    {
        public string ConfigureSetDigitsToGuess()
        {
            Random randomGenerator = new();
            string digits = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(7);
               
                digits += random;
            }
            return digits;
        }
    }
}
