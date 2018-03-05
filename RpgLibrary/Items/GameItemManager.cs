using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace RpgLibrary.Items
{
    public class GameItemManager
    {
        public Dictionary<string, GameItem> GameItems { get; } = new Dictionary<string, GameItem>();

        public static SpriteFont SpriteFront { get; private set; }

        public GameItemManager(SpriteFont spriteFont)
        {
            SpriteFront = spriteFont;
        }
    }
}
