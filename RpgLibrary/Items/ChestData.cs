using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Items
{
    public class ChestData
    {
        public string Name { get; set; }
        public string TextureName { get; set; }
        public bool IsTrapped { get; set; }
        public bool IsLocked { get; set; }
        public string TrapName { get; set; }
        public string KeyName { get; set; }
        public int MinGold { get; set; }
        public int MaxGold { get; set; }
        public Dictionary<string, string> ItemCollection { get; set; } = new Dictionary<string, string>();

        public ChestData()
        {

        }

        public override string ToString()
        {
            var newString = new StringBuilder();
            const string divider = ", ";

            newString.Append(Name).Append(divider);
            newString.Append(TextureName).Append(divider);
            newString.Append(IsTrapped).Append(divider);
            newString.Append(IsLocked).Append(divider);
            newString.Append(TrapName).Append(divider);
            newString.Append(KeyName).Append(divider);
            newString.Append(MinGold).Append(divider);
            newString.Append(MaxGold);

            foreach (var pair in ItemCollection)
                newString.Append(divider).Append(pair.Key).Append('+').Append(pair.Value);

            return newString.ToString();
        }
}
}
