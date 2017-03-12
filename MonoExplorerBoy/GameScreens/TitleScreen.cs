using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;

namespace MonoExplorerBoy.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        #region Field Region

        private Texture2D _backgroundTexture2D;

        #endregion

        #region Constructor Region

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        protected override void LoadContent()
        {
            var content = GameRef.Content;
            _backgroundTexture2D = content.Load<Texture2D>(@"Backgrounds\titlescreen.png");

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(_backgroundTexture2D, GameRef.ScreenRectangle, Color.White);

            GameRef.SpriteBatch.End();
        }

        #endregion
    }
}
