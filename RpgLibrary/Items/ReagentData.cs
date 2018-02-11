using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgLibrary.Items
{
    public class ReagentData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public float Weight { get; set; }

        public ReagentData()
        {
            
        }

        public override string ToString()
        {
            var newString = new StringBuilder();
            const string divider = ", ";

            newString.Append(Name).Append(divider);
            newString.Append(Type).Append(divider);
            newString.Append(Price).Append(divider);
            newString.Append(Weight).Append(divider);

            return newString.ToString();
        }
    }
}
