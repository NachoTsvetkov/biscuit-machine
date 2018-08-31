using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace BiscuitMaker.Tests.Managers
{
    [TestFixture]
    class ExtruderTests : TestsBase
    {
        [Test]
        public void ExtrudeTest()
        {
            Action action = () => Extruder.Extrude();

            action.Should().NotThrow();

            var biscuit = Extruder.Extrude();
            biscuit.IsExtruded.Should().BeTrue();
            biscuit.IsStamped.Should().BeFalse();
            biscuit.IsDone.Should().BeFalse();
        }

        [Test]
        public void HandleMotorPulseTest()
        {
            Action action = () => Extruder.HandleMotorPulse(
                null,
                new OnMotorPulseEventArgs { Maker = this.Maker }
            );

            action.Should().NotThrow();

            var biscuit = this.Maker.FirstConveyor.Belt.ElementAt(0);
            biscuit.Should().NotBeNull();
            biscuit.IsExtruded.Should().BeTrue();
            biscuit.IsStamped.Should().BeFalse();
            biscuit.IsDone.Should().BeFalse();
        }
    }
}
