using GamePlatform.Interfaces;

namespace GamePlatform.Test.Fakes
{
    internal class FakeIO : IIO
    {
        public string? UserInput { get; set; }
        public bool HandleUserInputRan { get; private set; }

        public void HandleUserInput(string input)
        {
            HandleUserInputRan = (input != null);
        }

        public string? ReturnUserInput()
        {
            return UserInput;
        }
    }
}
