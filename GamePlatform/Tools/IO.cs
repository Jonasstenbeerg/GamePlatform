using GamePlatform.Interfaces;

namespace GamePlatform.Helpers
{
    internal class IO : IIO
    {
        public void HandleUserInput(string input)
        {
            Console.WriteLine(input);
        }

        public string? ReturnUserInput()
        {
            return Console.ReadLine();
        }
    }
}
