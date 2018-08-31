using BiscuitMaker.Enumerations;
using BiscuitMaker.Managers;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace BiscuitMaker.Tests.Managers
{
    [TestFixture]
    class BiscuitMakerManagerTests : ManagerTestsBase
    {
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
