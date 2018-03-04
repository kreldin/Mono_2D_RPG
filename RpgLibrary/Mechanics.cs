using System;
using System.Linq;
using RpgLibrary.Characters;
using RpgLibrary.Skills;

namespace RpgLibrary
{
    public enum DieType { D4 = 4, D6 = 6, D8 = 8, D10 = 10, D12 = 12, D20 = 20, D100 = 100}

    public static class Mechanics
    {
        private static readonly Random Random = new Random();

        public static int RollDie(DieType die)
        {
            return Random.Next(0, (int) die) + 1;
        }

        public static bool UseSkill(Skill skill, Entity entity, DifficultyLevel difficulty)
        {
            var result = false;

            var target = 
                skill.SkillValue + (int) difficulty +
                skill.ClassModifiers.Keys.Where(s => s == entity.Class).Sum(s => skill.ClassModifiers[s]) +
                entity.SkillModifiers.Where(m => m.Modifying == skill.SkillName).Sum(m => m.Amount);

            var lower = skill.PrimaryAttribute.ToLower();

            switch (lower)
            {
                case "strength":
                    target += Skill.AttributeModifier(entity.Strength);
                    break;
                case "dexterity":
                    target += Skill.AttributeModifier(entity.Dexterity);
                    break;
                case "cunning":
                    target += Skill.AttributeModifier(entity.Cunning);
                    break;
                case "willpower":
                    target += Skill.AttributeModifier(entity.Willpower);
                    break;
                case "magic":
                    target += Skill.AttributeModifier(entity.Magic);
                    break;
                case "constitution":
                    target += Skill.AttributeModifier(entity.Constitution);
                    break;
            }

            if (RollDie(DieType.D100) <= target)
                result = true;

            return result;
        }
    }
}
