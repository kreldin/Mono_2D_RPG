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
using RpgLibrary.QuestClasses;
using EyesOfTheDragon.Components;

namespace EyesOfTheDragon.GameScreens
{
    public class QuestLogScreen : BaseGameState
    {
        #region Field Region

        PictureBox backgroundImage;
        public QuestBox currentQuestList;
        MenuScreen menuScreen;
        QuestDataScreen questDataScreen;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public QuestLogScreen(Game game, GameStateManager manager, MenuScreen menuScreen)
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

            currentQuestList = new QuestBox(
               new Texture2D(GameRef.GraphicsDevice, GameRef.ScreenRectangle.Width - 50,
                   GameRef.ScreenRectangle.Height - 40),
               Content.Load<Texture2D>(@"GUI\rightarrowUp"));

            currentQuestList.Position = Vector2.Zero;

            foreach (Quest quest in GamePlayScreen.Player.Quests)
            {
                currentQuestList.Items.Add(DataManager.QuestData[quest.QuestID.ToString()].questName);
                currentQuestList.QuestID.Add(quest.QuestID);
            }

            ControlManager.Add(currentQuestList);

            ControlManager.AcceptInput = false;

            currentQuestList.HasFocus = true;

            currentQuestList.SelectedIndex = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape) ||
                InputHandler.ButtonReleased(Buttons.Back, PlayerIndex.One))
            {
                Transition(ChangeType.Pop, menuScreen);
                currentQuestList.HasFocus = false;
                menuScreen.optionsPanel.HasFocus = true;
            }

            if (currentQuestList.QuestID.Count != 0 && (InputHandler.KeyReleased(Keys.Enter) || 
                InputHandler.ButtonReleased(Buttons.A, PlayerIndex.One)))
            {
                questDataScreen = new QuestDataScreen(this.GameRef, this.StateManager, this,
                    GamePlayScreen.Player.Quests.Find(quest => quest.QuestID == currentQuestList.QuestID[currentQuestList.SelectedIndex]));

                Transition(ChangeType.Push, questDataScreen);
                currentQuestList.HasFocus = false;
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
