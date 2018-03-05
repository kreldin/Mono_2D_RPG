using System;
using System.Collections.Generic;
using RpgLibrary.Skills;
using RpgLibrary.Spells;
using RpgLibrary.Talents;

namespace RpgLibrary.Characters
{
    public enum EntityGender {  Male, Female, Unknown }
    public enum EntityType   { Character, NPC, Monster, Creature }

    public sealed class Entity
    {
        private int _strength = 10;
        private int _dexterity = 10;
        private int _cunning = 10;
        private int _willpower = 10;
        private int _magic = 10;
        private int _constitution = 10;

        private int _strengthModifier;
        private int _dexterityModifier;
        private int _cunningModifier;
        private int _willpowerModifier;
        private int _magicModifier;
        private int _constitutionModifier;

        public string Name { get; }
        public string Class { get; }
        public EntityType Type { get; }
        public EntityGender Gender { get; }

        public int Strength
        {
            get => _strength + _strengthModifier;
            private set => _strength = value;
        }

        public int Dexterity
        {
            get => _dexterity + _dexterityModifier;
            private set => _dexterity = value;
        }

        public int Cunning
        {
            get => _cunning + _cunningModifier;
            private set => _cunning = value;
        }

        public int Willpower
        {
            get => _willpower + _willpowerModifier;
            private set => _willpower = value;
        }

        public int Magic
        {
            get => _magic + _magicModifier;
            private set => _magic = value;
        }

        public int Constitution
        {
            get => _constitution + _constitutionModifier;
            private set => _constitution = value;
        }

        public AttributePair Health { get; } = new AttributePair(0);
        public AttributePair Stamina { get; } = new AttributePair(0);
        public AttributePair Mana { get; } = new AttributePair(0);

        public int Level { get; }
        public int Experience { get; }

        public Dictionary<string, Skill> Skills { get; } = new Dictionary<string, Skill>();
        public List<Modifier> SkillModifiers { get; } = new List<Modifier>();

        public Dictionary<string, Spell> Spells { get; } = new Dictionary<string, Spell>();
        public List<Modifier> SpellModifiers { get; } = new List<Modifier>();

        public Dictionary<string, Talent> Talents { get; } = new Dictionary<string, Talent>();
        public List<Modifier> TalentModifiers { get; } = new List<Modifier>();
 
        private int Attack { get; }
        private int Damage { get; }
        private int Defense { get; }

        private Entity()
        {
        }

        public Entity(string name, EntityData data, EntityGender gender, EntityType type)
        {
            Name = name;
            Type = type;
            Gender = gender;
            Class = data.Name;
            Strength = data.Strength;
            Dexterity = data.Dexterity;
            Cunning = data.Cunning;
            Willpower = data.Willpower;
            Magic = data.Magic;
            Constitution = data.Constitution;
        }

        public void Update(TimeSpan elapsedTime)
        {
            foreach (var modifier in SkillModifiers)
                modifier.Update(elapsedTime);

            foreach (var modifier in SpellModifiers)
                modifier.Update(elapsedTime);

            foreach (var modifier in TalentModifiers)
                modifier.Update(elapsedTime);
        }
    }
}
