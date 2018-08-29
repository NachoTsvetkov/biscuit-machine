using System;

namespace BiscuitMaker
{
    public class BiscuitMakerSettings
    {
        public int ConveyorSize { get; internal set; }

        public int OvenMaxTemp { get; internal set; }

        public int OvenMinTemp { get; internal set; }

        public int OvenHeatingRate { get; internal set; }

        public int OvenCoolingRate { get; internal set; }

        public int ExtruderIndex { get; set; }

        public int SamperIndex { get; set; }

        public int OvenIndex { get; set; }

        public int OvenSize { get; set; }
    }
}