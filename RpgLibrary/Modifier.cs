using System;

namespace RpgLibrary
{
    public class Modifier
    {
        public string Modifying { get; set; }
        public int Amount { get; set; }
        public int Duration { get; set; }
        public TimeSpan TimeLeft { get; set; }

        public Modifier(string modifying, int amount)
        {
            Modifying = modifying;
            Amount = amount;
            Duration = -1;
            TimeLeft = TimeSpan.Zero;
        }

        public Modifier(string modifying, int amount, int duration)
        {
            Modifying = modifying;
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
