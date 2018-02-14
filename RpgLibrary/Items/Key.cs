using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Items
{
    public class Key : BaseItem
    {
        public Key(string name, string type) : base(name, type, 0, 0, null)
        {
            
        }

        public override object Clone()
        {
            var key = new Key(Name, Type);

            return key;
        }
    }
}
