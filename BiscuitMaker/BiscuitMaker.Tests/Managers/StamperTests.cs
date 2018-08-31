using FluentAssertions;
using NUnit.Framework;
using System;
namespace BiscuitMaker.Tests.Managers
{
    using System.Linq;
    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;

    [TestFixture]
    class StamperTests : TestsBase
    {
        [Test]
        public void ExtrudeTest()
        {
            Action action = () => Stamper.Stamp(Biscuit.Create());

            action.Should().NotThrow();

            var biscuit = Stamper.Stamp(Biscuit.Create(true, false, false));
            biscuit.IsExtruded.Should().BeTrue();
            biscuit.IsStamped.Should().BeTrue();
            biscuit.IsDone.Should().BeFalse();
        }

        [Test]
        public void HandleMotorPulseTest()
        {
            this.Maker.FirstConveyor.Belt.Insert(1, Biscuit.Create(true, false, false));
            Action action = () => Stamper.HandleMotorPulse(
                null,
                new OnMotorPulseEventArgs { Maker = this.Maker }
            );

            action.Should().NotThrow();

            var biscuit = this.Maker.FirstConveyor.Belt.ElementAt(1);
            biscuit.Should().NotBeNull();
            biscuit.IsExtruded.Should().BeTrue();
            biscuit.IsStamped.Should().BeTrue();
            biscuit.IsDone.Should().BeFalse();
        }
    }
}
