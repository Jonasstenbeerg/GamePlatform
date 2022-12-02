namespace GamePlatform.Data
{
    sealed class Context : IContext
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

        public Player GetPlayerOnName(string name)
        {
            var allPlayers = GetAllPlayers();

            return allPlayers.FirstOrDefault(player => player.Name == name);
        }
        public List<Player> GetAllPlayers()
        {
            List<Player> players = new();
            using (StreamReader reader = new("scoreboard.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] playerStats = reader.ReadLine()!.Split("#&#");
                    
                    Player player = new Player()
                    {
                        Name = playerStats[0],
                        TotalGuesses = int.Parse(playerStats[1]),
                        NumberOfGames = int.Parse(playerStats[2]),
                        AverageGuesses= double.Parse(playerStats[3]),
                    };
                    players.Add(player);
                }
            }
            return players;
        }
        public void PostPlayer(string playername) 
        {
            var allPlayers = GetAllPlayers();
            allPlayers.Add(new Player() { Name = playername });
            SavePlayers(allPlayers);
        }
        public void PutPlayer(Player _player) 
        {
            var allPlayers = GetAllPlayers();

            foreach (var player in allPlayers)
            {
                if (player.Name == _player.Name)
                {
                    player.TotalGuesses += _player.TotalGuesses;
                    player.NumberOfGames++;
                    player.AverageGuesses = (double)player.TotalGuesses / player.NumberOfGames;
                }
            }
            SavePlayers(allPlayers);
        }
        private void SavePlayers(List<Player> players)
        {
            using (StreamWriter writer = new("scoreboard.txt", append: false))
            {
                foreach (var player in players)
                {
                    writer.WriteLine(player.Name + "#&#" + player.TotalGuesses + "#&#" + player.NumberOfGames + "#&#" + player.AverageGuesses);
                }
            };
            
        }
    }
}
