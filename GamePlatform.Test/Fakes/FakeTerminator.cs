using GamePlatform.Interfaces;

namespace GamePlatform.Test.Fakes
{
    public class FakeTerminator : ITerminator
    {
        public bool TerminateProgramHasRun { get; private set; }
        public void TerminateProgram()
        {
            TerminateProgramHasRun = true;
        }
    }
}