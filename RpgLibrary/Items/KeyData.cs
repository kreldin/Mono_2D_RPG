using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Items
{
    public class KeyData
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public KeyData()
        {
            
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Name).Append(", ").Append(Type);

            return sb.ToString();
        }
    }
}
