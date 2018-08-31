// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerFactory.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitMakerFactory type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker
{
    using System.Collections.Generic;

    using BiscuitMaker.Interfaces;
    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;

    /// <summary>
    /// The biscuit maker factory.
    /// </summary>
    public static class BiscuitMakerFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <returns>
        /// The <see cref="BiscuitMakerObject"/>.
        /// </returns>
        public static BiscuitMakerObject Create(BiscuitMakerSettings settings = null)
        {
            var settingsAreValid = BiscuitMakerSettingsValidator.ValidateSettings(settings, false);

            if (!settingsAreValid)
            {
                return null;
            }

            var components = new List<IBiscuitComponent>();

            var switchComponent = Switch.Create();
            components.Add(switchComponent);

            var switcher = new Switcher();
            components.Add(switcher);

            if (settings != null)
            {
                var conveyor = Conveyor.Create(count: settings.ConveyorSize);
                components.Add(conveyor);
            }

            if (settings != null)
            {
                var oven = Oven.Create(settings.RoomTemperature);
                components.Add(oven);
            }

            var bucket = BiscuitBucket.Create();
            components.Add(bucket);

            var motor = new Motor();
            components.Add(motor);

            var timeRunner = new TimeRunner();
            components.Add(timeRunner);

            var biscuitMaker = BiscuitMakerObject.Create(components, settings);
            biscuitMaker.FirstSwitcher.RaiseSwitchOn += OvenManager.HandleSwitchOn;
            biscuitMaker.FirstTimeRunner.RaiseClockTick += OvenManager.HandleClockTick;

            biscuitMaker.FirstTimeRunner.RaiseClockTick += biscuitMaker.FirstMotor.HandleClockTick;
            biscuitMaker.FirstMotor.RaisePulse += ConveyorManager.HandleMotorPulse;

            return biscuitMaker;
        }
    }
}
