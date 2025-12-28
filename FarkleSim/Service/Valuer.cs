using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class Valuer
    {



        public int[] ThreeDiceValuer(Dictionary<int, int> faceCounts)
        {
            int[] frequencyCounts = faceCounts.Values.ToArray();

            int[] values = { 0, 0 }; // since 2 3's has 2 possible values


            switch (frequencyCounts)
            {
                case int[] x when x.Count(v => v == 3) == 2:

                    int[] triples = faceCounts.Where(v => v.Value == 3).Select(v => v.Key).ToArray();

                    values[0] = tripValuer(triples[0]);
                    values[1] = tripValuer(triples[1]);
                    break;

                case int[] x when x.Count(v => v >= 3) == 1: // >= because 4 needs to satisfy this

                    int triple = faceCounts.FirstOrDefault(v => v.Value >= 3).Key; // >= same reason

                    values[0] = tripValuer(triple);
                    break;
            }

            return values;
        }

        private int tripValuer(int tripleNumber)
        {
            int value = 0;
            switch (tripleNumber)
            {
                case 1:
                    value = (int)ScoreCombination.TripThrees;
                    break;
                case 2:
                    value = (int)ScoreCombination.TripTwos;
                    break;
                case 3:
                    value = (int)ScoreCombination.TripThrees;
                    break;
                case 4:
                    value = (int)ScoreCombination.TripFours;
                    break;
                case 5:
                    value = (int)ScoreCombination.TripFives;
                    break;
                case 6:
                    value = (int)ScoreCombination.TripSixes;
                    break;

            }
            return value;
        }



        public int FourDiceValuer(Dictionary<int, int> faceCounts)
        {
            int[] frequencyCounts = faceCounts.Values.ToArray();

            int value = 0;
            switch (frequencyCounts)
            {
                case int[] x when x.Any(v => v == 4):
                    value = (int)ScoreCombination.FourOfKind;
                    break;
            }
            return value;
        }



        public int FiveDiceValuer(Dictionary<int, int> faceCounts)
        {
            int[] frequencyCounts = faceCounts.Values.ToArray();

            int value = 0;
            switch (frequencyCounts)
            {
                case int[] x when x.Any(v => v == 5):
                    value = (int)ScoreCombination.FiveOfKind;
                    break;
            }

            return value;
        }


        public int SixDiceValuer(Dictionary<int, int> faceCounts)
        {
            int[] frequencyCounts = faceCounts.Values.ToArray();




            int value = 0;
            switch (frequencyCounts)
            {
                case int[] x when x.All(v => v == 1):
                    value = (int)ScoreCombination.Straight;
                    break;

                case int[] x when x.Any(v => v == 6):
                    value = (int)ScoreCombination.SixOfKind;
                    break;

                case int[] x when x.Any(v => v == 2) && x.Any(v => v == 4):
                    value = (int)ScoreCombination.FullHouse;
                    break;

                case int[] x when x.Count(v => v == 2) == 3:
                    value = (int)ScoreCombination.ThreePairs;
                    break;

                case int[] x when x.Count(v => v == 3) == 2:
                    value = (int)ScoreCombination.TwoTriplets;
                    break;
            }

            return value;
        }
    }
}
