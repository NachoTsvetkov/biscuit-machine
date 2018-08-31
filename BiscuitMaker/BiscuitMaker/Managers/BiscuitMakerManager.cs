﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public static class BiscuitMakerManager
    {
        public static void TurnOn(BiscuitMaker maker)
        {
            maker.FirstSwitcher.TurnOn(maker);
        }

        public static void TurnOff(BiscuitMaker maker)
        {
            maker.FirstSwitcher.TurnOff(maker);
        }

        public static void Pause(BiscuitMaker maker)
        {
            maker.FirstSwitcher.Pause(maker);
        }

        public static void Tick(BiscuitMaker maker)
        {
            maker.FirstTimeRunner.Tick(maker);
        }
    }
}
