public interface IDataAccess
{
    public Player GetPlayerOnName(string name);
    public List<Player> GetAllPlayers();
    public void PostPlayer(string playername);
    public void PutPlayer(Player _player);
}