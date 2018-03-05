using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgLibrary.Characters;

namespace RpgLibrary.Effects
{
    public enum EffectType { Damage, Heal }

    public abstract class BaseEffect
    {
        public string Name { get; protected set; }

        public abstract void Apply(Entity entity);
    }
}
