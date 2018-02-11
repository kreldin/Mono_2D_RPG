using System;
using System.Text;

namespace RpgLibrary.Characters
{
    public class EntityData : ICloneable
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Cunning { get; set; }
        public int Willpower { get; set; }
        public int Magic { get; set; }
        public int Constitution { get; set; }

        public string HealthFormula { get; set; }
        public string StaminaFormula { get; set; }
        public string MagicFormula { get; set; }

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

            newString.Append(Name).Append(divider);
            newString.Append(Strength.ToString()).Append(divider);
            newString.Append(Dexterity.ToString()).Append(divider);
            newString.Append(Cunning.ToString()).Append(divider);
            newString.Append(Willpower.ToString()).Append(divider);
            newString.Append(Magic.ToString()).Append(divider);
            newString.Append(Constitution.ToString()).Append(divider);
            newString.Append(HealthFormula).Append(divider);
            newString.Append(StaminaFormula).Append(divider);
            newString.Append(MagicFormula);

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
