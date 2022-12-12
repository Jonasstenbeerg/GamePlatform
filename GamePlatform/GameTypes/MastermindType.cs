﻿using GamePlatform.Interfaces;
using GamePlatform.Helpers;
using GamePlatform.Tools;

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
