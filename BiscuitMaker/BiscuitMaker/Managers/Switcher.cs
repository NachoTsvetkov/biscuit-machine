using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class Switcher : IBiscuitComponent
    {
        public event EventHandler<OnSwitchOnEventArgs> RaiseSwitchOn;

        public event EventHandler<OnSwitchOffEventArgs> RaiseSwitchOff;

        public event EventHandler<OnSwitchPauseEventArgs> RaiseSwitchPause;

        public static void SetSwitch(BiscuitMaker maker, SwitchState state)
        {
            var newSwitch = Switch.Create(state);
            maker.Components.Remove(maker.FirstSwitch);
            maker.Components.Add(newSwitch);
        }

        internal void TurnOn(BiscuitMaker maker)
        {
            Switcher.SetSwitch(maker, SwitchState.On);
            this.SwitchOn();
        }

        internal void TurnOff(BiscuitMaker maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Off);
            this.SwitchOff();
        }

        internal void Pause(BiscuitMaker maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Pause);
            this.SwitchPause();
        }

        public void SwitchOn()
        {
            this.RaiseSwitchOn?.Invoke(this, new OnSwitchOnEventArgs());
        }

        public void SwitchOff()
        {
            this.RaiseSwitchOff?.Invoke(this, new OnSwitchOffEventArgs());
        }

        public void SwitchPause()
        {
            this.RaiseSwitchPause?.Invoke(this, new OnSwitchPauseEventArgs());
        }
    }
}
