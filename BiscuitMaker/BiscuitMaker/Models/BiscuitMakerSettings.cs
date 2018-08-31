// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerSettings.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitMakerSettings type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    /// <summary>
    /// The biscuit maker settings.
    /// </summary>
    public class BiscuitMakerSettings
    {
        /// <summary>
        /// Gets or sets the conveyor size.
        /// </summary>
        public int ConveyorSize { get; set; }

        /// <summary>
        /// Gets or sets the oven max temp.
        /// </summary>
        public int OvenMaxTemp { get; set; }

        /// <summary>
        /// Gets or sets the oven min temp.
        /// </summary>
        public int OvenMinTemp { get; set; }

        /// <summary>
        /// Gets or sets the oven heating rate.
        /// </summary>
        public int OvenHeatingRate { get; set; }

        /// <summary>
        /// Gets or sets the oven cooling rate.
        /// </summary>
        public int OvenCoolingRate { get; set; }

        /// <summary>
        /// Gets or sets the extruder index.
        /// </summary>
        public int ExtruderIndex { get; set; }

        /// <summary>
        /// Gets or sets the stamper index.
        /// </summary>
        public int StamperIndex { get; set; }

        /// <summary>
        /// Gets or sets the oven index.
        /// </summary>
        public int OvenIndex { get; set; }

        /// <summary>
        /// Gets or sets the oven size.
        /// </summary>
        public int OvenSize { get; set; }

        /// <summary>
        /// Gets or sets the room temperature.
        /// </summary>
        public int RoomTemperature { get; set; }

        /// <summary>
        /// Gets or sets the revolutions per tick.
        /// </summary>
        public int RevolutionsPerTick { get; set; }
    }
}