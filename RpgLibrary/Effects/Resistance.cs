namespace RpgLibrary.Effects
{
    public class Resistance
    {
        private int _amount;

        public DamageType ResistanceType { get; private set; }

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

        public Resistance(ResistanceData data)
        {
            ResistanceType = data.ResistanceType;
            Amount = data.Amount;
        }

        public int Apply(int damage)
        {
            return damage - (damage * Amount) / 100;
        }
    }
}
