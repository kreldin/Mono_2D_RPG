using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgLibrary.Characters;

namespace RpgLibrary.Effects
{
    public enum HealType { Health, Mana, Stamina }

    public class HealEffect : BaseEffect
    {
        private HealType HealType { get; set; }
        private DieType DieType { get; set; }
        private int NumberOfDice { get; set; }
        private int Modifier { get; set; }

        private HealEffect()
        {
            
        }

        public static HealEffect FromHealEffectData(HealEffectData data)
        {
            var effect = new HealEffect
            {
                HealType = data.HealType,
                DieType = data.DieType,
                NumberOfDice = data.NumberOfDice,
                Modifier = data.Modifier
            };

            return effect;
        }

        public override void Apply(Entity entity)
        {
            var amount = Modifier;

            for (var i = 0; i < NumberOfDice; ++i)
                amount += Mechanics.RollDie(DieType);

            if (amount < 1)
                amount = 1;

            switch (HealType)
            {
                case HealType.Health:
                    entity.Health.Heal((ushort) amount);
                    break;
                case HealType.Mana:
                    entity.Mana.Heal((ushort) amount);
                    break;
                case HealType.Stamina:
                    entity.Stamina.Heal((ushort) amount);
                    break;
            }
        }
    }
}
