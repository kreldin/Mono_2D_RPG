using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoRPG.Components;
using RpgLibrary;
using RpgLibrary.Characters;
using RpgLibrary.World;

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
            Player.Camera.LockToSprite(Player.Sprite);

            if (InputHandler.IsKeyReleased(Keys.Space) ||
                InputHandler.IsButtonReleased(Buttons.A, PlayerIndex.One))
            {
                foreach (var c in World.Levels[World.CurrentLevel].Characters)
                {
                    var distance = Vector2.Distance(Player.Sprite.Center, c.Sprite.Center);

                    if (!(c is NonPlayerCharacter npc) || !(distance < Character.SpeakingRadius)) continue;
                    if (!npc.HasConversation) continue;

                    StateManager.PushState(GameRef.ConversationScreen);
                    GameRef.ConversationScreen.SetConversation(Player, npc, npc.CurrentConversation);
                    GameRef.ConversationScreen.StartConversation();
                }
            }

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

            World.DrawLevel(gameTime, GameRef.SpriteBatch, Player.Camera);
            Player.Draw(gameTime, GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }
    }
}
