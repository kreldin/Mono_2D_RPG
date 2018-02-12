using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Quests
{
    public class QuestManager
    {
        public Dictionary<string, Quest> Quests { get; } = new Dictionary<string, Quest>();
    }
}
