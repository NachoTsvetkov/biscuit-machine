using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    static class BiscuitManager
    {
        public static object Clone(Biscuit biscuit)
        {
            return new Biscuit
            {
                IsExtruded = biscuit.IsExtruded,
                IsStamped = biscuit.IsStamped,
                IsDone = biscuit.IsDone
            };
        }
    }
}
