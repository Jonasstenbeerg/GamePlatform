using GamePlatform.GameTypes;
using GamePlatform.Models;
using GamePlatform.TemplateClasses;
using GamePlatform.Test.Fakes;
using GamePlatform.Tools;

namespace GamePlatform.Test.Games
{
    [TestClass]
    public class MooGameTest
    {
        private Game _game = new(new MooType(new NumberGenerator(10, true)), "Moo");

        [TestMethod]
        public void SetPlayerName_Should_Set_PlayerName_Equal_To_Input()
        {
            const string NameToSet = "Svante";
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

            if (_game.PlayerName == NameToSet)
            {
                Assert.Fail("Player name set to no character value");
            }
        }

        [TestMethod]
        public void SetCurrentGuess_Should_Set_CurrentGuess_Equal_To_Input()
        {
            const string GuessToMake = "1234";
            _game!.SetCurrentGuess(GuessToMake);

            var expected = GuessToMake;
            var actual = _game.CurrentGuess;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow(4, 0, "3456")]
        [DataRow(0, 2, "5578")]
        [DataRow(0, 3, "4035")]
        [DataRow(2, 2, "3443")]
        public void GetGuessResult_Should_Return_Correct_GuessResult_After_Given_Guess(int bulls, int cows, string guess)
        {
            const string digitsToGuess = "3456";
            Game testGame = new(new FakeMooType(digitsToGuess), "MooTest");
            testGame.SetDigitsToGuess();
            testGame.SetCurrentGuess(guess);

            GuessResult actual = testGame.GetGuessResult();
            GuessResult expected = new(bulls, cows);

            Assert.AreEqual(actual.CowCounter, expected.CowCounter);
            Assert.AreEqual(actual.BullsCounter, expected.BullsCounter);
        }

        [TestMethod]
        [DataRow(1, 3, "B,CCC")]
        [DataRow(0, 2, ",CC")]
        [DataRow(0, 4, ",CCCC")]
        [DataRow(4, 0, "BBBB,")]
        [DataRow(1, 1, "B,C")]
        public void GuessResult_To_String_Should_Return_Correct_String(int bulls, int cows, string expected)
        {
            GuessResult result = new(bulls, cows);
            string actual = result.ToString();

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
        public void SetupDigitsToGuess_Should_Set_DigitsToGuess_To_Be_Four_In_Length()
        {
            _game!.SetDigitsToGuess();

            var expected = 4;
            var actual = _game.DigitsToGuess!.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetupDigitsToGuess_Should_Set_DigitsToGuess_To_Only_Be_Digits()
        {
            _game!.SetDigitsToGuess();

            foreach (var digit in _game.DigitsToGuess!)
            {
                if (Char.IsLetter(digit))
                {
                    Assert.Fail("Letter found in string that should contain only digits");
                }
            }
        }

        [TestMethod]
        public void SetupDigitsToGuess_Should_Set_DigitsToGuess_To_Unique_Characters()
        {
            _game!.SetDigitsToGuess();

            // int value of char 9 = 57, therefore the array length is 58
            bool[] array = new bool[58];

            foreach (char digit in _game.DigitsToGuess!)
            {
                if (array[digit])
                    Assert.Fail("Not Unique");
                else
                    array[digit] = true;
            }
        }
    }
}