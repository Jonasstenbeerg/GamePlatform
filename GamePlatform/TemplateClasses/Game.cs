using GamePlatform.Interfaces;
using GamePlatform.Models;

namespace GamePlatform.TemplateClasses
{
    public class Game : IDigitGuessGame
    {
        public int GuessCounter { get; private set; }
        public string GameTitle { get; private set; }
        public string? PlayerName { get; private set; }
        public int CurrentGuess { get; private set; }
        public int DigitsToGuess { get; private set; }

        private IGameType _gameType;

        public Game(IGameType gameType, string gameTitle)
        {
            _gameType = gameType;
            GameTitle = gameTitle;
        }

        public void SetPlayerName(string? playerName)
        {
            PlayerName = playerName!.Trim();
        }

        public void SetCurrentGuess(int digitGuess)
        {
            CurrentGuess = digitGuess;
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

        public GuessResult GetGuessResult()
        {
            int cows = 0;
            int bulls = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < CurrentGuess.ToString().Length; j++)
                {
                    if (DigitsToGuess.ToString()[i] == CurrentGuess.ToString()[j])
                    {
                        if (i == j)
                        {
                            bulls++;
                        }

                        else
                        {
                            cows++;
                        }
                    }
                }
            }
            GuessResult result = _gameType.ConfigureFormatGuessResult(new GuessResult(cows,bulls));

            return result;
        }

    }
}