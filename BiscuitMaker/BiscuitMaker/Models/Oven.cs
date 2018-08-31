// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Oven.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Oven type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The oven.
    /// </summary>
    public class Oven : IBiscuitComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Oven"/> class.
        /// </summary>
        /// <param name="currentTemperature">
        /// The current temperature.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="isWorkingTemperature">
        /// The is working temperature.
        /// </param>
        private Oven(int currentTemperature, OvenState state, bool isWorkingTemperature)
        {
            this.CurrentTemperature = currentTemperature;
            this.State = state;
            this.IsWorkingTemperature = isWorkingTemperature;
        }

        /// <summary>
        /// Gets the current temperature.
        /// </summary>
        public int CurrentTemperature { get; private set; }

        /// <summary>
        /// Gets the state.
        /// </summary>
        public OvenState State { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is working temperature.
        /// </summary>
        public bool IsWorkingTemperature { get; private set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="currentTemperature">
        /// The current temperature.
        /// </param>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <param name="isWorkingTemperature">
        /// The is working temperature.
        /// </param>
        /// <returns>
        /// The <see cref="Oven"/>.
        /// </returns>
        public static Oven Create(int currentTemperature = 0, OvenState state = OvenState.Off, bool isWorkingTemperature = false)
        {
            return new Oven(currentTemperature, state, isWorkingTemperature);
        }
    }
}