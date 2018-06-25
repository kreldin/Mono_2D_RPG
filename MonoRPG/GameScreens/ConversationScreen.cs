using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoRPG.Components;
using RpgLibrary;
using RpgLibrary.Characters;
using RpgLibrary.Conversations;

namespace MonoRPG.GameScreens
{
    public class ConversationScreen : BaseGameState
    {
        private ConversationManager Conversations { get; } = ConversationManager.Instance;
        private Conversation Conversation { get; set; }
        private Player Player { get; set; }
        private NonPlayerCharacter Npc { get; set; }

        public ConversationScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Update(GameTime gameTime)
        {
            Conversation.Update(gameTime);

            if (InputHandler.IsKeyReleased(Keys.Enter) || InputHandler.IsKeyReleased(Keys.Space) ||
                InputHandler.IsButtonReleased(Buttons.A, PlayerIndex.One))
            {
                InputHandler.Flush();

                var action = Conversation.CurrentScene.OptionAction;

                switch (action.Action)
                {
                    case ActionType.Talk:
                        Conversation.ChangeScene(Conversation.CurrentScene.OptionScene);
                        break;
                    case ActionType.Quest:
                        Conversation.ChangeScene(Conversation.CurrentScene.OptionScene);
                        break;
                    case ActionType.Change:
                        Conversation = Conversations.GetConversation(Conversation.CurrentScene.OptionScene);

                        Conversation.StartConversation();
                        break;
                    case ActionType.End:
                        StateManager.PopState();
                        break;
                    case ActionType.Buy:
                        break;
                    case ActionType.Sell:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameRef.SpriteBatch.Begin();
            Conversation.Draw(gameTime, GameRef.SpriteBatch, null);
            GameRef.SpriteBatch.End();
        }

        public void SetConversation(Player player, NonPlayerCharacter npc, string conversation)
        {
            Player = player;
            Npc = npc;
            Conversation = Conversations.GetConversation(conversation);
        }

        public void StartConversation()
        {
            Conversation.StartConversation();
        }
    }
}
