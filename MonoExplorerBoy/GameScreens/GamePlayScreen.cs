using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoExplorerBoy.Components;
using XRpgLibrary;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;

namespace MonoExplorerBoy.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        private TileMap Map { get; set; }
        private Player Player { get; }
        private AnimatedSprite Sprite { get; set; }

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
            Player = new Player(game as Game1);
        }

        protected override void LoadContent()
        {
            var spriteSheet = Game.Content.Load<Texture2D>(@"Sprites\PlayerSprites\" + 
                GameRef.CharacterGeneratorScreen.SelectedGender.ToLower() + GameRef.CharacterGeneratorScreen.SelectedClass.ToLower());
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

            Sprite = new AnimatedSprite(spriteSheet, animations);

            base.LoadContent();

            var tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            var tileset1 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");
            var tileset2 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            var tilesets = new List<Tileset> {tileset1, tileset2};

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

            var mapLayers = new List<MapLayer> {layer, splatter};

            Map = new TileMap(tilesets, mapLayers);
        }

        public override void Update(GameTime gameTime)
        {
            Player.Update(gameTime);
            Sprite.Update(gameTime);

            if (InputHandler.IsKeyReleased(Keys.PageUp) ||
                InputHandler.IsButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                Player.Camera.ZoomIn();
                if (Player.Camera.Mode == CameraMode.Follow)
                {
                    Player.Camera.LockToSprite(Sprite);
                }
            }
            else if (InputHandler.IsKeyReleased(Keys.PageDown) ||
                     InputHandler.IsButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                Player.Camera.ZoomOut();
                if (Player.Camera.Mode == CameraMode.Follow)
                {
                    Player.Camera.LockToSprite(Sprite);
                }
            }

            var motion = new Vector2();

            if (InputHandler.IsKeyDown(Keys.W) ||
                InputHandler.IsButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.IsKeyDown(Keys.S) ||
                     InputHandler.IsButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }

            if (InputHandler.IsKeyDown(Keys.A) ||
                InputHandler.IsButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.IsKeyDown(Keys.D) ||
                     InputHandler.IsButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (motion != Vector2.Zero)
            {
                Sprite.IsAnimating = true;
                motion.Normalize();

                Sprite.Position += motion * Sprite.Speed;
                Sprite.LockToMap();

                if (Player.Camera.Mode == CameraMode.Follow)
                {
                    Player.Camera.LockToSprite(Sprite);
                }
            }
            else
            {
                Sprite.IsAnimating = false;
            }

            if (InputHandler.IsKeyReleased(Keys.F) ||
                InputHandler.IsButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                Player.Camera.ToggleCameraMode();
                if (Player.Camera.Mode == CameraMode.Follow)
                {
                    Player.Camera.LockToSprite(Sprite);
                }
            }

            if (Player.Camera.Mode != CameraMode.Follow)
            {
                if (InputHandler.IsKeyReleased(Keys.C) ||
                    InputHandler.IsButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    Player.Camera.LockToSprite(Sprite);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null, null, null,
                Player.Camera.Transformation);

            Map.Draw(GameRef.SpriteBatch, Player.Camera);
            Sprite.Draw(gameTime, GameRef.SpriteBatch, Player.Camera);

            base.Draw(gameTime);

            GameRef.SpriteBatch.End();
        }
    }
}
