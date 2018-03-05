using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RpgLibrary.Items;

namespace RpgLibrary.Items
{
    public class GameItem
    {
        public Vector2 Position { get; set; }
        public Type Type { get; }
        public BaseItem Item { get;  }
        public Texture2D Image { get; }
        public Rectangle? SourceRectangle { get; set; }

        public GameItem(BaseItem item, Texture2D texture, Rectangle? source)
        {
            Item = item;
            Image = texture;
            SourceRectangle = source;

            Type = item.GetType();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Image, Position, SourceRectangle, Color.White);
        }
    }
}
