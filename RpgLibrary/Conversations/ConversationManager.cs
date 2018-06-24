using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace RpgLibrary.Conversations
{
    public sealed class ConversationManager
    {
        [ContentSerializer]
        public Dictionary<string, Conversation> ConversationList { get; private set; }

        public static ConversationManager Instance { get; } = new ConversationManager();

        private ConversationManager()
        {
            
        }

        public void AddConversation(string name, Conversation conversation)
        {
            if (!ConversationList.ContainsKey(name))
                ConversationList.Add(name, conversation);
        }

        public Conversation GetConversation(string name)
        {
            return ConversationList.ContainsKey(name) ? ConversationList[name] : null;
        }

        public bool ContainsConversation(string name)
        {
            return ConversationList.ContainsKey(name);
        }

        public void ClearConversations()
        {
            ConversationList = new Dictionary<string, Conversation>();
        }
    }
}
