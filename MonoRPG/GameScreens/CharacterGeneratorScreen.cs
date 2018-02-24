using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoRPG.Components;
using RpgLibrary.Items;
using XRpgLibrary;
using XRpgLibrary.Controls;
using XRpgLibrary.Items;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.TileEngine;
using XRpgLibrary.World;

namespace MonoRPG.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        private LeftRightSelector GenderSelector { get; set; }
        private LeftRightSelector ClassSelector { get; set; }
        private PictureBox BackgroundPictureBox { get; set; }
        private PictureBox CharacterPictureBox { get; set; }
        private Texture2D[,] CharacterImages { get; set; }
        private Texture2D Containers { get; set; }

        private string[] GenderItems { get; } = { "Male", "Female" };
        private string[] ClassItems { get; } = { "Fighter", "Wizard", "Rogue", "Priest" };

        public string SelectedGender => GenderSelector.SelectedItem;
        public string SelectedClass => ClassSelector.SelectedItem;

        public CharacterGeneratorScreen(Game game, GameStateManager manager) : base(game, manager)
        {
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

        protected override void LoadContent()
        {
            base.LoadContent();

            LoadImages();
            CreateControls();
            Containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
        }

        private void LoadImages()
        {
            CharacterImages  = new Texture2D[GenderItems.Length, ClassItems.Length];

            for (var i = 0; i < GenderItems.Length; i++)
            {
                for (var j = 0; j < ClassItems.Length; j++)
                {
                    CharacterImages[i, j] =
                        Game.Content.Load<Texture2D>(@"Sprites\PlayerSprites\" + GenderItems[i].ToLower() + ClassItems[j].ToLower());
                }
            }
        }

        private void CreateControls()
        {
            var leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            var rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            var stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            BackgroundPictureBox = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(BackgroundPictureBox);

            var label = new Label {Text = "Who will search for the Eyes of the Dragon?"};
            label.Size = label.SpriteFont.MeasureString(label.Text);
            label.Position = new Vector2((GameRef.Window.ClientBounds.Width - label.Size.X) / 2, 150);
            ControlManager.Add(label);

            GenderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            GenderSelector.SetItems(GenderItems, 125);
            GenderSelector.Position = new Vector2(label.Position.X, 200);
            GenderSelector.SelectionChanged += SelectionChanged;
            ControlManager.Add(GenderSelector);

            ClassSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            ClassSelector.SetItems(ClassItems, 125);
            ClassSelector.Position = new Vector2(label.Position.X, 250);
            ClassSelector.SelectionChanged += SelectionChanged;
            ControlManager.Add(ClassSelector);

            var linkLabel = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label.Position.X, 300)
            };
            linkLabel.Selected += LinkLabel_Selected;
            ControlManager.Add(linkLabel);

            CharacterPictureBox = new PictureBox(CharacterImages[0, 0],
                new Rectangle(500, 200, 96, 96),
                new Rectangle(0, 0, 32, 32));
            ControlManager.Add(CharacterPictureBox);

            ControlManager.NextControl();

            ControlManager.AcceptInput = true;
        }

        private void LinkLabel_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            CreateWorld();

            GameRef.SkillScreen.SkillPoints = 25;
            StateManager.ChangeState(GameRef.SkillScreen);
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            CharacterPictureBox.Image = CharacterImages[GenderSelector.SelectedIndex, ClassSelector.SelectedIndex];
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
                CharacterImages[GenderSelector.SelectedIndex, ClassSelector.SelectedIndex], 
                animations);

            GamePlayScreen.Player = new Player(GameRef, sprite);
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

            var chestData = Game.Content.Load<ChestData>(@"Game\Chests\Plain Chest");

            var chest = new Chest(chestData);

            var chestSprite = new BaseSprite(
                Containers,
                new Rectangle(0, 0, 32, 32),
                new Point(10,10));


            var itemSprite = new ItemSprite(
                chest,
                chestSprite);

            level.Chests.Add(itemSprite);

            GamePlayScreen.World = new World(GameRef, GameRef.ScreenRectangle);
            GamePlayScreen.World.AddLevel(level);
            GamePlayScreen.World.CurrentLevel = 0;
        }
    }
}
