// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Switch.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Switch type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The switch.
    /// </summary>
    public class Switch : IBiscuitComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Switch"/> class.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        private Switch(SwitchState state)
        {
            this.State = state;
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public SwitchState State { get; set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="state">
        /// The state.
        /// </param>
        /// <returns>
        /// The <see cref="Switch"/>.
        /// </returns>
        public static Switch Create(SwitchState state = SwitchState.Off)
        {
            return new Switch(state);
        }
    }
}