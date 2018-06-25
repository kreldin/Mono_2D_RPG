using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Sprites
{
    public sealed class AnimationManager
    {
        public static AnimationManager Instance { get; } = new AnimationManager();

        public Dictionary<AnimationKey, Animation> Animations { get; } = new Dictionary<AnimationKey, Animation>();

        private AnimationManager()
        {
            var animation = new Animation(3, 32, 32, 0, 0);

            Animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);

            Animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);

            Animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);

            Animations.Add(AnimationKey.Up, animation);
        }
    }
}
