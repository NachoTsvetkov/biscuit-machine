using System;

namespace BiscuitMaker
{
    public static class Stamper
    {
        public static Biscuit Stamp(Biscuit biscuit)
        {
            if (biscuit == null)
            {
                return null;
            }

            var newBiscuit = Biscuit.Create(
                isExtruded: biscuit.IsExtruded,
                isStamped: true,
                isDone: biscuit.IsDone
            );

            return newBiscuit;
        }
    }
}