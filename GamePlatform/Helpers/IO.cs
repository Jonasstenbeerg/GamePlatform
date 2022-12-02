using GamePlatform.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
