using GamePlatform.Tools;

namespace GamePlatform.Test.Tools
{
    [TestClass()]
    public class NumberGeneratorTest
    {
        NumberGenerator numberGenerator = new(9, true);

        [TestMethod()]
        public void GetFourRandomNumbers_Should_Return_Four_Numbers()
        {
            string result = numberGenerator.GetFourRandomNumbers();

            int actual = result.Length;
            int expected = 4;

            Assert.AreEqual(expected, actual);
        }
    }
}