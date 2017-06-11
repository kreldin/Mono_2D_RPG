using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class LinkLabel : Control
    {
        public Color SelectedColor { get; set; } = Color.Red;

        public LinkLabel()
        {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(SpriteFont, Text, Position, HasFocus ? SelectedColor : Color);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.IsKeyReleased(Keys.Enter) ||
                InputHandler.IsButtonReleased(Buttons.A, playerIndex))
                OnSelected(null);
        }
    }
}
