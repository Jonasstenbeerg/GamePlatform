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
            var actualDistinctPlayers = list.GetDistinctPlayersForEachGame();
            Assert.AreEqual(expectedPlayersTotal, actualDistinctPlayers.Count());
        }

        [TestMethod]
        [DataRow("Svante#&#5#&#Moo")]
        public void ParsePlayerDataFromString_Should_Return_Name_From_Parsed_String(string playerData)
        {
            Player player = PlayerExtensions.ParsePlayerDataFromString(playerData, "#&#");
            string expected = player.Name!;
            string actual = "Svante";

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Svante#&#5#&#Moo")]
        public void ParsePlayerDataFromString_Should_Return_Number_Of_Guesses_From_Parsed_String(string playerData)
        {
            Player player = PlayerExtensions.ParsePlayerDataFromString(playerData, "#&#");
            int expected = player.TotalGuesses;
            int actual = 5;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Svante#&#5#&#Moo")]
        public void ParsePlayerDataFromString_Should_Return_Game_Title_From_Parsed_String(string playerData)
        {
            Player player = PlayerExtensions.ParsePlayerDataFromString(playerData, "#&#");
            string expected = player.CurrentGameTitle;
            string actual = "Moo";

            Assert.AreEqual(expected, actual);
        }
    }
}
