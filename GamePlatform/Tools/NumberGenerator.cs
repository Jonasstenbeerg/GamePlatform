using GamePlatform.Interfaces;

namespace GamePlatform.Tools
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly Random? _random;
        private readonly int _maxValue;
        private readonly bool _isUniqueDigits;

        public NumberGenerator(int maxValue, bool isUniqueDigits)
        {
            _random = new Random();
            _maxValue = maxValue;
            _isUniqueDigits = isUniqueDigits;
        }

        public string GetRandomDigits()
        {
            string randomDigits = "";

            for (int i = 0; i < 4; i++)
            {
                randomDigits += _isUniqueDigits ?
                    GenerateUniqueDigits(randomDigits) :
                    _random!.Next(_maxValue);
            }

            return randomDigits;
        }

        private string GenerateUniqueDigits(string currentDigits)
        {
            string digits;

            do
            {
                digits = _random!.Next(_maxValue).ToString();
            } while (currentDigits.Contains(digits));

            return digits;
        }
    }
}