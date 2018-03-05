using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary;
using RpgLibrary.Controls;

namespace MonoRPG.GameScreens
{
    public abstract class BaseGameState : GameState
    {
        protected Game1 GameRef { get; set; }

        protected ControlManager ControlManager { get; set; }

        protected PlayerIndex PlayerIndexInControl { get; set; }

        protected BaseGameState TransitionTo { get; set; }

        protected bool Transitioning { get; set; }

        protected ChangeType ChangeType { get; set; }

        protected TimeSpan TransitionTimer { get; set; }

        protected TimeSpan TransitionInterval { get; set; } = TimeSpan.FromSeconds(0.5);

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

        public override void Update(GameTime gameTime)
        {
            if (Transitioning)
            {
                TransitionTimer += gameTime.ElapsedGameTime;

                if (TransitionTimer >= TransitionInterval)
                {
                    Transitioning = false;

                    switch (ChangeType)
                    {
                        case ChangeType.Change:
                            StateManager.ChangeState(TransitionTo);
                            break;
                        case ChangeType.Pop:
                            StateManager.PopState();
                            break;
                        case ChangeType.Push:
                            StateManager.PushState(TransitionTo);
                            break;
                    }
                }
            }

            base.Update(gameTime);
        }

        public virtual void Transition(ChangeType changeType, BaseGameState gameState)
        {
            Transitioning = true;
            ChangeType = changeType;
            TransitionTo = gameState;
            TransitionTimer = TimeSpan.Zero;
        }
    }
}
