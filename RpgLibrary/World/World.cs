using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Items;
using RpgLibrary.TileEngine;

namespace RpgLibrary.World
{
    public class World : DrawableGameComponent
    {
        private int _currentLevel = -1;

        private ItemManager Items { get; } = new ItemManager();

        private List<Level> Levels { get; } = new List<Level>();

        public Rectangle Screen { get; }

        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                if ((value < 0) || (value >= Levels.Count)) 
                    throw new IndexOutOfRangeException();

                if (Levels[value] == null)
                    throw new NullReferenceException();

                _currentLevel = value;
            }
        }
        
        public World(Game game, Rectangle screen) : base(game)
        {
            Screen = screen;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public void DrawLevel(GameTime gameTime, SpriteBatch spriteBatch, Camera camera)
        {
            Levels[CurrentLevel].Draw(gameTime, spriteBatch, camera);
        }

        public void AddLevel(Level level)
        {
            Levels.Add(level);
        }
    }
}
