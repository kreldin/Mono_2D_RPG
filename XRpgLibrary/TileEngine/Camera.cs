using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.TileEngine
{
    public class Camera
    {
        private float _speed;

        private Rectangle ViewportRectangle { get; }

        public Vector2 Position { get; private set; }

        public float Speed
        {
            get { return _speed;  }
            set { _speed = MathHelper.Clamp(value, 1f, 16f); }
        }

        public float Zoom { get; }

        public Camera(Rectangle viewportRect)
        {
            Speed = 4f;
            Zoom = 1f;
            ViewportRectangle = viewportRect;
        }

        public Camera(Rectangle viewportRect, Vector2 position)
        {
            Speed = 4f;
            Zoom = 1f;
            ViewportRectangle = viewportRect;
            Position = position;
        }

        public void Update(GameTime gameTime)
        {
            var motion = Vector2.Zero;

            if (InputHandler.IsKeyDown(Keys.Left))
            {
                motion.X = -Speed;
            }
            else if (InputHandler.IsKeyDown(Keys.Right))
            {
                motion.X = Speed;
            }

            if (InputHandler.IsKeyDown(Keys.Up))
            {
                motion.Y = -Speed;
            }
            else if (InputHandler.IsKeyDown(Keys.Down))
            {
                motion.Y = Speed;
            }

            if (motion != Vector2.Zero)
            {
                motion.Normalize();
            }

            Position += motion * Speed;

            LockCamera();
        }

        private void LockCamera()
        {
            var position = Vector2.Zero;
            position.X = MathHelper.Clamp(Position.X,
                0,
                TileMap.MapWidthInPixels - ViewportRectangle.Width);
            position.Y = MathHelper.Clamp(Position.Y,
                0,
                TileMap.MapHeightInPixels - ViewportRectangle.Height);

            Position = position;
        }
    }
}
