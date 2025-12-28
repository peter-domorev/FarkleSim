using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarkleSim
{
    public enum ScoreCombination
    {
        TripOnes=300,
        TripTwos=200,
        TripThrees=300,
        TripFours=400,
        TripFives=500,
        TripSixes=600,

        SingleFive=50,
        SingleOne=100,

        FourOfKind=1000,

        FiveOfKind=2000,

        SixOfKind=3000,
        Straight=1500,
        ThreePairs=1500,
        TwoTriplets=2500,
        FullHouse=2000,
    }
}
