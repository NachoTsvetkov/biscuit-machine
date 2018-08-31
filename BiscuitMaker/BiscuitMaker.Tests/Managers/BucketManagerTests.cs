
namespace BiscuitMaker.Tests.Managers
{
    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;
    using FluentAssertions;
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    class BucketManagerTests : TestsBase
    {
        [Test]
        public void HandleMotorPulseTest()
        {
            this.Maker.FirstConveyor.Belt.Add(Biscuit.Create(true, true, false));

            Action action = () => BucketManager.HandleMotorPulse(
                null,
                new OnMotorPulseEventArgs { Maker = this.Maker }
            );

            action.Should().NotThrow();

            var biscuit = this.Maker.FirstBucket.Biscuits.FirstOrDefault();
            biscuit.Should().NotBeNull();
            biscuit.IsExtruded.Should().BeTrue();
            biscuit.IsStamped.Should().BeTrue();
            biscuit.IsDone.Should().BeTrue();
        }
    }
}
