using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Sprites;

namespace RpgLibrary.Items
{
    public class ItemSprite
    {
        public BaseSprite Sprite { get; }
        public BaseItem Item { get; }

        public ItemSprite(BaseItem item, BaseSprite sprite)
        {
            Item = item;
            Sprite = sprite;
        }

        public virtual void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Sprite.Draw(gameTime, spriteBatch);
        }
    }
}
