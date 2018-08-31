namespace BiscuitMaker.Managers
{
    using System;
    using BiscuitMaker.Models;

    public class Switcher : IBiscuitComponent
    {
        public event EventHandler<OnSwitchOnEventArgs> RaiseSwitchOn;

        public event EventHandler<OnSwitchOffEventArgs> RaiseSwitchOff;

        public event EventHandler<OnSwitchPauseEventArgs> RaiseSwitchPause;

        public static void SetSwitch(BiscuitMakerObject maker, SwitchState state)
        {
            var newSwitch = Switch.Create(state);
            maker.Components.Remove(maker.FirstSwitch);
            maker.Components.Add(newSwitch);
        }

        public void TurnOn(BiscuitMakerObject maker)
        {
            Switcher.SetSwitch(maker, SwitchState.On);
            this.SwitchOn(maker);
        }

        public void TurnOff(BiscuitMakerObject maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Off);
            this.SwitchOff(maker);
        }

        public void Pause(BiscuitMakerObject maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Pause);
            this.SwitchPause(maker);
        }

        public void SwitchOn(BiscuitMakerObject maker)
        {
            this.RaiseSwitchOn?.Invoke(this, new OnSwitchOnEventArgs { Maker = maker });
        }

        public void SwitchOff(BiscuitMakerObject maker)
        {
            this.RaiseSwitchOff?.Invoke(this, new OnSwitchOffEventArgs { Maker = maker });
        }

        public void SwitchPause(BiscuitMakerObject maker)
        {
            this.RaiseSwitchPause?.Invoke(this, new OnSwitchPauseEventArgs { Maker = maker });
        }
    }
}
