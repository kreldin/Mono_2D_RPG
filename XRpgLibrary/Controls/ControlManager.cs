using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class ControlManager : List<Control>
    {
        private int SelectedControl { get; set; }

        public static SpriteFont SpriteFont { get; private set; }

        public event EventHandler FocusChanged;

        public ControlManager(SpriteFont spriteFont)
        {
            SpriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, int capacity) : base(capacity)
        {
            SpriteFont = spriteFont;
        }

        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection) : base(collection)
        {
            SpriteFont = spriteFont;
        }

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            if (Count == 0)
            {
                return;
            }

            foreach (var c in this)
            {
                if (c.Enabled)
                {
                    c.Update(gameTime);
                }

                if (c.HasFocus)
                {
                    c.HandleInput(playerIndex);
                }
            }

            if (InputHandler.IsButtonPressed(Buttons.LeftThumbstickUp, playerIndex) ||
                InputHandler.IsButtonPressed(Buttons.DPadUp, playerIndex) ||
                InputHandler.IsKeyPressed(Keys.Up))
            {
                PreviousControl();
            }

            if (InputHandler.IsButtonPressed(Buttons.LeftThumbstickDown, playerIndex) ||
                InputHandler.IsButtonPressed(Buttons.DPadDown, playerIndex) ||
                InputHandler.IsKeyPressed(Keys.Down))
            {
                NextControl();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var c in this)
            {
                if (c.Visible)
                {
                    c.Draw(spriteBatch);
                }
            }
        }

        public void NextControl()
        {
            if (Count == 0)
            {
                return;
            }

            var currentControl = SelectedControl;

            this[SelectedControl].HasFocus = false;

            do
            {
                SelectedControl++;

                if (SelectedControl == Count)
                {
                    SelectedControl = 0;
                }

                if (!this[SelectedControl].TabStop || !this[SelectedControl].Enabled)
                {
                    continue;
                }

                FocusChanged?.Invoke(this[SelectedControl], null);

                break;
            } while (currentControl != SelectedControl);

            this[SelectedControl].HasFocus = true;
        }

        public void PreviousControl()
        {
            if (Count == 0)
            {
                return;
            }

            var currentControl = SelectedControl;

            this[SelectedControl].HasFocus = false;

            do
            {
                SelectedControl--;

                if (SelectedControl < 0)
                {
                    SelectedControl = Count - 1;
                }

                if (!this[SelectedControl].TabStop || !this[SelectedControl].Enabled)
                {
                    continue;
                }

                FocusChanged?.Invoke(this[SelectedControl], null);
                break;
            } while (currentControl != SelectedControl);

            this[SelectedControl].HasFocus = true;
        }
    }
}
