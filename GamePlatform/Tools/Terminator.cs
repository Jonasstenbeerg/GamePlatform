using GamePlatform.Interfaces;

namespace GamePlatform.Tools
{
    public class Terminator : ITerminator
    {
        public void TerminateProgram()
        {
            Environment.Exit(0);
        }
    }
}