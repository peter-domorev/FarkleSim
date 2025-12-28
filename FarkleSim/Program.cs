using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FarkleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            ValueCalculator valueCalc = new ValueCalculator();


            int numRolls = 100;
            List<TradeOption>[] tradeOptions = new List<TradeOption>[numRolls];

            for (int i = 0; i < numRolls;  i++)
            {
                foreach (Dice dice in player.Dice) dice.Roll();

                tradeOptions[i] = valueCalc.Calculate(player.Dice.ToList());
            }

            int thresholdMax = 1000;
            int numAboveMax = tradeOptions.Count(t => t.Sc>= thresholdMax);
            Console.WriteLine($"Number above threshold: {numAboveMax}");







     



        }
    }
}
