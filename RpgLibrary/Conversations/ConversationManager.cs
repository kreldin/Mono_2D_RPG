using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Conversations
{
    public class ConversationManager
    {
        public Dictionary<string, Conversation> Conversations { get; } = new Dictionary<string, Conversation>();
    }
}
