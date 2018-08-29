using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public class BiscuitMaker
    {
        public List<IBiscuitComponent> Components { get; internal set; }

        internal void OnPulse(object sender, OnMotorPulseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
