using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Content;
using RpgLibrary.Characters;
using RpgLibrary.Items;
using RpgLibrary.Skills;

namespace MonoRPG
{
    internal static class DataManager
    {
        public static Dictionary<string, ArmorData> Armor { get; } = new Dictionary<string, ArmorData>();

        public static Dictionary<string, WeaponData> Weapons { get; } = new Dictionary<string, WeaponData>();

        public static Dictionary<string, ShieldData> Shields { get; } = new Dictionary<string, ShieldData>();

        public static Dictionary<string, KeyData> Keys { get; } = new Dictionary<string, KeyData>();

        public static Dictionary<string, ChestData> Chests { get; } = new Dictionary<string, ChestData>();

        public static Dictionary<string, EntityData> Entities { get; } = new Dictionary<string, EntityData>();

        public static Dictionary<string, SkillData> Skills { get; } = new Dictionary<string, SkillData>();

        public static void ReadEntityData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Classes", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Classes\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<EntityData>(filename);
                Entities.Add(data.Name, data);
            }
        }

        public static void ReadArmorData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Items\Armor", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Items\Armor\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<ArmorData>(filename);
                Armor.Add(data.Name, data);
            }
        }

        public static void ReadWeaponData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Items\Weapon", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Items\Weapon\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<WeaponData>(filename);
                Weapons.Add(data.Name, data);
            }
        }

        public static void ReadShieldData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Items\Shield", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Items\Shield\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<ShieldData>(filename);
                Shields.Add(data.Name, data);
            }
        }

        public static void ReadKeyData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Keys", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Keys\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<KeyData>(filename);
                Keys.Add(data.Name, data);
            }
        }

        public static void ReadChestData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Chests", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Chests\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<ChestData>(filename);
                Chests.Add(data.Name, data);
            }
        }

        public static void ReadSkillData(ContentManager content)
        {
            var filenames = Directory.GetFiles(@"Content\Game\Skills", "*.xnb");

            foreach (var name in filenames)
            {
                var filename = @"Game\Skills\" + Path.GetFileNameWithoutExtension(name);
                var data = content.Load<SkillData>(filename);
                Skills.Add(data.Name, data);
            }
        }
    }
}
