using System;

namespace BiscuitMaker
{
    internal class Motor : IBiscuitComponent 
    {
        public event EventHandler<OnMotorPulseEventArgs> OnPulse;

        internal void OnSwitchOn(object sender, OnSwitchOnEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void OnSwitchOff(object sender, OnSwitchOffEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void OnSwitchPause(object sender, OnSwitchPauseEventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void OnWorkingTempReached(object sender, OnWorkingTempReachedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}