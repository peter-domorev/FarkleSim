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
        protected List<Dice> _dice = new List<Dice>();

        protected ValueCalculator _valueCalc = new ValueCalculator();
        protected TradeOptionsSorter _sorter = new TradeOptionsSorter();

        public List<Dice> Dice => _dice;

        public Player()
        {
            for (int i = 0; i < NUM_DICE; i++)
            {
                _dice.Add(new Dice());
            }
        }

        public abstract int PlayTurn();

        protected void RollDice()
        {
            foreach (Dice dice in _dice) dice.Roll();
        }
    }
}
