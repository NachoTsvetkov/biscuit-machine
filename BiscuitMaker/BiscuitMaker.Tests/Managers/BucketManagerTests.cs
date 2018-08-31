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
    class BucketManagerTests : ManagerTestsBase
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
