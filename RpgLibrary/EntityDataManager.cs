using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgLibrary.Characters;

namespace RpgLibrary
{
    public class EntityDataManager
    {
        public Dictionary<string, EntityData> EntityData { get; } = new Dictionary<string, EntityData>();
    }
}
