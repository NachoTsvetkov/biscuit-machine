// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OvenState.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the OvenState type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Enumerations
{
    /// <summary>
    /// The oven state.
    /// </summary>
    public enum OvenState
    {
        /// <summary>
        /// The heating.
        /// </summary>
        Heating = 0,

        /// <summary>
        /// The cooling.
        /// </summary>
        Cooling = 1,

        /// <summary>
        /// The off.
        /// </summary>
        Off = 2,
    }
}
