namespace GamePlatform.Tools
{
    public static class PlayerExtensions
    {
        internal static List<Player> GetDistinctPlayersForEachGame(this IEnumerable<Player> players)
        {
            List<Player> distinctPlayersByGame = players
                .GroupBy(player => new { player.Name, player.CurrentGameTitle })
                .Select(grp =>
                    new Player()
                    {
                        Name = grp.Key.Name,
                        CurrentGameTitle = grp.Key.CurrentGameTitle,
                        TotalGuesses = grp.Sum(p => p.TotalGuesses),
                        NumberOfGames = grp.Sum(p => p.NumberOfGames)
                    })
                .ToList();

            return distinctPlayersByGame;
        }

        internal static Player ParsePlayerDataFromString(string line, string separator)
        {
            string[] playerStats = line.Split(separator);

            Player player = new Player()
            {
                Name = playerStats[0],
                TotalGuesses = int.Parse(playerStats[1]),
                CurrentGameTitle = playerStats[2]
            };
            return player;
        }
    }
}
