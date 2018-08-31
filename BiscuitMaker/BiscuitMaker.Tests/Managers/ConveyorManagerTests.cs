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
    class ConveyorManagerTests : TestsBase
    {
        [Test]
        public void HandleOneMotorPulseTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            Action action = () => ConveyorManager.HandleMotorPulse(
                null, 
                new OnMotorPulseEventArgs { Maker = this.Maker }
            );

            action.Should().NotThrow();

            this.Maker.FirstConveyor.Belt.Count.Should().Be(6);
            this.Maker.FirstConveyor.Belt.ElementAt(1).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(1).IsExtruded.Should().BeTrue();
        }

        [Test]
        public void HandleTwoMotorPulseTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            Action action = () => ConveyorManager.HandleMotorPulse(
                null,
                new OnMotorPulseEventArgs { Maker = this.Maker }
            );

            action.Should().NotThrow();
            action.Invoke();

            this.Maker.FirstConveyor.Belt.Count.Should().Be(6);
            this.Maker.FirstConveyor.Belt.ElementAt(1).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(1).IsExtruded.Should().BeTrue();

            this.Maker.FirstConveyor.Belt.ElementAt(2).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(2).IsExtruded.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.ElementAt(2).IsStamped.Should().BeTrue();
        }

        [Test]
        public void HandleFullCycleMotorPulseTest()
        {
            BiscuitMakerManager.TurnOn(this.Maker);
            Action action = () => ConveyorManager.HandleMotorPulse(
                null,
                new OnMotorPulseEventArgs { Maker = this.Maker }
            );

            action.Should().NotThrow();
            action.Invoke();
            action.Invoke();
            action.Invoke();
            action.Invoke();
            action.Invoke();

            this.Maker.FirstConveyor.Belt.Count.Should().Be(6);
            this.Maker.FirstConveyor.Belt.ElementAt(0).Should().BeNull();

            this.Maker.FirstConveyor.Belt.ElementAt(1).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(1).IsExtruded.Should().BeTrue();

            this.Maker.FirstConveyor.Belt.ElementAt(2).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(2).IsExtruded.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.ElementAt(2).IsStamped.Should().BeTrue();

            this.Maker.FirstConveyor.Belt.ElementAt(3).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(3).IsExtruded.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.ElementAt(3).IsStamped.Should().BeTrue();
            
            this.Maker.FirstConveyor.Belt.ElementAt(4).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(4).IsExtruded.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.ElementAt(4).IsStamped.Should().BeTrue();

            this.Maker.FirstConveyor.Belt.ElementAt(5).Should().NotBeNull();
            this.Maker.FirstConveyor.Belt.ElementAt(5).IsExtruded.Should().BeTrue();
            this.Maker.FirstConveyor.Belt.ElementAt(5).IsStamped.Should().BeTrue();

            this.Maker.FirstBucket.Biscuits.Count.Should().Be(1);
            this.Maker.FirstBucket.Biscuits.First().IsExtruded.Should().BeTrue();
            this.Maker.FirstBucket.Biscuits.First().IsStamped.Should().BeTrue();
            this.Maker.FirstBucket.Biscuits.First().IsDone.Should().BeTrue();
        }
    }
}
