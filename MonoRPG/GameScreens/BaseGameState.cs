using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace MonoRPG.GameScreens
{
    public abstract class BaseGameState : GameState
    {
        protected Game1 GameRef { get; set; }

        protected ControlManager ControlManager { get; set; }

        protected PlayerIndex PlayerIndexInControl { get; set; }

        protected BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            GameRef = (Game1)game;

            PlayerIndexInControl = PlayerIndex.One;
        }

        protected override void LoadContent()
        {
            var content = Game.Content;

            var menuFont = content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);
            base.LoadContent();
        }
    }
}
