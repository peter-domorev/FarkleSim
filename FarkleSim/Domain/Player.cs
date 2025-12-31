using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public abstract class Player : IPlayer
    {
        private const int NUM_DICE = 6;
        private List<Dice> _dice = new List<Dice>();
        private int _score = 0;

        private ValueCalculator _valueCalc = new ValueCalculator();
        private TradeOptionsSorter _sorter = new TradeOptionsSorter();

        public List<Dice> Dice => _dice;
        public int Score => _score;



        public Player()
        {
            for (int i = 0; i < NUM_DICE; i++)
            {
                _dice.Add(new Dice());
            }
        }

        public int PlayTurn()
        {
            int score = gameFramework(makeDecision);

            return score;
        }



        private TradeOptions RollDiceGetTrades(int numDice)
        {
            Console.WriteLine($"Rolling {numDice} dice!");
            List<Dice> diceToRoll = _dice.GetRange(0, numDice).ToList();
            foreach (Dice dice in diceToRoll) dice.Roll();

            TradeOptions tradeOptions = _valueCalc.Calculate(diceToRoll.ToList()); // TO LIST
            tradeOptions = _sorter.Clean(tradeOptions);

            foreach (Dice dice in diceToRoll) Console.WriteLine($"Dice: {dice.Number}");
            foreach (TradeOption tradeOption in tradeOptions.Options) Console.WriteLine($"Trade option: Number to trade: {tradeOption.NumDice}, Score in return: {tradeOption.Score}");

            return tradeOptions;
        }


        private int gameFramework(MakeDecision makeDecision)
        {
            int score = 0;
            bool isStanding = false;



            int numDiceToRoll = 6;
            while (!isStanding)
            {
                if (numDiceToRoll == 0) numDiceToRoll = 6;
                TradeData tradeData = new TradeData(numDiceToRoll, score); // add other trade data
                tradeData.Add(RollDiceGetTrades(numDiceToRoll));




                if (tradeData.IsBust)
                {
                    return score = 0;
                    Console.WriteLine("Bust!\n");
                }

                makeDecision(tradeData, out int numDiceTradingIn, out isStanding);


                if (!isStanding) numDiceToRoll -= numDiceTradingIn;

                score += tradeData.GetScore(numDiceTradingIn);


                Console.WriteLine($"DECISION: Number of dice trading: {numDiceTradingIn}, New Score {score}\n");
            }
                
            return score;
        }

        protected abstract int numDiceToTrade(TradeData tradeData);
        protected abstract bool willStand(TradeData tradeData);
        protected abstract void makeDecision(TradeData tradeData, out int numDiceTradingIn, out bool isStanding);

        protected delegate void MakeDecision(TradeData tradeData, out int numDiceTradingIn, out bool isStanding);
    }
}
