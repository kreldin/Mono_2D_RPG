using Microsoft.Xna.Framework;
using XRpgLibrary.TileEngine;

namespace MonoExplorerBoy.Components
{
    public class Player 
    {
        private Game1 GameRef { get; }

        public Camera Camera { get; set; }

        public Player(Game1 game1)
        {
            GameRef = game1;
            Camera = new Camera(GameRef.ScreenRectangle);
        }

        public void Update(GameTime gameTime)
        {
            Camera.Update(gameTime);
        }
    }
}
