namespace FarkleSim
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dice dice = new Dice();
            Player player = new Player();


            foreach(Dice d in player.Dice)
            {
                d.Roll();
                Console.WriteLine(d.Number);
            }



            ValueCalculator valueCalc = new ValueCalculator();
            Dictionary<int, int> faceCounts = valueCalc.countFaces(player.Dice.ToList());

            foreach(var kvp in faceCounts)
            {
                Console.WriteLine($"{kvp.Key}:{kvp.Value}");
            }


        }
    }
}
