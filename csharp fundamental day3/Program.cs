namespace csharp_fundamental_day3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            ViewClock viewClock = new ViewClock();
            viewClock.Subscribe(clock);
            clock.Run();
        }
    }
}