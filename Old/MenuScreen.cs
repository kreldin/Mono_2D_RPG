using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using XRpgLibrary;
using XRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens
{
    public class MenuScreen : BaseGameState
    {
        #region Field Region

        PictureBox backgroundImage;
        public ListBox optionsPanel;
        InventoryScreen inventoryScreen;
        QuestLogScreen questLogScreen;

        #endregion

        #region Property Region

        #endregion

        #region Constructor Region

        public MenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            
        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region
        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;

            backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Menu\menubackground"),
                GameRef.ScreenRectangle);

            ControlManager.Add(backgroundImage);

            optionsPanel = new ListBox(
               new Texture2D(GameRef.GraphicsDevice, 100, GameRef.ScreenRectangle.Height - 40),
               Content.Load<Texture2D>(@"GUI\rightarrowUp"));
            optionsPanel.Position = new Vector2(800, 50);

            optionsPanel.Items.Add("Inventory");
            optionsPanel.Items.Add("Quest Log");
            optionsPanel.Items.Add("Skills");
            optionsPanel.Items.Add("Equip");
            optionsPanel.Items.Add("Magic");
            optionsPanel.Items.Add("Formation");
            optionsPanel.Items.Add("Settings");
            optionsPanel.Selected += new EventHandler(optionsPanel_Selected);

            ControlManager.Add(optionsPanel);

            ControlManager.AcceptInput = false;

            optionsPanel.HasFocus = true;

            optionsPanel.SelectedIndex = 0;
        }

        public override void Update(GameTime gameTime)
        {
            GamePlayScreen.Player.Update(gameTime);
            ControlManager.Update(gameTime, playerIndexInControl);

            if (InputHandler.KeyReleased(Keys.Escape) || InputHandler.ButtonReleased(Buttons.Back, PlayerIndex.One))
                Transition(ChangeType.Pop, GameRef.GamePlayScreen);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Event Handler Region

        public void optionsPanel_Selected(object sender, EventArgs e)
        {
            ListBox temp = sender as ListBox;

            if (temp.SelectedIndex == 0)
            {
                inventoryScreen = new InventoryScreen(this.GameRef, this.StateManager, this);
                Transition(ChangeType.Push, inventoryScreen);
            }

            if (temp.SelectedIndex == 1)
            {
                questLogScreen = new QuestLogScreen(this.GameRef, this.StateManager, this);
                Transition(ChangeType.Push, questLogScreen);
            }
        }

        #endregion
    }
}
