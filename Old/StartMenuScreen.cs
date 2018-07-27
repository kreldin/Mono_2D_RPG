using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary.SpriteClasses;
using RpgLibrary.CharacterClasses;
using XRpgLibrary.CharacterClasses;
using EyesOfTheDragon.Components;
using RpgLibrary.SkillClasses;
using XRpgLibrary.WorldClasses;
using RpgLibrary.WorldClasses;

using XRpgLibrary;
using XRpgLibrary.Controls;

namespace EyesOfTheDragon.GameScreens
{
    public class StartMenuScreen : BaseGameState
    {
        #region Field region

       PictureBox backgroundImage;
        PictureBox arrowImage;
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel exitGame;
        float maxItemWidth = 0f;
        
        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
            : base(game, manager)
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

            ContentManager Content = Game.Content;

           backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\titlescreen"), 
                GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

            Texture2D arrowTexture = Content.Load<Texture2D>(@"GUI\leftarrowUp");
            
            arrowImage = new PictureBox(
                arrowTexture,
                new Rectangle(
                    0,
                    0,
                    arrowTexture.Width,
                    arrowTexture.Height));
            ControlManager.Add(arrowImage);

            startGame = new LinkLabel();
            startGame.Text = "The story begins";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.Selected +=new EventHandler(menuItem_Selected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "The story continues";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected += menuItem_Selected;

            ControlManager.Add(loadGame);

            exitGame = new LinkLabel();
            exitGame.Text = "The story ends";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menuItem_Selected;

            ControlManager.Add(exitGame);

            ControlManager.NextControl();

            ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);
            
            Vector2 position = new Vector2(350, 500);
            foreach (Control c in ControlManager)
            {
                if (c is LinkLabel)
                {
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;

                    c.Position = position;
                    position.Y += c.Size.Y + 5f;
                }
            }

            ControlManager_FocusChanged(startGame, null);
        }

        void ControlManager_FocusChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
            arrowImage.SetPosition(position);
        }

        private void menuItem_Selected(object sender, EventArgs e)
        {
            if (sender == startGame)
            {
               // Transition(ChangeType.Push, GameRef.CharacterGeneratorScreen);
                Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

                Animation animation = new Animation(3, 32, 32, 0, 0);
                animations.Add(AnimationKey.Down, animation);

                animation = new Animation(3, 32, 32, 0, 32);
                animations.Add(AnimationKey.Left, animation);

                animation = new Animation(3, 32, 32, 0, 64);
                animations.Add(AnimationKey.Right, animation);

                animation = new Animation(3, 32, 32, 0, 96);
                animations.Add(AnimationKey.Up, animation);

                Texture2D img = Game.Content.Load<Texture2D>(@"PlayerSprites\malefighter");

                AnimatedSprite sprite = new AnimatedSprite(
                    img,
                    animations);
                EntityGender gender = EntityGender.Male;

                Entity entity = new Entity(
                    "Pat",
                    DataManager.EntityData["Fighter"],
                    gender,
                    EntityType.Character);

               // entity.Health.MaximumValue = 50;
               // entity.Health.CurrentValue = 50;

                foreach (string s in DataManager.SkillData.Keys)
                {
                    Skill skill = Skill.FromSkillData(DataManager.SkillData[s]);
                    entity.Skills.Add(s, skill);
                }

                Character character = new Character(entity, sprite);

                GamePlayScreen.Player = new Player(GameRef, character);

                MapData mapData = Game.Content.Load<MapData>(@"Game\Levels\Maps\Village");

                LevelData levelData = Game.Content.Load<LevelData>(@"Game\Levels\Level 5000");

                Level level = new Level(levelData, mapData, Game,
                    DataManager.NPCData, DataManager.ChestData, DataManager.WeaponData, DataManager.ShieldData,
                    DataManager.ArmorData);

                World world = new World(GameRef, GameRef.ScreenRectangle);
                world.Levels.Add(level);
                world.CurrentLevel = level.LevelNumber;

                GamePlayScreen.World = world;

                Transition(ChangeType.Change, GameRef.GamePlayScreen);
            }

            if (sender == loadGame)
                Transition(ChangeType.Push, GameRef.LoadGameScreen);

            if (sender == exitGame)
                GameRef.Exit();
        }

        public override void Update(GameTime gameTime)
        {
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

        #region Game State Method Region
        #endregion

    }
}
