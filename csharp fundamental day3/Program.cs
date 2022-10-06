using System;
namespace csharp_fundamental_day3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DisplayClock displayClock = new DisplayClock();
            displayClock.Subscribe(clock);
            clock.Run();
        }
    }
}