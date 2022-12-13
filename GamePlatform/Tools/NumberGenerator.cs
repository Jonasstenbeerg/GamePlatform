namespace GamePlatform.Tools
{
    public class NumberGenerator
    {
        private readonly Random? _random;
        private readonly int _numberSpan;
        private readonly bool _isUnique;

        public NumberGenerator(int numberSpan, bool isUnique)
        {
            _random = new Random();
            _numberSpan = numberSpan;
            _isUnique = isUnique;
        }

        public string GetFourRandomNumbers()
        {

            string randomDigits = "";
            for (int i = 0; i < 4; i++)
            {
                randomDigits += _isUnique ?
                    GenerateUniqueNumbers(randomDigits) :
                    _random!.Next(_numberSpan);
            }
            return randomDigits;
        }

        private string GenerateUniqueNumbers(string currentNumbers)
        {
            int randomNumbers;
            do
            {
                randomNumbers = _random!.Next(_numberSpan);
            } while (currentNumbers.Contains(randomNumbers.ToString()));

            return randomNumbers.ToString();
        }


    }
}
