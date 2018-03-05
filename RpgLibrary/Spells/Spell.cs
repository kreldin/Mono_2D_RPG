using System.Collections.Generic;
using System.Linq;
using RpgLibrary.Characters;
using RpgLibrary.Talents;

namespace RpgLibrary.Spells
{
    public class Spell
    {
        public string Name { get; private set; }
        public List<string> AllowedClasses { get; } = new List<string>();
        public Dictionary<string, int> AttributeRequirements { get; } = new Dictionary<string, int>();
        public List<string> SpellPrerequisites { get; } = new List<string>();
        public int LevelRequirement { get; }
        public SpellType SpellType { get; }
        public int ActivationCost { get; }
        public List<string> Effects { get; } = new List<string>();

        public static Spell FromTalentData(SpellData data)
        {
            var talent = new Spell
            {
                Name = data.Name
            };

            foreach (var s in data.AllowedClasses)
                talent.AllowedClasses.Add(s.ToLower());

            foreach (var s in data.AttributeRequirements.Keys)
            {
                talent.AttributeRequirements.Add(
                    s.ToLower(),
                    data.AttributeRequirements[s]);
            }

            foreach (var s in data.SpellPrerequisites)
                talent.SpellPrerequisites.Add(s);

            foreach (var s in data.Effects)
                talent.Effects.Add(s);

            return talent;
        }

        public static bool CanLearn(Entity entity, Talent talent)
        {
            var canLearn = !(entity.Level < talent.LevelRequirement);

            var entityClass = entity.Class.ToLower();

            if (!talent.AllowedClasses.Contains(entityClass))
                canLearn = false;

            if (talent.AttributeRequirements.Keys.Any(s => Mechanics.GetAttributeByString(entity, s) < talent.AttributeRequirements[s]))
                canLearn = false;

            if (talent.TalentPrerequisites.Any(s => !entity.Talents.ContainsKey(s)))
                canLearn = false;

            return canLearn;
        }
    }
}
