using GamePlatform.Data;
using GamePlatform.Interfaces;
using GamePlatform.Models;
using Moq;
using System.Text;

namespace GamePlatform.Test.Datatest
{
    [TestClass]
    public class DataAccessTest
    {
        DataAccess? _dataAccess;

        [TestMethod]
        public void GetAllPlayers_Should_Return_A_List_Containing_Players_Matching_Text_File_Lines()
        {
            Mock<IFileManager> fileManagerMock = new();
            string testPlayerData = "Sven#&#4#&#Moo\nJohannes#&#1#&#Mastermind";
            byte[] testBytes = Encoding.UTF8.GetBytes(testPlayerData);

            using (MemoryStream testMemoryStream = new(testBytes))
            using (StreamReader testStreamReader = new(testMemoryStream))
            {
                fileManagerMock.Setup(mock => mock.GetStreamReader(It.IsAny<string>()))
                .Returns(() => testStreamReader);
                _dataAccess = new DataAccess("test.txt", fileManagerMock.Object);

                var actual = _dataAccess.GetAllPlayers();
                var expected = new List<PlayerData>()
                {
                    new PlayerData { Name = "Sven", TotalGuesses = 4 },
                    new PlayerData { Name = "Johannes", TotalGuesses = 1 }
                };

                Assert.IsInstanceOfType(actual, typeof(List<PlayerData>));
                Assert.AreEqual(expected[0].Name, actual[0].Name);
                Assert.AreEqual(expected[0].TotalGuesses, actual[0].TotalGuesses);
                Assert.AreEqual(expected[1].Name, actual[1].Name);
                Assert.AreEqual(expected[1].TotalGuesses, actual[1].TotalGuesses);
            }
        }

        [TestMethod]
        public void SavePlayer_Should_Add_Specific_Player_To_File()
        {
            using (MemoryStream testMemoryStream = new())
            using (StreamWriter testStreamWriter = new(testMemoryStream))
            {
                Mock<IFileManager> fileManagerMock = new();
                fileManagerMock.Setup(mock => mock.GetStreamWriter(It.IsAny<string>()))
                    .Returns(() => testStreamWriter);
                _dataAccess = new DataAccess("test.txt", fileManagerMock.Object);

                PlayerData player = new()
                {
                    Name = "Sven",
                    TotalGuesses = 2,
                    CurrentGameTitle = "Moo"
                };

                _dataAccess.SavePlayer(player);
                string actual = Encoding.UTF8.GetString(testMemoryStream.ToArray());
                string expected = "Sven#&#2#&#Moo\r\n";

                Assert.AreEqual(expected, actual);
            }
        }
    }
}