using GamePlatform.Models;
using GamePlatform.Tools;

namespace GamePlatform.Test.Controllers
{
    [TestClass]
    public class PlayerExtensionsTest
    {
        [TestMethod]
        public void GetDistinctPlayers_Should_Return_List_Of_Distinct_Players_For_Each_Game()
        {
            List<Player> players = new()
            {
                new Player() { Name = "Madde", NumberOfGames = 2, TotalGuesses = 5, CurrentGameTitle = "Moo"},
                new Player() { Name = "Jonas", NumberOfGames = 7, TotalGuesses = 2, CurrentGameTitle = "Mastermind"},
                new Player() { Name = "Madde", NumberOfGames = 4, TotalGuesses = 4, CurrentGameTitle = "Moo" }
            };

            int expected = 2;
            var result = players.GetDistinctPlayersForEachGame();
            int actual = result.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParsePlayerDataFromString_Should_Return_Name_From_Parsed_String()
        {
            string playerData = "Svante#&#5#&#Moo";

            Player player = PlayerExtensions.ParsePlayerDataFromString(playerData, "#&#");
            string expected = "Svante";
            string actual = player.Name!;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParsePlayerDataFromString_Should_Return_Number_Of_Guesses_From_Parsed_String()
        {
            string playerData = "Svante#&#5#&#Moo";

            Player player = PlayerExtensions.ParsePlayerDataFromString(playerData, "#&#");
            int expected = 5;
            int actual = player.TotalGuesses;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParsePlayerDataFromString_Should_Return_Game_Title_From_Parsed_String()
        {
            string playerData = "Svante#&#5#&#Moo";

            Player player = PlayerExtensions.ParsePlayerDataFromString(playerData, "#&#");
            string expected = "Moo";
            string actual = player.CurrentGameTitle!;

            Assert.AreEqual(expected, actual);
        }
    }
}