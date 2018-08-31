// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Extruder.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Extruder type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.EventArgs;
    using BiscuitMaker.Models;

    /// <summary>
    /// The extruder.
    /// </summary>
    public static class Extruder
    {
        /// <summary>
        /// The extrude.
        /// </summary>
        /// <returns>
        /// The <see cref="Biscuit"/>.
        /// </returns>
        public static Biscuit Extrude()
        {
            var biscuit = Biscuit.Create(isExtruded: true);

            return biscuit;
        }

        /// <summary>
        /// The handle motor pulse.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            if (e.Maker.FirstSwitch.State != SwitchState.On)
            {
                return;
            }

            var conveyor = e.Maker.FirstConveyor;
            var extruderIndex = e.Maker.Settings.ExtruderIndex;
            var biscuit = Extruder.Extrude();
            conveyor.Belt.RemoveAt(extruderIndex);
            conveyor.Belt.Insert(extruderIndex, biscuit);
        }
    }
}