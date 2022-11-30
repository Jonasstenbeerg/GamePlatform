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
        MooGame game;
        string digitsToGuessField;
        [TestInitialize] 
        public void Initialize() 
        {
            game = new MooGame();
            digitsToGuessField = game.SetupDigitsToGuess();
        }

        [TestMethod]
        public void GetGuessResult_Should_Return_BBBB_On_Correct_Guess()
        {
            var actual = game.GetGuessResult(digitsToGuessField, digitsToGuessField);

            var expected = "BBBB,";


            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void IncrementGuessCounter_Should_Increase_GuessCounter_By_One()
        {
            game.IncrementGuessCounter();

            var expected = 1;

            var actual = game.GuessCounter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ResetGuessCounter_Should_Set_GuessCounter_To_Zero()
        {
            game.ResetGuessCounter();

            var expected = 0;

            var actual = game.GuessCounter;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetupDigitsToGuess_Should_Return_A_String()
        {
            var returnValue = game.SetupDigitsToGuess();

            Assert.IsInstanceOfType(returnValue, typeof(string));
            
        }

        [TestMethod]
        public void SetupDigitsToGuess_Return_Value_Should_Be_Four_In_Length()
        {
            var expected = 4;

            var actual = game.SetupDigitsToGuess().Length;

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void SetupDigitsToGuess_Return_Value_Should_Only_Be_Digits()
        {
            var numbers = game.SetupDigitsToGuess();

            foreach (var number in numbers)
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
            var numbers = game.SetupDigitsToGuess();

            bool[] array = new bool[100]; // or larger for Unicode

            foreach (char number in numbers)
            {
                if (array[(int)number])
                    Assert.Fail("Not Unique");
                else
                    array[(int)number] = true;
            }
                
            
        }

    }
}
