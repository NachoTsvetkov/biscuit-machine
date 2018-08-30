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
    public class BiscuitMakerFactoryTests
    {
        [Test]
        public void CreateWithNoSettingsTest()
        {
            Action create = () => BiscuitMakerFactory.Create();
            create.Should().NotThrow();
        }

        [Test]
        public void CreateWithValidSettingsTest()
        {
            var settings = new BiscuitMakerSettings
            {
                ConveyorSize = 6,
                ExtruderIndex = 0,
                OvenCoolingRate = 10,
                OvenHeatingRate = 10,
                OvenIndex = 3,
                OvenMaxTemp = 240,
                OvenMinTemp = 220,
                OvenSize = 2,
                StamperIndex = 1,
            };

            Action create = () => BiscuitMakerFactory.Create(settings);
            create.Should().NotThrow();
        }
    }
}
