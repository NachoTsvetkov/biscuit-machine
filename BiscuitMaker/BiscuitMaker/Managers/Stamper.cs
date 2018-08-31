// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Stamper.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Stamper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using System.Linq;

    using BiscuitMaker.EventArgs;
    using BiscuitMaker.Models;

    public static class Stamper
    {
        /// <summary>
        /// The stamp.
        /// </summary>
        /// <param name="biscuit">
        /// The biscuit.
        /// </param>
        /// <returns>
        /// The <see cref="Biscuit"/>.
        /// </returns>
        public static Biscuit Stamp(Biscuit biscuit)
        {
            if (biscuit == null)
            {
                return null;
            }

            var newBiscuit = Biscuit.Create(
                isExtruded: biscuit.IsExtruded,
                isStamped: true,
                isDone: biscuit.IsDone);

            return newBiscuit;
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
            var conveyor = e.Maker.FirstConveyor;
            var stamperIndex = e.Maker.Settings.StamperIndex;
            var biscuitToBeStamped = conveyor.Belt.ElementAt(stamperIndex);
            var stampedBiscuit = Stamper.Stamp(biscuitToBeStamped);

            conveyor.Belt.Insert(stamperIndex, stampedBiscuit);
            conveyor.Belt.RemoveAt(stamperIndex + 1);
        }
    }
}