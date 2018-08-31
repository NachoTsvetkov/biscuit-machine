namespace BiscuitMaker.Tests.Managers
{
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class MotorTests : TestsBase
    {
        [Test]
        public void PulseTest()
        {
            var hasPulsed = false;
            var motor = new Motor();

            motor.RaisePulse += (s, e) => hasPulsed = true;

            Action act = () => motor.Pulse(this.Maker);
            act.Should().NotThrow();
            hasPulsed.Should().BeTrue();
        }

        [Test]
        public void HandleInitialClockTickTest()
        {
            var hasPulsed = false;
            var motor = new Motor();

            motor.RaisePulse += (s, e) => hasPulsed = true;

            Action act = () => motor.HandleClockTick(null, new OnClockTickEventArgs { Maker = this.Maker });
            act.Should().NotThrow();

            hasPulsed.Should().BeFalse();
        }

        [Test]
        public void HandleFirstClockTickTest()
        {
            Switcher.SetSwitch(this.Maker, SwitchState.On);
            OvenManager.SetState(this.Maker, 220, OvenState.Heating);

            var hasPulsed = false;
            var motor = new Motor();

            motor.RaisePulse += (s, e) => hasPulsed = true;

            Action act = () => motor.HandleClockTick(null, new OnClockTickEventArgs { Maker = this.Maker });
            act.Should().NotThrow();

            hasPulsed.Should().BeTrue();
        }

        [Test]
        public void HandleOnInWorkTempClockTickTest()
        {
            Switcher.SetSwitch(this.Maker, SwitchState.On);
            OvenManager.SetState(this.Maker, 220, OvenState.Heating);

            var hasPulsed = false;
            var motor = new Motor();
            var arg = new OnClockTickEventArgs { Maker = this.Maker };

            motor.RaisePulse += (s, e) => hasPulsed = true;

            Action act = () => motor.HandleClockTick(null, arg);
            act.Should().NotThrow();
            
            hasPulsed.Should().BeTrue();
        }

        [Test]
        public void HandleOffWithBiscuitClockTickTest()
        {
            Switcher.SetSwitch(this.Maker, SwitchState.Off);
            OvenManager.SetState(this.Maker, 220, OvenState.Heating);
            this.Maker.FirstConveyor.Belt.Add(Biscuit.Create(true, true, false));

            var hasPulsed = false;
            var motor = new Motor();
            var arg = new OnClockTickEventArgs { Maker = this.Maker };

            motor.RaisePulse += (s, e) => hasPulsed = true;

            Action act = () => motor.HandleClockTick(null, arg);
            act.Should().NotThrow();

            hasPulsed.Should().BeTrue();
        }
    }
}
