namespace BiscuitMaker.Tests.Managers
{
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class OvenManagerTests : TestsBase
    {
        [Test]
        public void SetStateTest()
        {
            Action act = () => OvenManager.SetState(this.Maker, 220, OvenState.Heating);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
        }

        [Test]
        public void HandleSiwtchOnTest()
        {
            Action act = () => OvenManager.HandleSiwtchOn(null, new OnSwitchOnEventArgs { Maker = this.Maker });
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
        }

        [Test]
        public void HandleClockTickTest()
        {
            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Off);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(22);
        }

        [Test]
        public void HandleHeatingClockTickTest()
        {
            OvenManager.SetState(this.Maker, 100, OvenState.Heating);
            Switcher.SetSwitch(this.Maker, SwitchState.On);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(110);
        }

        [Test]
        public void HandleCoolingClockTickTest()
        {
            OvenManager.SetState(this.Maker, 230, OvenState.Cooling);
            Switcher.SetSwitch(this.Maker, SwitchState.On);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
        }

        [Test]
        public void HandleHeatingBorderTickTest()
        {
            OvenManager.SetState(this.Maker, 232, OvenState.Heating);
            Switcher.SetSwitch(this.Maker, SwitchState.On);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Cooling);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(240);
        }

        [Test]
        public void HandleCoolingBorderTickTest()
        {
            OvenManager.SetState(this.Maker, 228, OvenState.Cooling);
            Switcher.SetSwitch(this.Maker, SwitchState.On);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
        }

        [Test]
        public void HandlePausedHeatingBorderTickTest()
        {
            OvenManager.SetState(this.Maker, 232, OvenState.Heating);
            Switcher.SetSwitch(this.Maker, SwitchState.Pause);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Cooling);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(240);
        }

        [Test]
        public void HandlePausedCoolingBorderTickTest()
        {
            OvenManager.SetState(this.Maker, 228, OvenState.Cooling);
            Switcher.SetSwitch(this.Maker, SwitchState.Pause);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
        }

        [Test]
        public void HandleOffNoBiscuitTickTest()
        {
            OvenManager.SetState(this.Maker, 228, OvenState.Cooling);
            Switcher.SetSwitch(this.Maker, SwitchState.Off);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Off);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(218);
        }

        [Test]
        public void HandleOffNoBiscuitBorderTickTest()
        {
            OvenManager.SetState(this.Maker, 28, OvenState.Cooling);
            Switcher.SetSwitch(this.Maker, SwitchState.Off);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Off);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(22);
        }

        [Test]
        public void HandleOffBiscuitCoolingTickTest()
        {
            this.Maker.FirstConveyor.Belt.Add(Biscuit.Create(true, true, false));
            OvenManager.SetState(this.Maker, 221, OvenState.Cooling);
            Switcher.SetSwitch(this.Maker, SwitchState.Off);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Heating);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
        }

        [Test]
        public void HandleOffBiscuitHeatingTickTest()
        {
            this.Maker.FirstConveyor.Belt.Add(Biscuit.Create(true, true, false));
            OvenManager.SetState(this.Maker, 235, OvenState.Heating);
            Switcher.SetSwitch(this.Maker, SwitchState.Off);

            var arg = new OnClockTickEventArgs { Maker = this.Maker };
            Action act = () => OvenManager.HandleClockTick(null, arg);
            act.Should().NotThrow();

            this.Maker.FirstOven.State.Should().Be(OvenState.Cooling);
            this.Maker.FirstOven.CurrentTemperature.Should().Be(240);
        }
    }
}
