using GamePlatform.Interfaces;
using GamePlatform.Models;
using GamePlatform.Tools;

namespace GamePlatform.Data
{
    public class DataAccess : IDataAccess
    {
        private const string _separator = "#&#";
        private readonly string _filePath;
        private readonly IFileManager _fileManager;

        public DataAccess(string filePath, IFileManager fileManager)
        {
            _filePath = filePath;
            _fileManager = fileManager;
        }

        public List<PlayerData> GetAllPlayers()
        {
            List<PlayerData> players = new();
            using (StreamReader reader = _fileManager.GetStreamReader(_filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine()!;
                    PlayerData player = PlayerExtensions.ParsePlayerDataFromString(line, _separator);
                    players.Add(player);
                }
            }
            return players;
        }

        public void SavePlayer(PlayerData player)
        {
            using (StreamWriter writer = _fileManager.GetStreamWriter(_filePath))
            {
                writer.WriteLine(player.Name + _separator + player.TotalGuesses + _separator + player.CurrentGameTitle);
            };
        }
    }
}