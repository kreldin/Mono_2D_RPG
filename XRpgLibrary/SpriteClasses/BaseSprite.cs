using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.SpriteClasses
{
    public class BaseSprite
    {
        protected float _speed = 2.0f;
        protected Vector2 _velocity = Vector2.Zero;

        protected Texture2D Texture { get; set; }
        protected Rectangle SourceRectangle { get; set; }

        public Vector2 Position { get; set; } = Vector2.Zero;

        public int Width => SourceRectangle.Width;
        public int Height => SourceRectangle.Height;

        public Rectangle Rectangle => 
            new Rectangle(
                (int) Position.X,
                (int) Position.Y,
                Width,
                Height);

        public float Speed
        {
            get => _speed;
            set => _speed = MathHelper.Clamp(Speed, 1.0f, 16.0f);
        }

        public Vector2 Velocity
        {
            get => _velocity;
            set
            {
                _velocity = value;
                if (_velocity != Vector2.Zero)
                    _velocity.Normalize();
            }
        }

        public BaseSprite(Texture2D texture, Rectangle? sourceRectangle)
        {
            Texture = texture;

            if (sourceRectangle.HasValue)
                SourceRectangle = sourceRectangle.Value;
            else
                SourceRectangle = new Rectangle(
                    0,
                    0,
                    Texture.Width,
                    Texture.Height);
        }

        public BaseSprite(Texture2D texture, Rectangle? sourceRectangle, Point tile)
            : this(texture, sourceRectangle)
        {
            Position = new Vector2(
                tile.X * Engine.TileWidth,
                tile.Y * Engine.TileHeight);
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                Texture,
                Position,
                SourceRectangle,
                Color.White);
        }
    }
}
