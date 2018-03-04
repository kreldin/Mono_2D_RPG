using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoRPG.Components;
using RpgLibrary.Characters;
using XRpgLibrary;
using XRpgLibrary.Characters;
using XRpgLibrary.Controls;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.TileEngine;
using XRpgLibrary.World;

namespace MonoRPG.GameScreens
{
    public class LoadGameScreen : BaseGameState
    {
        private PictureBox BackgroundImage { get; set; }
        private ListBox LoadListBox { get; set; }
        private LinkLabel LoadLabel { get; set; }
        private LinkLabel ExitLabel { get; set; }

        public LoadGameScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            var content = Game.Content;

            BackgroundImage = new PictureBox(
                content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(BackgroundImage);

            LoadLabel = new LinkLabel
            {
                Text = "Select game",
                Position = new Vector2(50, 100)
            };
            LoadLabel.Selected += LoadLabel_Selected;
            ControlManager.Add(LoadLabel);

            ExitLabel = new LinkLabel
            {
                Text = "Back",
            };
            ExitLabel.Position = new Vector2(50, 100 + ExitLabel.SpriteFont.LineSpacing);
            ExitLabel.Selected += ExitLabel_Selected;
            ControlManager.Add(ExitLabel);

            LoadListBox = new ListBox(
                content.Load<Texture2D>(@"GUI\listBoxImage"),
                content.Load<Texture2D>(@"GUI\rightarrowUp"))
            {
                Position = new Vector2(400, 100)
            };
            LoadListBox.Selected += LoadListBox_Selected;
            LoadListBox.Leave += LoadListBox_Leave;

            for (var i = 0; i < 20; i++)
                LoadListBox.AddItem("Game number: " + i);

            ControlManager.Add(LoadListBox);
            ControlManager.NextControl();

            ControlManager.AcceptInput = true;
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        private void LoadListBox_Leave(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = true;
            LoadLabel.HasFocus = true;
            InputHandler.Flush();
        }

        private void LoadListBox_Selected(object sender, EventArgs e)
        {
            LoadLabel.HasFocus = true;
            LoadListBox.HasFocus = false;
            ControlManager.AcceptInput = true;

            Transition(ChangeType.Change, GameRef.GamePlayScreen);
            CreatePlayer();
            CreateWorld();
        }

        private void ExitLabel_Selected(object sender, EventArgs eventArgs)
        {
            Transition(ChangeType.Pop, null);
        }

        private void LoadLabel_Selected(object sender, EventArgs e)
        {
            ControlManager.AcceptInput = false;
            LoadLabel.HasFocus = false;
            LoadListBox.HasFocus = true;
            InputHandler.Flush();
        }

        private void CreatePlayer()
        {
            var animationDown = new Animation(3, 32, 32, 0, 0);
            var animationLeft = new Animation(3, 32, 32, 0, 32);
            var animationRight = new Animation(3, 32, 32, 0, 64);
            var animationUp = new Animation(3, 32, 32, 0, 96);

            var animations = new Dictionary<AnimationKey, Animation>
            {
                { AnimationKey.Down, animationDown },
                { AnimationKey.Left, animationLeft },
                { AnimationKey.Right, animationRight} ,
                { AnimationKey.Up, animationUp }
            };

            var sprite = new AnimatedSprite(
                GameRef.Content.Load<Texture2D>(@"Sprites\PlayerSprites\malefighter"),
                animations);

            var entity = new Entity(
                "Kreldin",
                DataManager.Entities["Fighter"],
                EntityGender.Male,
                EntityType.Character);

            GamePlayScreen.Player = new Player(GameRef, new Character(entity, sprite));
        }

        private void CreateWorld()
        {
            base.LoadContent();

            var tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            var tileset1 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");
            var tileset2 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            var tilesets = new List<Tileset> { tileset1, tileset2 };

            var layer = new MapLayer(100, 100);

            for (var y = 0; y < layer.Height; y++)
            {
                for (var x = 0; x < layer.Width; x++)
                {
                    var tile = new Tile(0, 0);

                    layer.SetTile(x, y, tile);
                }
            }

            var splatter = new MapLayer(100, 100);
            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                var x = random.Next(0, 100);
                var y = random.Next(0, 100);
                var index = random.Next(2, 14);

                var tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            var mapLayers = new List<MapLayer> { layer, splatter };

            var map = new TileMap(tilesets, mapLayers);
            var level = new Level(map);

            GamePlayScreen.World = new World(GameRef, GameRef.ScreenRectangle);
            GamePlayScreen.World.AddLevel(level);
            GamePlayScreen.World.CurrentLevel = 0;
        }
    }

}
