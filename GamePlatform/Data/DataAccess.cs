using GamePlatform.Interfaces;
using GamePlatform.Tools;

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
                    Player player = PlayerExtensions.ParsePlayerDataFromString(line,_separator);
                    players.Add(player);
                }
            }
            return players;
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
