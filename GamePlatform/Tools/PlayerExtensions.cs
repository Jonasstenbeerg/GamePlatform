namespace GamePlatform.Tools
{
    public static class PlayerExtensions
    {
        internal static List<Player> GetDistinctPlayers(this IEnumerable<Player> players)
        {
            List<Player> distinctPlayers = new();
            foreach (Player player in players)
            {
                Player? distinctPlayer = distinctPlayers.FirstOrDefault(p => p.Name == player.Name);

                if (distinctPlayer == null)
                {
                    distinctPlayers.Add(player);
                }
                else
                {
                    distinctPlayer?.IncrementStats(player.TotalGuesses);
                }
            }

            return distinctPlayers;
        }

        internal static Player ParsePlayerDataFromString(string line,string separator)
        {
            string[] playerStats = line.Split(separator);

            Player player = new Player()
            {
                Name = playerStats[0],
                TotalGuesses = int.Parse(playerStats[1])

            };
            return player;
        }
    }
}
