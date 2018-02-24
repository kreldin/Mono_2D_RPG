using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class SpinBox : Control
    {
        public event EventHandler SelectionChanged;

        private int _current;
        private int _minValue;
        private int _maxValue;
        private readonly Texture2D _leftTexture;
        private readonly Texture2D _rightTexture;
        private readonly Texture2D _stopTexture;

        public int Increment { get; set; }

        public int Width { get; set; }

        public int MinimumValue
        {
            get => _minValue;
            set => _minValue = value > _maxValue ? _maxValue : value;
        }

        public int MaximumValue
        {
            get => _maxValue;
            set => _maxValue = value < _minValue ? _minValue : value;
        }

        public int SpinValue
        {
            get => _current;
            set
            {
                if (value < _minValue)
                    _current = _minValue;
                else if (value > _maxValue)
                    _current = _maxValue;
                else
                    _current = value;
            }
        }

        public Color SelectedColor { get; set; } = Color.Red;

        public SpinBox(Texture2D leftArrow, Texture2D rightArrow, Texture2D stop)
        {
            MinimumValue = 0;
            MaximumValue = 100;
            Increment = 1;
            Width = 50;

            _leftTexture = leftArrow;
            _rightTexture = rightArrow;
            _stopTexture = stop;

            TabStop = true;
            Color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            var drawTo = Position;

            spriteBatch.Draw(_current != MinimumValue ? _leftTexture : _stopTexture, drawTo, Color.White);

            drawTo.X += _leftTexture.Width + 5f;

            var currentValue = _current.ToString();
            var itemWidth = SpriteFont.MeasureString(currentValue).X;
            var offset = (Width - itemWidth) / 2;

            drawTo.X += offset;

            spriteBatch.DrawString(SpriteFont, currentValue, drawTo, HasFocus ? SelectedColor : Color);

            drawTo.X += (-1 * offset) + Width + 5f;

            spriteBatch.Draw(_current != _maxValue ? _rightTexture : _stopTexture, drawTo, Color.White);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
            if (InputHandler.IsButtonReleased(Buttons.LeftThumbstickLeft, playerIndex) ||
                InputHandler.IsButtonReleased(Buttons.DPadLeft, playerIndex) ||
                InputHandler.IsKeyReleased(Keys.Left))
            {
                _current -= Increment;
                if (_current < _minValue)
                    _current = _minValue;
                OnSelectionChanged();
            }

            if (InputHandler.IsButtonReleased(Buttons.LeftThumbstickRight, playerIndex) ||
                InputHandler.IsButtonReleased(Buttons.DPadRight, playerIndex) ||
                InputHandler.IsKeyReleased(Keys.Right))
            {
                _current += Increment;
                if (_current > _maxValue)
                    _current = _maxValue;
                OnSelectionChanged();
            }
        }

        protected virtual void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, null);
        }
    }
}
