using System.Collections.Generic;
using RpgLibrary.Characters;
using RpgLibrary.Conversations;
using RpgLibrary.Quests;
using RpgLibrary.Sprites;

namespace RpgLibrary.Characters
{
    public class NonPlayerCharacter : Character
    {
        public List<Quest> Quests { get; } = new List<Quest>();

        public string CurrentConversation { get; private set; }
        public string CurrentQuest { get; private set; }

        public bool HasConversation => !string.IsNullOrEmpty(CurrentConversation);
        public bool HasQuest => Quests.Count > 0;      

        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
        {
        }

        public void SetConversation(string conversation)
        {
            CurrentConversation = conversation;
        }
    }
}
