using GamePlatform.Interfaces;

namespace GamePlatform.Helpers
{
    public class Terminator : ITerminator
    {
        public void TerminateProgram()
        {
            Environment.Exit(0);
        }
    }
}
