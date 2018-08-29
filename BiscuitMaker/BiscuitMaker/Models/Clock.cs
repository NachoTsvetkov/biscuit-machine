using System;

namespace BiscuitMaker
{
    public class Clock : IBiscuitComponent
    {
        public event EventHandler<OnClockTickEventArgs> OnClockTick;
    }
}