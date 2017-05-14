namespace RpgLibrary.Characters
{
    public enum EntityGender {  Male, Female, Unknown }

    public abstract class Entity
    {
        public string EntityType { get; }

        public EntityGender Gender { get; protected set; }

        public int Strength
        {
            get => strength + strengthModifier;
            protected set => strength = value;
        }

        public int Dexterity
        {
            get => dexterity + dexterityModifier;
            protected set => dexterity = value;
        }

        public int Cunning
        {
            get => cunning + cunningModifier;
            protected set => cunning = value;
        }

        public int Willpower
        {
            get => willpower + willpowerModifier;
            protected set => willpower = value;
        }

        public int Magic
        {
            get => magic + magicModifier;
            protected set => magic = value;
        }

        public int Constitution
        {
            get => constitution + constitutionModifier;
            set => constitution = value;
        }

        public AttributePair Health { get; } = new AttributePair(0);
        public AttributePair Stamina { get; } = new AttributePair(0);
        public AttributePair Mana { get; } = new AttributePair(0);

        public int Level { get; protected set; }
        public int Experience { get; protected set; }

        protected int strength;
        protected int dexterity;
        protected int cunning;
        protected int willpower;
        protected int magic;
        protected int constitution;
        protected int strengthModifier;
        protected int dexterityModifier;
        protected int cunningModifier;
        protected int willpowerModifier;
        protected int magicModifier;
        protected int constitutionModifier;

        protected int Attack { get; }
        protected int Damage { get; }
        protected int Defense { get; }

        private Entity()
        {
            Strength = 0;
            Dexterity = 0;
            Cunning = 0;
            Willpower = 0;
            Magic = 0;
            Constitution = 0;

            Health = new AttributePair(0);
            Stamina = new AttributePair(0);
            Mana = new AttributePair(0);
        }

        protected Entity(EntityData entityData)
        {
            EntityType = entityData.Name;

            Strength = entityData.Strength;
            Dexterity = entityData.Dexterity;
            Cunning = entityData.Cunning;
            Willpower = entityData.Willpower;
            Magic = entityData.Magic;
            Constitution = entityData.Constitution;
        }
    }
}
