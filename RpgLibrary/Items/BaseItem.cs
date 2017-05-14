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

    public abstract class BaseItem
    {
        protected List<Type> AllowableClasses { get; } = new List<Type>();
        
        public string Name { get; protected set; }
        public string Type { get; protected set; }
        public int Price { get; protected set; }
        public float Weight { get; protected set; }
        public bool IsEquipped { get; protected set; }

        protected BaseItem(string name, string type, int price, float weight, params Type[] allowableClasses)
        {
            foreach (var t in allowableClasses)
            {
                AllowableClasses.Add(t);
            }

            Name = name;
            Type = type;
            Price = price;
            Weight = weight;
            IsEquipped = false;
        }

        public abstract object Clone();

        public virtual bool CanEquip(Type characterType)
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
