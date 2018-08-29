using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    static class BiscuitMakerManager
    {
        internal static void OnPulse(object sender, OnMotorPulseEventArgs e)
        {
            //e.Belt.OnPulse(sender, e);
            //e.Extruder.OnPulse(sender, e);
            //e.Stamper.OnPulse(sender, e);

            throw new NotImplementedException();
        }
    }
}
