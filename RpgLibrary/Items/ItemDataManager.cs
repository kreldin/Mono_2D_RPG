﻿using System.Collections.Generic;

namespace RpgLibrary.Items
{
    public class ItemDataManager
    {
        public Dictionary<string, ArmorData> ArmorData { get; } = new Dictionary<string, ArmorData>();

        public Dictionary<string, ShieldData> ShieldData { get; } = new Dictionary<string, ShieldData>();

        public Dictionary<string, WeaponData> WeaponData { get; } = new Dictionary<string, WeaponData>();

        public Dictionary<string, ReagentData> ReagentData { get; } = new Dictionary<string, ReagentData>();

        public Dictionary<string, KeyData> KeyData { get; } = new Dictionary<string, KeyData>();

        public Dictionary<string, ChestData> ChestData { get; } = new Dictionary<string, ChestData>();
    }
}