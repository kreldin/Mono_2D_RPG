using System.Text;

namespace RpgLibrary.Items
{
    public class ShieldData
    {
        public string Name;
        public string Type;
        public int Price;
        public float Weight;
        public bool Equipped;
        public int DefenseValue;
        public int DefenseModifier;
        public string[] AllowableClasses;

        public ShieldData()
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
            newString.Append(DefenseValue).Append(divider);
            newString.Append(DefenseModifier).Append(divider);

            foreach (var s in AllowableClasses)
                newString.Append(divider).Append(s);

            return newString.ToString();
        }
    }
}
