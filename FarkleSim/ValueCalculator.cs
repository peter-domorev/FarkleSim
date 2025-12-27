using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class ValueCalculator
    {
        public int Calculate(List<Dice> dice)
        {
            int value = 0;



            return value;
        }

        private Dictionary<int, int> countFaces(List<Dice> dice)
        {
            Dictionary<int, int> faceCounts = new Dictionary<int, int>
            {
                { 1, 0 },
                { 2, 0 },
                { 3, 0 },
                { 4, 0 },
                { 5, 0 },
                { 6, 0 },
            };

            foreach(Dice die in dice)
            {
                faceCounts[die.Number]++;
            }

            return faceCounts;
        }

        private int sixDiceValue(Dictionary<int, int>)

    }
}
