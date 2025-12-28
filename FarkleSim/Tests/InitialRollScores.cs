using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class InitialRollScores
    {
        public void Run(ValueCalculator valueCalc, Player player)
        {

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("ROLL");
                foreach (Dice die in player.Dice)
                {
                    die.Roll();
                    Console.WriteLine($"{die.Number}");
                }

                foreach (TradeOption tradeOption in valueCalc.Calculate(player.Dice.ToList()))
                {
                    Console.WriteLine($"Number of dice to trade: {tradeOption.NumDice}, Score in Return: {tradeOption.Score}");
                }

                Console.WriteLine("ROLL\n\n");
            }
        }
    }
}
