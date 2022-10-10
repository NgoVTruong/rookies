namespace csharp_fundamental_day3
{
    public class Clock
    {
        private readonly int second;
        public delegate void clockTickHandler(object clock, ClockEventArgs clockEventArgs);
        public event clockTickHandler? clockTickEvent;
        protected void OnTick(object clock, ClockEventArgs clockEventArgs)
        {
            if (clockTickEvent != null)
            {
                clockTickEvent(clock, clockEventArgs);
            }
        }
        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                var time = DateTime.Now;

                if (time.Second != this.second)
                {
                    ClockEventArgs clockEventArgs = new ClockEventArgs(time.Hour, time.Minute, time.Second);
                    OnTick(this, clockEventArgs);
                }
            }
        }
        
    }
}