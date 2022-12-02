using System;
using GamePlatform.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
