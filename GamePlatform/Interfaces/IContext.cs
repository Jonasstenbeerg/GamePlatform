public interface IContext
{
    public void SavePlayerDataToScoreboard(string playerName, int guessCounter);
    public List<PlayerData> GetScoreboard();
}