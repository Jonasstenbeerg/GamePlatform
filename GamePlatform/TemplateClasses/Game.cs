using GamePlatform.Interfaces;

namespace GamePlatform.TemplateClasses
{
    public class Game : IDigitGuessGame
    {
        public int GuessCounter { get; private set; }
        public string? PlayerName { get; private set; }
        public string? CurrentGuess { get; private set; }
        public string? DigitsToGuess { get; private set; }

        private IGameType _gameType;

        public Game(IGameType gameType)
        {
            _gameType = gameType;
        }

        public void SetPlayerName(string? playerName)
        {
            PlayerName = playerName!.Trim();
        }

        public void SetCurrentGuess(string? guess)
        {
            CurrentGuess = guess!.Trim();
        }

        public void SetDigitsToGuess()
        {
            DigitsToGuess = _gameType.ConfigureSetDigitsToGuess();
        }

        public void IncrementGuessCounter()
        {
            GuessCounter++;
        }

        public void ResetGuessCounter()
        {
            GuessCounter = 0;
        }

        public string GetGuessResult()
        {
            string cows = "";
            string bulls = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < CurrentGuess!.Length; j++)
                {
                    if (DigitsToGuess![i] == CurrentGuess[j])
                    {
                        if (i == j)
                        {
                            bulls += 'B';           // Jämför goal och guess och hittar rätt
                        }                           // gissningar baserat på indexplats och innehåll
                                                    // adderar cow för rätt siffra fel index
                        else                        // adderar bulls för rätt siffra rätt index
                        {                           // returnerar antal bulls och cows i en sträng
                            cows += 'C';
                        }
                    }
                }
            }
            return $"{bulls},{cows}";
        }
    }
}