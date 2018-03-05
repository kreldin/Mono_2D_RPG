using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Effects
{
    public class HealEffectData
    {
        public HealType HealType { get; set; }
        public DieType DieType { get; set; }
        public int NumberOfDice { get; set; }
        public int Modifier { get; set; }

        public HealEffectData()
        {
            
        }
    }
}
