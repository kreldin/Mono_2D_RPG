using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary;
using XRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;
using XRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens
{
    public class InventoryScreen : BaseGameState
    {
        #region Field Region

        PictureBox backgroundImage;
        ListBox inventoryList;
        MenuScreen menuScreen;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

       public InventoryScreen(Game game, GameStateManager manager, MenuScreen menuScreen)
            : base(game, manager)
        {
            this.menuScreen = menuScreen;
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

            inventoryList = new ListBox(
               new Texture2D(GameRef.GraphicsDevice, GameRef.ScreenRectangle.Width - 50,
                   GameRef.ScreenRectangle.Height - 40),
               Content.Load<Texture2D>(@"GUI\rightarrowUp"));

            inventoryList.Position = Vector2.Zero;

            foreach (GameItem item in GamePlayScreen.Player.Backpack.Items)
            {
                inventoryList.Items.Add(item.Item.Name);
            }

            ControlManager.Add(inventoryList);

            ControlManager.AcceptInput = false;

            inventoryList.HasFocus = true;

            inventoryList.SelectedIndex = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape) ||
                InputHandler.ButtonReleased(Buttons.Back, PlayerIndex.One))
            {
                Transition(ChangeType.Pop, menuScreen);
                inventoryList.HasFocus = false;
               menuScreen.optionsPanel.HasFocus = true;
            }
                
            GamePlayScreen.Player.Update(gameTime);
            ControlManager.Update(gameTime, playerIndexInControl);

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

        #endregion
    }
}
