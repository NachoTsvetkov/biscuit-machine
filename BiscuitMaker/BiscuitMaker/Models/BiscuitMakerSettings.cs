using System;

namespace BiscuitMaker
{
    public class BiscuitMakerSettings
    {
        public int ConveyorSize { get; set; }

        public int OvenMaxTemp { get; set; }

        public int OvenMinTemp { get; set; }

        public int OvenHeatingRate { get; set; }

        public int OvenCoolingRate { get; set; }

        public int ExtruderIndex { get; set; }

        public int SamperIndex { get; set; }

        public int OvenIndex { get; set; }

        public int OvenSize { get; set; }

        public int RoomTemperature { get; set; }

        public int RevolutionsPerTick { get; set; }
    }
}