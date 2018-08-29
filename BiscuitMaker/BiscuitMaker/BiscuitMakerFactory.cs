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
            var settingsAreValid = BiscuitMakerSettingsValidator.AreValid(settings, false);

            if (!settingsAreValid)
            {
                return null;
            }

            var components = new List<IBiscuitComponent>();

            var switchComponent = Switch.Create();
            components.Add(switchComponent);

            var conveyor = Conveyor.Create(count: settings.ConveyorSize);
            components.Add(conveyor);

            var oven = Oven.Create(settings);
            components.Add(oven);
            
            var biscuitMaker = BiscuitMaker.Create(components);
            
            return biscuitMaker;
        }
    }
}
