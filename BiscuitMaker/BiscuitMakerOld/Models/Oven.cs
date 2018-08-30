using System;

namespace BiscuitMaker
{
    public class Oven : IBiscuitComponent
    {
        /// <summary>
        /// Maximum temperature in celsius
        /// </summary>
        public int MaxTemp { get; private set; }

        /// <summary>
        /// Minimum temperature in celsius
        /// </summary>
        public int MinTemp { get; private set; }

        /// <summary>
        /// Heating rate degrees celsius per tick
        /// </summary>
        public int HeatingRate { get; private set; }

        /// <summary>
        /// Cooling rate degrees celsius per tick
        /// </summary>
        public int CoolingRate { get; private set; }

        private Oven(int maxTemp, int minTemp, int heatingRate, int coolingRate)
        {
            this.MaxTemp = maxTemp;
            this.MinTemp = minTemp;
            this.HeatingRate = heatingRate;
            this.CoolingRate = coolingRate;
        }

        public static Oven Create(BiscuitMakerSettings settings)
        {
            return new Oven(
                settings.OvenMaxTemp,
                settings.OvenMinTemp,
                settings.OvenHeatingRate,
                settings.OvenCoolingRate
            );
        }
    }
}