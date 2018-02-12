using System.Collections.Generic;
using RpgLibrary.Characters;
using RpgLibrary.Conversations;
using RpgLibrary.Quests;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.Characters
{
    public class NonPlayerCharacter : Character
    {
        public List<Conversation> Conversations { get; } = new List<Conversation>();
        public List<Quest> Quests { get; } = new List<Quest>();

        public bool HasConversation => Conversations.Count > 0;
        public bool HasQuest => Quests.Count > 0;

        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite) : base(entity, sprite)
        {
        }
    }
}
