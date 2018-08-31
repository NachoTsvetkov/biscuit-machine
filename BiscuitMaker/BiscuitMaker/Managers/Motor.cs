using BiscuitMaker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class Motor : IBiscuitComponent
    {
        public event EventHandler<OnMotorPulseEventArgs> RaisePulse;

        public void Pulse(BiscuitMakerObject maker)
        {
            this.RaisePulse?.Invoke(this, new OnMotorPulseEventArgs { Maker = maker });
        }

        public void HandleClockTick(object sender, OnClockTickEventArgs e)
        {
            var canPulse = (e.Maker.FirstSwitch.State == SwitchState.On && e.Maker.FirstOven.IsWorkingTemperature) || 
                    (e.Maker.FirstSwitch.State == SwitchState.Off && e.Maker.FirstConveyor.HasBiscuits);

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
