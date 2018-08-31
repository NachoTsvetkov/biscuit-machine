namespace BiscuitMaker.Tests.Managers
{
    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;
    using FluentAssertions;
    using NUnit.Framework;
    using System;

    [TestFixture]
    class BiscuitMakerSettingsValidatorTests
    {
        [Test]
        public void ValidateValidSettingsTest()
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

            Action action = () => BiscuitMakerSettingsValidator.ValidateSettings(settings);
            action.Should().NotThrow();
        }

        [Test]
        public void ValidateNullSettingsTest()
        {
            BiscuitMakerSettings settings = null;

            Action action = () => BiscuitMakerSettingsValidator.ValidateSettings(settings, true);
            action.Should().Throw<ArgumentException>().WithMessage("Settings can not be null");
        }

        [Test]
        public void ValidateInvalidConveyorSizeSettingsTest()
        {
            BiscuitMakerSettings settings = new BiscuitMakerSettings
            {
                ConveyorSize = 3,
                ExtruderIndex = 5,
                OvenCoolingRate = 10,
                OvenHeatingRate = 10,
                OvenIndex = 3,
                OvenMaxTemp = 240,
                OvenMinTemp = 220,
                OvenSize = 2,
                StamperIndex = 1,
            };

            Action action = () => BiscuitMakerSettingsValidator.ValidateSettings(settings, true);
            action.Should().Throw<ArgumentException>().WithMessage("Conveyor too small");
        }

        [Test]
        public void ValidateInvalidComponentPlacemetSettingsTest()
        {
            BiscuitMakerSettings settings = new BiscuitMakerSettings
            {
                ConveyorSize = 6,
                ExtruderIndex = 5,
                OvenCoolingRate = 10,
                OvenHeatingRate = 10,
                OvenIndex = 3,
                OvenMaxTemp = 240,
                OvenMinTemp = 220,
                OvenSize = 2,
                StamperIndex = 1,
            };

            Action action = () => BiscuitMakerSettingsValidator.ValidateSettings(settings, true);
            action.Should().Throw<ArgumentException>().WithMessage("Invalid component placement");
        }

        [Test]
        public void ValidateInvalidOvenTemperatureSettingsTest()
        {
            BiscuitMakerSettings settings = new BiscuitMakerSettings
            {
                ConveyorSize = 6,
                ExtruderIndex = 0,
                OvenCoolingRate = 10,
                OvenHeatingRate = 10,
                OvenIndex = 3,
                OvenMaxTemp = 220,
                OvenMinTemp = 240,
                OvenSize = 2,
                StamperIndex = 1,
            };

            Action action = () => BiscuitMakerSettingsValidator.ValidateSettings(settings, true);
            action.Should().Throw<ArgumentException>().WithMessage("Invalid oven temperature settings");
        }
    }
}
