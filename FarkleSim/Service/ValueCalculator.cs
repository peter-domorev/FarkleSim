using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class ValueCalculator
    {
        private Valuer _valuer = new Valuer();



        public TradeOptions Calculate(List<Dice> dice)
        {
            Dictionary<int, int> faceCounts = countFaces(dice);




            int numOnes = faceCounts[1];
            int numFives = faceCounts[5];
            TradeOptions tradeOptions = calculateAllCombos(numOnes, numFives, dice);



           


            return tradeOptions;
        }



        private TradeOptions calculateAllCombos(int numOnes, int numFives, List<Dice> dice)
        {
            TradeOptions tradeOptions = new TradeOptions();


            // get vanilla chunk trade options
            TradeOptions chunkTradeOptions = calculateChunks(dice);
            tradeOptions.Add(chunkTradeOptions);



            List<Dice> removeOnesDice = dice;
            List<Dice> removeFivesDice;
            int numOnesToTrade = 0; int numFivesToTrade = 0;

            for (numOnesToTrade = 0; numOnesToTrade <= numOnes; numOnesToTrade++)
            {
                removeFivesDice = removeOnesDice;


                for (numFivesToTrade = 0; numFivesToTrade <= numFives; numFivesToTrade++)
                {
                    if (numOnesToTrade == 0 && numFivesToTrade == 0) continue;


                    removeFivesDice.Remove(dice.Find(d => d.Number == 5)); // remove for further combinations

                    // get singles trade options
                    int numDice = numOnesToTrade + numFivesToTrade;
                    int score = numOnesToTrade * (int)ScoreCombination.SingleOne + numFivesToTrade * (int)ScoreCombination.SingleFive;
                    TradeOption singlesTradeOption = new TradeOption(numDice, score); // keep to combine with chunks
                    tradeOptions.Add(singlesTradeOption);

                    // get leftover chunk trade options
                    TradeOptions leftoverChunkTradeOptions = calculateChunks(removeFivesDice);
                    // then combine with singles trade options
                    leftoverChunkTradeOptions.Combine(singlesTradeOption);
                    tradeOptions.Add(leftoverChunkTradeOptions);


                }



                removeOnesDice.Remove(dice.Find(d => d.Number == 1)); // remove for further combinations

            }


            

            return tradeOptions;
        }



        private TradeOptions calculateChunks(List<Dice> dice)
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

            return tradeOptions;
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
