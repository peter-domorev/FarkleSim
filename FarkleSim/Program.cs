namespace FarkleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Player player = new Player();

            ValueCalculator valueCalc = new ValueCalculator();






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
