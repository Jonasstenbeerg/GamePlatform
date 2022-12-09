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
                TotalGuesses = int.Parse(playerStats[1])

            };
            return player;
        }

        public void SavePlayer(Player player)
        {
            using (StreamWriter writer = _fileManager.StreamWriter(_filePath))
            {
                writer.WriteLine(player.Name + _separator + player.TotalGuesses);
            };
        }
    }
}
