using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoRPG.GameScreens;
using RpgLibrary;

namespace MonoRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private static int ScreenWidth { get; } = 1024;
        private static int ScreenHeight { get; } = 768;

        private float FramesPerSecond { get; set; }
        private float UpdateInterval { get; } = 1.0f;
        private float TimeSinceLastUpdate { get; set; }
        private float FrameCount { get; set; }

        public SpriteBatch SpriteBatch { get; set; }
        public TitleScreen TitleScreen { get; set; }
        public StartMenuScreen StartMenuScreen { get; set; }
        public LoadGameScreen LoadGameScreen { get; set; }
        public CharacterGeneratorScreen CharacterGeneratorScreen { get; set; }
        public GamePlayScreen GamePlayScreen { get; set; }
        public SkillScreen SkillScreen { get; set; }
        public ConversationScreen ConversationScreen { get; set; }

        public Rectangle ScreenRectangle { get; }

        public GraphicsDeviceManager Graphics { get; }

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this)
            {
                GraphicsProfile = GraphicsProfile.HiDef,
                PreferredBackBufferWidth = ScreenWidth,
                PreferredBackBufferHeight = ScreenHeight
            };

            IsFixedTimeStep = true;
            Graphics.SynchronizeWithVerticalRetrace = false;

            ScreenRectangle = new Rectangle(0, 0, ScreenWidth, ScreenHeight);

            Content.RootDirectory = "Content";

            Components.Add(new InputHandler(this));

            var stateManager = new GameStateManager(this);
            Components.Add(stateManager);

            TitleScreen = new TitleScreen(this, stateManager);
            StartMenuScreen = new StartMenuScreen(this, stateManager);
            CharacterGeneratorScreen = new CharacterGeneratorScreen(this, stateManager);
            LoadGameScreen = new LoadGameScreen(this, stateManager);
            GamePlayScreen = new GamePlayScreen(this, stateManager);
            SkillScreen = new SkillScreen(this, stateManager);
            ConversationScreen = new ConversationScreen(this, stateManager);

            stateManager.ChangeState(TitleScreen);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            DataManager.ReadEntityData(Content);
            DataManager.ReadArmorData(Content);
            DataManager.ReadShieldData(Content);
            DataManager.ReadChestData(Content);
            DataManager.ReadWeaponData(Content);
            DataManager.ReadSkillData(Content);
            DataManager.ReadKeyData(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            var elapsed = (float) gameTime.ElapsedGameTime.TotalSeconds;
            ++FrameCount;
            TimeSinceLastUpdate += elapsed;

            if (!(TimeSinceLastUpdate > UpdateInterval)) return;

            FramesPerSecond = FrameCount / TimeSinceLastUpdate;
#if XBOX360
                System.Diagnostics.Debug.WriteLine("framesPerSecond: + framesPerSecond.ToString());
#else
            Window.Title = "FPS: " + FramesPerSecond;
#endif

            FrameCount = 0;
            TimeSinceLastUpdate -= UpdateInterval;
        }
    }
}
