using GamePlatform.Models;

public interface IDataAccess
{
    public void SavePlayer(PlayerData player);
    public List<PlayerData> GetAllPlayers();
}