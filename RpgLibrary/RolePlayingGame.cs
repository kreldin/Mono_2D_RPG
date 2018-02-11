namespace RpgLibrary
{
    public class RolePlayingGame
    {
        public string Name { get; set; }
        public string Description { get; set; }

        private RolePlayingGame()
        {
            
        }

        public RolePlayingGame(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
