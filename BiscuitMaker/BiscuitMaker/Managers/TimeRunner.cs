namespace BiscuitMaker.Managers
{
    using System;
    using BiscuitMaker.Models;

    public class TimeRunner : IBiscuitComponent
    {
        public event EventHandler<OnClockTickEventArgs> RaiseClockTick;

        public void Tick(BiscuitMakerObject maker)
        {
            this.RaiseClockTick?.Invoke(this, new OnClockTickEventArgs { Maker = maker });
        }
    }
}
