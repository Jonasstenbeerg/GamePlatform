namespace GamePlatform.Models
{
    public class GuessResult
    {
        public int CowCounter { get; private set; }
        public int BullsCounter { get; private set; }
        public GuessResult(int cowCounter, int bullsCounter)
        {
            CowCounter = cowCounter;
            BullsCounter = bullsCounter;
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