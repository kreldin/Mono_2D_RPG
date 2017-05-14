using System;
using System.Text;

namespace RpgLibrary.Items
{
    public class Weapon : BaseItem
    {
        public Hands NumberHands { get; protected set; }

        public int AttackValue { get; protected set; }

        public int AttackModifier { get; protected set; }

        public int DamageValue { get; protected set; }

        public int DamageModifier { get; protected set; }

        public Weapon(string name, string type, int price, float weight,
            Hands hands, int attackValue, int attackModifier, int damageValue, int damageModifier, 
            params Type[] allowableClasses) : base(name, type, price, weight, allowableClasses)
        {
            NumberHands = hands;
            AttackValue = attackValue;
            AttackModifier = attackModifier;
            DamageValue = damageValue;
            DamageModifier = damageModifier;
        }

        public override object Clone()
        {
            var allowedClasses = new Type[AllowableClasses.Count];

            AllowableClasses.CopyTo(allowedClasses, 0);

            return new Weapon(Name, Type, Price, Weight, NumberHands, AttackValue, AttackModifier, DamageValue, DamageModifier, allowedClasses);
        }

        public override string ToString()
        {
            const string itemDivider = ", ";
            var itemString = new StringBuilder(base.ToString());
            itemString.Append(itemDivider).Append(NumberHands).Append(itemDivider);
            itemString.Append(AttackValue.ToString()).Append(itemDivider);
            itemString.Append(AttackModifier.ToString()).Append(itemDivider);
            itemString.Append(DamageValue.ToString()).Append(itemDivider);
            itemString.Append(DamageModifier.ToString());

            foreach (var t in AllowableClasses)
            {
                itemString.Append(itemDivider).Append(t.Name);
            }

            return itemString.ToString();
        }
    }
}
