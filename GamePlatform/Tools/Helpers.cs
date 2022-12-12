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

        private static string GenerateUniqueNumbers(int numberspan, string currentNumbers)
        {
            int random;
            do
            {
                random = _random.Next(numberspan);
            } while (currentNumbers.Contains(random.ToString()));

            return random.ToString();
        }

        public static string GuessResultToString(GuessResult guessResult)
        {
            return $"{MultiplyGivenChar('C', guessResult.CowCounter)},{MultiplyGivenChar('B', guessResult.BullsCounter)}";
        }
        private static string MultiplyGivenChar(char givenChar,int times)
        {
            return new string(givenChar, times);
        }
    }
}
