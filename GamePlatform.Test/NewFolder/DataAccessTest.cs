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

namespace GamePlatform.Test.NewFolder
{
    [TestClass]
    public class DataAccessTest
    {
         
        DataAccess _dataAccess;

        [TestInitialize]
        public void Initialize()
        {
            Mock<IFilemanager> filemangaerMock = new Mock<IFilemanager>();
            string testContent = "sven#&#4\nJohannes#&#1";
            byte[] testBytes = Encoding.UTF8.GetBytes(testContent);

            MemoryStream testMemoryStream = new MemoryStream(testBytes);

            filemangaerMock.Setup(m => m.StreamReader(It.IsAny<string>()))
                .Returns(() => new StreamReader(testMemoryStream));
            _dataAccess = new DataAccess("test.txt", filemangaerMock.Object);

        }

        [TestMethod]
        public void GetAllPlayers_Should_return_A_List_Containing_Players_Matching_TextFile_Lines()
        {
            var actual = _dataAccess.GetAllPlayers();
            var expected = new List<Player>() { new Player { Name = "sven", TotalGuesses = 4 } };


            Assert.IsInstanceOfType(actual, typeof(List<Player>));
            Assert.AreEqual(expected[0].Name, actual[0].Name);
            Assert.AreEqual(expected[0].TotalGuesses, actual[0].TotalGuesses);

        }
    }
}
