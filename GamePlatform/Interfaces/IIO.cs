using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Interfaces
{
    public interface IIO
    {
        public string? ReturnUserInput();
        public void HandleUserInput(string input);
    }
}
