﻿namespace BiscuitMaker.Tests.Managers
{
    using NUnit.Framework;

    [TestFixture]
    internal class ManagerTestsBase
    {
        static readonly BiscuitMakerSettings settings = new BiscuitMakerSettings
        {
            ConveyorSize = 6,
            ExtruderIndex = 0,
            OvenCoolingRate = 10,
            OvenHeatingRate = 10,
            OvenIndex = 3,
            OvenMaxTemp = 240,
            OvenMinTemp = 220,
            OvenSize = 2,
            StamperIndex = 1,
            RevolutionsPerTick = 1,
            RoomTemperature = 22,
        };

        public BiscuitMaker Maker { get; set; }

        [SetUp]
        public void SetUp()
        {
            this.Maker = BiscuitMakerFactory.Create(settings);
        }
    }
}