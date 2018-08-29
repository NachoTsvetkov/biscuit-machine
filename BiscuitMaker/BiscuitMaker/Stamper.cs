using System;

namespace BiscuitMaker
{
    public class Stamper: IBiscuitComponent
    {
        public Biscuit Stamp(Biscuit biscuit)
        {
            var newBiscuit = (Biscuit)biscuit.Clone();
            newBiscuit.IsStamped = true;

            return newBiscuit;
        }

        internal void OnPulse(object sender, OnMotorPulseEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}