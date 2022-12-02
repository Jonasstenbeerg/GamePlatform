using GamePlatform.Interfaces;
using GamePlatform.Test.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Test.UIs
{
    [TestClass]
    public class ConsoleUITest
    {
        private ConsoleUI? _consoleIO;
        private FakeTerminator? _terminator;
        private FakeIO? _iO; 
        [TestInitialize] 
        public void Init() 
        {
            _terminator = new FakeTerminator();
            _iO = new FakeIO();

            _consoleIO = new ConsoleUI(_terminator,_iO);
        }

        [TestMethod]
        public void Exit_Should_Run_TerminateProgram_In_Terminator()
        {
            _consoleIO!.Exit();

            var expected = true;

            var actual = _terminator!.TerminateProgramRan;

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
        public void PrintString_Should_Run_HandleUserInput_With_Input_In_IO()
        {
            const string input = "Hej";
           
            _consoleIO.PrintString(input);

            Assert.IsTrue(_iO.HandleUserInputRan);
        }
    }
}
