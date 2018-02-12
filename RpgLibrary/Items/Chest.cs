using System;

namespace RpgLibrary.Items
{
    public class Chest : BaseItem
    {
        private static readonly Random Random = new Random();

        private readonly ChestData _chestData;

        public bool IsLocked => _chestData.IsLocked;

        public bool IsTrapped => _chestData.IsTrapped;

        public int Gold
        {
            get
            {
                if ((_chestData.MinGold == 0) && (_chestData.MaxGold == 0)) return 0;

                var gold = Random.Next(_chestData.MinGold, _chestData.MaxGold);
                _chestData.MinGold = 0;
                _chestData.MaxGold = 0;

                return gold;
            }
        }

        public Chest(ChestData chestData)
            : base(chestData.Name, "", 0, 0)
        {
            _chestData = chestData;
        }

        public override object Clone()
        {
            var data = new ChestData
            {
                Name = _chestData.Name,
                IsLocked = _chestData.IsLocked,
                IsTrapped = _chestData.IsTrapped,
                TextureName = _chestData.TextureName,
                TrapName = _chestData.TrapName,
                KeyName = _chestData.KeyName,
                MinGold = _chestData.MinGold,
                MaxGold = _chestData.MaxGold
            };

            foreach (var pair in _chestData.ItemCollection)
                data.ItemCollection.Add(pair.Key, pair.Value);

            var chest = new Chest(data);

            return chest;
        }
    }
}
