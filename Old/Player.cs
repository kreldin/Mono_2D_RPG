using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;
using XRpgLibrary.CharacterClasses;
using XRpgLibrary.ItemClasses;
using RpgLibrary.ItemClasses;
using XRpgLibrary.ConversationClasses;
using XRpgLibrary.Controls;
using RpgLibrary.QuestClasses;
using RpgLibrary.DecisionClasses;

using EyesOfTheDragon.GameScreens;
using XRpgLibrary.EventClasses;

namespace EyesOfTheDragon.Components
{
    public class Player
    {
        #region Field Region

        Camera camera;
        Game1 gameRef;
        Backpack backpack;
        readonly Character character;
        static float PickUpRadius = 64.0f;
        ControlManager ControlManager;
        ConversationManager ConversationManager;
        bool inConversation;
        List<Quest> quests;
        QuestManager QuestManager;
        List<Character> party;
        int stepsToNextBattle;

        #endregion

        #region Property Region

        public List<Character> Party
        {
            get { return party; }
        }

        public Camera Camera
        {
            get { return camera; }
            set { camera = value; }
        }

        public AnimatedSprite Sprite
        {
            get { return character.Sprite; }
        }

        public Character Character
        {
            get { return character; }
        }

        public Backpack Backpack
        {
            get { return backpack; }
        }

        public List<Quest> Quests
        {
            get { return QuestManager.CurrentQuests; }
        }

        #endregion

        public int StepsToNextBattle
        {
            get;
            set;
        }

        #region Constructor Region

        public Player(Game game, Character character)
        {
            gameRef = (Game1)game;
            camera = new Camera(gameRef.ScreenRectangle);
            backpack = new Backpack();
            this.character = character;
            SpriteFont menuFont = gameRef.Content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);
            QuestManager = new QuestManager(ControlManager);
            ConversationManager = new ConversationManager(this.gameRef, this.character, this.ControlManager, this.QuestManager);
            inConversation = false;
            quests = new List<Quest>();
            StepsToNextBattle = 10;
            SetUpParty();
        }

        #endregion

        #region Event Handler Region

        #endregion

        #region Method Region

        private void SetUpParty()
        {
            party = new List<Character>();
             Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

                Animation animation = new Animation(AnimationKey.Down);
                animations.Add(AnimationKey.Down, animation);

                animation = new Animation(AnimationKey.Left);
                animations.Add(AnimationKey.Left, animation);

                animation = new Animation(AnimationKey.Right);
                animations.Add(AnimationKey.Right, animation);

                animation = new Animation(AnimationKey.Up);
                animations.Add(AnimationKey.Up, animation);

            AnimatedSprite tempSprite = new AnimatedSprite(this.character.Sprite.Texture, animations);

            tempSprite.Position = new Vector2(600, 100);
            tempSprite.CurrentAnimation = AnimationKey.Left;

            Character member = new Character(this.character.Entity, tempSprite);


            party.Add(member);
        }

        private void ResetStepsToNextBattle()
        {
            StepsToNextBattle = 10;
        }

        public void Update(GameTime gameTime)
        {
            camera.Update(gameTime);
            Sprite.Update(gameTime);
           // ControlManager.Update(gameTime, PlayerIndex.One);
            ConversationManager.Update(gameTime, PlayerIndex.One);
            

            if (inConversation)
            {
                if (InputHandler.KeyReleased(Keys.Space))
                {
                    inConversation = ConversationManager.HandleInput();
                }   

                return;
            }

     /*       if (InputHandler.KeyReleased(Keys.PageUp) ||
                InputHandler.ButtonReleased(Buttons.LeftShoulder, PlayerIndex.One))
            {
                camera.ZoomIn();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }
            else if (InputHandler.KeyReleased(Keys.PageDown) ||
                InputHandler.ButtonReleased(Buttons.RightShoulder, PlayerIndex.One))
            {
                camera.ZoomOut();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }*/

            Vector2 motion = new Vector2();

            if (InputHandler.KeyDown(Keys.W) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickUp, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.KeyDown(Keys.S) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickDown, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }

            if (InputHandler.KeyDown(Keys.A) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickLeft, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.KeyDown(Keys.D) ||
                InputHandler.ButtonDown(Buttons.LeftThumbstickRight, PlayerIndex.One))
            {
                Sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (InputHandler.KeyReleased(Keys.P))
            {
                FieldInfo mInfo = typeof(DecisionData).GetField("WasMeanToDanik");

                object temp = mInfo.GetValue(DataManager.DecisionData);

                if ((int)temp == -1)
                {
                    gameRef.Window.Title = "Decision not made";
                     
                }

                if ((int)temp == 0)
                {
                    gameRef.Window.Title = "You were not mean to Danik.";
                }

                if ((int)temp == 1)
                {
                    gameRef.Window.Title = "You were mean to Danik!";
                }
            }

            if (motion != Vector2.Zero)
            {
                Sprite.IsAnimating = true;
                motion.Normalize();

                Vector2 positionAfterMove = Sprite.Position + (motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds);

                if (CheckCollision(positionAfterMove))
                {
                    Sprite.Position += motion * Sprite.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    Sprite.LockToMap();

                    if (camera.CameraMode == CameraMode.Follow)
                        camera.LockToSprite(Sprite);
                }

                if(--StepsToNextBattle == 0)
                {
                    //trigger battle
                    BattleScreen battleScreen = new BattleScreen(gameRef, gameRef.StateManager);

                    gameRef.GamePlayScreen.Transition(ChangeType.Push, battleScreen);

                    StepsToNextBattle = 10;
                }
            }
            else
            {
                Sprite.IsAnimating = false;
            }

         /*   if (InputHandler.KeyReleased(Keys.F) ||
                InputHandler.ButtonReleased(Buttons.RightStick, PlayerIndex.One))
            {
                camera.ToggleCameraMode();
                if (camera.CameraMode == CameraMode.Follow)
                    camera.LockToSprite(Sprite);
            }

            if (camera.CameraMode != CameraMode.Follow)
            {
                if (InputHandler.KeyReleased(Keys.C) ||
                    InputHandler.ButtonReleased(Buttons.LeftStick, PlayerIndex.One))
                {
                    camera.LockToSprite(Sprite);
                }
            } */

            if ((InputHandler.KeyReleased(Keys.M) ||
                InputHandler.ButtonReleased(Buttons.Y, PlayerIndex.One)) && !(gameRef.CurrentState is MenuScreen))
            {
                MenuScreen menu;

                if (gameRef.CurrentState == gameRef.GamePlayScreen)
                {
                    menu = new MenuScreen(gameRef, gameRef.StateManager); 

                    gameRef.GamePlayScreen.Transition(ChangeType.Push, menu);
                  
                }
             //   else if (gameRef.CurrentState is MenuScreen)
            //    {
              //      menu.Transition(ChangeType.Pop, gameRef.GamePlayScreen);
             //   }
            }

            if (InputHandler.KeyReleased(Keys.Space) ||
                InputHandler.ButtonReleased(Buttons.X, PlayerIndex.One))
            {
                if (gameRef.CurrentState == gameRef.GamePlayScreen)
                {
                    CheckItemPickup();

                    CheckNPCInteraction();

                    Rectangle player = new Rectangle((int)character.Sprite.Position.X, (int)character.Sprite.Position.Y,
                        Engine.TileWidth, Engine.TileWidth);

                    foreach (GameEvent gameEvent in GamePlayScreen.World.Levels[GamePlayScreen.World.CurrentLevel].GameEvents)
                    {
                        Rectangle eventRectangle = new Rectangle((int)Engine.CellToVector(gameEvent.EventPosition).X, 
                            (int)Engine.CellToVector(gameEvent.EventPosition).Y,
                            Engine.TileWidth, Engine.TileHeight);

                        if (player.Intersects(eventRectangle))
                        {
                            if (gameEvent is LevelTransitionEvent)
                            {
                               // gameRef.Window.Title = "Level Transition Event Fired";
                                LevelTransitionEvent tempEvent = gameEvent as LevelTransitionEvent;
                                GamePlayScreen.World.CurrentLevel = tempEvent.LevelNumber;
                            }

                            break;
                        }
                    }
                }
            }



            //gameRef.Window.Title = "Location: " + GamePlayScreen.Player.Sprite.Position.ToString(); 
        }

        private bool CheckCollision(Vector2 positionAfterMove)
        {
            int currentlevel = GamePlayScreen.World.CurrentLevel;

            Point position = Engine.VectorToCell(positionAfterMove);

            Rectangle player = new Rectangle((int)positionAfterMove.X, (int)positionAfterMove.Y,
                Engine.TileWidth, Engine.TileWidth);

            foreach (MapLayer layer in GamePlayScreen.World.Levels[currentlevel].Map.MapLayers)
            {
                try
                {
                    if (layer.GetTilePassable(position.X, position.Y) == false ||
                     layer.GetTilePassable(position.X + 1, position.Y) == false ||
                     layer.GetTilePassable(position.X, position.Y + 1) == false ||
                     layer.GetTilePassable(position.X + 1, position.Y + 1) == false)
                    {
                        return false;
                    }

                }
                catch (IndexOutOfRangeException)
                { }
            }

            List<ItemSprite> chests = GamePlayScreen.World.Levels[currentlevel].Chests;
            List<NonPlayerCharacter> characters = GamePlayScreen.World.Levels[currentlevel].Characters;

            for (int i = 0; i < characters.Count; i++)
            {
                Rectangle npcRect = new Rectangle((int)characters[i].Sprite.Position.X, (int)characters[i].Sprite.Position.Y,
                    Engine.TileWidth, Engine.TileHeight);

                if (player.Intersects(npcRect))
                    return false;

            }

            for (int i = 0; i < chests.Count; i++)
            {
                Rectangle chestRect = new Rectangle((int)chests[i].Sprite.Position.X, (int)chests[i].Sprite.Position.Y,
                    Engine.TileWidth, Engine.TileHeight);

                if (player.Intersects(chestRect) && chests[i].Sprite.ShowForQuest == true)
                    return false;
            }

                return true;
        }

        private bool IsCollidingWithObject(int x, int y, Point npcPosition)
        {
            if (x == npcPosition.X && y == npcPosition.Y)
                return false;
            else
                return true;
        }

        private void CheckItemPickup()
        {
      //      if (InputHandler.KeyPressed(Keys.Space))
        //    {
                int currentLevel = GamePlayScreen.World.CurrentLevel;
                List<ItemSprite> chests = GamePlayScreen.World.Levels[currentLevel].Chests;

                for (int i = 0; i < chests.Count; i++)
                {
                    if (CheckPickupRadius(chests[i]))
                    {
                        Chest tempChest = (Chest)chests[i].Item;
                        GameItem item = new GameItem(tempChest.Item, chests[i].Sprite.Texture,
                            chests[i].Sprite.Rectangle);

                        backpack.AddItem(item);
                        QuestManager.CheckItemPickUp(item);

                        chests.RemoveAt(i);
                        break;
                    }
                }
           // }
        }

        private void CheckNPCInteraction()
        {
                int currentLevel = GamePlayScreen.World.CurrentLevel;
                List<NonPlayerCharacter> characters = GamePlayScreen.World.Levels[currentLevel].Characters;

                for (int i = 0; i < characters.Count; i++)
                {
                    if (CheckNPCInteractionRadius(characters[i].Sprite))
                    {
                        ConversationManager.NewConversation(characters[i], 
                            new Conversation(DataManager.ConversationData[characters[i].Conversations[characters[i].CurrentConversation].ToString()]));

                        inConversation = true;
                        break;
                    }
                }
        }

        private bool CheckPickupRadius(ItemSprite item)
        {
            float distance = Vector2.Distance(
                item.Sprite.Position, character.Sprite.Position);

            if (distance < PickUpRadius)
            {
                return true;
            }

            return false;
        }

        private bool CheckNPCInteractionRadius(AnimatedSprite sprite)
        {
            float distance = Vector2.Distance(
               sprite.Position, character.Sprite.Position);

            if (distance < PickUpRadius)
            {
                return true;
            }

            return false;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            character.Draw(gameTime, spriteBatch);
            ConversationManager.Draw(spriteBatch);
        }

        #endregion
    }
}
