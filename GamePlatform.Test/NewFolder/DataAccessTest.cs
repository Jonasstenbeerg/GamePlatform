using GamePlatform.Games;
using GamePlatform.Data;
using GamePlatform.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Reflection;
using GamePlatform.Test.Fakes;

namespace GamePlatform.Test.NewFolder
{
    [TestClass]
    public class DataAccessTest
    {
         
        DataAccess _dataAccess;

        [TestInitialize]
        public void Initialize()
        {
            

        }

        [TestMethod]
        public void GetAllPlayers_Should_return_A_List_Containing_Players_Matching_TextFile_Lines()
        {
            Mock<IFilemanager> filemangaerMock = new Mock<IFilemanager>();
            string testContent = "sven#&#4\nJohannes#&#1";
            byte[] testBytes = Encoding.UTF8.GetBytes(testContent);

            using (MemoryStream testMemoryStream = new MemoryStream(testBytes))
            using (StreamReader testStreamReader = new StreamReader(testMemoryStream))
            {
                filemangaerMock.Setup(m => m.StreamReader(It.IsAny<string>()))
                .Returns(() => testStreamReader);
                _dataAccess = new DataAccess("test.txt", filemangaerMock.Object);


                var actual = _dataAccess.GetAllPlayers();
                var expected = new List<Player>() { new Player { Name = "sven", TotalGuesses = 4 }, new Player { Name = "Johannes", TotalGuesses = 1 } };


                Assert.IsInstanceOfType(actual, typeof(List<Player>));
                Assert.AreEqual(expected[0].Name, actual[0].Name);
                Assert.AreEqual(expected[0].TotalGuesses, actual[0].TotalGuesses);
                Assert.AreEqual(expected[1].Name, actual[1].Name);
                Assert.AreEqual(expected[1].TotalGuesses, actual[1].TotalGuesses);

            }
        }

        [TestMethod]
        public void SavePlayer_Should_Add_Specific_Player_To_File()
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                // arrange
                var mockFilemanager = new Mock<IFilemanager>();
                mockFilemanager.Setup(m => m.StreamWriter(It.IsAny<string>()))
                    .Returns(() => writer);
                _dataAccess = new DataAccess("Test.txt", mockFilemanager.Object);

                var player = new Player { Name = "sven", TotalGuesses = 2 };

                // act


                _dataAccess.SavePlayer(player);
                string actual = Encoding.UTF8.GetString(stream.ToArray());
                string expected = "sven#&#2\r\n";


                // assert

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
