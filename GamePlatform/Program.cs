
bool playOn = true;
Console.WriteLine("Enter your username:\n");
string name = Console.ReadLine();

while (playOn)
{
    string goal = makeGoal();

    Console.WriteLine("New game:\n");
    //comment out or remove next line to play real games!
    Console.WriteLine("For practice, number is: " + goal + "\n");
    string guess = Console.ReadLine();

    int nGuess = 1;
    string bbcc = checkBC(goal, guess);
    Console.WriteLine(bbcc + "\n");
    while (bbcc != "BBBB,")
    {
        nGuess++;
        guess = Console.ReadLine();
        Console.WriteLine(guess + "\n");
        bbcc = checkBC(goal, guess);
        Console.WriteLine(bbcc + "\n");
    }
    StreamWriter output = new StreamWriter("result.txt", append: true);
    output.WriteLine(name + "#&#" + nGuess);
    output.Close();
    showTopList();
    Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
    string answer = Console.ReadLine();
    if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
    {
        playOn = false;
    }
}

static string makeGoal()
{
    Random randomGenerator = new Random();
    string goal = "";
    for (int i = 0; i < 4; i++)
    {
        int random = randomGenerator.Next(10);
        string randomDigit = "" + random;
        while (goal.Contains(randomDigit))              //Slumpar fram 4 unika siffror mellan 0 och 9
        {
            random = randomGenerator.Next(10);
            randomDigit = "" + random;
        }
        goal = goal + randomDigit;
    }
    return goal;
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

static void showTopList() // vill skriva ut player name, nr of game, average guesses
{
    StreamReader input = new StreamReader("result.txt");
    List<PlayerData> results = new List<PlayerData>();
    string line;
    while ((line = input.ReadLine()) != null)
    {
        string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None); // Förenkla split genom bara Split("#&#")
        string name = nameAndScore[0];
        int guesses = Convert.ToInt32(nameAndScore[1]);
        PlayerData pd = new PlayerData(name, guesses);
        int pos = results.IndexOf(pd);
        if (pos < 0)
        {
            results.Add(pd);                                            //Sorterar scoreboard på lägst average
                                                                        //guess och skriver ut den
        }
        else
        {
            results[pos].Update(guesses);
        }
    }
    results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
    Console.WriteLine("Player   games average");
    foreach (PlayerData p in results)
    {
        Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
    }
    input.Close();
}


class PlayerData
{
    public string Name { get; private set; }
    public int NGames { get; private set; }
    int totalGuess;

    public PlayerData(string name, int guesses)
    {
        this.Name = name;
        NGames = 1;
        totalGuess = guesses;
    }

    public void Update(int guesses)
    {
        totalGuess += guesses;
        NGames++;
    }

    public double Average()
    {
        return (double)totalGuess / NGames;
    }

    public override bool Equals(Object p)
    {
        return Name.Equals(((PlayerData)p).Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}
