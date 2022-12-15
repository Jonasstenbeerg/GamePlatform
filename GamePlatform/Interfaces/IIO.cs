namespace GamePlatform.Interfaces
{
    public interface IIO
    {
        public string? ReturnUserInput();
        public void HandleUserInput(string input);
    }
}