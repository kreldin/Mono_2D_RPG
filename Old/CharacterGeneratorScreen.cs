using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;
using XRpgLibrary.Controls;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.TileEngine;
using XRpgLibrary.WorldClasses;

using XRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;
using RpgLibrary.CharacterClasses;
using XRpgLibrary.CharacterClasses;

using EyesOfTheDragon.Components;
using RpgLibrary.SkillClasses;

using RpgLibrary.WorldClasses;

namespace EyesOfTheDragon.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        #region Field Region

        LeftRightSelector genderSelector;
        LeftRightSelector classSelector;
        PictureBox backgroundImage;

        PictureBox characterImage;
        Texture2D[,] characterImages;


        string[] genderItems = { "Male", "Female" };
        string[] classItems;

        #endregion

        #region Property Region

        public string SelectedGender
        {
            get { return genderSelector.SelectedItem; }
        }

        public string SelectedClass
        {
            get { return classSelector.SelectedItem; }
        }

        #endregion

        #region Constructor Region

        public CharacterGeneratorScreen(Game game, GameStateManager stateManager)
            : base(game, stateManager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            classItems = new string[DataManager.EntityData.Count];

            int counter = 0;

            foreach (string className in DataManager.EntityData.Keys)
            {
                classItems[counter] = className;
                counter++;
            }

            LoadImages();
            CreateControls();
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

        #endregion

        #region Method Region

        private void CreateControls()
        {
            Texture2D leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            Texture2D rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            Texture2D stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            backgroundImage = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Label label1 = new Label();

            label1.Text = "Who will search for the Eyes of the Dragon?";
            label1.Size = label1.SpriteFont.MeasureString(label1.Text);
            label1.Position = new Vector2((GameRef.Window.ClientBounds.Width - label1.Size.X) / 2, 150);

            ControlManager.Add(label1);

            genderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            genderSelector.SetItems(genderItems, 125);
            genderSelector.Position = new Vector2(label1.Position.X, 200);
            genderSelector.SelectionChanged += new EventHandler(selectionChanged);

            ControlManager.Add(genderSelector);

            classSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            classSelector.SetItems(classItems, 125);
            classSelector.Position = new Vector2(label1.Position.X, 250);
            classSelector.SelectionChanged += selectionChanged;

            ControlManager.Add(classSelector);

            LinkLabel linkLabel1 = new LinkLabel();
            linkLabel1.Text = "Accept this character.";
            linkLabel1.Position = new Vector2(label1.Position.X, 300);
            linkLabel1.Selected += new EventHandler(linkLabel1_Selected);

            ControlManager.Add(linkLabel1);

            characterImage = new PictureBox(
                characterImages[0, 0], 
                new Rectangle(500, 200, 96, 96), 
                new Rectangle(0, 0, 32, 32));
            ControlManager.Add(characterImage);

            ControlManager.NextControl();
        }

        private void LoadImages()
        {
            characterImages = new Texture2D[genderItems.Length, classItems.Length];

            for (int i = 0; i < genderItems.Length; i++)
            {
                for (int j = 0; j < classItems.Length; j++)
                {
                    characterImages[i, j] = Game.Content.Load<Texture2D>(@"PlayerSprites\" + genderItems[i] + classItems[j]);
                }
            }
        }

        void linkLabel1_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            CreateWorld();

            GameRef.SkillScreen.SkillPoints = 10;
            Transition(ChangeType.Change, GameRef.SkillScreen);
            GameRef.SkillScreen.SetTarget(GamePlayScreen.Player.Character);
        }

        private void CreatePlayer()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            AnimatedSprite sprite = new AnimatedSprite(
                characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex],
                animations);
            EntityGender gender = EntityGender.Male;

            if (genderSelector.SelectedIndex == 1)
                gender = EntityGender.Female;

            Entity entity = new Entity(
                "Pat",
                DataManager.EntityData[classSelector.SelectedItem],
                gender,
                EntityType.Character);

            foreach (string s in DataManager.SkillData.Keys)
            {
                Skill skill = Skill.FromSkillData(DataManager.SkillData[s]);
                entity.Skills.Add(s, skill);
            }

            Character character = new Character(entity, sprite);

            GamePlayScreen.Player = new Player(GameRef, character);
        }

        private void CreateWorld()
        {    

            MapData mapData = Game.Content.Load<MapData>(@"Game\Levels\Maps\Village");

            LevelData levelData = Game.Content.Load<LevelData>(@"Game\Levels\Level 5000");
            
            Level level = new Level(levelData, mapData, Game,
                DataManager.NPCData, DataManager.ChestData, DataManager.WeaponData, DataManager.ShieldData, 
                DataManager.ArmorData);

            World world = new World(GameRef, GameRef.ScreenRectangle);
            world.Levels.Add(level);
            world.CurrentLevel = level.LevelNumber;

            GamePlayScreen.World = world;         
        }

        void selectionChanged(object sender, EventArgs e)
        {
            characterImage.Image = characterImages[genderSelector.SelectedIndex, classSelector.SelectedIndex];
        }

        #endregion
    }
}
