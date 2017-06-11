using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoRPG.Components;
using XRpgLibrary;
using XRpgLibrary.World;

namespace MonoRPG.GameScreens
{
    public class GamePlayScreen : BaseGameState
    {
        public static Player Player { get; set; }
        public static World World { get; set; }

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Update(GameTime gameTime)
        {
            World.Update(gameTime);
            Player.Update(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin(
                SpriteSortMode.Deferred,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null, null, null,
                Player.Camera.Transformation);

            base.Draw(gameTime);

            World.DrawLevel(GameRef.SpriteBatch, Player.Camera);
            Player.Draw(gameTime, GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }
    }
}
