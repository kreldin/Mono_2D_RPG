﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.TileEngine;

namespace MonoRPG.Components
{
    public class Player 
    {
        private Game1 GameRef { get; }

        public AnimatedSprite Sprite { get; }

        public Camera Camera { get; set; }

        public Player(Game1 game1, AnimatedSprite sprite)
        {
            Sprite = sprite;
            GameRef = game1;
            Camera = new Camera(GameRef.ScreenRectangle);
        }

        public void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);
            Sprite.Update(gameTime);

            HandleInput();
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Sprite.Draw(gameTime, spriteBatch);
        }

        private void HandleInput()
        {
            HandleZoomInput();

            HandleMovementInput();

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

        private void HandleMovementInput()
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

                Sprite.Position += motion * Sprite.Speed;
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
