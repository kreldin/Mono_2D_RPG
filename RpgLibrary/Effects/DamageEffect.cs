using System.Linq;
using RpgLibrary.Characters;

namespace RpgLibrary.Effects
{
    public enum DamageType { Weapon, Poison, Disease, Fire, Ice, Lightning, Earth }

    public enum AttackType { Health, Mana, Stamina }

    public class DamageEffect : BaseEffect
    {
        private DamageType DamageType { get; set; }
        private AttackType AttackType { get; set; }
        private DieType DieType { get; set; }
        private int NumberOfDice { get; set; }
        private int Modifier { get; set; }

        private DamageEffect()
        {

        }

        public static DamageEffect FromDamageEffectData(DamageEffectData data)
        {
            var effect = new DamageEffect
            {
                DamageType = data.DamageType,
                AttackType = data.AttackType,
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

            amount = entity.Weaknesses.Where(weakness => weakness.WeaknessType == DamageType).Aggregate(amount, (current, weakness) => weakness.Apply(current));

            amount = entity.Resistances.Where(resistance => resistance.ResistanceType == DamageType).Aggregate(amount, (current, resistance) => resistance.Apply(current));

            if (amount < 1)
                amount = 1;

            switch (AttackType)
            {
                case AttackType.Health:
                    entity.Health.Damage((ushort)amount);
                    break;
                case AttackType.Mana:
                    entity.Mana.Damage((ushort)amount);
                    break;
                case AttackType.Stamina:
                    entity.Stamina.Damage((ushort)amount);
                    break;
            }
        }
    }
}
