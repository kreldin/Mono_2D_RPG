using System.Text;

namespace RpgLibrary.Items
{
    public class Shield : BaseItem
    {
        public int DefenseValue { get; protected set; }
        public int DefenseModifier { get; protected set; }

        public Shield(
            string name, string type, int price, float weight,
            int defenseValue, int defenseModifier, params string[] allowableClasses) 
            : base(name, type, price, weight, allowableClasses)
        {
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }

        public override object Clone()
        {
            var allowedClasses = new string[AllowableClasses.Count];

            AllowableClasses.CopyTo(allowedClasses, 0);

            return new Shield(Name, Type, Price, Weight, DefenseValue, DefenseModifier, allowedClasses);
        }

        public override string ToString()
        {
            const string itemDivider = ", ";
            var itemString = new StringBuilder(base.ToString());

            itemString.Append(DefenseValue.ToString()).Append(itemDivider);
            itemString.Append(DefenseModifier.ToString());

            foreach (var charClass in AllowableClasses)
                itemString.Append(itemDivider).Append(charClass);

            return itemString.ToString();
        }
    }
}
