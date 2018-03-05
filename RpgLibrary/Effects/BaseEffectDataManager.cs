using System.Collections.Generic;

namespace RpgLibrary.Effects
{
    public class BaseEffectDataManager
    {
        public Dictionary<string, BaseEffectData> EffectData { get; } = new Dictionary<string, BaseEffectData>();
    }
}
