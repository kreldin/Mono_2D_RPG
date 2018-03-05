namespace RpgLibrary.Effects
{
    public class Weakness
    {
        private int _amount;

        public DamageType WeaknessType { get; private set; }

        public int Amount
        {
            get => _amount;
            private set
            {
                if (value < 0)
                    _amount = 0;
                else if (value > 100)
                    _amount = 100;
                else
                    _amount = value;
            }
        }

        public Weakness(WeaknessData data)
        {
            WeaknessType = data.WeaknessType;
            Amount = data.Amount;
        }

        public int Apply(int damage)
        {
            return damage + ((damage * Amount) / 100);
        }
    }
}
