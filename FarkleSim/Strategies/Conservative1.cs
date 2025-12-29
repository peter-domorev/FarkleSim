using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class Conservative1 : Player, IPlayer
    {
        public override int PlayTurn()
        {
            int score = 0;

            Decision decision = Decision.RollAgain;

            List<Dice> currentHandDice = _dice.ToList();



            while (decision == Decision.RollAgain)
            {
                if (currentHandDice.Count == 0) // another roll
                {
                    currentHandDice = _dice.ToList();
                }

                foreach (Dice dice in currentHandDice) dice.Roll();
                

                TradeOptions tradeOptions = _valueCalc.Calculate(currentHandDice);
                tradeOptions = _sorter.RemoveUselessOptions(tradeOptions);

                int bigThreshold = 50;
                if (tradeOptions.Options.Count == 0)
                {
                    score = 0;
                    decision = Decision.Bust;
                    

                }
                else if (tradeOptions.Options.Max(t => t.Score >= bigThreshold))
                {
                    TradeOption bigTrade = tradeOptions.Options.FirstOrDefault(t => t.Score == tradeOptions.Options.Max(t => t.Score));
                    currentHandDice.Remove(currentHandDice.FirstOrDefault(t => t.Number == bigTrade.NumDice));
                    score += bigTrade.Score;
                    decision = Decision.Stand;
                }
                else
                {
                    TradeOption singleTrade = tradeOptions.Options.FirstOrDefault(t => t.NumDice == 1) ?? tradeOptions.Options.FirstOrDefault(t => t.Score == tradeOptions.Options.Max(t => t.Score));
                    currentHandDice.Remove(currentHandDice.FirstOrDefault());
                    score += singleTrade.Score;
                    decision = Decision.RollAgain;
                }
            }

            return score;
            

        }
    }
}
