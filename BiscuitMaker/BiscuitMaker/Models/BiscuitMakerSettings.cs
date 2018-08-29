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
    }
}