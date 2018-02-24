using System.Collections.Generic;
using System.Text;

namespace RpgLibrary.Skills
{
    public class SkillData
    {
        public string Name { get; set; }
        public string PrimaryAttribute { get; set; }
        public Dictionary<string, int> ClassModifiers { get; set; } = new Dictionary<string, int>();

        public SkillData()
        {
            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name).Append(", ");
            sb.Append(PrimaryAttribute);

            foreach (var s in ClassModifiers.Keys)
                sb.Append(", ").Append(s).Append("+").Append(ClassModifiers[s].ToString());

            return sb.ToString();
        }
    }
}
