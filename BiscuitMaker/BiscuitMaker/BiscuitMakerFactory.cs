using BiscuitMaker.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public static class BiscuitMakerFactory
    {
        public static BiscuitMaker Create(BiscuitMakerSettings settings = null)
        {
            var settingsAreValid = BiscuitMakerSettingsManager.AreValid(settings, false);

            if (!settingsAreValid)
            {
                return null;
            }
            
            var biscuitMaker = new BiscuitMaker
            {
                Components = new List<IBiscuitComponent>()
            };

            var clock = new Clock();
            biscuitMaker.Components.Add(clock);
            
            var stateSwitch = new Switch();
            biscuitMaker.Components.Add(stateSwitch);

            var oven = new Oven();
            stateSwitch.OnSwitchOn += OvenManager.OnSwitchOn;
            stateSwitch.OnSwitchOff += OvenManager.OnSwitchOff;
            clock.OnClockTick += OvenManager.OnClockTick;
            biscuitMaker.Components.Add(oven);

            var motor = new Motor();
            oven.OnWorkingTempReached += MotorManager.OnWorkingTempReached;
            stateSwitch.OnSwitchOn += MotorManager.OnSwitchOn;
            stateSwitch.OnSwitchOff += MotorManager.OnSwitchOff;
            stateSwitch.OnSwitchPause += MotorManager.OnSwitchPause;
            clock.OnClockTick += MotorManager.OnClockTick;
            biscuitMaker.Components.Add(motor);
            
            var bucket = new BiscuitBucket();
            biscuitMaker.Components.Add(bucket);

            var conveyor = Conveyor.CreateConveyor(settings.ConveyorSize);
            biscuitMaker.Components.Add(conveyor);

            return biscuitMaker;
        }
    }
}
