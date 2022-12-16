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
            string randomNumbers = "";

            for (int i = 0; i < 4; i++)
            {
                randomNumbers += _isUnique ?
                    GenerateUniqueNumbers(randomNumbers) :
                    _random!.Next(_numberSpan);
            }

            return randomNumbers;
        }

        private string GenerateUniqueNumbers(string currentNumbers)
        {
            string numbers;

            do
            {
                numbers = _random!.Next(_numberSpan).ToString();
            } while (currentNumbers.Contains(numbers));

            return numbers;
        }
    }
}