using System;
using System.Text;

namespace RpgLibrary.Characters
{
    public class EntityData : ICloneable
    {
        public string Name { get; private set; }

        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Cunning { get; private set; }
        public int Willpower { get; private set; }
        public int Magic { get; private set; }
        public int Constitution { get; private set; }

        public string HealthFormula { get; private set; }
        public string StaminaFormula { get; private set; }
        public string MagicFormula { get; private set; }

        private EntityData()
        {
        }

        public EntityData(string name, int strength, int dexterity, int cunning, int willpower, int magic,
            int constitution, string health, string stamina, string mana)
        {
            Name = name;
            Strength = strength;
            Dexterity = dexterity;
            Cunning = cunning;
            Willpower = willpower;
            Magic = magic;
            Constitution = constitution;
            HealthFormula = health;
            StaminaFormula = stamina;
            MagicFormula = mana;
        }

        public override string ToString()
        {
            var newString = new StringBuilder();
            const string divider = ", ";

            newString.Append("Name = ").Append(Name).Append(divider);
            newString.Append("Strength = ").Append(Strength.ToString()).Append(divider);
            newString.Append("Dexterity = ").Append(Dexterity.ToString()).Append(divider);
            newString.Append("Cunning = ").Append(Cunning.ToString()).Append(divider);
            newString.Append("Willpower = ").Append(Willpower.ToString()).Append(divider);
            newString.Append("Magic = ").Append(Magic.ToString()).Append(divider);
            newString.Append("Constitution = ").Append(Constitution.ToString()).Append(divider);
            newString.Append("Health Formula = ").Append(HealthFormula).Append(divider);
            newString.Append("Stamina Formula = ").Append(StaminaFormula).Append(divider);
            newString.Append("Magic Formula = ").Append(MagicFormula);

            return newString.ToString();
        }

        public object Clone()
        {
            var data = new EntityData
            {
                Name = Name,
                Strength = Strength,
                Dexterity = Dexterity,
                Cunning = Cunning,
                Willpower = Willpower,
                Magic = Magic,
                Constitution = Constitution,
                HealthFormula = HealthFormula,
                StaminaFormula = StaminaFormula,
                MagicFormula = MagicFormula
            };

            return data;
        }
    }
}
