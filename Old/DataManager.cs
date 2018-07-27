using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

using RpgLibrary.CharacterClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.SkillClasses;
using RpgLibrary.SpellClasses;
using RpgLibrary.TalentClasses;
using RpgLibrary.TrapClasses;
using RpgLibrary.ConversationClasses;
using RpgLibrary.QuestClasses;
using RpgLibrary.DecisionClasses;

namespace EyesOfTheDragon.Components
{
    static public class DataManager
    {
        #region Field Region

        static Dictionary<int, BaseItem> item = new Dictionary<int, BaseItem>();

        static Dictionary<string, ArmorData> armor = new Dictionary<string,ArmorData>();
        static Dictionary<string, WeaponData> weapons = new Dictionary<string,WeaponData>();
        static Dictionary<string, ShieldData> shields = new Dictionary<string,ShieldData>();

        static Dictionary<string, KeyData> keys = new Dictionary<string, KeyData>();
        static Dictionary<string, ChestData> chests = new Dictionary<string, ChestData>();

        static Dictionary<string, EntityData> entities = new Dictionary<string,EntityData>();

        static Dictionary<string, SkillData> skills = new Dictionary<string, SkillData>();

        static Dictionary<string, NonPlayerCharacterData> npcs = new Dictionary<string, NonPlayerCharacterData>();

        static Dictionary<string, ConversationData> conversations = new Dictionary<string, ConversationData>();

        static Dictionary<string, QuestData> quests = new Dictionary<string, QuestData>();

        static DecisionData decisions = new DecisionData();

        static List<ObjectiveData> objectives = new List<ObjectiveData>();

        #endregion

        #region Property Region

        public static Dictionary<int, BaseItem> ItemData
        {
            get { return item; }
        }

        public static Dictionary<string, NonPlayerCharacterData> NPCData
        {
            get { return npcs; }
        }

        public static Dictionary<string, ArmorData> ArmorData
        {
            get { return armor; }
        }

        public static Dictionary<string, WeaponData> WeaponData
        {
            get { return weapons; }
        }

        public static Dictionary<string, ShieldData> ShieldData
        {
            get { return shields; }
        }

        public static Dictionary<string, EntityData> EntityData
        {
            get { return entities; }
        }

        public static Dictionary<string, ChestData> ChestData
        {
            get { return chests; }
        }

        public static Dictionary<string, KeyData> KeyData
        {
            get { return keys; }
        }

        public static Dictionary<string, SkillData> SkillData
        {
            get { return skills; }
        }

        public static Dictionary<string, ConversationData> ConversationData
        {
            get { return conversations; }
        }

        public static Dictionary<string, QuestData> QuestData
        {
            get { return quests; }
        }
        
        public static DecisionData DecisionData
        {
            get { return decisions; }
        }

        public static List<ObjectiveData> ObjectiveData
        {
            get { return objectives; }
        }
        
        #endregion

        #region Constructor Region
        #endregion

        #region Method Region

        public static void ReadEntityData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Classes", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Classes\" + Path.GetFileNameWithoutExtension(name);
                EntityData data = Content.Load<EntityData>(filename);
                EntityData.Add(data.EntityName, data);
            }
        }

        public static void ReadArmorData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Armor", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Armor\" + Path.GetFileNameWithoutExtension(name);
                ArmorData data = Content.Load<ArmorData>(filename);
                ArmorData.Add(data.Name, data);
                Armor item = new Armor(data);
                ItemData.Add(data.ItemID, item);
            }
        }

        public static void ReadWeaponData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Weapon", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Weapon\" + Path.GetFileNameWithoutExtension(name);
                WeaponData data = Content.Load<WeaponData>(filename);
                WeaponData.Add(data.Name, data);
                Weapon item = new Weapon(data);
                ItemData.Add(data.ItemID, item);
            }
        }

        public static void ReadShieldData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Items\Shield", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Items\Shield\" + Path.GetFileNameWithoutExtension(name);
                ShieldData data = Content.Load<ShieldData>(filename);
                ShieldData.Add(data.Name, data);
                Shield item = new Shield(data);
                ItemData.Add(data.ItemID, item);
            }
        }

        public static void ReadKeyData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Keys", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Keys\" + Path.GetFileNameWithoutExtension(name);
                KeyData data = Content.Load<KeyData>(filename);
                KeyData.Add(data.Name, data);
                Key item = new Key(data.ItemID, data.Name, data.Type, data.AssociatedWithQuestIDs);
                ItemData.Add(data.ItemID, item);
            }
        }

        public static void ReadChestData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Chests", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Chests\" + Path.GetFileNameWithoutExtension(name);
                ChestData data = Content.Load<ChestData>(filename);
                ChestData.Add(data.Name, data);
                Chest item = new Chest(data);
                ItemData.Add(data.ItemID, item);
            }
        }

        public static void ReadSkillData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\Skills", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\Skills\" + Path.GetFileNameWithoutExtension(name);
                SkillData data = Content.Load<SkillData>(filename);
                SkillData.Add(data.Name, data);
            }
        }

        public static void ReadNPCData(ContentManager Content)
        {
            string[] filenames = Directory.GetFiles(@"Content\Game\NPCs", "*.xnb");

            foreach (string name in filenames)
            {
                string filename = @"Game\NPCs\" + Path.GetFileNameWithoutExtension(name);
                NonPlayerCharacterData data = Content.Load<NonPlayerCharacterData>(filename);
                NPCData.Add(data.npcid, data);
            }
        }

        public static void ReadConversationData(ContentManager Content)
        {
            string filename = @"Game\Conversations\Conversations";
            ConversationsData convoList = Content.Load<ConversationsData>(filename);
 
            foreach (ConversationData data in convoList.ConversationData)
            {
                ConversationData.Add(data.ID, data);
            }

        }

        public static void ReadQuestData(ContentManager Content)
        {
            string filename = @"Game\Quests\Quests";
            QuestsData questList = Content.Load<QuestsData>(filename);

            foreach(QuestData data in questList.QuestData)
            {
                QuestData.Add(data.questID, data);
            }
        }

        public static void ReadDecisionData(ContentManager Content)
        {
            string filename = @"Game\Decisions\Decisions";
            decisions = Content.Load<DecisionData>(filename);
        }

        public static void ReadObjectiveData(ContentManager Content)
        {
            string filename = @"Game\Quests\Objectives";
            ObjectivesData objectiveList = Content.Load<ObjectivesData>(filename);

            foreach(ObjectiveData data in objectiveList.ObjectivesList)
            {
                objectives.Add(data);
            }
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
