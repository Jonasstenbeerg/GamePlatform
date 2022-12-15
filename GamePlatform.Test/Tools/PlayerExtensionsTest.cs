using GamePlatform.Tools;

namespace GamePlatform.Test.Controllers
{
    [TestClass()]
    public class PlayerExtensionsTest
    {
        [TestMethod()]
        public void GetDistinctPlayers_Should_Return_List_Of_Distinct_Players()
        {
            List<Player> players = new()
            {
                new Player() { Name = "Madde", NumberOfGames = 2, TotalGuesses = 5, CurrentGameTitle = "Moo"},
                new Player() { Name = "Jonas", NumberOfGames = 7, TotalGuesses = 2, CurrentGameTitle = "Mastermind"},
                new Player() { Name = "Madde", NumberOfGames = 4, TotalGuesses = 4, CurrentGameTitle = "Moo" }
            };

            var result = players.GetDistinctPlayersForEachGame();
            int actual = result.Count();
            int expected = 2;

            Assert.AreEqual(expected, actual);
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