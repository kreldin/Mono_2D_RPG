using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RpgLibrary.Items
{
    public enum Hands
    {
        One,
        Two
    }

    public enum ArmorLocation
    {
        Body,
        Head,
        Hands,
        Feet
    }

    public abstract class BaseItem : ICloneable
    {
        protected List<string> AllowableClasses { get; } = new List<string>();
        
        public string Name { get; }
        public string Type { get; }
        public int Price { get; }
        public float Weight { get; }
        public bool IsEquipped { get; }

        protected BaseItem(
            string name, string type, int price,
            float weight, params string[] allowableClasses)
        {
            foreach (var charClass in allowableClasses)
                AllowableClasses.Add(charClass);

            Name = name;
            Type = type;
            Price = price;
            Weight = weight;
            IsEquipped = false;
        }

        public abstract object Clone();

        public bool CanEquip(string characterType)
        {
            return AllowableClasses.Contains(characterType);
        }

        public override string ToString()
        {
            const string itemDivider = ", ";
            var itemString = new StringBuilder("");

            itemString.Append(Name).Append(itemDivider);
            itemString.Append(Type).Append(itemDivider);
            itemString.Append(Price.ToString()).Append(itemDivider);
            itemString.Append(Weight.ToString(CultureInfo.CurrentCulture));

            return itemString.ToString();
        }
    }
}
