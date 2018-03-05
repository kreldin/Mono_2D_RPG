using System;
using Microsoft.Xna.Framework;

namespace RpgLibrary.Sprites
{
    public enum AnimationKey { Down, Left, Right, Up }

    public class Animation : ICloneable
    {
        private int _framesPerSecond;
        private int _currentFrame;

        private Rectangle[] Frames { get; }

        private TimeSpan FrameLength { get; set; }

        private TimeSpan FrameTimer { get; set; }

        public int FrameWidth { get; set; }

        public int FrameHeight { get; set; }

        public int FramesPerSecond
        {
            get => _framesPerSecond;
            set
            {
                _framesPerSecond = MathHelper.Clamp(value, 1, 60);
                FrameLength = TimeSpan.FromSeconds(1 / (double) _framesPerSecond);
            }
        }

        public Rectangle CurrentFrameRect => Frames[_currentFrame];

        public int CurrentFrame { get => _currentFrame; set => _currentFrame = MathHelper.Clamp(value, 0, Frames.Length - 1); }

        private Animation(Animation animation)
        {
            Frames = animation.Frames;
            FramesPerSecond = 5;
        }

        public Animation(int frameCount, int frameWidth, int frameHeight, int xOffset, int yOffset)
        {
            Frames = new Rectangle[frameCount];
            FrameWidth = frameWidth;
            FrameHeight = frameHeight;

            for (var i = 0; i < frameCount; i++)
            {
                Frames[i] = new Rectangle(
                    xOffset + (FrameWidth * i),
                    yOffset,
                    FrameWidth,
                    FrameHeight);
            }

            FramesPerSecond = 5;
            Reset();
        }

        public void Update(GameTime gameTime)
        {
            FrameTimer += gameTime.ElapsedGameTime;

            if (FrameTimer < FrameLength)
                return;

            FrameTimer = TimeSpan.Zero;
            CurrentFrame = (CurrentFrame + 1) % Frames.Length;
        }

        public void Reset()
        {
            CurrentFrame = 0;
            FrameTimer = TimeSpan.Zero;
        }

        public object Clone()
        {
            var animationClone = new Animation(this)
            {
                FrameWidth = FrameWidth,
                FrameHeight = FrameHeight
            };

            animationClone.Reset();

            return animationClone;
        }
    }
}
