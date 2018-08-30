using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class Motor
    {
        public event EventHandler<OnMotorPulseEventArgs> RaisePulse;

        public void Pulse()
        {
            this.RaisePulse?.Invoke(this, new OnMotorPulseEventArgs());
        }
    }
}
