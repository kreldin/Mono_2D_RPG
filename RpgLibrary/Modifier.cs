using System;

namespace RpgLibrary
{
    public struct Modifier
    {
        public int Amount;
        public int Duration;
        public TimeSpan TimeLeft;

        public Modifier(int amount)
        {
            Amount = amount;
            Duration = -1;
            TimeLeft = TimeSpan.Zero;
        }

        public Modifier(int amount, int duration)
        {
            Amount = amount;
            Duration = duration;
            TimeLeft = TimeSpan.FromSeconds(duration);
        }

        public void Update(TimeSpan elapsedTime)
        {
            if (Duration == -1) return;

            TimeLeft -= elapsedTime;

            if (!(TimeLeft.TotalMilliseconds < 0)) return;

            TimeLeft = TimeSpan.Zero;
            Amount = 0;
        }
    }
}
