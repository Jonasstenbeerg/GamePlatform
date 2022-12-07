using GamePlatform.Tools;

namespace GamePlatform.Test.Controllers
{
    [TestClass()]
    public class PlayerExtensionsTest
    {
        [TestMethod()]
        public void GetDistinctPlayers_Should_Return_List_Of_Distinct_Players()
        {
            List<Player> list = new List<Player>();
            list.Add(new Player("Madde", 5));
            list.Add(new Player("Jonas", 2));
            list.Add(new Player("Madde", 4));

            int expectedPlayersTotal = 2;
            var actualDistinctPlayers = list.GetDistinctPlayers();
            Assert.AreEqual(expectedPlayersTotal, actualDistinctPlayers.Count());
        }
    }
}
