namespace GamePlatform.Test.Controllers
{
    [TestClass()]
    public class GameControllerTest
    {
        [TestMethod()]
        public void Get_Distinct_Player()
        {
            List<Player> list = new List<Player>();
            list.Add(new Player("Madde", 5));
            list.Add(new Player("Jonas", 2));
            list.Add(new Player("Madde", 4));

            var actualDistinctPlayers = list.GetDistinctPlayers();
            int expectedPlayersTotal = 2;
            Assert.AreEqual(expectedPlayersTotal, actualDistinctPlayers.Count());
        }
    }
}
