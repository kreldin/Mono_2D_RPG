using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.World
{
    public class Level
    {
        public TileMap Map { get; }

        public Level(TileMap tileMap)
        {
            Map = tileMap;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            Map.Draw(spriteBatch, camera);
        }
    }
}
