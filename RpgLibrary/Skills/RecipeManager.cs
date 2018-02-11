using System.Collections.Generic;

namespace RpgLibrary.Skills
{
    public class RecipeManager
    {
        public Dictionary<string, Recipe> Recipes { get; } = new Dictionary<string, Recipe>();
    }
}
