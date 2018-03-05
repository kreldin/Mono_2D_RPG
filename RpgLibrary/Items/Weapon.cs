using System.Text;
using RpgLibrary.Effects;

namespace RpgLibrary.Items
{
    public class Weapon : BaseItem
    {
        public Hands NumberHands { get; protected set; }
        public int AttackValue { get; protected set; }
        public int AttackModifier { get; protected set; }
        public DamageEffectData DamageEffectData { get; protected set; }
        public int DamageModifier { get; protected set; }

        public Weapon(
            string name, string type, int price, float weight,
            Hands hands, int attackValue, int attackModifier,
            DamageEffectData damageEffectData,
            params string[] allowableClasses)
            : base(name, type, price, weight, allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageEffectData = damageEffectData;
        }

        public override object Clone()
        {
            var allowedClasses = new string[AllowableClasses.Count];

            AllowableClasses.CopyTo(allowedClasses, 0);

            return new Weapon(Name, Type, Price, Weight, NumberHands, AttackValue, AttackModifier, DamageEffectData, allowedClasses);
        }

        public override string ToString()
        {
            const string itemDivider = ", ";
            var itemString = new StringBuilder(base.ToString());

            itemString.Append(itemDivider).Append(NumberHands).Append(itemDivider);
            itemString.Append(AttackValue.ToString()).Append(itemDivider);
            itemString.Append(AttackModifier.ToString()).Append(itemDivider);
            itemString.Append(DamageEffectData);

            foreach (var charClass in AllowableClasses)
                itemString.Append(itemDivider).Append(charClass);

            return itemString.ToString();
        }
    }
}
