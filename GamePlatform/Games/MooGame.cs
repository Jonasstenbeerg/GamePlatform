using GamePlatform.Data;
using GamePlatform.Interfaces;

namespace GamePlatform.Games
{
    public class MooGame : IDigitGuessGame
    {
        private string? _playerName;
        private int _guessCounter;
        private string? _digitsToGuess;
        private string? _currentGuess;
        private readonly Context? _context;
        public MooGame()
        {
            _context = Context.GetInstance();
        }

        public void SetupDigitsToGuess()
        {
            Random randomGenerator = new();
            string digits = "";
            for (int i = 0; i < 4; i++)
            {
                int random = randomGenerator.Next(10);
                while (digits.Contains(random.ToString()))    //Slumpar fram 4 unika siffror mellan 0 och 9
                {
                    random = randomGenerator.Next(10);        //Skapa en ytterligare funktion som adderar random unique number?
                                                              //Private används bara till Moo, ingår inte i Interface
                }
                digits += random;
            }
            _digitsToGuess = digits;
        }

        public void MakeGuess(IUI ui)
        {
            _guessCounter++;
            _currentGuess = ui.GetString();
            if (_guessCounter != 1) ui.PrintString($"{_currentGuess}\n");
        }

        public void VerifyLastGuess(IUI ui)
        {
            string cows = "";
            string bulls = "";

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < _currentGuess!.Length; j++)
                {
                    if (_digitsToGuess![i] == _currentGuess[j])
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
            ui.PrintString($"{bulls},{cows}");
        }

        public void PrintScoreboard(IUI ui)
        {
            var scoreboard = _context!.GetScoreboard();
            ui.PrintString("Player   Games Average");

            foreach (PlayerData player in scoreboard)
            {
                ui.PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", 
                    player.Name, 
                    player.NumberOfGames, 
                    player.GetAverageGuesses()));
            }
        }

        public void SaveGameResult()
        {
            _context!.UpdateScoreboard(_playerName!, _guessCounter);
        }

        public void RegisterPlayer(IUI ui)
        {
            ui.PrintString("Enter your username: ");
            _playerName = ui.GetString();
        }

        public bool WantsToContinue(IUI uI)
        {
            uI.PrintString($"\nCorrect, it took {_guessCounter} guesses\nContinue?");
            return uI.GetString()[0] != 'n';
        }

        public bool IsGuessWrong()
        {
            return _currentGuess != _digitsToGuess;
        }

        public void DisplayStringToGuess(IUI uI)
        {
            uI.PrintString($"For practice, number is: {_digitsToGuess}\n");
        }
    }
}