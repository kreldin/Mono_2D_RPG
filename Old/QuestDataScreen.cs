using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EyesOfTheDragon.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using XRpgLibrary.Controls;
using XRpgLibrary;
using RpgLibrary.QuestClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class QuestDataScreen : BaseGameState
    {
        #region Field Region

        PictureBox backgroundImage;
        QuestLogScreen questLogScreen;
        Quest quest;
        ObjectiveData objectiveData;
        Label questName;
        Label questDescription;
        Label questObjectiveHeader;
        List<Label> questObjectives;
    //    Label questObjectives;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public QuestDataScreen(Game game, GameStateManager manager, QuestLogScreen questLogScreen, Quest quest)
            : base(game, manager)
        {
            this.questLogScreen = questLogScreen;
            this.quest = quest;
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

            questName = new Label();
            questDescription = new Label();
            questObjectiveHeader = new Label();
            questObjectives = new List<Label>();

            StringBuilder temp = new StringBuilder();

            questName.Text = "Quest Name: " + quest.QuestName;
            questName.Position = new Vector2(100, 50);
            questName.Size = questName.SpriteFont.MeasureString(questName.Text);

            questDescription.Position = new Vector2(100, questName.Position.Y + questName.Size.Y);
            temp = new StringBuilder("Quest Description: " + quest.QuestText);
            questDescription.Text = ControlManager.WrapText(questDescription.SpriteFont, temp.ToString(), GameRef.ScreenRectangle.Width -
                questDescription.Position.Y + questDescription.SpriteFont.MeasureString(temp.ToString()).Y - 15);
            questDescription.Size = questDescription.SpriteFont.MeasureString(questDescription.Text);

            questObjectiveHeader.Position = new Vector2(100, questDescription.Position.Y + questDescription.Size.Y);
            temp = new StringBuilder("Quest Objectives:");
            questObjectiveHeader.Text = temp.ToString();
            questObjectiveHeader.Size = questObjectiveHeader.SpriteFont.MeasureString(questObjectiveHeader.Text);

            int cnt = 0;
            float objectiveYPos = questObjectiveHeader.Position.Y + questObjectiveHeader.Size.Y;

            foreach (Objective objective in quest.Objectives)
            {
                Label objectiveText = new Label();
                cnt++;

                objectiveText.Position = new Vector2(100, objectiveYPos);

                temp = new StringBuilder(cnt.ToString() + ": "); 

                if (objective is KillXObjective)
                {
                    temp.Append("Kill " + ((KillXObjective)objective).KillTotal.ToString() + " " + DataManager.NPCData[((KillXObjective)objective).NpcID.ToString()].name);
                    if (((KillXObjective)objective).IsComplete)
                        temp.Append("\n---Completed");
                    else
                        temp.Append("\n---Current: " + ((KillXObjective)objective).CurrentKillCount.ToString());
                }

                if (objective is GatherXItemsObjective)
                {
                    temp.Append("Gather " + ((GatherXItemsObjective)objective).GatherTotal.ToString());
                    if (((GatherXItemsObjective)objective).IsComplete)
                        temp.Append("\n---Completed");
                    else
                        temp.Append("\n---Current: " + ((GatherXItemsObjective)objective).CurrentGatherAmount.ToString());
                }

                if (objective is SpeakToNPCObjective)
                {
                    temp.Append("Speak to " + DataManager.NPCData[((SpeakToNPCObjective)objective).NpcID.ToString()].name);
                    if (((SpeakToNPCObjective)objective).IsComplete)
                        temp.Append("\n---Completed");                    
                }

                if (objective is VisitAreaObjective)
                {
                    temp.Append("Visit area");
                    if (((VisitAreaObjective)objective).IsComplete)
                        temp.Append("\n---Completed");
                }

                objectiveText.Text = temp.ToString();

                objectiveText.Size = objectiveText.SpriteFont.MeasureString(objectiveText.Text);
                questObjectives.Add(objectiveText);                
                objectiveYPos = objectiveText.Position.Y + objectiveText.Size.Y;
            }


          /*  temp = new StringBuilder("Quest Objectives: " + questData.objectives);
            questObjectives.Text = ControlManager.WrapText(questObjectives.SpriteFont, temp.ToString(), GameRef.ScreenRectangle.Width -
                questObjectives.Position.Y + questObjectives.SpriteFont.MeasureString(temp.ToString()).Y - 15);
            */
            ControlManager.Add(questName);
            ControlManager.Add(questDescription);
            ControlManager.Add(questObjectiveHeader);
            foreach (Label lb in questObjectives)
            {
                ControlManager.Add(lb);
            }

        
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.KeyReleased(Keys.Escape) ||
                InputHandler.ButtonReleased(Buttons.Back, PlayerIndex.One))
            {
                Transition(ChangeType.Pop, questLogScreen);
                questLogScreen.currentQuestList.HasFocus = true;
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
