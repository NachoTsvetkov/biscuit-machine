using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    static class BiscuitMakerManager
    {
        public static void TurnOn(BiscuitMaker maker)
        {
            Switcher.TurnOn(maker);
        }

        public static void TurnOff(BiscuitMaker maker)
        {
            Switcher.TurnOff(maker);
        }

        public static void Pause(BiscuitMaker maker)
        {
            Switcher.Pause(maker);
        }
    }
}
