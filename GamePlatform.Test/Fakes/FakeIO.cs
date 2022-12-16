using GamePlatform.Interfaces;

namespace GamePlatform.Test.Fakes
{
    public class FakeIO : IIO
    {
        public string? UserInput { get; set; }
        public bool HandleUserInputHasRun { get; private set; }

        public void HandleUserInput(string input)
        {
            HandleUserInputHasRun = true;
        }

        public string? ReturnUserInput()
        {
            return UserInput;
        }
    }
}