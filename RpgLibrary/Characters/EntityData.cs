namespace RpgLibrary.Characters
{
    public class EntityData
    {
        public string Name { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Cunning { get; set; }
        public int Willpower { get; set; }
        public int Magic { get; set; }
        public int Constitution { get; set; }

        public string HealthFormula;
        public string StaminaFormula;
        public string MagicFormula;

        protected EntityData()
        {
        }

        public static void ToFile(string fileName)
        {
            
        }

        public static EntityData FromFile(string fileName)
        {
            return new EntityData();
        }
    }
}
