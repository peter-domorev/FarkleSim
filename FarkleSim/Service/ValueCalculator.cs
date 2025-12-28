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



        public List<TradeOption> Calculate(List<Dice> dice)
        {
            TradeOptions tradeOptions = new TradeOptions();
            Dictionary<int, int> faceCounts = countFaces(dice);


            // count only basic chunks
            List<TradeOption> chunckTradeOptions = calculateChunks(dice);
            tradeOptions.Add(chunckTradeOptions);



            // now deal with singles combinations
            int numOnes = faceCounts[1];
            int numFives = faceCounts[5];

            tradeOptions.Add(calculateSinglesCombinations(1, numOnes, ScoreCombination.SingleOne, dice));
            tradeOptions.Add(calculateSinglesCombinations(5, numFives, ScoreCombination.SingleFive, dice));

            // deal with doubles combinations
            tradeOptions.Add(calculateDoublesCombinations(numOnes, numFives, dice));



           


            return tradeOptions.Options;
        }


        private TradeOptions calculateDoublesCombinations(int numOnes, int numFives, List<Dice> dice)
        {
            TradeOptions tradeOptions = new TradeOptions();

            List<Dice> otherDice = dice; // seperate other dice

            for (int numOnesToTrade = 1; numOnesToTrade <= numOnes; numOnesToTrade++)
            {
                otherDice.Remove(dice.Find(d => d.Number == 1)); // remove for combinations


                for (int numFivesToTrade = 1; numFivesToTrade <= numFives; numFivesToTrade++)
                {
                    int numDice = numOnesToTrade + numFivesToTrade;
                    int score = numOnesToTrade * (int)ScoreCombination.SingleOne + numFivesToTrade * (int)ScoreCombination.SingleFive;


                    TradeOption individualTradeOption = new TradeOption(numDice, score);
                    tradeOptions.Add(individualTradeOption);



                    otherDice.Remove(dice.Find(d => d.Number == 5));
                    List<TradeOption> otherTradeOptions = calculateChunks(otherDice); // find all other chunks

                    // add new combined chunks
                    TradeOptions combinedTradeOptions = new TradeOptions();
                    combinedTradeOptions.Add(otherTradeOptions);
                    combinedTradeOptions.Combine(individualTradeOption);
                    tradeOptions.Add(combinedTradeOptions);
                }
            }
            return tradeOptions;

        }

        /// <summary>
        /// Calculates all combinations with single 5 or single 1 and chunks
        /// </summary>
        /// <param name="single"></param>
        /// <param name="numSingles"></param>
        /// <param name="dice"></param>
        /// <returns></returns>
        private TradeOptions calculateSinglesCombinations(int single, int numSingles, ScoreCombination valueOfSingle, List<Dice> dice)
        {
            TradeOptions tradeOptions = new TradeOptions();

            // just deal with 1's or 5's and combined chunks
            for (int numSinglesToTrade = 1; numSinglesToTrade <= numSingles; numSinglesToTrade++)
            {
                int numDice = numSinglesToTrade; int score = numSinglesToTrade * (int)valueOfSingle;
                TradeOption individualTradeOption = new TradeOption(numDice, score);
                tradeOptions.Add(individualTradeOption);

                // deal with other chunks


                //if (numSinglesToTrade <= dice.Count - 3) // no other chunks can be formed
                
                List<Dice> otherDice = dice; // seperate other dice
                otherDice.Remove(dice.First(d => d.Number == single)); // returns a bool
                List<TradeOption> otherTradeOptions = calculateChunks(otherDice); // find all other chunks


                TradeOptions combinedTradeOptions = new TradeOptions();
                combinedTradeOptions.Add(otherTradeOptions);
                combinedTradeOptions.Combine(individualTradeOption);

                tradeOptions.Add(combinedTradeOptions);

                
            }

            return tradeOptions;
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
