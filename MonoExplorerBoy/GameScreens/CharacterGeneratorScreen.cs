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
        private PictureBox CharacterPictureBox { get; set; }
        private Texture2D[,] CharacterImages { get; set; }

        private string[] GenderItems { get; } = { "Male", "Female" };
        private string[] ClassItems { get; } = { "Fighter", "Wizard", "Rogue", "Priest" };

        public string SelectedGender => GenderSelector.SelectedItem;
        public string SelectedClass => ClassSelector.SelectedItem;

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

            LoadImages();
            CreateControls();
        }

        private void LoadImages()
        {
            CharacterImages  = new Texture2D[GenderItems.Length, ClassItems.Length];

            for (var i = 0; i < GenderItems.Length; i++)
            {
                for (var j = 0; j < ClassItems.Length; j++)
                {
                    CharacterImages[i, j] =
                        Game.Content.Load<Texture2D>(@"Sprites\PlayerSprites\" + GenderItems[i].ToLower() + ClassItems[j].ToLower());
                }
            }
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
            GenderSelector.SelectionChanged += SelectionChanged;
            ControlManager.Add(GenderSelector);

            ClassSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            ClassSelector.SetItems(ClassItems, 125);
            ClassSelector.Position = new Vector2(label.Position.X, 250);
            ClassSelector.SelectionChanged += SelectionChanged;
            ControlManager.Add(ClassSelector);

            var linkLabel = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label.Position.X, 300)
            };
            linkLabel.Selected += LinkLabel_Selected;
            ControlManager.Add(linkLabel);

            CharacterPictureBox = new PictureBox(CharacterImages[0, 0],
                new Rectangle(500, 200, 96, 96),
                new Rectangle(0, 0, 32, 32));
            ControlManager.Add(CharacterPictureBox);

            ControlManager.NextControl();
        }

        private void LinkLabel_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();
            StateManager.PopState();
            StateManager.PushState(GameRef.GamePlayScreen);
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            CharacterPictureBox.Image = CharacterImages[GenderSelector.SelectedIndex, ClassSelector.SelectedIndex];
        }
    }
}
