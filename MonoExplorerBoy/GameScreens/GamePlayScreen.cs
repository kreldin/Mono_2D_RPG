using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoExplorerBoy.Components;
using XRpgLibrary;
using XRpgLibrary.TileEngine;

namespace MonoExplorerBoy.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        private TileMap Map { get; set; }
        private Player Player { get; }

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            Player = new Player(game as Game1);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            var tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            var tileset1 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");
            var tileset2 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            var tilesets = new List<Tileset> {tileset1, tileset2};

            var layer = new MapLayer(40, 40);

            for (var y = 0; y < layer.Height; y++)
            {
                for (var x = 0; x < layer.Width; x++)
                {
                    var tile = new Tile(0, 0);

                    layer.SetTile(x, y, tile);
                }
            }

            var splatter = new MapLayer(40, 40);
            var random = new Random();

            for (var i = 0; i < 80; i++)
            {
                var x = random.Next(0, 40);
                var y = random.Next(0, 40);
                var index = random.Next(2, 14);

                var tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            var mapLayers = new List<MapLayer> {layer, splatter};

            Map = new TileMap(tilesets, mapLayers);
        }

        public override void Update(GameTime gameTime)
        {
            Player.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null, null, null,
                Matrix.Identity);

            Map.Draw(GameRef.SpriteBatch, Player.Camera);

            base.Draw(gameTime);

            GameRef.SpriteBatch.End();
        }
    }
}
