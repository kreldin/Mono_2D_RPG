using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace XRpgLibrary
{
    public abstract class GameState : DrawableGameComponent
    {
        #region Fields and Properties

        public List<GameComponent> Components { get; }

        public GameState Tag { get; }

        protected GameStateManager StateManager;

        #endregion

        #region Constructor Region

        protected GameState(Game game, GameStateManager manager) : base(game)
        {
            StateManager = manager;
            Components = new List<GameComponent>();
            Tag = this;
        }

        #endregion

        #region XNA Drawable Game Component Methods

        public override void Update(GameTime gameTime)
        {
            foreach (var gameComponent in Components)
            {
                if (gameComponent.Enabled)
                {
                    gameComponent.Update(gameTime);
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (var gameComponent in Components)
            {
                if (!(gameComponent is DrawableGameComponent)) continue;
                var drawableGameComponent = gameComponent as DrawableGameComponent;

                if (drawableGameComponent.Visible)
                {
                    drawableGameComponent.Draw(gameTime);
                }
            }
            base.Draw(gameTime);
        }

        #endregion

        #region GameState Method Region

        protected internal virtual void StateChange(object sender, EventArgs e)
        {
            if (StateManager.CurrentState == Tag)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        protected virtual void Show()
        {
            Visible = true;
            Enabled = true;
            foreach (var gameComponent in Components)
            {
                gameComponent.Enabled = true;
                var component = gameComponent as DrawableGameComponent;
                if (component != null)
                {
                    component.Visible = true;
                }
            }
        }

        protected virtual void Hide()
        {
            Visible = false;
            Enabled = false;
            foreach (var gameComponent in Components)
            {
                gameComponent.Enabled = false;
                var component = gameComponent as DrawableGameComponent;
                if (component != null)
                {
                    component.Visible = false;
                }
            }
        }

        #endregion
    }
}