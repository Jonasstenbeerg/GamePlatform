IUI ui = new ConsoleIO();

ui.PrintString("Enter your username: ");
string playerName = ui.GetString();

while (true)
{
    string digitsToGuess = GetDigits();

    ui.PrintString("New game:\n");
    //comment out or remove next line to play real games!
    ui.PrintString($"For practice, number is: {digitsToGuess}\n");
    string guess = ui.GetString();

    int guessCounter = 1;
    string guessResult = GetGuessResult(digitsToGuess, guess);
    ui.PrintString($"{guessResult}  \n");
    while (guess != digitsToGuess)
    {
        guessCounter++;
        guess = ui.GetString();
        ui.PrintString(guess + "\n");
        guessResult = GetGuessResult(digitsToGuess, guess);
        ui.PrintString(guessResult + "\n");
    }

    using (StreamWriter writer = new("scoreboard.txt", append: true))
    {
        writer.WriteLine(playerName + "#&#" + guessCounter);
    }

    PrintScoreboard(ui);
    ui.PrintString($"\nCorrect, it took {guessCounter} guesses\nContinue?");
    string answer = ui.GetString();
    if (answer[0] == 'n')
    {
        ui.Exit();
    }
}

static string GetDigits() //Fråga sebastian om GetDigitsToGuess blir för långt? En eller två metoder?
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
    return digits;
}

static string GetGuessResult(string digitsToGuess, string guess)
{
    string cows = ""; 
    string bulls = "";
    guess += "    ";     // if player entered less than 4 chars
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (digitsToGuess[i] == guess[j])
            {
                if (i == j)
                {
                    bulls += 'B';                // Jämför goal och guess och hittar rätt
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

static void PrintScoreboard(IUI ui) // vill skriva ut player name, nr of game, average guesses
{
    var scoreboard = GenerateScoreboard();
    ui.PrintString("Player   games average");

    foreach (PlayerData player in scoreboard)
    {
        ui.PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.GetAverageGuesses()));
    }
}

static List<PlayerData> GenerateScoreboard()
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

interface IUI
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