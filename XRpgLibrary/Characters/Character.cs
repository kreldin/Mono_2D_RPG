using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Characters;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.Characters
{
    public class Character
    {
        public Entity Entity { get; protected set; }

        public AnimatedSprite Sprite { get; protected set; }

        public Character(Entity entity, AnimatedSprite sprite)
        {
            Entity = entity;
            Sprite = sprite;
        }

        public virtual void Update(GameTime gameTime)
        {
            Entity.Update(gameTime.ElapsedGameTime);
            Sprite.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Sprite.Draw(gameTime, spriteBatch);
        }
    }
}
