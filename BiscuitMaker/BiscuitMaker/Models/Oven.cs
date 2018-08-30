using BiscuitMaker.Enumerations;
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

        /// <summary>
        /// The Current Temperature of the oven
        /// </summary>
        public int CurrentTemperature { get; private set; }

        /// <summary>
        /// The Current Temperature of the oven
        /// </summary>
        public OvenState State { get; private set; }
        
        private Oven(int currentTemperature, OvenState state)
        {
            this.CurrentTemperature = currentTemperature;
            this.State = state;
        }

        public static Oven Create(int currentTemperature = 0, OvenState state = OvenState.Cooling)
        {
            return new Oven(currentTemperature, state);
        }
    }
}