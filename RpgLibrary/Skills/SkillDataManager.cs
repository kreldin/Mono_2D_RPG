using System.Collections.Generic;

namespace RpgLibrary.Skills
{
    public class SkillDataManager
    {
        public Dictionary<string, SkillData> SkillData { get; } = new Dictionary<string, SkillData>();

        public SkillDataManager()
        {
            
        }
    }
}
