using GamePlatform.Tools;

namespace GamePlatform.Test.Tools
{
    [TestClass]
    public class NumberGeneratorTest
    {
        [TestMethod]
        public void GetFourRandomNumbers_Should_Return_Four_Numbers()
        {
            NumberGenerator numberGenerator = new(9, true);

            string result = numberGenerator.GetRandomDigits();
            int expected = 4;
            int actual = result.Length;

            Assert.AreEqual(expected, actual);
        }
    }
}