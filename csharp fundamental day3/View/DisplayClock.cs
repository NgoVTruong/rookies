using System;

namespace csharp_fundamental_day3
{
    public class DisplayClock
    {
        public void Subscribe(Clock clock)
        {
            clock.clockTickEvent += new Clock.clockTickHandler(ShowClock);
        }
        public void ShowClock(object clock, ClockEventArgs clockEventArgs)
        {
            Console.WriteLine(
                $"{clockEventArgs.hour} : {clockEventArgs.minute} : {clockEventArgs.second}"
            );
        }

    }
}