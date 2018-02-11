namespace RpgLibrary.Skills
{
    public struct Reagents
    {
        public string Name;
        public ushort AmountRequired;

        public Reagents(string name, ushort amountRequired)
        {
            Name = name;
            AmountRequired = amountRequired;
        }
    }

    public class Recipe
    {
        public string Name { get; set; }
        public Reagents[] Reagents { get; set; }

        private Recipe()
        {
            
        }

        public Recipe(string name, params Reagents[] reagents)
        {
            Name = name;

            if (reagents.Length <= 0) return;

            Reagents = new Reagents[reagents.Length];

            reagents.CopyTo(Reagents, 0);
        }
    }
}
