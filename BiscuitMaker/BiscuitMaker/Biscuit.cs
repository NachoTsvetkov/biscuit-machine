using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker
{
    public class Biscuit : ICloneable
    {
        public bool IsExtruded { get; internal set; }

        public bool IsStamped { get; internal set; }

        public bool IsDone { get; internal set; }

        public object Clone()
        {
            return new Biscuit
            {
                IsExtruded = this.IsExtruded,
                IsStamped = this.IsStamped,
                IsDone = this.IsDone
            };
        }
    }
}
