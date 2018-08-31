using BiscuitMaker.Enumerations;
using BiscuitMaker.Managers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker.Tests.Managers
{
    [TestFixture]
    class BiscuitMakerManagerTests
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

        [Test]
        public void TurnOnTest()
        {
            Action action = () => BiscuitMakerManager.TurnOn(this.Maker);
            action.Should().NotThrow();

            Maker.FirstSwitch.State.Should().Be(SwitchState.On);
            Maker.FirstOven.State.Should().Be(OvenState.Heating);
        }

        [Test]
        public void TurnOffTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            Action action = () => BiscuitMakerManager.TurnOff(this.Maker);
            action.Should().NotThrow();

            Maker.FirstSwitch.State.Should().Be(SwitchState.Off);
        }

        [Test]
        public void TurnPauseTest()
        {
            BiscuitMakerManager.TurnOff(this.Maker);
            Action action = () => BiscuitMakerManager.Pause(this.Maker);
            action.Should().NotThrow();

            Maker.FirstSwitch.State.Should().Be(SwitchState.Pause);
        }
    }
}
