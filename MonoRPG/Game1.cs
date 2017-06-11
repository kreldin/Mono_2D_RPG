﻿using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoRPG.GameScreens;
using XRpgLibrary;

namespace MonoRPG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private static int ScreenWidth { get; } = 1024;
        private static int ScreenHeight { get; } = 768;

        public SpriteBatch SpriteBatch { get; set; }
        public TitleScreen TitleScreen { get; set; }
        public StartMenuScreen StartMenuScreen { get; set; }
        public LoadGameScreen LoadGameScreen { get; set; }
        public CharacterGeneratorScreen CharacterGeneratorScreen { get; set; }
        public GamePlayScreen GamePlayScreen { get; set; }
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

            // TODO: use this.Content to load your game content here
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
        }
    }
}