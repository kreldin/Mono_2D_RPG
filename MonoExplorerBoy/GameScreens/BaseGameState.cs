using Microsoft.Xna.Framework;
using XRpgLibrary;

namespace MonoExplorerBoy.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields Region

        protected Game1 GameRef;

        #endregion

        #region Constructor Region

        protected BaseGameState(Game game, GameStateManager manager) : base(game, manager)
        {
            GameRef = (Game1)game;
        }

        #endregion
    }
}
