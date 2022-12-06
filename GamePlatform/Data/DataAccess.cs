using GamePlatform.Interfaces;

namespace GamePlatform.Data
{
    public class DataAccess : IDataAccess
    {
        private string _filePath;
        private const string _separator = "#&#";
        private IFilemanager _fileManager;
        public DataAccess(string filePath, IFilemanager filemanager)
        {
            _filePath = filePath;
            _fileManager = filemanager;
        }

        public Player GetPlayerOnName(string name)
        {
            var allPlayers = GetAllPlayers();

            return allPlayers.FirstOrDefault(player => player.Name == name);
        }
        public List<Player> GetAllPlayers()
        {
            List<Player> players = new();
            using (StreamReader reader = _fileManager.StreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine()!;
                    Player player = ParsePlayerDataFromString(line);
                    players.Add(player);
                }
            }
            return players;
        }

        private Player ParsePlayerDataFromString(string line)
        {
            string[] playerStats = line.Split(_separator);

            Player player = new Player()
            {
                Name = playerStats[0],
                TotalGuesses = int.Parse(playerStats[1]),
                //NumberOfGames = int.Parse(playerStats[2]),
                //AverageGuesses = double.Parse(playerStats[3]),
            };
            return player;
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
            using (StreamWriter writer = new(_filePath, append: false))
            {
                foreach (var player in players)
                {
                    writer.WriteLine(player.Name + _separator
                        + player.TotalGuesses + _separator
                        + player.NumberOfGames + _separator
                        + player.AverageGuesses);
                }
            };
        }

    }
}
