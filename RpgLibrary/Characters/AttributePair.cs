using Microsoft.Xna.Framework;

namespace RpgLibrary.Characters
{
    public class AttributePair
    {
        private int _currentValue;

        public int CurrentValue
        {
            get => _currentValue;
            private set => _currentValue = MathHelper.Clamp(value, 0, MaximumValue);
        }

        public int MaximumValue { get; private set; }

        public static AttributePair Zero => new AttributePair();

        private AttributePair()
        {
            CurrentValue = 0;
            MaximumValue = 0;
        }

        public AttributePair(int maxValue)
        {
            CurrentValue = maxValue;
            MaximumValue = maxValue;
        }

        public void Heal(ushort value)
        {
            CurrentValue += value;
        }

        public void Damage(ushort value)
        {
            CurrentValue -= value;
        }

        public void SetCurrent(int value)
        {
            CurrentValue = value;
        }

        public void SetMaximum(int value)
        {
            MaximumValue = value;
            CurrentValue = CurrentValue;
        }
}
}
