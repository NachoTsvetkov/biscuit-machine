// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerManager.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitMakerManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using BiscuitMaker.Models;

    /// <summary>
    /// The biscuit maker manager.
    /// </summary>
    public static class BiscuitMakerManager
    {
        /// <summary>
        /// The turn on.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public static void TurnOn(BiscuitMakerObject maker)
        {
            maker.FirstSwitcher.TurnOn(maker);
        }

        /// <summary>
        /// The turn off.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public static void TurnOff(BiscuitMakerObject maker)
        {
            maker.FirstSwitcher.TurnOff(maker);
        }

        /// <summary>
        /// The pause.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public static void Pause(BiscuitMakerObject maker)
        {
            maker.FirstSwitcher.Pause(maker);
        }

        /// <summary>
        /// The tick.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public static void Tick(BiscuitMakerObject maker)
        {
            maker.FirstTimeRunner.Tick(maker);
        }
    }
}
