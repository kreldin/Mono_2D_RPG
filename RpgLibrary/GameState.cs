using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RpgLibrary
{
    public abstract class GameState : DrawableGameComponent
    {
        protected GameStateManager StateManager { get; set; }

        public List<GameComponent> Components { get; } = new List<GameComponent>();

        public GameState Tag { get; }

        protected GameState(Game game, GameStateManager manager) : base(game)
        {
            StateManager = manager;
            Tag = this;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var gameComponent in Components)
            {
                if (gameComponent.Enabled)
                    gameComponent.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var gameComponent in Components)
            {
                var drawableGameComponent = gameComponent as DrawableGameComponent;

                if (drawableGameComponent?.Visible == true)
                    drawableGameComponent.Draw(gameTime);
            }
            base.Draw(gameTime);
        }

        protected internal virtual void StateChange(object sender, EventArgs e)
        {
            if (StateManager.CurrentState == Tag)
                Show();
            else
                Hide();
        }

        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;
            foreach (var gameComponent in Components)
            {
                gameComponent.Enabled = true;
                if (gameComponent is DrawableGameComponent component)
                    component.Visible = true;
            }
        }

        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach (var gameComponent in Components)
            {
                gameComponent.Enabled = false;
                if (gameComponent is DrawableGameComponent component)
                    component.Visible = false;
            }
        }
    }
}