using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.SpriteClasses;

namespace XRpgLibrary.TileEngine
{
    public enum CameraMode
    {
        Free,
        Follow
    }

    public class Camera
    {
        private float _speed = 4f;
        private Vector2 _position;
        private float _zoom = 1f;
        private Rectangle _viewportRectangle;

        private static float ZoomVal { get; } = .25f;

        public Rectangle ViewportRectangle
        {
            get => new Rectangle(_viewportRectangle.X, _viewportRectangle.Y, _viewportRectangle.Width, _viewportRectangle.Height);
            private set => _viewportRectangle = value;
        }

        public Vector2 Position
        {
            get => _position;
            private set => _position = value;
        }

        public float Speed
        {
            get => _speed;
            set => _speed = MathHelper.Clamp(value, 1f, 16f);
        }

        public float Zoom
        {
            get => _zoom;
            private set => _zoom = MathHelper.Clamp(value, .5f, 2.5f);
        }

        public Matrix Transformation => Matrix.CreateScale(Zoom) *
                                            Matrix.CreateTranslation(new Vector3(-Position, 0f));

        public CameraMode Mode { get; private set; } = CameraMode.Follow;

        public Camera(Rectangle viewportRect)
        {
            ViewportRectangle = viewportRect;
        }

        public Camera(Rectangle viewportRect, Vector2 position)
        {
            ViewportRectangle = viewportRect;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            if (Mode == CameraMode.Follow)
                return;

            var motion = Vector2.Zero;

            if (InputHandler.IsKeyDown(Keys.Left) ||
                InputHandler.IsButtonDown(Buttons.RightThumbstickLeft, PlayerIndex.One))
                motion.X = -Speed;
            else if (InputHandler.IsKeyDown(Keys.Right) ||
                     InputHandler.IsButtonDown(Buttons.RightThumbstickRight, PlayerIndex.One))
                motion.X = Speed;

            if (InputHandler.IsKeyDown(Keys.Up) ||
                InputHandler.IsButtonDown(Buttons.RightThumbstickUp, PlayerIndex.One))
                motion.Y = -Speed;
            else if (InputHandler.IsKeyDown(Keys.Down) ||
                     InputHandler.IsButtonDown(Buttons.RightThumbstickDown, PlayerIndex.One))
                motion.Y = Speed;

            if (motion == Vector2.Zero)
                return;

            motion.Normalize();
            Position += motion * Speed;
            LockCamera();
        }

        public void LockToSprite(AnimatedSprite sprite)
        {
            _position.X = ((sprite.Position.X + (sprite.Width / 2f)) * Zoom) - (ViewportRectangle.Width / 2f);

            _position.Y = ((sprite.Position.Y + (sprite.Height / 2f)) * Zoom) - (ViewportRectangle.Height / 2f);

            LockCamera();
        }

        public void ToggleCameraMode()
        {
            switch (Mode)
            {
                case CameraMode.Follow:
                    Mode = CameraMode.Free;
                    break;
                case CameraMode.Free:
                    Mode = CameraMode.Follow;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ZoomIn()
        {
            Zoom += ZoomVal;

            SnapToPosition(Position * Zoom);
        }

        public void ZoomOut()
        {
            Zoom -= ZoomVal;

            SnapToPosition(Position * Zoom);
        }

        private void SnapToPosition(Vector2 newPosition)
        {
            _position.X = newPosition.X - (ViewportRectangle.Width / 2f);
            _position.Y = newPosition.Y - (ViewportRectangle.Height / 2f);
            LockCamera();
        }

        private void LockCamera()
        {
            _position.X = MathHelper.Clamp(
                Position.X,
                0,
                (TileMap.MapWidthInPixels * Zoom) - ViewportRectangle.Width);

            _position.Y = MathHelper.Clamp(
                Position.Y,
                0,
                (TileMap.MapHeightInPixels * Zoom) - ViewportRectangle.Height);
        }
    }
}
