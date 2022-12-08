using GamePlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Games
{
    internal class MastermindGame : IGameType
    {
        public string ConfigureSetupDigitsToGuess()
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
