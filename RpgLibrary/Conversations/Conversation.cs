using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RpgLibrary.Conversations
{
    public class Conversation
    {
        private string _currentScene;

        public string Name { get; set; }
        public string FirstScene { get; set; }

        public Dictionary<string, GameScene> GameScenes { get; set; }

        [ContentSerializerIgnore]
        public GameScene CurrentScene => GameScenes[_currentScene];

        private Conversation()
        {
            
        }

        public Conversation(string name, string firstScene)
        {
            Name = name;
            _currentScene = firstScene;
            FirstScene = _currentScene;
        }

        public void Update(GameTime gameTime)
        {
            CurrentScene.Update(gameTime, PlayerIndex.One);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D portrait)
        {
            CurrentScene.Draw(gameTime, spriteBatch, portrait);
        }

        public void AddScene(string sceneName, GameScene scene)
        {
            if (!GameScenes.ContainsKey(sceneName))
                GameScenes.Add(sceneName, scene);
        }

        public GameScene GetScene(string sceneName)
        {
            return GameScenes.ContainsKey(sceneName) ? GameScenes[sceneName] : null;
        }

        public void StartConversation()
        {
            _currentScene = FirstScene;
        }

        public void ChangeScene(string sceneName)
        {
            _currentScene = sceneName;
        }
    }
}
