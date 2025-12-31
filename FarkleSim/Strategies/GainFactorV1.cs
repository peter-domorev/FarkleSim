using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class GainFactorV1 : Player
    {
        // working on thresholds and means from 0 gain, assume no 2nd roll stats

        protected override int numDiceToTrade(TradeData tradeData)
        {
            makeDecision(tradeData, out int numDiceTradingIn, out bool isStanding);
            return numDiceTradingIn;
        }


        protected override bool willStand(TradeData tradeData)
        {
            makeDecision(tradeData, out int numDiceTradingIn, out bool isStanding);
            return isStanding;
        }



        protected override void makeDecision(TradeData tradeData, out int numDiceTradingIn, out bool isStanding)
        {
            numDiceTradingIn = 0;
            isStanding = false;

            int runningScore = tradeData.RunningScore;
            int numDiceRolled = tradeData.NumDiceRolled;


            /*
            if (runningScore > getThreshold(numDiceRolled))
            {
                isStanding = true;
                
                return;
            }*/
            // if above 0 gain threshold for number of dice just rolled, stop



            int maxTradeableScore = tradeData.GetMaxScore();
            if (maxTradeableScore > getMean(numDiceRolled - 1) || runningScore > getThreshold(numDiceRolled))
            {
                numDiceTradingIn = tradeData.GetNumDice(maxTradeableScore); // if tradeable amount is above the next mean, stop
                isStanding = true;
            }

            // else, take min number of dice
            numDiceTradingIn = tradeData.GetMinNumDice();
        }








        private int getThreshold(int numDice)
        {
            int threshold;

            switch (numDice)
            {
                case 1:
                    threshold = 0;
                    break;

                case 2:
                    threshold = 51;
                    break;
                case 3:
                    threshold = 201;
                    break;
                case 4:
                    threshold = 701;
                    break;

                case 5:
                    threshold = 2401;
                    break;

                case 6:
                    threshold = 16551;
                    break;

                default:
                    throw new Exception("numDice is too large");
            }
            return threshold;
        }

        private int getMean(int numDice)
        {
            int mean;

            switch (numDice)
            {
                case 1:
                    mean = 24;
                    break;

                case 2:
                    mean = 50;
                    break;
                case 3:
                    mean = 83;
                    break;
                case 4:
                    mean = 132;
                    break;

                case 5:
                    mean = 202;
                    break;

                case 6:
                    mean = 390;
                    break;

                default:
                    throw new Exception("numDice is too large");
            }
            return mean;
        }
    }
}
