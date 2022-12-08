using GamePlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.GamesTypes
{
    internal class MooGame : IGameType
    {
        public string ConfigureSetupDigitsToGuess()
        {
            Random randomGenerator = new();
            string digits = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                while (digits.Contains(random.ToString()))    //Slumpar fram 4 unika siffror mellan 0 och 9
                {
                    random = randomGenerator.Next(10);        //Skapa en ytterligare funktion som adderar random unique number?
                                                              //Private används bara till Moo, ingår inte i Interface
                }
                digits += random;
            }
            return digits;
        }
    }
}
