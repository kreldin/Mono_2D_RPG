using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using RpgLibrary.QuestClasses;
using XRpgLibrary.Controls;

using RpgLibrary.ItemClasses;
using XRpgLibrary.ItemClasses;


namespace EyesOfTheDragon.Components
{
    public class QuestManager
    {
        #region Field Region

    //    readonly Dictionary<string, Quest> quests;
        List<Quest> currentQuests;
        List<Quest> completedQuests;
        ControlManager ControlManager;
        Label lb;



        #endregion

        #region Property Region

        /*public Dictionary<string, Quest> Quests
        {
            get { return quests; }
        }*/

        public List<Quest> CurrentQuests
        {
            get { return currentQuests; }
        }

        public List<Quest> CompletedQuests
        {
            get { return completedQuests; }
        }


        #endregion

        #region Constructor Region

        public QuestManager(ControlManager ControlManager)
        {
        //    quests = new Dictionary<string, Quest>();
            currentQuests = new List<Quest>();
            completedQuests = new List<Quest>();
            this.ControlManager = ControlManager;
        }

        #endregion

        #region Method Region

        public void AcceptQuest(string questIDString)
        {
            int questID = Convert.ToInt32(questIDString);

            List<Objective> objectives = new List<Objective>();

            QuestData questData = DataManager.QuestData[questIDString];

            foreach (int objectiveID in questData.objectives)
            {
                ObjectiveData data = DataManager.ObjectiveData.Find(obj => obj.objectiveID == objectiveID.ToString());

                Objective objective;

                if (data is KillXObjectiveData)
                {
                    objective = new KillXObjective((KillXObjectiveData)data);
                    objectives.Add(objective);
                }
                else if (data is GatherXItemsObjectiveData)
                {
                    objective = new GatherXItemsObjective((GatherXItemsObjectiveData)data);
                    objectives.Add(objective);

                    GameScreens.GamePlayScreen.World.Levels[GameScreens.GamePlayScreen.World.CurrentLevel].MakeObjectsVisibleForNewQuest(((GatherXItemsObjective)objective).ItemID,
                        questID);
                }
                else if (data is SpeakToNPCObjectiveData)
                {
                    objective = new SpeakToNPCObjective((SpeakToNPCObjectiveData)data);
                    objectives.Add(objective);
                }
                else if (data is VisitAreaObjectiveData)
                {
                    objective = new VisitAreaObjective((VisitAreaObjectiveData)data);
                    objectives.Add(objective);
                }    
            }


            Quest temp = new Quest(questData, objectives);


            try
            {
                ValidateQuest(questID);
            }
            catch (Exception)
            {
                throw;
            }

            if (currentQuests.Contains(temp))
            {
                throw new Exception("You're already on this quest!");
            }
            
            currentQuests.Add(temp);

            Thread acceptQuestThread = new Thread(() =>
            {
                lb = new Label();

                QuestData data;
                DataManager.QuestData.TryGetValue(questIDString, out data);

                lb.HasFocus = true;
                lb.Position = new Vector2(200, 200);
                lb.Visible = true;
                lb.Type = "QuestAccept";
                lb.Text = "Accepted Quest \"" + data.questName + "\"";

                ControlManager.Add(lb);

                ControlManager.NextControl();

                Thread.Sleep(2000);

                ControlManager.PreviousControl();
             //   ControlManager.SelectedControl = 0;
                
            });

            acceptQuestThread.Start();


        }

        public void CompleteQuest(string questIDString)
        {
            int questID = Convert.ToInt32(questIDString);

            try
            {
                ValidateQuest(questID);
            }
            catch (Exception)
            {
                throw;
            }

            Quest questToComplete = currentQuests.Find(quest => ((Quest)quest).QuestID == questID);

            currentQuests.Remove(questToComplete);

            completedQuests.Add(questToComplete);

            Thread completeQuestThread = new Thread(() =>
            {
                lb = new Label();

                QuestData data;
                DataManager.QuestData.TryGetValue(questIDString, out data);

                lb.HasFocus = true;
                lb.Position = new Vector2(200, 200);
                lb.Visible = true;
                lb.Text = "Completed Quest \"" + data.questName + "\"";

                ControlManager.Add(lb);

                ControlManager.NextControl();

                Thread.Sleep(2000);

                ControlManager.PreviousControl();
                //   ControlManager.SelectedControl = 0;

            });

            completeQuestThread.Start();
        }

        public bool HasQuest(string questIDString)
        {
            int questID = Convert.ToInt32(questIDString);
            Quest questToFind = currentQuests.Find(quest => ((Quest)quest).QuestID == questID);
            return currentQuests.Contains(questToFind);
        }

        public bool HasFinishedQuest(string questIDString)
        {
            int questID = Convert.ToInt32(questIDString);
            Quest questToFind = currentQuests.Find(quest => ((Quest)quest).QuestID == questID);
            return questToFind.IsComplete;
        }

        void ValidateQuest(int questID)
        {
            if (!DataManager.QuestData.ContainsKey(questID.ToString()))
            {
                throw new Exception("Quest does not exist in data manager.");
            }

            Quest questToCheck = currentQuests.Find(quest => ((Quest)quest).QuestID == questID);

            if (CompletedQuests.Contains(questToCheck))
            {
                throw new Exception("You already completed this quest.");
            }
        }

        public void CheckItemPickUp(GameItem item)
        {
            int itemID = item.Item.ItemID;

            foreach (Quest quest in currentQuests)
            {
                foreach (GatherXItemsObjective objective in quest.Objectives)
                {
                    if (itemID == objective.ItemID && !objective.IsComplete)
                    {
                        objective.FurtherProgress();
                    }
                }
            }
        }

        #endregion

        #region Virtual Method region
        #endregion
    }
}
