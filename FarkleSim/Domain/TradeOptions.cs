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

        public void Add(TradeOption tradeOption)
        {
            _options.Add(tradeOption);
        }
        public void Add(TradeOptions tradeOptions)
        {
            _options.AddRange(tradeOptions.Options);
        }

        /// <summary>
        /// Add one trade option to all other trade options
        /// </summary>
        public void Combine(TradeOption combinerTradeOption)
        {
            List<TradeOption> oldTradeOptions = _options;
            _options = new List<TradeOption>();

            foreach(TradeOption oldTradeOption in oldTradeOptions)
            {
                int newNumDice = oldTradeOption.NumDice + combinerTradeOption.NumDice;
                int newScore = oldTradeOption.Score + combinerTradeOption.Score;
                Add(newNumDice, newScore);
            }
        }
    }
}
