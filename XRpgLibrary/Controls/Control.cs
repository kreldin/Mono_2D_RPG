using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.Controls
{
    public abstract class Control
    {
        #region Field and Property Region

        protected Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set
            {
                position = value;
                position.Y = (int)position.Y;
            }
        }

        public string Name { get; set; }
        public string Text { get; set; }
        public Vector2 Size { get; set; }
        public object Value { get; set; }
        public bool HasFocus { get; set; }
        public bool Enabled { get; set; }
        public bool Visible { get; set; }
        public bool TabStop { get; set; }
        public SpriteFont SpriteFont { get; set; }
        public Color Color { get; set; }
        public string Type { get; set; }

        #endregion

        #region Event Region

        public event EventHandler Selected;

        #endregion

        #region Constructor Region

        public Control()
        {
            Color = Color.White;
            Enabled = true;
            Visible = true;
            SpriteFont = ControlManager.SpriteFont;
        }

        #endregion

        #region Abstract Methods

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
        public abstract void HandleInput(PlayerIndex playerIndex);

        #endregion

        #region Virtual Methods

        protected virtual void OnSelected(EventArgs e)
        {
            if (Selected != null)
            {
                Selected(this, e);
            }
        }

        #endregion
    }
}
