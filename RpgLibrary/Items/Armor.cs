using System;
using System.Text;

namespace RpgLibrary.Items
{
    public class Armor : BaseItem
    {
        public ArmorLocation Location { get; protected set; }

        public int DefenseValue { get; protected set; }

        public int DefenseModifier { get; protected set; }

        public Armor(string name, string type, int price, float weight,
            ArmorLocation location, int defenseValue, int defenseModifier, params Type[] allowableClasses) : base(name, type, price, weight, allowableClasses)
        {
            Location = location;
            DefenseValue = defenseValue;
            DefenseModifier = defenseModifier;
        }

        public override object Clone()
        {
            var allowedClasses = new Type[AllowableClasses.Count];

            AllowableClasses.CopyTo(allowedClasses, 0);

            return new Armor(Name, Type, Price, Weight, Location, DefenseValue, DefenseModifier, allowedClasses);
        }

        public override string ToString()
        {
            const string itemDivider = ", ";
            var itemString = new StringBuilder(base.ToString());
            itemString.Append(itemDivider).Append(Location).Append(itemDivider);
            itemString.Append(DefenseValue.ToString()).Append(itemDivider);
            itemString.Append(DefenseModifier.ToString());

            foreach (var t in AllowableClasses)
            {
                itemString.Append(itemDivider).Append(t.Name);
            }

            return itemString.ToString();
        }
    }
}
