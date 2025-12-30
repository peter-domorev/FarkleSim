using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarkleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValueCalculator valueCalc = new ValueCalculator();

            Conservative1 consPlayer = new Conservative1();

            /*
            int numTurns = 10000;
            int[] scores = new int[numTurns];

            for (int i = 0; i < numTurns; i++)
            {
                int score = consPlayer.PlayTurn();
                Console.WriteLine($"Score: {score}");
                scores[i] = score;
            }

            double mean = scores.Average();
            Console.WriteLine($"Mean: {mean}");*/


            // make 6 dice
            List<Dice> dice = new List<Dice>();
            int maxNumDice = 6;
            for (int i = 0; i < maxNumDice; i++)
            {
                dice.Add(new Dice());
            }

            // set up to collect data
            int numRuns = 1000000;
            double[] means = new double[maxNumDice];
            double[] stds = new double[maxNumDice];
            double[] percentBust = new double[maxNumDice];
            double[] numBust = new double[maxNumDice];




            for (int j = 0; j < 6; j++) // simulate each number of dice
            {
                int[] maxScores = new int[numRuns];
                int numDice = dice.Count;   // 6,5,4,3,2,1


                // errors, valueCalc modifies the dice reference
                // incorrect indexing (for loop vs num dice)

                for (int i = 0; i < numRuns; i++) // simulate rolls
                {
                    foreach (Dice singleDice in dice) singleDice.Roll(); // roll


                    // calculate max value, add to maxScores
                    TradeOptions tradeOptions = valueCalc.Calculate(dice.ToList());
                    if(tradeOptions.Options.Count == 0)
                    {
                        maxScores[i] = 0;
                        continue;
                    }
                    maxScores[i] = tradeOptions.Options.Max(t => t.Score);
                }


                // calculate data from set of dice, add
                double mean = maxScores.Average();
                double std = Math.Sqrt(maxScores.Average(v => (v - mean) * (v - mean)));
                means[numDice - 1] = mean;
                stds[numDice - 1] = std;

                double pBust = (double)maxScores.Count(t => t == 0) / numRuns;
                percentBust[numDice - 1] = pBust;

                numBust[numDice - 1] = maxScores.Count(t => t == 0);

                dice.RemoveAt(dice.Count - 1);
            }


            for (int numDice = 1; numDice <= maxNumDice; numDice++)
            {
                Console.WriteLine($"Number of dice: {numDice}, Mean: {means[numDice - 1]}, Std: {stds[numDice - 1]}");
                Console.WriteLine($"Percentage bust: {percentBust[numDice - 1]}");
            }



















            /*
            int numRolls = 100;
            int thresholdMax = 1000;
            bool[] isAboveThreshold = new bool[numRolls];



            int maxTradeScore;
            for (int i = 0; i < numRolls;  i++)
            {
                foreach (Dice dice in player.Dice) dice.Roll();

                List<TradeOption> tradeOptions = valueCalc.Calculate(player.Dice.ToList());
                maxTradeScore = tradeOptions.Max(t => t.Score);

                if (maxTradeScore >= thresholdMax)
                {
                    isAboveThreshold[i] = true;
                }
                else isAboveThreshold[i] = false;


            }

            int numAboveMax = isAboveThreshold.Count(b => b == true);
            Console.WriteLine($"Number above threshold: {numAboveMax}");
            */










        }
    }
}
