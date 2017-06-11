using System.Collections.Generic;

namespace RpgLibrary.Items
{
    public class ItemManager
    {
        private readonly Dictionary<string, BaseItem> _items = new Dictionary<string, BaseItem>();

        public Dictionary<string, BaseItem>.KeyCollection ItemKeys => _items.Keys;

        public void AddItem(BaseItem item)
        {
            if (!ContainsItem(item.Name))
                _items.Add(item.Name, item);
        }

        public BaseItem GetItem(string name)
        {
            if (ContainsItem(name))
                return (BaseItem)_items[name].Clone();
            return null;
        }

        public bool ContainsItem(string name)
        {
            return _items.ContainsKey(name);
        }
    }
}
