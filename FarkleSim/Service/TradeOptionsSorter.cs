using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class TradeOptionsSorter
    {
        public TradeOptions RemoveUselessOptions(TradeOptions tradeOptions)
        {
            TradeOptions cleanedTradeOptions = new TradeOptions();

            const int NUM_FACES = 6;
            for (int numDice = 0; numDice < NUM_FACES; numDice++)
            {
                TradeOptions currentTradeOptions = new TradeOptions();
                currentTradeOptions.Add(tradeOptions.Options.FindAll(t => t.NumDice == numDice));

                if (currentTradeOptions.Options.Count == 0) continue;

                int maxScore = currentTradeOptions.Options.Max(t => t.Score); // if there was none added because there isn't any
                cleanedTradeOptions.Add(numDice, maxScore);
          
            }

            return cleanedTradeOptions;
        }
    }
}
