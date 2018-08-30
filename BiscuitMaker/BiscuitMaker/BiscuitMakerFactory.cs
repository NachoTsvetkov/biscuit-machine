﻿using BiscuitMaker.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public static class BiscuitMakerFactory
    {
        public static BiscuitMaker Create(BiscuitMakerSettings settings = null)
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

            var oven = Oven.Create();
            components.Add(oven);

            var ovenManager = new OvenManager();
            components.Add(ovenManager);

            var bucket = BiscuitBucket.Create();
            components.Add(bucket);

            var biscuitMaker = BiscuitMaker.Create(components, settings);
            biscuitMaker.FirstSwitcher.RaiseSwitchOn += biscuitMaker.FirstOvenManager.HandleSiwtchOn;
            biscuitMaker.FirstSwitcher.RaiseSwitchOff += biscuitMaker.FirstOvenManager.HandleSiwtchOff;
            biscuitMaker.FirstTimeRunner.RaiseClockTick += biscuitMaker.FirstOvenManager.HandleClockTick;


            return biscuitMaker;
        }
    }
}
