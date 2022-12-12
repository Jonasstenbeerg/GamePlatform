using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Interfaces
{
    public interface IGameController
    {
        public void RunGame(IDigitGuessGame game);
    }
}
