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
using XRpgLibrary.CharacterClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class BattleScreen : BaseGameState
    {
        #region Field Region

        PictureBox pbBox;
        ListBox characterNames;
        LinkLabel battleMenu;
        MonsterParty thisBattle;
        int cnt = 0;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public BattleScreen(Game game, GameStateManager manager)
            :base(game, manager)
        {

        }

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        protected override void LoadContent()
        {
            base.LoadContent();

            thisBattle = GamePlayScreen.World.Levels[GamePlayScreen.World.CurrentLevel].LevelMonsters[0];

            ContentManager Content = Game.Content;

            pbBox = new PictureBox(
                Content.Load<Texture2D>(GamePlayScreen.World.Levels[GamePlayScreen.World.CurrentLevel].BattleBackground),
                GameRef.ScreenRectangle);

                  ControlManager.Add(pbBox);


            Rectangle battleMenuRectangle = new Rectangle(0, GameRef.ScreenRectangle.Bottom - 200, GameRef.ScreenRectangle.Width, 200);

            pbBox = new PictureBox(Content.Load<Texture2D>(@"Backgrounds\BattleBackgrounds\battlemenu"), battleMenuRectangle);

            ControlManager.Add(pbBox);

            characterNames = new ListBox(Content.Load<Texture2D>(@"Backgrounds\BattleBackgrounds\battlemenu"), Content.Load<Texture2D>(@"GUI\rightarrowUp"),
                new Vector2(20, 50));
            characterNames.Position = new Vector2(20, battleMenuRectangle.Top + 5);

            Label characterHealth = new Label();
            characterHealth.Position = new Vector2(70, battleMenuRectangle.Top + 5);
            characterHealth.Visible = true;
           // characterHealth.SpriteFont = 
            characterNames.Selected += new EventHandler(characterNames_Selected);



            foreach (Character character in GamePlayScreen.Player.Party)
            {
               // LinkLabel characterDetails = new LinkLabel();
               // characterDetails.Position = new Vector2(5, battleMenuRectangle.Top + 5);
               // characterDetails.Text = 

                characterNames.Items.Add(character.Entity.EntityName);
                characterHealth.Text = character.Entity.Health.CurrentValue.ToString() + @"/" + character.Entity.Health.MaximumValue.ToString();
                ControlManager.Add(characterHealth);
            }

            characterNames.Items.Add("Joe");
            characterHealth.Enabled = true;


            ControlManager.Add(characterNames);

            ControlManager.AcceptInput = true;

           characterNames.HasFocus = true;

           ControlManager.SelectedControl = 3;

            
        }

        private void characterNames_Selected(object sender, EventArgs e)
        {
            ListBox attackBox = new ListBox(Game.Content.Load<Texture2D>(@"Backgrounds\BattleBackgrounds\battlemenu"), Game.Content.Load<Texture2D>(@"GUI\rightarrowUp"),
                new Vector2(5, 3));
            attackBox.Items.Add("Attack");
            attackBox.Items.Add("Leave");
            attackBox.HasFocus = true;
            characterNames.HasFocus = false;
            attackBox.Position = new Vector2(100, GameRef.ScreenRectangle.Bottom - 210);
            ControlManager.Add(attackBox);
          //  ControlManager.NextControl();
            ControlManager.SelectedControl = 4;

            attackBox.Selected += new EventHandler(attackBox_Selected);
        }

        private void attackBox_Selected(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex == 0)
            {
                thisBattle.KillMonster(cnt++);

                characterNames.HasFocus = true;
                ControlManager.SelectedControl = 3;
                ControlManager.RemoveAt(4);

            }
            if (((ListBox)sender).SelectedIndex == 1)
            {
                characterNames.HasFocus = true;
                ControlManager.SelectedControl = 3;
                ControlManager.RemoveAt(4);
            }
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, PlayerIndex.One);

            if (thisBattle.Monsters.Count == 0)
            {
                StateManager.PopState();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);



            thisBattle.Draw(gameTime, GameRef.SpriteBatch);

            foreach (Character partyMember in GamePlayScreen.Player.Party)
            {
                partyMember.Sprite.Draw(gameTime, GameRef.SpriteBatch);
            }

            GameRef.SpriteBatch.End();
        }

        #endregion

    }
}
