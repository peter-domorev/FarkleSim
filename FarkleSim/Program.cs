using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarkleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            ValueCalculator valueCalc = new ValueCalculator();




            MultipleGames multipleGames = new MultipleGames();
            InitialRollScores initialRoll = new InitialRollScores();
            //initialRoll.Run(valueCalc, player);
            multipleGames.Run(valueCalc, player);












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
