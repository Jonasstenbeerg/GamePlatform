namespace GamePlatform.Models
{
    public class PlayerData
    {
        public string? Name { get; set; }
        public int NumberOfGames { get; set; }
        public int TotalGuesses { get; set; }
        public string? CurrentGameTitle { get; set; }
        public double AverageGuesses { get { return (double)TotalGuesses / NumberOfGames; } }

        public PlayerData()
        {
            NumberOfGames = 1;
        }
    }
}