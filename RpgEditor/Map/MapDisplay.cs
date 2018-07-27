using System;
using RpgEditor.Graphics;

namespace RpgEditor.Map
{
    internal class MapDisplay : GraphicsDeviceControl
    {
        public event EventHandler OnInitialize;
        public event EventHandler OnDraw;

        protected override void Initialize()
        {
            OnInitialize?.Invoke(this, null);
        }

        protected override void Draw()
        {
            OnDraw?.Invoke(this, null);
        }
    }
}
