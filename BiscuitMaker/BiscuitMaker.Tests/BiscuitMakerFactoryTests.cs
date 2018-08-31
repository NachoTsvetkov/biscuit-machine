using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker.Tests
{
    [TestFixture]
    public class BiscuitMakerFactoryTests : TestsBase
    {
        [Test]
        public void CreateWithNoSettingsTest()
        {
            Action create = () => BiscuitMakerFactory.Create();
            create.Should().NotThrow();
        }

        [Test]
        public void MakerPropertiesBuildTest()
        {
            this.Maker.FirstBucket.Should().NotBeNull();
            this.Maker.FirstConveyor.Should().NotBeNull();
            this.Maker.FirstMotor.Should().NotBeNull();
            this.Maker.FirstOven.Should().NotBeNull();
            this.Maker.FirstSwitch.Should().NotBeNull();
            this.Maker.FirstSwitcher.Should().NotBeNull();
            this.Maker.FirstTimeRunner.Should().NotBeNull();
        }
    }
}
