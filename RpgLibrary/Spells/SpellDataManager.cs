using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Spells
{
    public class SpellDataManager
    {
        public Dictionary<string, SpellData> SpellData { get; } = new Dictionary<string, SpellData>();

        public SpellDataManager()
        {
            
        }
    }
}
