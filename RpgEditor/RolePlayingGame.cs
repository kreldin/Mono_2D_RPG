﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgEditor
{
    public class RolePlayingGame
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public RolePlayingGame(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
