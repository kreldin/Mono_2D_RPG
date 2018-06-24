using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RpgLibrary.Conversations
{
    public class GameScene
    {
        private Vector2 TextPosition { get; set; }

        protected Game Game { get; set; }
        protected string TextureName { get; set; }
        protected Texture2D Texture { get; set; }
        protected SpriteFont Font { get; set; }
        

        public string Text { get; set; }
        public List<SceneOption> Options { get; set; }
        public int SelectedIndex { get; private set; }

        public Vector2 MenuPosition { get; private set; }

        [ContentSerializerIgnore]
        public Color HighlightColor { get; set; }

        [ContentSerializerIgnore]
        public Color NormalColor { get; set; }

        public static Texture2D Selected { get; private set; }

        private GameScene()
        {
            HighlightColor = Color.Red;
            NormalColor = Color.Blue;
        }

        public GameScene(string text, List<SceneOption> options, string textureName = "basic_scene")
        {
            Text = text;
            Options = options;
            TextureName = textureName;
            TextPosition = Vector2.Zero;
        }

        public GameScene(Game game, string textureName, string text, List<SceneOption> options)
        {
            Text = text;
            Game = game;
            TextureName = textureName;

            LoadContent(textureName);

            NormalColor = Color.Black;

            Options = options;
        }

        public void SetText(string text)
        {
            TextPosition = new Vector2(450, 50);

            var sb = new StringBuilder();
            var currentLength = 0f;

            if (Font == null)
            {
                Text = text;
                return;
            }

            var parts = Text.Split(' ');

            foreach (var s in parts)
            {
                var size = Font.MeasureString(s);

                if ((currentLength + size.X) < 500f)
                {
                    sb.Append(s);
                    sb.Append(" ");
                    currentLength += size.X;
                }
                else
                {
                    sb.Append("\n\r");
                    sb.Append(s);
                    sb.Append(" ");
                    currentLength = size.X;
                }
            }

            Text = sb.ToString();
        }

        public void Initialize()
        {
            
        }

        protected void LoadContent(string textureName)
        {
            Texture = Game.Content.Load<Texture2D>(@"Backgrounds\" + textureName);
            Selected = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");
            Font = Game.Content.Load<SpriteFont>(@"Fonts\scenefont");
        }

        public void Update(GameTime gameTime, PlayerIndex index)
        {
            if (InputHandler.IsKeyReleased(Keys.Up) ||
                InputHandler.IsButtonReleased(Buttons.LeftThumbstickUp, index))
            {
                if (--SelectedIndex < 0)
                    SelectedIndex = Options.Count - 1;
            }
            else if (InputHandler.IsKeyReleased(Keys.Down) ||
                     InputHandler.IsButtonReleased(Buttons.LeftThumbstickDown, index))
            {
                if (++SelectedIndex > (Options.Count - 1))
                    SelectedIndex = 0;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Texture2D portait)
        {
            var selectedPosition = new Vector2();
            var portraitRect = new Rectangle(25, 25, 425, 425);

            if (Selected == null)
                Selected = Game.Content.Load<Texture2D>(@"GUI\rightarrowUp");

            if (TextPosition == Vector2.Zero)
                SetText(Text);

            if (Texture == null)
                Texture = Game.Content.Load<Texture2D>(@"Backgrounds\" + TextureName);

            if (portait != null)
                spriteBatch.Draw(portait, portraitRect, Color.White);

            spriteBatch.DrawString(Font, Text, TextPosition, Color.White);

            var position = MenuPosition;

            for (var i = 0; i < Options.Count; ++i)
            {
                Color color;
                if (i == SelectedIndex)
                {
                    color = HighlightColor;
                    selectedPosition.X = position.X - 35;
                    selectedPosition.Y = position.Y;

                    spriteBatch.Draw(Selected, selectedPosition, Color.White);
                }
                else
                {
                    color = NormalColor;
                }

                spriteBatch.DrawString(Font, Options[i].OptionText, position, color);

                position.Y += Font.LineSpacing + 5;
            }
        }
    }
}
