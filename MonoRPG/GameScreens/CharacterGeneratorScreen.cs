using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoRPG.Components;
using RpgLibrary.Characters;
using RpgLibrary.Items;
using RpgLibrary.Skills;
using RpgLibrary;
using RpgLibrary.Controls;
using RpgLibrary.Conversations;
using RpgLibrary.Sprites;
using RpgLibrary.TileEngine;
using RpgLibrary.World;

namespace MonoRPG.GameScreens
{
    public class CharacterGeneratorScreen : BaseGameState
    {
        private LeftRightSelector GenderSelector { get; set; }
        private LeftRightSelector ClassSelector { get; set; }
        private PictureBox BackgroundPictureBox { get; set; }
        private PictureBox CharacterPictureBox { get; set; }
        private Texture2D[,] CharacterImages { get; set; }
        private Texture2D Containers { get; set; }

        private string[] GenderItems { get; } = { "Male", "Female" };

        private string[] ClassItems { get; set; }

        public string SelectedGender => GenderSelector.SelectedItem;
        public string SelectedClass => ClassSelector.SelectedItem;

        public CharacterGeneratorScreen(Game game, GameStateManager manager) : base(game, manager)
        {
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

        protected override void LoadContent()
        {
            base.LoadContent();

            ClassItems = new string[DataManager.Entities.Count];

            var counter = 0;

            foreach (var className in DataManager.Entities.Keys)
            {
                ClassItems[counter] = className;
                ++counter;
            }

            LoadImages();
            CreateControls();
            Containers = Game.Content.Load<Texture2D>(@"ObjectSprites\containers");
        }

        private void LoadImages()
        {
            CharacterImages  = new Texture2D[GenderItems.Length, ClassItems.Length];

            for (var i = 0; i < GenderItems.Length; i++)
            {
                for (var j = 0; j < ClassItems.Length; j++)
                {
                    CharacterImages[i, j] =
                        Game.Content.Load<Texture2D>(@"Sprites\PlayerSprites\" + GenderItems[i].ToLower() + ClassItems[j].ToLower());
                }
            }
        }

        private void CreateControls()
        {
            var leftTexture = Game.Content.Load<Texture2D>(@"GUI\leftarrowUp");
            var rightTexture = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            var stopTexture = Game.Content.Load<Texture2D>(@"GUI\StopBar");

            BackgroundPictureBox = new PictureBox(
                Game.Content.Load<Texture2D>(@"Backgrounds\titlescreen"),
                GameRef.ScreenRectangle);
            ControlManager.Add(BackgroundPictureBox);

            var label = new Label {Text = "Who will search for the Eyes of the Dragon?"};
            label.Size = label.SpriteFont.MeasureString(label.Text);
            label.Position = new Vector2((GameRef.Window.ClientBounds.Width - label.Size.X) / 2, 150);
            ControlManager.Add(label);

            GenderSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            GenderSelector.SetItems(GenderItems, 125);
            GenderSelector.Position = new Vector2(label.Position.X, 200);
            GenderSelector.SelectionChanged += SelectionChanged;
            ControlManager.Add(GenderSelector);

            ClassSelector = new LeftRightSelector(leftTexture, rightTexture, stopTexture);
            ClassSelector.SetItems(ClassItems, 125);
            ClassSelector.Position = new Vector2(label.Position.X, 250);
            ClassSelector.SelectionChanged += SelectionChanged;
            ControlManager.Add(ClassSelector);

            var linkLabel = new LinkLabel
            {
                Text = "Accept this character.",
                Position = new Vector2(label.Position.X, 300)
            };
            linkLabel.Selected += LinkLabel_Selected;
            ControlManager.Add(linkLabel);

            CharacterPictureBox = new PictureBox(CharacterImages[0, 0],
                new Rectangle(500, 200, 96, 96),
                new Rectangle(0, 0, 32, 32));
            ControlManager.Add(CharacterPictureBox);

            ControlManager.NextControl();

            ControlManager.AcceptInput = true;
        }

        private void LinkLabel_Selected(object sender, EventArgs e)
        {
            InputHandler.Flush();

            CreatePlayer();
            CreateWorld();

            GameRef.SkillScreen.SkillPoints = 10;
            Transition(ChangeType.Change, GameRef.SkillScreen);
            GameRef.SkillScreen.SetTarget(GamePlayScreen.Player.Character);
        }

        private void SelectionChanged(object sender, EventArgs e)
        {
            CharacterPictureBox.Image = CharacterImages[GenderSelector.SelectedIndex, ClassSelector.SelectedIndex];
        }

        private void CreatePlayer()
        {
            var sprite = new AnimatedSprite(
                CharacterImages[GenderSelector.SelectedIndex, ClassSelector.SelectedIndex], 
                AnimationManager.Instance.Animations);

            var gender = EntityGender.Male;

            if (GenderSelector.SelectedIndex == 1)
                gender = EntityGender.Female;
            
            var entity = new Entity(
                "Kreldin",
                DataManager.Entities[ClassSelector.SelectedItem],
                gender,
                EntityType.Character);

            foreach (var s in DataManager.Skills.Keys)
            {
                var skill = Skill.FromSkillData(DataManager.Skills[s]);
                entity.Skills.Add(s, skill);
            }

            GamePlayScreen.Player = new Player(GameRef, new Character(entity, sprite));
        }

        private void CreateWorld()
        {
            base.LoadContent();

            var tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset1");
            var tileset1 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            tilesetTexture = Game.Content.Load<Texture2D>(@"Tilesets\tileset2");
            var tileset2 = new Tileset(tilesetTexture, 8, 8, Engine.TileWidth, Engine.TileHeight);

            var layer = new MapLayer(100, 100);

            for (var y = 0; y < layer.Height; y++)
            {
                for (var x = 0; x < layer.Width; x++)
                {
                    var tile = new Tile(0, 0);

                    layer.SetTile(x, y, tile);
                }
            }

            var splatter = new MapLayer(100, 100);
            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                var x = random.Next(0, 100);
                var y = random.Next(0, 100);
                var index = random.Next(2, 14);

                var tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

            splatter.SetTile(1, 0, new Tile(0, 1));
            splatter.SetTile(2, 0, new Tile(2, 1));
            splatter.SetTile(3, 0, new Tile(0, 1));

            var map = new TileMap(tileset1, layer);
            map.AddTileset(tileset2);
            map.AddLayer(splatter);

            var level = new Level(map);

            var chestData = Game.Content.Load<ChestData>(@"Game\Chests\Plain Chest");

            var chest = new Chest(chestData);

            var chestSprite = new BaseSprite(
                Containers,
                new Rectangle(0, 0, 32, 32),
                new Point(10,10));


            var itemSprite = new ItemSprite(
                chest,
                chestSprite);

            level.Chests.Add(itemSprite);

            GamePlayScreen.World = new World(GameRef, GameRef.ScreenRectangle);
            GamePlayScreen.World.AddLevel(level);
            GamePlayScreen.World.CurrentLevel = 0;

            var npcSprite = new AnimatedSprite(
                GameRef.Content.Load<Texture2D>(@"Sprites\NPCSprites\Eliza"),
                AnimationManager.Instance.Animations)
            {
                Position = new Vector2(5 * Engine.TileWidth, 5 * Engine.TileHeight)
            };

            var npcEntityData = new EntityData("Eliza", 10, 10, 10, 10, 10, 10, "20|CON|12", "16|WIL|16", "0|0|0");
            var entity = new Entity("Eliza", npcEntityData, EntityGender.Female, EntityType.NPC);
            var npc = new NonPlayerCharacter(entity, npcSprite);
            npc.SetConversation("eliza1");

            GamePlayScreen.World.Levels[GamePlayScreen.World.CurrentLevel].Characters.Add(npc);

            CreateConversation();
        }

        private void CreateConversation()
        {
            var c = new Conversation("eliza1", "welcome");

            var scene = new GameScene(
                GameRef,
                "basic_scene",
                "The unthinkable has happened. A thief has stolen the eyes of the village guardian." + 
                " With out his eyes the dragon will not be animated if the village is attacked.",
                new List<SceneOption>());

            var action = new SceneAction
            {
                Action = ActionType.Talk,
                Parameter = "none"
            };

            var option = new SceneOption("Continue", "welcome2", action);

            scene.Options.Add(option);

            c.AddScene("welcome", scene);

            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Will you retrieve the eyes of the dargon for us?",
                new List<SceneOption>());

            action = new SceneAction
            {
                Action = ActionType.Change,
                Parameter = "none"
            };

            option = new SceneOption("Yes", "eliza2", action);
            scene.Options.Add(option);

            action = new SceneAction()
            {
                Action = ActionType.Talk,
                Parameter = "none"
            };

            option = new SceneOption("No", "pleasehelp", action);
            scene.Options.Add(option);

            c.AddScene("welcome2", scene);

            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Please, you are the only one that can help us. If you change your mind " +
                "come back and see me.",
                new List<SceneOption>());

            action = new SceneAction
            {
                Action = ActionType.End,
                Parameter = "none"
            };

            option = new SceneOption("Bye", "welcome2", action);
            scene.Options.Add(option);

            c.AddScene("pleasehelp", scene);

            ConversationManager.Instance.AddConversation("eliza1", c);

            c = new Conversation("eliza2", "thankyou");

            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Thank you for agreeing to help us! Please find Faulke in the inn and ask " +
                "him what he knows about this thief",
                new List<SceneOption>());

            action = new SceneAction
            {
                Action = ActionType.Quest,
                Parameter = "Faulke"
            };

            option = new SceneOption("Continue", "thankyou2", action);

            scene.Options.Add(option);

            c.AddScene("thankyou", scene);

            scene = new GameScene(
                GameRef,
                "basic_scene",
                "Return to me once you've spoken with Faulke.",
                new List<SceneOption>());

            action = new SceneAction
            {
                Action = ActionType.End,
                Parameter = "none"
            };

            option = new SceneOption("Good Bye", "thankyou2", action);
            scene.Options.Add(option);

            c.AddScene("thankyou2", scene);

            ConversationManager.Instance.AddConversation("eliza2", c);
        }
    }
}
