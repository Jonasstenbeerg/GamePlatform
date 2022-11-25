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

    int nGuess = 1;
    string bbcc = checkBC(digitsToGuess, guess);
    ui.PrintString($"{bbcc}  \n");
    while (bbcc != "BBBB,")
    {
        nGuess++;
        guess = ui.GetString();
        ui.PrintString(guess + "\n");
        bbcc = checkBC(digitsToGuess, guess);
        ui.PrintString(bbcc + "\n");
    }

    using (StreamWriter writer = new("scoreboard.txt", append: true))
    {
        writer.WriteLine(playerName + "#&#" + nGuess);
    }

    PrintScoreboard(ui);
    ui.PrintString($"\nCorrect, it took {nGuess} guesses\nContinue?");
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



static string checkBC(string goal, string guess)
{
    int cows = 0, bulls = 0;
    guess += "    ";     // if player entered less than 4 chars
    for (int i = 0; i < 4; i++)
    {
        for (int j = 0; j < 4; j++)
        {
            if (goal[i] == guess[j])
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
    return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
}

static void PrintScoreboard(IUI ui) // vill skriva ut player name, nr of game, average guesses
{
    var scoreboard = GenerateScoreboard();
    ui.PrintString("Player   games average");

    foreach (PlayerData player in scoreboard)
    {
        ui.PrintString(string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumberOfGames, player.Average()));
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
            int guesses = Convert.ToInt32(nameAndScore[1]);

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
    scoreboard.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
    return scoreboard;
}

interface IUI
{
    public string GetString();
    public void PrintString(string input);
    void Exit();
    void Clear();
}

class ConsoleIO : IUI
{
    public void Clear()
    {
        throw new NotImplementedException();
    }
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

    public double Average()
    {
        return (double)totalGuess / NumberOfGames;
    }
}
