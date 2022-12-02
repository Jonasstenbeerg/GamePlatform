using GamePlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
