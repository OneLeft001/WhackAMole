using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhackAMole.Objects
{
    static class LevelDifficultyData
    {

        public static readonly Dictionary<string, int> easyLevelData = new Dictionary<string, int> { 
            { "Mole", 5 }
        
        };

        public static readonly Dictionary<string, int> mediumLevelData = new Dictionary<string, int>
        {
            { "Mole", 5 },
            { "Bomb", 6 }
        };

        public static readonly Dictionary<string, int> hardLevelData = new Dictionary<string, int>
        {
            { "Mole", 5 },
            { "Bomb", 6 },
            { "RangerMole", 7 }
        };
        



    }

}
