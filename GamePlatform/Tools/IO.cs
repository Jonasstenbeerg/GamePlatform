using GamePlatform.Interfaces;

namespace GamePlatform.Tools
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
