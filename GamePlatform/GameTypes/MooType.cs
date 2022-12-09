using GamePlatform.Interfaces;

namespace GamePlatform.GameTypes
{
    internal class MooType : IGameType
    {
        public string ConfigureSetDigitsToGuess()
        {
            Random randomGenerator = new();
            string digits = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                while (digits.Contains(random.ToString()))
                {
                    random = randomGenerator.Next(10);

                }
                digits += random;
            }
            return digits;
        }
    }
}
