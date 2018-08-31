namespace BiscuitMaker
{
    using System.Collections.Generic;

    using BiscuitMaker.Managers;
    using BiscuitMaker.Models;

    public static class BiscuitMakerFactory
    {
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

            var conveyor = Conveyor.Create(count: settings.ConveyorSize);
            components.Add(conveyor);

            var oven = Oven.Create(settings.RoomTemperature);
            components.Add(oven);

            var bucket = BiscuitBucket.Create();
            components.Add(bucket);

            var motor = new Motor();
            components.Add(motor);

            var timeRunner = new TimeRunner();
            components.Add(timeRunner);

            var biscuitMaker = BiscuitMakerObject.Create(components, settings);
            biscuitMaker.FirstSwitcher.RaiseSwitchOn += OvenManager.HandleSiwtchOn;
            biscuitMaker.FirstTimeRunner.RaiseClockTick += OvenManager.HandleClockTick;

            biscuitMaker.FirstTimeRunner.RaiseClockTick += biscuitMaker.FirstMotor.HandleClockTick;
            biscuitMaker.FirstMotor.RaisePulse += ConveyorManager.HandleMotorPulse;

            return biscuitMaker;
        }
    }
}
