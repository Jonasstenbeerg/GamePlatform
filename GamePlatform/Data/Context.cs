namespace GamePlatform.Data
{
    sealed class Context
    {
        private static Context? instance;
        private Context() 
        {
            
        }

        public static Context? GetInstance()
        {
            if (instance == null)
            {
                instance = new Context();
            }
            return instance;
        }

        public List<PlayerData> GetScoreboard()
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

        public void UpdateScoreboard(string playerName, int guessCounter)
        {
            using StreamWriter writer = new("scoreboard.txt", append: true);
            writer.WriteLine(playerName + "#&#" + guessCounter);
        }
    }
}
