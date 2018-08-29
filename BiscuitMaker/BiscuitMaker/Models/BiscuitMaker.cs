using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public class BiscuitMaker
    {
        public event EventHandler<OnClockTickEventArgs> OnClockTick;

        public event EventHandler<OnMotorPulseEventArgs> OnPulse;
        
        public event EventHandler<OnWorkingTempReachedEventArgs> OnWorkingTempReached;
        
        public event EventHandler<OnSwitchOnEventArgs> OnSwitchOn;

        public event EventHandler<OnSwitchOffEventArgs> OnSwitchOff;

        public event EventHandler<OnSwitchPauseEventArgs> OnSwitchPause;

        public List<IBiscuitComponent> Components { get; internal set; }

        private BiscuitMaker(List<IBiscuitComponent> components)
        {
            this.Components = components;
        }

        public static BiscuitMaker Create(List<IBiscuitComponent> components)
        {
            return new BiscuitMaker(components);
        }
    }
}
