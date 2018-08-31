namespace BiscuitMaker
{
    using BiscuitMaker.Enumerations;

    public class Oven : IBiscuitComponent
    {
        /// <summary>
        /// The Current Temperature of the oven
        /// </summary>
        public int CurrentTemperature { get; private set; }

        /// <summary>
        /// The Current Temperature of the oven
        /// </summary>
        public OvenState State { get; private set; }

        /// <summary>
        /// If the oven is in the working temperature
        /// </summary>
        public bool IsWorkingTemperature { get; private set; }

        private Oven(int currentTemperature, OvenState state, bool isWorkingTemperature)
        {
            this.CurrentTemperature = currentTemperature;
            this.State = state;
            this.IsWorkingTemperature = isWorkingTemperature;
        }

        public static Oven Create(int currentTemperature = 0, OvenState state = OvenState.Off, bool isWorkingTemperature = false)
        {
            return new Oven(currentTemperature, state, isWorkingTemperature);
        }
    }
}