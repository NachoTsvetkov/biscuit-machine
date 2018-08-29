using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public static class BiscuitMakerFactory
    {
        public static BiscuitMaker Create(BiscuitMakerSettings settings)
        {
            var settingsAreValid = settings.AreValid(false);

            if (!settingsAreValid)
            {
                return null;
            }
            
            var biscuitMaker = new BiscuitMaker
            {
                Components = new List<IBiscuitComponent>()
            };
            
            var stateSwitch = new Switch();
            biscuitMaker.Components.Add(stateSwitch);

            var oven = new Oven();
            stateSwitch.OnSwitchOn += oven.OnSwitchOn;
            stateSwitch.OnSwitchOff += oven.OnSwitchOff;
            biscuitMaker.Components.Add(oven);

            var motor = new Motor();
            oven.OnWorkingTempReached += motor.OnWorkingTempReached;
            stateSwitch.OnSwitchOn += motor.OnSwitchOn;
            stateSwitch.OnSwitchOff += motor.OnSwitchOff;
            stateSwitch.OnSwitchPause += motor.OnSwitchPause;
            biscuitMaker.Components.Add(motor);

            var extruder = new Extruder();
            motor.OnPulse += biscuitMaker.OnPulse;
            biscuitMaker.Components.Add(extruder);

            var stamper = new Stamper();
            motor.OnPulse += stamper.OnPulse;
            biscuitMaker.Components.Add(stamper);

            var bucket = new BiscuitBucket();
            biscuitMaker.Components.Add(bucket);

            var conveyor = new Conveyor();
            motor.OnPulse += conveyor.OnPulse();
            biscuitMaker.Components.Add(conveyor);

            return biscuitMaker;
        }
    }
}
