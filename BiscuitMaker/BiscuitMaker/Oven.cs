using System;

namespace BiscuitMaker
{
    public class Oven : IBiscuitComponent
    {
        public event EventHandler<OnWorkingTempReachedEventArgs> OnWorkingTempReached;

        internal void OnSwitchOff(object sender, OnSwitchOffEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void OnSwitchOn(object sender, OnSwitchOnEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void OnClockTick(object sender, OnClockTickEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}