// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Switcher.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Switcher type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using System;

    using BiscuitMaker.Enumerations;
    using BiscuitMaker.EventArgs;
    using BiscuitMaker.Interfaces;
    using BiscuitMaker.Models;

    /// <inheritdoc />
    /// <summary>
    /// The switcher.
    /// </summary>
    public class Switcher : IBiscuitComponent
    {
        /// <summary>
        /// The raise switch on.
        /// </summary>
        public event EventHandler<OnSwitchOnEventArgs> RaiseSwitchOn;

        /// <summary>
        /// The raise switch off.
        /// </summary>
        public event EventHandler<OnSwitchOffEventArgs> RaiseSwitchOff;

        /// <summary>
        /// The raise switch pause.
        /// </summary>
        public event EventHandler<OnSwitchPauseEventArgs> RaiseSwitchPause;

        /// <summary>
        /// The set switch.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        public static void SetSwitch(BiscuitMakerObject maker, SwitchState state)
        {
            var newSwitch = Switch.Create(state);
            maker.Components.Remove(maker.FirstSwitch);
            maker.Components.Add(newSwitch);
        }

        /// <summary>
        /// The turn on.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void TurnOn(BiscuitMakerObject maker)
        {
            Switcher.SetSwitch(maker, SwitchState.On);
            this.SwitchOn(maker);
        }

        /// <summary>
        /// The turn off.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void TurnOff(BiscuitMakerObject maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Off);
            this.SwitchOff(maker);
        }

        /// <summary>
        /// The pause.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void Pause(BiscuitMakerObject maker)
        {
            Switcher.SetSwitch(maker, SwitchState.Pause);
            this.SwitchPause(maker);
        }

        /// <summary>
        /// The switch on.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void SwitchOn(BiscuitMakerObject maker)
        {
            this.RaiseSwitchOn?.Invoke(this, new OnSwitchOnEventArgs { Maker = maker });
        }

        /// <summary>
        /// The switch off.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void SwitchOff(BiscuitMakerObject maker)
        {
            this.RaiseSwitchOff?.Invoke(this, new OnSwitchOffEventArgs { Maker = maker });
        }

        /// <summary>
        /// The switch pause.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void SwitchPause(BiscuitMakerObject maker)
        {
            this.RaiseSwitchPause?.Invoke(this, new OnSwitchPauseEventArgs { Maker = maker });
        }
    }
}
