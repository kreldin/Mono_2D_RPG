using System.Collections.Generic;

namespace RpgLibrary.Skills
{
    public enum DifficultyLevel
    {
        Master = -25,
        Expert = -10,
        Improved = -5,
        Normal = 0,
        Easy = 10
    }

    public class Skill
    {
        public string SkillName { get; private set; }
        public int SkillValue { get; private set; }
        public string PrimaryAttribute { get; }
        public Dictionary<string, int> ClassModifiers { get; } = new Dictionary<string, int>();

        public void IncreaseSkill(int value)
        {
            SkillValue += value;

            if (SkillValue > 100)
                SkillValue = 100;
        }

        public void DecreaseSkill(int value)
        {
            SkillValue -= value;

            if (SkillValue < 0)
                SkillValue = 0;
        }

        public static Skill FromSkillData(SkillData data)
        {
            var skill = new Skill { SkillName = data.Name };

            foreach (var s in data.ClassModifiers.Keys)
                skill.ClassModifiers.Add(s, data.ClassModifiers[s]);

            return skill;
        }

        public static int AttributeModifier(int attribute)
        {
            int result;

            if (attribute < 25)
                result = 1;
            else if (attribute < 50)
                result = 2;
            else if (attribute < 75)
                result = 3;
            else if (attribute < 90)
                result = 4;
            else if (attribute < 95)
                result = 5;
            else
                result = 10;

            return result;
        }
    }
}