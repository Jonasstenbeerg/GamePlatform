﻿namespace GamePlatform.Models
{
    public class GuessResultData
    {
        public int BullsCounter { get; private set; }
        public int CowCounter { get; private set; }

        public GuessResultData(int bullsCounter, int cowCounter)
        {
            BullsCounter = bullsCounter;
            CowCounter = cowCounter;
        }

        public override string ToString()
        {
            return $"{GetGivenCharMultiplied('B', BullsCounter)},{GetGivenCharMultiplied('C', CowCounter)}";
        }

        private static string GetGivenCharMultiplied(char givenChar, int times)
        {
            return new string(givenChar, times);
        }
    }
}