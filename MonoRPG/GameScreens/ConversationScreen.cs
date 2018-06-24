using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
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
