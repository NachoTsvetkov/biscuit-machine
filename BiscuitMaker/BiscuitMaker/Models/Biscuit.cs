using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public class Biscuit
    {
        public bool IsExtruded { get; internal set; }

        public bool IsStamped { get; internal set; }

        public bool IsDone { get; internal set; }
    }
}
