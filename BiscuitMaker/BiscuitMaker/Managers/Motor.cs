// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Motor.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Motor type.
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
    /// The motor.
    /// </summary>
    public class Motor : IBiscuitComponent
    {
        /// <summary>
        /// The raise pulse.
        /// </summary>
        public event EventHandler<OnMotorPulseEventArgs> RaisePulse;

        /// <summary>
        /// The pulse.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void Pulse(BiscuitMakerObject maker)
        {
            this.RaisePulse?.Invoke(this, new OnMotorPulseEventArgs { Maker = maker });
        }

        /// <summary>
        /// The handle clock tick.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void HandleClockTick(object sender, OnClockTickEventArgs e)
        {
            var canPulse = (e.Maker.FirstSwitch.State == SwitchState.On && e.Maker.FirstOven.IsWorkingTemperature) || 
                    (e.Maker.FirstSwitch.State == SwitchState.Off && e.Maker.FirstConveyor.HasBiscuits);

            if (!canPulse)
            {
                return;
            }

            for (var i = 0; i < e.Maker.Settings.RevolutionsPerTick; i++)
            {
                this.Pulse(e.Maker);
            }
        }
    }
}
