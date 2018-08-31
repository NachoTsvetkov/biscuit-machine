using BiscuitMaker.Enumerations;
using BiscuitMaker.Managers;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace BiscuitMaker.Tests.Managers
{
    [TestFixture]
    class BiscuitMakerManagerTests : TestsBase
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
        
        [Test]
        public void HeatUpTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            BiscuitMakerManager.Tick(this.Maker);

            this.Maker.FirstConveyor.HasBiscuits.Should().BeFalse();
            this.Maker.FirstOven.CurrentTemperature.Should().Be(32);

            for (int i = 0; i < 19; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(222);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(1);

            
        }
        
        [Test]
        public void HitMaxTempTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 22; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(240);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(3);
        }

        [Test]
        public void HitMinTempTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(5);
        }

        [Test]
        public void CreateFiveTurnOffAndCheckOvenTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.TurnOff(this.Maker);

            BiscuitMakerManager.Tick(this.Maker);
            BiscuitMakerManager.Tick(this.Maker);

            this.Maker.FirstOven.CurrentTemperature.Should().Be(240);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(3);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(2);
        }

        [Test]
        public void CheckTurnOffMinBorderTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }
            
            BiscuitMakerManager.TurnOff(this.Maker);

            for (int i = 0; i < 4; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(1);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(4);

            
        }
        
        [Test]
        public void CreateFiveTurnOffAndUnloadTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.TurnOff(this.Maker);

            for (int i = 0; i < 5; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }
            
            this.Maker.FirstOven.CurrentTemperature.Should().Be(230);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeFalse();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(0);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(5);
        }

        [Test]
        public void TurnOffOvenTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.TurnOff(this.Maker);

            for (int i = 0; i < 6; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }
            
            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstOven.State.Should().Be(OvenState.Off);
        }

        [Test]
        public void OvenCoolDownTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.TurnOff(this.Maker);

            for (int i = 0; i < 26; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(22);
        }
        
        [Test]
        public void PauseOvenKeepWorkingTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }
            
            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(5);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(0);

            BiscuitMakerManager.Pause(this.Maker);
            
            for (int i = 0; i < 2; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(240);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(5);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(0);


            for (int i = 0; i < 2; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(5);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(0);
        }
        
        [Test]
        public void PauseTurnOnTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.Pause(this.Maker);

            for (int i = 0; i < 2; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }
            
            BiscuitMakerManager.TurnOn(this.Maker);

            for (int i = 0; i < 2; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(5);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(2);
        }

        [Test]
        public void PauseTurnOffTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            for (int i = 0; i < 24; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.Pause(this.Maker);

            for (int i = 0; i < 2; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            BiscuitMakerManager.TurnOff(this.Maker);

            for (int i = 0; i < 2; i++)
            {
                BiscuitMakerManager.Tick(this.Maker);
            }

            this.Maker.FirstOven.CurrentTemperature.Should().Be(220);
            this.Maker.FirstConveyor.HasBiscuits.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.Count(x => x != null).Should().Be(3);
            this.Maker.FirstBucket.Biscuits.Count.Should().Be(2);
        }
    }
}
