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

        public void TurnOn(BiscuitMaker maker)
        {
            Switcher.SetSwitch(maker, SwitchState.On);
            this.SwitchOn(maker);
        }

        public void TurnOff(BiscuitMaker maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Off);
            this.SwitchOff(maker);
        }

        public void Pause(BiscuitMaker maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Pause);
            this.SwitchPause(maker);
        }

        public void SwitchOn(BiscuitMaker maker)
        {
            this.RaiseSwitchOn?.Invoke(this, new OnSwitchOnEventArgs { Maker = maker });
        }

        public void SwitchOff(BiscuitMaker maker)
        {
            this.RaiseSwitchOff?.Invoke(this, new OnSwitchOffEventArgs { Maker = maker });
        }

        public void SwitchPause(BiscuitMaker maker)
        {
            this.RaiseSwitchPause?.Invoke(this, new OnSwitchPauseEventArgs { Maker = maker });
        }
    }
}
