// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerDisplay.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Simple facade for displaying current state. To be consumed and extended wherever
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker
{
    using BiscuitMaker.Models;
    
    /// <summary>
    /// Simple facade for displaying current state. To be consumed and extended wherever
    /// </summary>
    public class BiscuitMakerDisplay
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiscuitMakerDisplay"/> class.
        /// </summary>
        /// <param name="maker">
        /// The maker.
        /// </param>
        public BiscuitMakerDisplay(BiscuitMakerObject maker)
        {
            this.Maker = maker;
        }

        /// <summary>
        /// Gets the maker.
        /// </summary>
        public BiscuitMakerObject Maker { get; }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        public BiscuitMakerSettings Settings => this.Maker.Settings;

        /// <summary>
        /// The conveyor.
        /// </summary>
        public Conveyor Conveyor => this.Maker.FirstConveyor;

        /// <summary>
        /// The bucket.
        /// </summary>
        public BiscuitBucket Bucket => this.Maker.FirstBucket;

        /// <summary>
        /// Gets the switch.
        /// </summary>
        public Switch Switch => this.Maker.FirstSwitch;

        /// <summary>
        /// Gets the oven.
        /// </summary>
        public Oven Oven => this.Maker.FirstOven;
    }
}
