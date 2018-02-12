using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.Characters;
using XRpgLibrary.Items;
using XRpgLibrary.TileEngine;

namespace XRpgLibrary.World
{
    public class Level
    {
        public TileMap Map { get; }
        public List<Character> Characters { get; } = new List<Character>();
        public List<ItemSprite> Chests { get; } = new List<ItemSprite>();


        public Level(TileMap tileMap)
        {
            Map = tileMap;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var character in Characters)
                character.Update(gameTime);

            foreach (var sprite in Chests)
                sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            Map.Draw(spriteBatch, camera);

            foreach (var character in Characters)
                character.Draw(gameTime, spriteBatch);

            foreach (var sprite in Chests)
                sprite.Draw(gameTime, spriteBatch);
        }
    }
}
