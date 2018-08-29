using System;

namespace BiscuitMaker
{
    public class Switch : IBiscuitComponent
    {
        public SwitchState State { get; set; }
        
        public event EventHandler<OnSwitchOnEventArgs> OnSwitchOn;

        public event EventHandler<OnSwitchOffEventArgs> OnSwitchOff;

        public event EventHandler<OnSwitchPauseEventArgs> OnSwitchPause;
    }
}