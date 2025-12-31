using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class TradeData : TradeOptions
    {
        public TradeData(int numDiceRolled, int runningScore)
        {
            _numDiceRolled = numDiceRolled;
            _runningScore = runningScore;
        }

        private int _numDiceRolled;
        private int _runningScore;

        public int NumDiceRolled => _numDiceRolled;
        public int RunningScore => _runningScore;
    }
}
