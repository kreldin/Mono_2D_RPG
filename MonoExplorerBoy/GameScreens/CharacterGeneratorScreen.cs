using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace MonoExplorerBoy.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        private LeftRightSelector GenderSelector { get; set; }
        private LeftRightSelector ClassSelector { get; set; }
        private PictureBox BackgroundPictureBox { get; set; }

        private string[] GenderItems { get; } = { "Male", "Female" };
        private string[] ClassItems { get; } = { "Fighter", "Wizard", "Rogue", "Priest " };

        public CharacterGeneratorScreen(Game game, GameStateManager manager) : base(game, manager)
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

            CreateControls();
        }

        private void CreateControls()
        {
            var leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            var rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            var stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            BackgroundPictureBox = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(BackgroundPictureBox);

            var label = new Label {Text = "Who will search for the Eyes of the Dragon?"};
            label.Size = label.SpriteFont.MeasureString(label.Text);
            label.Position = new Vector2((GameRef.Window.ClientBounds.Width - label.Size.X) / 2, 150);
            ControlManager.Add(label);

            GenderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            GenderSelector.SetItems(GenderItems, 125);
            GenderSelector.Position = new Vector2(label.Position.X, 200);
            ControlManager.Add(GenderSelector);

            ClassSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            ClassSelector.SetItems(ClassItems, 125);
            ClassSelector.Position = new Vector2(label.Position.X, 250);
            ControlManager.Add(ClassSelector);

            var linkLabel = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label.Position.X, 300)
            };
            linkLabel.Selected += LinkLabel_Selected;
            ControlManager.Add(linkLabel);

            ControlManager.NextControl();
        }

        private void LinkLabel_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();
            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }
    }
}
