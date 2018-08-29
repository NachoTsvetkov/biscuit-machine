using System;

namespace BiscuitMaker
{
    internal class Motor : IBiscuitComponent 
    {
        public event EventHandler<OnMotorPulseEventArgs> OnPulse;
    }
}