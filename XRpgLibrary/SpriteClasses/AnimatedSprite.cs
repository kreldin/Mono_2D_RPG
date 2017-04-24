using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.SpriteClasses
{
    public class AnimatedSprite
    {
        private Vector2 _velocity;
        private Vector2 _position;
        private float _speed = 2.0f;

        private Dictionary<AnimationKey, Animation> Animations { get; } = new Dictionary<AnimationKey, Animation>();

        private Texture2D Texture { get; }

        public AnimationKey CurrentAnimation { get; set; }

        public bool IsAnimating { get; set; }

        public int Width => Animations[CurrentAnimation].FrameWidth;

        public int Height => Animations[CurrentAnimation].FrameHeight;

        public float Speed { get => _speed; set => _speed = MathHelper.Clamp(value, 1.0f, 16.0f); }

        public Vector2 Position { get => _position; set => _position = value; }

        public Vector2 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                if (_velocity != Vector2.Zero)
                {
                    _velocity.Normalize();
                }
            }
        }

        public AnimatedSprite(Texture2D texture, Dictionary<AnimationKey, Animation> animations)
        {
            Texture = texture;

            foreach (var key in animations.Keys)
            {
                Animations.Add(key, (Animation)animations[key].Clone());
            }
        }

        public void Update(GameTime gameTime)
        {
            if (IsAnimating)
            {
                Animations[CurrentAnimation].Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            spriteBatch.Draw(
                Texture,
                Position - camera.Position,
                Animations[CurrentAnimation].CurrentFrameRect,
                Color.White);
        }

        public void LockToMap()
        {
            _position.X = MathHelper.Clamp(Position.X, 0, TileMap.MapWidthInPixels - Width);
            _position.Y = MathHelper.Clamp(Position.Y, 0, TileMap.MapHeightInPixels - Height);
        }
    }
}
