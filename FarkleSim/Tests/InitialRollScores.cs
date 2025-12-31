using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class InitialRollScores
    {
        private TradeOptionsSorter _sorter = new TradeOptionsSorter();
        public void Run(ValueCalculator valueCalc, Player player)
        {
            int numRuns = 100;
            int[] maxScores = new int[numRuns];

            for (int i = 0; i < numRuns; i++)
            {
                Console.WriteLine("ROLL");
                foreach (Dice die in player.Dice)
                {
                    die.Roll();
                    Console.WriteLine($"{die.Number}");
                }


                /*foreach (TradeOption tradeOption in valueCalc.Calculate(player.Dice.ToList()).Options)
                {
                    Console.WriteLine($"Number of dice to trade: {tradeOption.NumDice}, Score in Return: {tradeOption.Score}");
                }*/

                TradeOptions tradeOptions = valueCalc.Calculate(player.Dice.ToList());
                TradeOptions cleanedTradeOptions = _sorter.Clean(tradeOptions);

                try
                {
                    maxScores[i] = cleanedTradeOptions.Options.Max(t => t.Score);
                }
                catch
                {
                    maxScores[i] = 0;
                }

                foreach (TradeOption tradeOption in cleanedTradeOptions.Options)
                {
                    Console.WriteLine($"Number dice: {tradeOption.NumDice}, Score: {tradeOption.Score}");
                }


                Console.WriteLine("ROLL\n\n");
            }

            double meanScore = maxScores.Average();
            Console.WriteLine($"Mean: {meanScore}");
        }
    }
}
