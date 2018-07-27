using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ConversationClasses;
using XRpgLibrary.Controls;
using XRpgLibrary;
using System.Text.RegularExpressions;
using System.Reflection;
using RpgLibrary.DecisionClasses;

namespace EyesOfTheDragon.Components
{
    public class ConversationManager
    {
        #region Field Region

        Character player;
        NonPlayerCharacter currentNpc;
        Conversation currentConversation;
        ControlManager ControlManager;
        List<string> messages;
        int currentMessage;
        DialogBox dbConv;
        LinkLabel choiceLabel;
        Game1 gameRef;
        QuestManager QuestManager;
        string[] choices;
        bool displayChoices;
        bool choiceDecision;

        #endregion

        #region Property Region

        #endregion

        #region Constructor Region

        public ConversationManager(Game1 gameRef, Character player, ControlManager ControlManager, QuestManager QuestManager)
        {
            this.gameRef = gameRef;
            this.player = player;
            this.ControlManager = ControlManager;
            this.QuestManager = QuestManager;
            currentMessage = -1;
        }

        #endregion

        #region Method Region

        public void NewConversation(NonPlayerCharacter npc, Conversation conversation)
        {
            currentNpc = npc;
            currentConversation = conversation;

            if (conversation.Message.StartsWith("+IfHasQuest"))
            {
                HandleAction(conversation.Message);

                currentConversation = new Conversation(DataManager.ConversationData[currentNpc.Conversations[currentNpc.CurrentConversation].ToString()]);

            }

            if (conversation.Message.StartsWith("+IfFinishedQuest"))
            {
                HandleAction(conversation.Message);

                currentConversation = new Conversation(DataManager.ConversationData[currentNpc.Conversations[currentNpc.CurrentConversation].ToString()]);
            }

            string convo = currentConversation.Message;

           if (conversation.Message.StartsWith("+IfMadeDecision"))
           {
               convo = HandleAction(conversation.Message);
           }

            currentNpc.BeginConversation();

            messages = new List<string>();



          //  convo = convo.TrimEnd(' ');

            var words = convo.Split(' ');

            StringBuilder temp = new StringBuilder();

            int cnt = 1;
            displayChoices = false;

            foreach (string word in words)
            {
                string tempWord = word;

                if (tempWord[0] == '+')
                {
                    tempWord = HandleAction(word);
                    if (tempWord == "+Choices")
                    {
                        displayChoices = true;
                        break;
                    }

                    if (tempWord == "+ChoicesWithDecision")
                    {
                        displayChoices = true;
                        choiceDecision = true;
                        break;
                    }

                    if (tempWord == "GoTo")
                    {
                        currentConversation = new Conversation(DataManager.ConversationData[currentNpc.Conversations[currentNpc.CurrentConversation].ToString()]);
                        NewConversation(npc, currentConversation);
                        return;
                    }
                }

                if (temp.Length + tempWord.Length > (54 * cnt))
                {
                    temp.AppendLine(tempWord + ' ');
                    cnt++;

                    if (cnt == 3)
                    {
                        messages.Add(temp.ToString());
                        cnt = 0;
                        temp = new StringBuilder();
                    }
                }
                else
                    temp.Append(tempWord + ' ');
            }

            if (temp.Length > 0)
                messages.Add(temp.ToString());

            foreach (string s in messages)
            {
                dbConv = new DialogBox(gameRef.Content.Load<Texture2D>(@"GUI\convo"), new Rectangle(0, 0, gameRef.ScreenRectangle.Width, 100));

                dbConv.Position = new Vector2(0, 0);

                dbConv.Text = s;

                if (ControlManager.Count == 0 || ControlManager[ControlManager.SelectedControl].Type == "QuestAccept")
                {
                    dbConv.HasFocus = true;
                    dbConv.Visible = true;
                }
                else
                {
                    dbConv.HasFocus = false;
                    dbConv.Visible = false;
                }

                ControlManager.Add(dbConv);

                if (displayChoices == true)
                {
                    Vector2 nextControlPosition = new Vector2(0, 110);
                    foreach (string choice in choices)
                    {
                        choiceLabel = new LinkLabel();

                        choiceLabel.TabStop = true;
                        choiceLabel.Text = choice.Substring(0, choice.IndexOf('='));

                        if (choiceDecision == false)
                        {
                            choiceLabel.GoToMessage = Convert.ToInt32(choice.Substring(choice.IndexOf('=') + 1, choice.Length - choice.IndexOf('=') - 1));
                            choiceLabel.Decision = -1;
                        }
                        else
                        {

                            string fieldName = choice.Substring(choice.IndexOf('=') + 1, choice.Length - choice.IndexOf('=') - 1);
                            fieldName = fieldName.Substring(0, fieldName.IndexOf('>'));

                            string decision = choice.Substring(choice.IndexOf('=') + 1, choice.Length - choice.IndexOf('=') - 1);
                            decision = decision.Substring(decision.IndexOf('>') + 1, 1);

                            string goTo = choice.Substring(choice.IndexOf('=') + 1, choice.Length - choice.IndexOf('=') - 1);
                            goTo = goTo.Substring(goTo.IndexOf('#') + 1, 1);

                            choiceLabel.GoToMessage = Convert.ToInt32(goTo);
                            choiceLabel.Decision = Convert.ToInt32(decision);
                            choiceLabel.FieldName = fieldName;
                        }
                        
                        choiceLabel.Position = new Vector2(nextControlPosition.X + 390, nextControlPosition.Y);
                        nextControlPosition.Y += ControlManager.SpriteFont.LineSpacing + 10f;

                        choiceLabel.Selected += chooseLabelChoice_Selected;
                        
                        ControlManager.Add(choiceLabel);
                    }

                    ControlManager.NextControl();
                }
            }

            currentMessage = 1;
        }

        void chooseLabelChoice_Selected(object sender, EventArgs e)
        {
            int goToMessage = ((LinkLabel)sender).GoToMessage;
            if (currentNpc.Conversations.Contains(goToMessage))
                currentNpc.CurrentConversation = currentNpc.Conversations.IndexOf(goToMessage);

            int decision = ((LinkLabel)sender).Decision;
            if (decision > -1)
            {
                string fieldName = ((LinkLabel)sender).FieldName;
                FieldInfo fInfo = typeof(DecisionData).GetField(fieldName);
                object value = fInfo.GetValue(DataManager.DecisionData);

                fInfo.SetValue(DataManager.DecisionData, Convert.ToInt32(decision));    
            }


            NonPlayerCharacter npc = currentNpc;
            ClearAll();
            NewConversation(npc, new Conversation(DataManager.ConversationData[npc.Conversations[npc.CurrentConversation].ToString()]));
        }


        public bool HandleInput()
        {
            if (displayChoices)
                return true;

            if (currentMessage < messages.Count)
            {
                ControlManager.NextConvo();
                currentMessage++;

                return true;
            }
            else
            { 
                ClearAll();
                return false;
            }            
        }

        private void ClearAll()
        {
            ControlManager.Clear();
            ControlManager.SelectedControl = 0;
            displayChoices = false;
            choiceDecision = false;
            currentMessage = -1;
            currentNpc.EndConversation();
            currentNpc = null;
            currentConversation = null;
            messages = null;
            dbConv = null;
            choices = null;
        }

        public string HandleAction(string action)
        {
            int initialLength = action.Length;

            string function = action.Substring(1, action.LastIndexOf(')'));

            string additional = "";

            if (function.Length != action.Length)
            {
                additional = action.Substring(action.LastIndexOf(")") + 1, action.Length - action.LastIndexOf(")") - 1);
            }

            if (function == "GetPlayerName()")
                return player.Entity.EntityName + additional;

            if (function == "GetPlayerClass()")
                return player.Entity.EntityClass + additional;

            if (function == "GetPlayerGender()")
                return player.Entity.Gender.ToString() + additional;

            if (function == "GetNPCName()")
                return currentNpc.Entity.EntityName + additional;

            if (function == "GetNPCGender()")
                return currentNpc.Entity.Gender.ToString() + additional;

            if (function == "GetPlayerGenderPronoun()")
            {
                if (player.Entity.Gender == RpgLibrary.CharacterClasses.EntityGender.Male)
                    return "he" + additional;
                else if (player.Entity.Gender == RpgLibrary.CharacterClasses.EntityGender.Female)
                    return "she" + additional;
                else
                    return "they" + additional;
            }

            if (function.StartsWith("GoToMessage"))
            {
                int goToMessage = Convert.ToInt32(Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value);
                if (currentNpc.Conversations.Contains(goToMessage))
                    currentNpc.CurrentConversation = currentNpc.Conversations.IndexOf(goToMessage);
            }

            if (function.StartsWith("GiveChoicesMakeDecision"))
            {
                //+GiveChoicesMakeDecision(Yes=MakeDecision(WasMeanToDanik=0)*No=MakeDecision(WasMeanToDanik=1))
                choices = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value.Split('*');
                return "+ChoicesWithDecision";
            }

            if (function.StartsWith("GiveChoices"))
            {
                choices = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value.Split('*');
                return "+Choices";

            }

            if (function.StartsWith("GiveQuest"))
            {
                string questID = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value;

                try
                {
                    QuestManager.AcceptQuest(questID);
                }
                catch (Exception ex)
                {
                    QuestError(ex);
                }
            }

            if (function.StartsWith("IfHasQuest"))
            {
                string[] hasQuest = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value.Split('*'); 

                if (QuestManager.HasQuest(hasQuest[0]))
                {
                  /*  try
                    {
                        //QuestManager.CompleteQuest(hasQuest[0]);
                    }
                    catch (Exception ex)
                    {
                        QuestError(ex);
                    }*/

                    int goToMessage = Convert.ToInt32(hasQuest[1]);
                    if (currentNpc.Conversations.Contains(goToMessage))
                        currentNpc.CurrentConversation = currentNpc.Conversations.IndexOf(goToMessage);
                }
                else
                {
                    int goToMessage = Convert.ToInt32(hasQuest[2]);
                    if (currentNpc.Conversations.Contains(goToMessage))
                        currentNpc.CurrentConversation = currentNpc.Conversations.IndexOf(goToMessage);
                }
            }

            if (function.StartsWith("CompleteQuest"))
            {
                string questToComplete = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value;

                if (QuestManager.HasQuest(questToComplete))
                {
                     try
                      {
                          QuestManager.CompleteQuest(questToComplete);
                      }
                      catch (Exception ex)
                      {
                          QuestError(ex);
                      }
                }
            }

            if (function.StartsWith("IfFinishedQuest"))
            {
              //  +IfFinishedQuest(1*10*11)
                string[] hasQuest = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value.Split('*');

                if (QuestManager.HasQuest(hasQuest[0]))
                {
                    try
                    {
                        if (QuestManager.HasFinishedQuest(hasQuest[0]))
                        {
                            int goToMessage = Convert.ToInt32(hasQuest[1]);
                            if (currentNpc.Conversations.Contains(goToMessage))
                                currentNpc.CurrentConversation = currentNpc.Conversations.IndexOf(goToMessage);
                        }
                        else
                        {
                            int goToMessage = Convert.ToInt32(hasQuest[2]);
                            if (currentNpc.Conversations.Contains(goToMessage))
                                currentNpc.CurrentConversation = currentNpc.Conversations.IndexOf(goToMessage);
                        }

                        return "GoTo";
                    }
                    catch (Exception ex)
                    {
                        QuestError(ex);
                    }
                }

            }

            if (function.StartsWith("IfMadeDecision"))
            {
                string[] messages = Regex.Match(function, @"\(([^)]*)\)").Groups[1].Value.Split('*');

                foreach (string choice in messages)
                {
                    string fieldName = choice.Substring(0, choice.IndexOf('='));

                    string decision = choice.Substring(choice.IndexOf('=') + 1, choice.IndexOf('>') - choice.IndexOf('=') - 1);

                    string message = choice.Substring(choice.IndexOf('>') + 1, choice.Length - choice.IndexOf('>') - 1);

                    FieldInfo mInfo = typeof(DecisionData).GetField(fieldName);

                    object temp = mInfo.GetValue(DataManager.DecisionData);

                    if ((int)temp == Convert.ToInt32(decision))
                    {
                        additional = message;
                    }
                }
            }


            return "" + additional;
        }

        void QuestError(Exception msg)
        {
            dbConv = new DialogBox(gameRef.Content.Load<Texture2D>(@"GUI\convo"), new Rectangle(0, 0, gameRef.ScreenRectangle.Width, 100));

            dbConv.Position = new Vector2(0, 0);

            dbConv.Text = msg.Message;

            if (ControlManager.Count == 0)
            {
                dbConv.HasFocus = true;
                dbConv.Visible = true;
            }
            else
            {
                dbConv.HasFocus = false;
                dbConv.Visible = false;
            }

            ControlManager.Add(dbConv);

            ControlManager.NextControl();
        }

        #endregion

        #region Virtual Method region

        public void Update(GameTime gameTime, PlayerIndex playerIndex)
        {
            ControlManager.Update(gameTime, playerIndex);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            ControlManager.Draw(spriteBatch);
        }


        #endregion
    }
}
