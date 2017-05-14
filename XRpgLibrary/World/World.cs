using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Items;

namespace XRpgLibrary.World
{
    public class World
    {
        public Rectangle Screen { get; }

        private ItemManager Items { get; } = new ItemManager();

        public World(Rectangle screen)
        {
            Screen = screen;
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
        }
    }
}
