using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing",
              "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.")
    {}

    protected override void RunActivity()
    {
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in... ");
            Countdown(4);

            Console.Write("\nBreathe out... ");
            Countdown(4);
        }
    }
}