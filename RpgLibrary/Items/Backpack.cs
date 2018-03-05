using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Items
{
    public class Backpack
    {
        public List<GameItem> Items { get; } = new List<GameItem>();

        public int Capacity => Items.Count;

        public void AddItem(GameItem gameItem)
        {
            Items.Add(gameItem);
        }

        public void RemoveItem(GameItem gameItem)
        {
            Items.Remove(gameItem);
        }
    }
}
