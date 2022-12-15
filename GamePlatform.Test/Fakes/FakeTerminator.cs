using GamePlatform.Interfaces;

namespace GamePlatform.Test.Fakes
{
    public class FakeTerminator : ITerminator
    {
        public bool TerminateProgramRan { get; private set; }
        public void TerminateProgram()
        {
            TerminateProgramRan = true;
        }
    }
}