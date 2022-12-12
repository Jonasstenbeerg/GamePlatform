using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePlatform.Models
{
    public class GuessResult
    {
        public int CowCounter { get; private set; }
        public int BullsCounter { get; private set; }
        public GuessResult(int cowCounter, int bullsCounter)
        {
            CowCounter = cowCounter;
            BullsCounter = bullsCounter;
        }
    }
}
