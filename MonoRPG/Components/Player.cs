using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RpgLibrary;
using RpgLibrary.Characters;
using RpgLibrary.Sprites;
using RpgLibrary.TileEngine;

namespace MonoRPG.Components
{
    public class Player 
    {
        private Game1 GameRef { get; }

        public Character Character { get; }

        public AnimatedSprite Sprite => Character.Sprite;

        public Camera Camera { get; set; }

        public Player(Game1 game1, Character character)
        {
            Character = character;
            GameRef = game1;
            Camera = new Camera(GameRef.ScreenRectangle);
        }

        public void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);
            Character.Update(gameTime);

            HandleInput(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Character.Draw(gameTime, spriteBatch);
        }

        private void HandleInput(GameTime gameTime)
        {
            HandleZoomInput();

            HandleMovementInput(gameTime);

            HandleToggleInput();

            HandleLockInput();
        }

        private void HandleLockInput()
        {
            if (Camera.Mode == CameraMode.Follow)
                return;

            if (InputHandler.IsKeyReleased(Keys.C) ||
                InputHandler.IsButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                Camera.LockToSprite(Sprite);
        }

        private void HandleToggleInput()
        {
            if (!InputHandler.IsKeyReleased(Keys.F) &&
                !InputHandler.IsButtonReleased(Buttons.RightStick, PlayerIndex.One))
                return;

            Camera.ToggleCameraMode();
            if (Camera.Mode == CameraMode.Follow)
                Camera.LockToSprite(Sprite);
        }

        private void HandleMovementInput(GameTime gameTime)
        {
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

                Sprite.Position += motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Sprite.LockToMap();

                if (Camera.Mode == CameraMode.Follow)
                    Camera.LockToSprite(Sprite);
            }
            else
            {
                Sprite.IsAnimating = false;
            }
        }

        private void HandleZoomInput()
        {
            if (InputHandler.IsKeyReleased(Keys.PageUp) ||
                InputHandler.IsButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                Camera.ZoomIn();
                if (Camera.Mode == CameraMode.Follow)
                    Camera.LockToSprite(Sprite);
            }
            else if (InputHandler.IsKeyReleased(Keys.PageDown) ||
                     InputHandler.IsButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                Camera.ZoomOut();
                if (Camera.Mode == CameraMode.Follow)
                    Camera.LockToSprite(Sprite);
            }
        }
    }
}
