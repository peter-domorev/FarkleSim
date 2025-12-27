using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class Player
    {
        private const int NUM_DICE = 6;
        private Dice[] _dice = new Dice[NUM_DICE];

        public Dice[] Dice => _dice;

        public Player()
        {
            for(int i = 0; i < NUM_DICE; i++)
            {
                _dice[i] = new Dice();
            }
        }

        

    }
}
