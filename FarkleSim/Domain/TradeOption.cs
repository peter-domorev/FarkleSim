using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class TradeOption
    {
        public int NumDice { get; }
        public int Score { get; }

        public TradeOption(int numDice, int score)
        {
            NumDice = numDice;
            Score = score;
        }
    }
}
