using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class Motor : IBiscuitComponent
    {
        public event EventHandler<OnMotorPulseEventArgs> RaisePulse;

        public void Pulse()
        {
            this.RaisePulse?.Invoke(this, new OnMotorPulseEventArgs());
        }

        internal void HandleClockTick(object sender, OnClockTickEventArgs e)
        {
            for (int i = 0; i < e.Maker.Settings.RevolutionsPerTick; i++)
            {
                this.Pulse();
            }
        }
    }
}
