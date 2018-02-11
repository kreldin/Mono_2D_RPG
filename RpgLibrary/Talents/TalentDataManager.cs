using System.Collections.Generic;

namespace RpgLibrary.Talents
{
    public class TalentDataManager
    {
        public Dictionary<string, TalentData> TalentData { get; } = new Dictionary<string, TalentData>();

        public TalentDataManager()
        {

        }
    }
}
