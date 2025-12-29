using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarkleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ValueCalculator valueCalc = new ValueCalculator();

            Conservative1 consPlayer = new Conservative1();

            int numTurns = 10000;
            int[] scores = new int[numTurns];

            for (int i = 0; i < numTurns; i++)
            {
                int score = consPlayer.PlayTurn();
                Console.WriteLine($"Score: {score}");
                scores[i] = score;
            }

            double mean = scores.Average();
            Console.WriteLine($"Mean: {mean}");




            














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
