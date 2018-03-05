using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RpgLibrary.Controls
{
    public abstract class Control
    {
        private Vector2 _position;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                _position.Y = (int)_position.Y;
            }
        }

        public string Name { get; set; }
        public string Text { get; set; }
        public Vector2 Size { get; set; }
        public object Value { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public bool TabStop { get; set; }
        public string Type { get; set; }
        public SpriteFont SpriteFont { get; set; } = ControlManager.SpriteFont;
        public Color Color { get; set; } = Color.White;

        public virtual bool HasFocus { get; set; }

        public event EventHandler Selected;

        protected Control()
        {
            Enabled = true;
            Visible = true;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        protected virtual void OnSelected(EventArgs e)
        {
            Selected?.Invoke(this, e);
        }
    }
}
