using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public class Dice
    {
        Random _rng = new Random();
        private int _number;

        public int Number => _number;

        public Dice()
        {
            Roll();
        }


        public void Roll()
        {
            const int NUM_FACES = 6;
            int roll = _rng.Next(NUM_FACES) + 1;
            _number = roll;
        }
    }
}
