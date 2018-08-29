using System;
using System.Collections.Generic;
using System.Linq;
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

        /// <summary>
        /// The components are not separate properties because the Biscuit Maker can have
        /// multiple Stampers, Switches, Conveyors etc. Just to make it more flexible
        /// </summary>
        public List<IBiscuitComponent> Components { get; private set; }

        public BiscuitMakerSettings Settings { get; private set; }

        public Conveyor FirstConveyor
        {
            get
            {
                return (Conveyor)this.Components.FirstOrDefault(x => x is Conveyor);
            }
        }

        public Oven FirstOven
        {
            get
            {
                return (Oven)this.Components.FirstOrDefault(x => x is Oven);
            }
        }

        public BiscuitBucket FirstBucket
        {
            get
            {
                return (BiscuitBucket)this.Components.FirstOrDefault(x => x is BiscuitBucket);
            }
        }

        private BiscuitMaker(List<IBiscuitComponent> components, BiscuitMakerSettings settings)
        {
            this.Components = components;
            this.Settings = settings;
        }

        public static BiscuitMaker Create(List<IBiscuitComponent> components, BiscuitMakerSettings settings)
        {
            return new BiscuitMaker(components, settings);
        }
    }
}
