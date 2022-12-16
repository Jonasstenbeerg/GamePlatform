using GamePlatform.Test.Fakes;

namespace GamePlatform.Test.UIs
{
    [TestClass]
    public class ConsoleUITest
    {
        private FakeTerminator? _terminator;
        private FakeIO? _iO;
        private ConsoleUI? _consoleIO;

        [TestInitialize]
        public void Initialize()
        {
            _terminator = new FakeTerminator();
            _iO = new FakeIO();
            _consoleIO = new ConsoleUI(_terminator, _iO);
        }

        [TestMethod]
        public void Exit_Should_Run_TerminateProgram_In_Terminator()
        {
            _consoleIO!.Exit();

            var expected = true;
            var actual = _terminator!.TerminateProgramHasRun;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetString_Should_Get_User_Input_From_IO()
        {
            _iO!.UserInput = "Hej";

            var expected = "Hej";
            var actual = _consoleIO!.GetString();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("Hej")]
        [DataRow("")]
        [DataRow(null)]
        public void PrintString_Should_Run_HandleUserInput_On_Any_String_Input(string? input)
        {
            _consoleIO!.PrintString(input);

            Assert.IsTrue(_iO!.HandleUserInputHasRun);
        }
    }
}