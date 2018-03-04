using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace MonoRPG.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        private Texture2D BackgroundTexture2D { get; set; }
        private LinkLabel StartLinkLabel { get; set; }

        public TitleScreen(Game game, GameStateManager manager) : base(game, manager)
        {
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(BackgroundTexture2D, GameRef.ScreenRectangle, Color.White);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            var content = GameRef.Content;
            BackgroundTexture2D = content.Load<Texture2D>(@"Backgrounds\titlescreen");

            base.LoadContent();

            StartLinkLabel = new LinkLabel
            {
                Position = new Vector2(350, 600),
                Text = "Press ENTER to begin.",
                Color = Color.White,
                TabStop = true,
                HasFocus = true
            };
            StartLinkLabel.Selected += StartLinkLabel_Selected;

            ControlManager.Add(StartLinkLabel);

            ControlManager.AcceptInput = true;
        }

        private void StartLinkLabel_Selected(object sender, EventArgs e)
        {
            Transition(ChangeType.Push, GameRef.StartMenuScreen);
        }
    }
}
