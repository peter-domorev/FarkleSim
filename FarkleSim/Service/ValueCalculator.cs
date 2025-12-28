using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class ValueCalculator
    {
        private Valuer _valuer = new Valuer();



        public List<TradeOption> Calculate(List<Dice> dice)
        {
            TradeOptions tradeOptions = new TradeOptions();
            Dictionary<int, int> faceCounts = countFaces(dice);


            // count only basic chunks
            List<TradeOption> chunckTradeOptions = calculateChunks(dice);
            tradeOptions.Add(chunckTradeOptions);



            // now deal with combinations
            int numOnes = faceCounts[1];
            int numFives = faceCounts[5];

            // just deal with 1's
            for(int numOnesToTrade = 1; numOnesToTrade <= numOnes; numOnesToTrade++)
            {
                tradeOptions.Add(numOnesToTrade, numOnesToTrade * (int)ScoreCombination.SingleOne);

                // deal with other chunks
                List<Dice> otherDice = dice.




                if (numOnesToTrade <= 3)
                { 
                }
            }

            // just deal with 5's
            for(int numFivesToTrade = 1; numFivesToTrade <= numFives; numFivesToTrade++)
            {
                tradeOptions.Add(numFivesToTrade, numFivesToTrade * (int)ScoreCombination.SingleFive);

                if (numFivesToTrade <= 3)
                {

                }
            }


            // deal with combo of 1's and 5's


           


            return tradeOptions.Options;
        }




        private List<TradeOption> calculateChunks(List<Dice> dice)
        {
            TradeOptions tradeOptions = new TradeOptions();
            Dictionary<int, int> faceCounts = countFaces(dice);


            int sixDiceValue = _valuer.SixDiceValuer(faceCounts);
            if (sixDiceValue != 0) tradeOptions.Add(6, sixDiceValue);

            int fiveDiceValue = _valuer.FiveDiceValuer(faceCounts);
            if (fiveDiceValue != 0) tradeOptions.Add(5, fiveDiceValue);

            int fourDiceValue = _valuer.FourDiceValuer(faceCounts);
            if (fourDiceValue != 0) tradeOptions.Add(4, fourDiceValue);

            int[] threeDiceValue = _valuer.ThreeDiceValuer(faceCounts);
            switch (threeDiceValue)
            {
                case int[] x when x[0] != 0 && x[1] != 0:
                    tradeOptions.Add(3, x[0]);
                    tradeOptions.Add(3, x[1]);
                    break;

                case int[] x when x[0] != 0 || x[1] != 0:
                    int value = x.FirstOrDefault(v => v != 0);
                    tradeOptions.Add(3, value);
                    break;
            }

            return tradeOptions.Options;
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



    }
}
