using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RpgLibrary.Controls
{
    public class ListBox : Control
    {
        private bool _hasFocus;

        private Texture2D Background { get; }
        private Texture2D Cursor { get; }

        private int _selectedItem;

        private List<string> Items { get; } = new List<string>();

        public Color SelectedColor { get; set; } = Color.Red;

        public int SelectedIndex
        {
            get => _selectedItem;
            set => _selectedItem = MathHelper.Clamp(value, 0, Items.Count);
        }

        public string SelectedItem => Items[SelectedIndex];

        public override bool HasFocus
        {
            get => _hasFocus;
            set
            {
                _hasFocus = value;
                if (_hasFocus)
                    OnEnter(null);
                else
                    OnLeave(null);
            }
        }

        private int StartItem { get; set; }
        private int LineCount { get; }

        public event EventHandler SelectionChanged;
        public event EventHandler Enter;
        public event EventHandler Leave;

        public ListBox(Texture2D background, Texture2D cursor)
        {
            Background = background;
            Cursor = cursor;

            Size = new Vector2(Background.Width, Background.Height);
            LineCount = Background.Height / SpriteFont.LineSpacing;
            Color = Color.Black;
        }

        public void AddItem(string item)
        {
            Items.Add(item);
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Background, Position, Color.White);

            for (var i = 0; i < LineCount; i++)
            {
                if ((StartItem + i) >= Items.Count)
                    break;

                if ((StartItem + i) == SelectedIndex)
                {
                    spriteBatch.DrawString(
                        SpriteFont,
                        Items[StartItem + i],
                        new Vector2(Position.X, Position.Y + (i * SpriteFont.LineSpacing)),
                        SelectedColor);

                    spriteBatch.Draw(
                        Cursor,
                        new Vector2(
                            Position.X - (Cursor.Width + 2),
                            Position.Y + ((i * SpriteFont.LineSpacing) + 5)),
                            Color.White);
                }
                else
                {
                    spriteBatch.DrawString(
                        SpriteFont,
                        Items[StartItem + i],
                        new Vector2(Position.X, 2 + Position.Y + (i * SpriteFont.LineSpacing)),
                        Color);
                }
            }
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (!HasFocus)
                return;

            if (InputHandler.IsKeyReleased(Keys.Down) ||
                InputHandler.IsButtonReleased(Buttons.LeftThumbstickDown, playerIndex))
            {
                if (SelectedIndex < (Items.Count - 1))
                {
                    SelectedIndex++;
                    if (SelectedIndex >= (StartItem + LineCount))
                        StartItem = (SelectedIndex - LineCount) + 1;
                    
                    OnSelectionChanged(null);
                }
            }
            else if (InputHandler.IsKeyReleased(Keys.Up) ||
                     InputHandler.IsButtonReleased(Buttons.LeftThumbstickUp, playerIndex))
            {
                if (SelectedIndex > 0)
                {
                    SelectedIndex--;
                    if (SelectedIndex < StartItem)
                        StartItem = SelectedIndex;

                    OnSelectionChanged(null);
                }
            }

            if (InputHandler.IsKeyReleased(Keys.Enter) ||
                InputHandler.IsButtonReleased(Buttons.A, playerIndex))
            {
                HasFocus = false;
                OnSelected(null);
            }

            if (InputHandler.IsKeyReleased(Keys.Escape) ||
                InputHandler.IsButtonReleased(Buttons.B, playerIndex))
            {
                HasFocus = false;
                OnLeave(null);
            }
        }

        protected virtual void OnSelectionChanged(EventArgs e)
        {
            SelectionChanged?.Invoke(this, e);
        }

        protected virtual void OnEnter(EventArgs e)
        {
            Enter?.Invoke(this, e);
        }

        protected virtual void OnLeave(EventArgs e)
        {
            Leave?.Invoke(this, e);
        }
    }
}
