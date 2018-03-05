using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.Spells
{
    public enum SpellType { Passive, Sustained, Activated }

    public class SpellData
    {
        public string Name { get; set; }
        public string[] AllowedClasses { get; set; }
        public Dictionary<string, int> AttributeRequirements { get; set; } = new Dictionary<string, int>();
        public string[] SpellPrerequisites { get; set; }
        public int LevelRequirement { get; set; }
        public SpellType SpellType { get; set; }
        public int ActivationCost { get; set; }
        public string[] Effects { get; set; }

        public SpellData()
        {

        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name);

            foreach (var s in AllowedClasses)
                sb.Append(", ").Append(s);

            foreach (var s in AttributeRequirements.Keys)
                sb.Append(", ").Append(s).Append("+").Append(AttributeRequirements[s]);

            foreach (var s in SpellPrerequisites)
                sb.Append(", ").Append(s);

            sb.Append(", ").Append(LevelRequirement);

            sb.Append(", ").Append(SpellType);

            sb.Append(", ").Append(ActivationCost);

            foreach (var s in Effects)
                sb.Append(", ").Append(s);

            return sb.ToString();
        }
    }
}
