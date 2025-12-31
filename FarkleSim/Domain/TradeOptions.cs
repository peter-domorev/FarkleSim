using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class TradeOptions
    {
        private List<TradeOption> _options = new List<TradeOption>();
        public List<TradeOption> Options => _options;

        public bool IsBust => _options.Count == 0;

        public void Add(int numDice, int score)
        {
            _options.Add(new TradeOption(numDice, score));
        }

        public void Add(TradeOption tradeOption)
        {
            _options.Add(tradeOption);
        }
        public void Add(TradeOptions tradeOptions)
        {
            _options.AddRange(tradeOptions.Options);
        }
        public void Add(List<TradeOption> tradeOptions)
        {
            _options.AddRange(tradeOptions);
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
        public void Combine(int numDice, int score)
        {
            TradeOption combinerTradeOption = new TradeOption(numDice, score);
            Combine(combinerTradeOption);
        }

        public int GetScore(int numDiceToTrade)
        {
            if (IsBust) return 0;
            if (numDiceToTrade == 0) return 0;
            return Options.FirstOrDefault(t => t.NumDice == numDiceToTrade).Score;
        }

        public int GetMaxScore()
        {
            if (IsBust) return 0;
            return Options.Max(t => t.Score);
        }

        public int GetNumDice(int score)
        {
            return Options.FirstOrDefault(t => t.Score == score)?.NumDice ?? 0;
        }

        public int GetMinNumDice()
        {
            if (IsBust) return 0;
            return Options.Min(t => t.NumDice);
        }

        
    }
}
