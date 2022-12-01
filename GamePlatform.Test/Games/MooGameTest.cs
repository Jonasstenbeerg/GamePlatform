using GamePlatform.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Test.Games
{
    [TestClass]
    public class MooGameTest
    {
        private MooGame? _game;
        
        [TestInitialize] 
        public void Initialize() 
        {
            _game = new MooGame();
            _game!.SetupDigitsToGuess();
            _game.SetCurrentGuess(_game.DigitsToGuess);
        }

        [TestMethod]
        public void SetPlayerName_Should_Change_PlayerName_Equal_To_Input()
        {
            const string NameToSet = "svante";
            _game!.SetPlayerName(NameToSet);

            var expected = NameToSet;

            var actual = _game.PlayerName; 

            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void SetPlayerName_Must_Require_Characters()
        {
            const string NameToSet = "    ";
            _game!.SetPlayerName(NameToSet);

           if(_game.PlayerName == NameToSet) 
            {
                Assert.Fail("Player name set to no character value");
            }
        }
        [TestMethod]
        public void SetCurrentGuess_Should_Change_PlayerName_Equal_To_Input()
        {
            const string GuessToMake = "1234";
            _game!.SetCurrentGuess(GuessToMake);

            var expected = GuessToMake;

            var actual = _game.CurrentGuess;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void GetGuessResult_Should_Return_BBBB_On_Correct_Guess()
        {
            var actual = _game!.GetGuessResult();

            var expected = "BBBB,";


            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IncrementGuessCounter_Should_Increase_GuessCounter_By_One()
        {
            _game!.IncrementGuessCounter();

            var expected = 1;

            var actual = _game.GuessCounter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetGuessCounter_Should_Set_GuessCounter_To_Zero()
        {
            _game!.ResetGuessCounter();

            var expected = 0;

            var actual = _game.GuessCounter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetupDigitsToGuess_Should_Return_A_String()
        {
            _game!.SetupDigitsToGuess();

            Assert.IsInstanceOfType(_game.DigitsToGuess, typeof(string));
            
        }

        [TestMethod]
        public void SetupDigitsToGuess_Return_Value_Should_Be_Four_In_Length()
        {
            _game!.SetupDigitsToGuess();

            var expected = 4;

            var actual = _game.DigitsToGuess!.Length;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SetupDigitsToGuess_Return_Value_Should_Only_Be_Digits()
        {
            _game!.SetupDigitsToGuess();

            foreach (var number in _game.DigitsToGuess!)
            {
                if (Char.IsLetter(number))
                {
                    Assert.Fail("Letter found in string that should contain only digits");
                }
            }

        }
        [TestMethod]
        public void SetupDigitsToGuess_Return_Value_Should_Have_Unique_Characters()
        {
            _game!.SetupDigitsToGuess();

            bool[] array = new bool[100];

            foreach (char number in _game.DigitsToGuess!)
            {
                if (array[(int)number])
                    Assert.Fail("Not Unique");
                else
                    array[(int)number] = true;
            }
                
            
        }

    }
}
