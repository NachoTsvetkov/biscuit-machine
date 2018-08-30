using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class Motor : IBiscuitComponent
    {
        public event EventHandler<OnMotorPulseEventArgs> RaisePulse;

        public void Pulse(BiscuitMaker maker)
        {
            this.RaisePulse?.Invoke(this, new OnMotorPulseEventArgs { Maker = maker });
        }

        internal void HandleClockTick(object sender, OnClockTickEventArgs e)
        {
            var canPulse = e.Maker.FirstOven.IsWorkingTemperature || e.Maker.FirstConveyor.HasBiscuits;

            if (!canPulse)
            {
                return;
            }

            for (int i = 0; i < e.Maker.Settings.RevolutionsPerTick; i++)
            {
                this.Pulse(e.Maker);
            }
        }
    }
}
