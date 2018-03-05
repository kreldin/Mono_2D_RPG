using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RpgLibrary.Controls
{
    public class LeftRightSelector : Control
    {
        private int _selectedIndex;

        public event EventHandler SelectionChanged;

        private Texture2D LeftTexture { get; }
        private Texture2D RightTexture { get; }
        private Texture2D StopTexture { get; }
        private int MaxItemWidth { get; set; }

        public List<string> Items { get; } = new List<string>();

        public Color SelectedColor { get; set; } = Color.Red;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => _selectedIndex = MathHelper.Clamp(value, 0, Items.Count);
        }

        public string SelectedItem => Items[SelectedIndex];

        public LeftRightSelector(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            LeftTexture = leftArrow;
            RightTexture = rightArrow;
            StopTexture = stop;
            TabStop = true;
            Color = Color.White;
        }

        public void SetItems(string[] items, int maxWidth)
        {
            Items.Clear();

            foreach (var s in items)
                Items.Add(s);

            MaxItemWidth = maxWidth;
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var drawTo = Position;

            spriteBatch.Draw(SelectedIndex != 0 ? LeftTexture : StopTexture, drawTo, Color.White);

            drawTo.X += LeftTexture.Width + 5.0f;

            var itemWidth = SpriteFont.MeasureString(Items[SelectedIndex]).X;
            var offset = (MaxItemWidth - itemWidth) / 2;

            drawTo.X += offset;

            spriteBatch.DrawString(SpriteFont, Items[SelectedIndex], drawTo, HasFocus ? SelectedColor : Color);

            drawTo.X += (-1 * offset) + MaxItemWidth + 5.0f;

            spriteBatch.Draw(SelectedIndex != (Items.Count - 1) ? RightTexture : StopTexture, drawTo, Color.White);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (Items.Count == 0)
                return;

            if (InputHandler.IsButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.IsButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.IsKeyReleased(Keys.Left))
            {
                _selectedIndex--;
                if (_selectedIndex < 0)
                    _selectedIndex = 0;

                OnSelectionChanged();
            }
            else if (InputHandler.IsButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.IsButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.IsKeyReleased(Keys.Right))
            {
                _selectedIndex++;
                if (_selectedIndex >= Items.Count)
                    _selectedIndex = Items.Count - 1;

                OnSelectionChanged();
            }
        }

        protected void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, null);
        }
    }
}
