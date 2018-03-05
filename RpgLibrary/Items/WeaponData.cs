using System.Text;
using RpgLibrary.Effects;

namespace RpgLibrary.Items
{
    public class WeaponData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public Hands NumberHands;
        public int AttackValue;
        public int AttackModifier;
        public DamageEffectData DamageEffectData;
        public string[] AllowableClasses;

        public WeaponData()
        {
        }

        public override string ToString()
        {
            var newString = new StringBuilder();
            const string divider = ", ";

            newString.Append(Name).Append(divider);
            newString.Append(Type).Append(divider);
            newString.Append(Price).Append(divider);
            newString.Append(Weight).Append(divider);
            newString.Append(NumberHands).Append(divider);
            newString.Append(AttackValue).Append(divider);
            newString.Append(AttackModifier).Append(divider);
            newString.Append(DamageEffectData);

            foreach (var s in AllowableClasses)
                newString.Append(divider).Append(s);

            return newString.ToString();
        }
    }
}
