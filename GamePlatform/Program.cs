IUI ui = new ConsoleIO();

IDigitGuessGame guessGame = new MooGame();

Gamecontroller controller = new Gamecontroller(ui, guessGame);

controller.RunGame();


public interface IUI
{
    public string GetString();
    public void PrintString(string input);
    void Exit();
}

class ConsoleIO : IUI
{
    public void Exit()
    {
        Environment.Exit(0);
    }

    public string GetString()
    {
        string? input;

        do
        {
            input = Console.ReadLine();

        } while (string.IsNullOrEmpty(input));
        return input!;
    }

    public void PrintString(string input)
    {
        Console.WriteLine(input);
    }
}

public class MooGame : IDigitGuessGame
{
    private string? _playerName;
    private int _guessCounter;
    private string? _digitsToGuess;
    private string? _currentGuess;
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
        _digitsToGuess= digits;
    }

    public void MakeGuess(IUI ui)
    {
        _guessCounter++;
        _currentGuess = ui.GetString();
       if(_guessCounter != 1) ui.PrintString($"{_currentGuess}\n");
    }

    public void PrintLastGuessResult(IUI ui)
    {
        int cows = 0;
        int bulls = 0;
        //_currentGuess += "    ";     // if player entered less than 4 chars
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < _currentGuess!.Length; j++)
            {
                if (_digitsToGuess![i] == _currentGuess[j])
                {
                    if (i == j)
                    {
                        bulls++;                // Jämför goal och guess och hittar rätt
                    }                           // gissningar baserat på indexplats och innehåll
                                                // adderar cow för rätt siffra fel index
                    else                        // adderar bulls för rätt siffra rätt index
                    {                           // returnerar antal bulls och cows i en sträng
                        cows++;
                    }
                }
            }
        }
        ui.PrintString("BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows)+"\n");
    }

    public void PrintScoreboard(IUI ui)
    {
        var scoreboard = GenerateScoreboard();
        ui.PrintString("Player   games average");

        foreach (PlayerData player in scoreboard)
        {
            ui.PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.GetAverageGuesses()));
        }
    }
    
    private List<PlayerData> GenerateScoreboard()
    {
        List<PlayerData> scoreboard = new();
        using (StreamReader reader = new("scoreboard.txt"))
        {
            while (!reader.EndOfStream)
            {
                string[] nameAndScore = reader.ReadLine()!.Split("#&#");
                string name = nameAndScore[0];
                int guesses = int.Parse(nameAndScore[1]);

                PlayerData playerToAdd = new(name, guesses);

                if (scoreboard.Any(player => player.Name == playerToAdd.Name))
                {                                                                                                 //Sorterar scoreboard på lägst average
                    scoreboard.Find(player => player.Name == playerToAdd.Name)!.Update(guesses);                  //guess och skriver ut den
                }
                else
                {
                    scoreboard.Add(playerToAdd);
                }
            }
        }
        return scoreboard.OrderBy(player => player.GetAverageGuesses()).ToList();
    }

    public void RegisterPlayer(IUI ui)
    {
        ui.PrintString("Enter your username: ");
        _playerName = ui.GetString();
    }

    public bool WantsToContinue(IUI uI)
    {
        uI.PrintString($"\nCorrect, it took {_guessCounter} guesses\nContinue?");
        return uI.GetString()[0] == 'n' ? false : true; 
        
    }

    public bool ISGuessWrong()
    {
        return _currentGuess != _digitsToGuess;
    }

    public void DisplayStringToGuess(IUI uI)
    {
        uI.PrintString($"For practice, number is: {_digitsToGuess}\n");
    }

    public void UpdateScoreboard()
    {
        using (StreamWriter writer = new("scoreboard.txt", append: true))
        {
            writer.WriteLine(_playerName + "#&#" + _guessCounter);
        }
    }
}

public class Gamecontroller
{
    private readonly IUI _ui;
    private readonly IDigitGuessGame _game;
    public Gamecontroller(IUI ui, IDigitGuessGame digitGuessGame)
    {
        _ui = ui;
        _game = digitGuessGame;
    }

    public void RunGame()
    {
        _game.RegisterPlayer(_ui);

        do
        {
            _game.SetupDigitsToGuess();
            _ui.PrintString("New game:\n");
            _game.DisplayStringToGuess(_ui);

            do
            {
                _game.MakeGuess(_ui);
                _game.PrintLastGuessResult(_ui);
            }
            while (_game.ISGuessWrong());
            
            _game.UpdateScoreboard();
            _game.PrintScoreboard(_ui);

        } while (_game.WantsToContinue(_ui));

        _ui.Exit();
    }
}

public interface IDigitGuessGame
{
    public void RegisterPlayer(IUI ui);

    public void SetupDigitsToGuess();

    public void MakeGuess(IUI ui);

    public bool ISGuessWrong();

    public void PrintLastGuessResult(IUI ui);

    public void PrintScoreboard(IUI ui);

    public void UpdateScoreboard();

    public bool WantsToContinue(IUI uI);

    public void DisplayStringToGuess(IUI uI);
}

class PlayerData
{
    public string Name { get; private set; }
    public int NumberOfGames { get; private set; }
    int totalGuess;

    public PlayerData(string name, int guesses)
    {
        this.Name = name;
        NumberOfGames = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        NumberOfGames++;
    }

    public double GetAverageGuesses()
    {
        return (double)totalGuess / NumberOfGames;
    }
}