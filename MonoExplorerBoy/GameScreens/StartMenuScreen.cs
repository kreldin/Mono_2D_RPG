using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace MonoExplorerBoy.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        private PictureBox BackgroundPictureBox { get; set; }
        private PictureBox ArrowPictureBox { get; set; }
        private LinkLabel StartGameLinkLabel { get; set; }
        private LinkLabel LoadGameLinkLabel { get; set; }
        private LinkLabel ExitGameLinkLabel { get; set; }
        private float MaxItemWidth { get; set; }

        public StartMenuScreen(Game game, GameStateManager manager) : base(game, manager)
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

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            var content = Game.Content;

            BackgroundPictureBox = new PictureBox(
                content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(BackgroundPictureBox);

            var arrowTexture = content.Load<Texture2D>(@"GUI\leftarrowUp");
            ArrowPictureBox = new PictureBox(
                arrowTexture,
                new Rectangle(
                    0,
                    0,
                    arrowTexture.Width,
                    arrowTexture.Height));
            ControlManager.Add(ArrowPictureBox);

            StartGameLinkLabel = new LinkLabel {Text = "The story begins"};
            StartGameLinkLabel.Size = StartGameLinkLabel.SpriteFont.MeasureString(StartGameLinkLabel.Text);
            StartGameLinkLabel.Selected += MenuItem_Selected;
            ControlManager.Add(StartGameLinkLabel);

            LoadGameLinkLabel = new LinkLabel {Text = "The story continues"};
            LoadGameLinkLabel.Size = LoadGameLinkLabel.SpriteFont.MeasureString(LoadGameLinkLabel.Text);
            LoadGameLinkLabel.Selected += MenuItem_Selected;
            ControlManager.Add(LoadGameLinkLabel);

            ExitGameLinkLabel = new LinkLabel {Text = "The story ends"};
            ExitGameLinkLabel.Size = ExitGameLinkLabel.SpriteFont.MeasureString(ExitGameLinkLabel.Text);
            ExitGameLinkLabel.Selected += MenuItem_Selected;
            ControlManager.Add(ExitGameLinkLabel);

            ControlManager.NextControl();

            ControlManager.FocusChanged += ControlManager_FocusChanged;

            var position = new Vector2(350, 500);

            foreach (var c in ControlManager)
            {
                if (!(c is LinkLabel))
                {
                    continue;
                }

                if (c.Size.X > MaxItemWidth)
                {
                    MaxItemWidth = c.Size.X;
                }

                c.Position = position;
                position.Y += c.Size.Y + 5f;
            }

            ControlManager_FocusChanged(StartGameLinkLabel, null);
        }

        private void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control == null)
            {
                return;
            }

            var position = new Vector2(control.Position.X + MaxItemWidth + 10f,
                control.Position.Y);

            ArrowPictureBox.SetPosition(position);
        }

        private void MenuItem_Selected(object sender, EventArgs e)
        {
            if (sender == StartGameLinkLabel)
            {
                StateManager.PushState(GameRef.GamePlayScreen);
            }
            else if (sender == LoadGameLinkLabel)
            {
                StateManager.PushState(GameRef.GamePlayScreen);
            }
            else if (sender == ExitGameLinkLabel)
            {
                GameRef.Exit();
            }
        }
    }
}
