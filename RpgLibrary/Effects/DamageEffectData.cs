using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Effects
{ 
    public class DamageEffectData : BaseEffectData
    {
        public DamageType DamageType { get; set; }
        public AttackType AttackType { get; set; }
        public DieType DieType { get; set; }
        public int NumberOfDice { get; set; }
        public int Modifier { get; set; }

        public DamageEffectData()
        {
            
        }
    }
}
