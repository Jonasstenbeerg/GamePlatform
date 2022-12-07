public class Player
{
    public string? Name { get; set; }
    public int NumberOfGames { get; set; }
    public int TotalGuesses { get; set; }
    public double AverageGuesses { get { return (double)TotalGuesses / NumberOfGames; }}

    public Player()
    {
        NumberOfGames = 1;      
    }

    public Player(string name, int numberOfGuesses)
    {
        Name = name;
        NumberOfGames = numberOfGuesses;
        NumberOfGames = 1;
    }
    public void IncrementStats(int totalGuesses, int numberOfGames)
    {
        TotalGuesses += totalGuesses;
        NumberOfGames += numberOfGames;
    }
}