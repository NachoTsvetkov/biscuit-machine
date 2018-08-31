// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventArgsBase.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the EventArgsBase type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.EventArgs
{
    using BiscuitMaker.Models;

    /// <summary>
    /// The event args base.
    /// </summary>
    public class EventArgsBase
    {
        /// <summary>
        /// Gets or sets the maker.
        /// </summary>
        public BiscuitMakerObject Maker { get; set; }
    }
}
