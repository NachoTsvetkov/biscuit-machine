using System;

namespace BiscuitMaker
{
    public static class Stamper
    {
        public static Biscuit Stamp(Biscuit biscuit)
        {
            var newBiscuit = (Biscuit)BiscuitManager.Clone(biscuit);
            newBiscuit.IsStamped = true;

            return newBiscuit;
        }
    }
}