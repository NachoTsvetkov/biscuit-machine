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
    class SwitcherTests : ManagerTestsBase
    {
        [Test]
        public void SwitchOnTest()
        {
            var hasSwitchedOn = false;
            var switcher = new Switcher();

            switcher.RaiseSwitchOn += (s, e) => hasSwitchedOn = true;

            Action act = () => switcher.SwitchOn(this.Maker);
            act.Should().NotThrow();
            hasSwitchedOn.Should().BeTrue();
        }

        [Test]
        public void SwitchOffTest()
        {
            var hasSwitchedOff = false;
            var switcher = new Switcher();

            switcher.RaiseSwitchOff += (s, e) => hasSwitchedOff = true;

            Action act = () => switcher.SwitchOff(this.Maker);
            act.Should().NotThrow();
            hasSwitchedOff.Should().BeTrue();
        }

        [Test]
        public void SwitchPauseTest()
        {
            var hasSwitchedPause = false;
            var switcher = new Switcher();

            switcher.RaiseSwitchPause += (s, e) => hasSwitchedPause = true;

            Action act = () => switcher.SwitchPause(this.Maker);
            act.Should().NotThrow();
            hasSwitchedPause.Should().BeTrue();
        }

        [Test]
        public void TurnOnTest()
        {
            var hasSwitchedOn = false;
            var switcher = new Switcher();

            switcher.RaiseSwitchOn += (s, e) => hasSwitchedOn = true;

            Action act = () => switcher.TurnOn(this.Maker);
            act.Should().NotThrow();
            hasSwitchedOn.Should().BeTrue();
            this.Maker.FirstSwitch.State.Should().Be(SwitchState.On);
        }

        [Test]
        public void TurnOffTest()
        {
            var hasSwitchedOff = false;
            var switcher = new Switcher();

            switcher.RaiseSwitchOff += (s, e) => hasSwitchedOff = true;

            Action act = () => switcher.TurnOff(this.Maker);
            act.Should().NotThrow();
            hasSwitchedOff.Should().BeTrue();
            this.Maker.FirstSwitch.State.Should().Be(SwitchState.Off);
        }

        [Test]
        public void PauseTest()
        {
            var hasSwitchedPause = false;
            var switcher = new Switcher();

            switcher.RaiseSwitchPause += (s, e) => hasSwitchedPause = true;

            Action act = () => switcher.Pause(this.Maker);
            act.Should().NotThrow();
            hasSwitchedPause.Should().BeTrue();
            this.Maker.FirstSwitch.State.Should().Be(SwitchState.Pause);
        }
    }
}
