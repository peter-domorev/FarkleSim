using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class MultipleGames
    {
        private TradeOptionsSorter _sorter = new TradeOptionsSorter();
        public void Run(ValueCalculator valueCalc, Player player)
        {

            int numRuns = 50;
            int[] maxScores = new int[numRuns];
            int maxValue;

            int numMetaRuns = 2;
            double[] sampleAverages = new double[numMetaRuns];


            for (int j = 0; j < numMetaRuns; j++)
            {
                for (int i = 0; i < numRuns; i++)
                {

                    // roll dice
                    foreach (Dice dice in player.Dice)
                    {
                        dice.Roll();
                    }

                    TradeOptions tradeOptions = valueCalc.Calculate(player.Dice.ToList());
                    TradeOptions cleanedTradeOptions = _sorter.Clean(tradeOptions);


                    if (cleanedTradeOptions.Options.Count == 0)
                    {
                        maxScores[i] = 0;
                        continue;
                    }

                    maxValue = cleanedTradeOptions.Options.Max(t => t.Score);


                    maxScores[i] = maxValue;
                }

                double meanScore = maxScores.Average();
                Console.WriteLine($"mean: {meanScore}");

                sampleAverages[j] = meanScore;
            }

            double[] data = sampleAverages;
            double mean = data.Average();
            double samplingSTD = Math.Sqrt(data.Average(v => (v - mean) * (v - mean)));
            Console.WriteLine($"Sampling mean: {mean}, sampling std {samplingSTD}");
        }

    }
}
