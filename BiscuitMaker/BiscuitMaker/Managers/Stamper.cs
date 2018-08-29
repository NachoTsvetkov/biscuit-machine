using System;

namespace BiscuitMaker
{
    public static class Stamper
    {
        public static Biscuit Stamp(Biscuit biscuit)
        {
            var newBiscuit = Biscuit.Create(
                isExtruded: biscuit.IsExtruded,
                isStamped: true,
                isDone: biscuit.IsDone
            );

            return newBiscuit;
        }
    }
}