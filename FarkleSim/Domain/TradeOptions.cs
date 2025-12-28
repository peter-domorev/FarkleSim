using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class TradeOptions
    {
        private List<TradeOption> _options = new List<TradeOption>();
        public List<TradeOption> Options => _options;

        public void Add(int numDice, int score)
        {
            _options.Add(new TradeOption(numDice, score));
        }

        public void Add(List<TradeOption> tradeOptions)
        {
            _options.AddRange(tradeOptions);
        }
    }
}
