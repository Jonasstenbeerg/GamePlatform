using GamePlatform.Models;
namespace GamePlatform.Tools
{
    public static class Helpers
    {
        private static Random _random = new();
        
        public static int GetFourRandomNumbers(int numberSpan, bool isUnique = false)
        {
            
            string randomDigits = "";
            for (int i = 0; i < 4; i++)
            {
                randomDigits += isUnique ? 
                    GenerateUniqueNumbers(numberSpan,randomDigits) : 
                    _random.Next(numberSpan).ToString();
            }
            return int.Parse(randomDigits);
        }

        private static string GenerateUniqueNumbers(int numberSpan, string currentNumbers)
        {
            int randomNumbers;
            do
            {
                randomNumbers = _random.Next(numberSpan);
            } while (currentNumbers.Contains(randomNumbers.ToString()));

            return randomNumbers.ToString();
        }

        public static string GuessResultToString(GuessResult guessResult)
        {
            return $"{GetGivenCharMultiplied('C', guessResult.CowCounter)},{GetGivenCharMultiplied('B', guessResult.BullsCounter)}";
        }
        private static string GetGivenCharMultiplied(char givenChar,int times)
        {
            return new string(givenChar, times);
        }
    }
}
