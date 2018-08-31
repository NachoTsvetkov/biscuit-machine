// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeRunner.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the TimeRunner type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using System;

    using BiscuitMaker.EventArgs;
    using BiscuitMaker.Interfaces;
    using BiscuitMaker.Models;

    /// <inheritdoc />
    /// <summary>
    /// The time runner.
    /// </summary>
    public class TimeRunner : IBiscuitComponent
    {
        /// <summary>
        /// The raise clock tick.
        /// </summary>
        public event EventHandler<OnClockTickEventArgs> RaiseClockTick;

        /// <summary>
        /// The tick.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public void Tick(BiscuitMakerObject maker)
        {
            this.RaiseClockTick?.Invoke(this, new OnClockTickEventArgs { Maker = maker });
        }
    }
}
