using GamePlatform.Models;

namespace GamePlatform.Tools
{
    public static class PlayerExtensions
    {
        internal static List<PlayerData> GetDistinctPlayersForEachGame(this IEnumerable<PlayerData> players)
        {
            List<PlayerData> distinctPlayersByGame = players
                .GroupBy(player => new { player.Name, player.CurrentGameTitle })
                .Select(grp =>
                    new PlayerData()
                    {
                        Name = grp.Key.Name,
                        CurrentGameTitle = grp.Key.CurrentGameTitle,
                        TotalGuesses = grp.Sum(p => p.TotalGuesses),
                        NumberOfGames = grp.Sum(p => p.NumberOfGames)
                    })
                .ToList();

            return distinctPlayersByGame;
        }

        internal static PlayerData ParsePlayerDataFromString(string line, string separator)
        {
            string[] playerStats = line.Split(separator);

            PlayerData player = new()
            {
                Name = playerStats[0],
                TotalGuesses = int.Parse(playerStats[1]),
                CurrentGameTitle = playerStats[2]
            };

            return player;
        }
    }
}