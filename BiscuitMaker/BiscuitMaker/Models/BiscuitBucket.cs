using System.Collections.Generic;

namespace BiscuitMaker
{
    public class BiscuitBucket : IBiscuitComponent
    {
        public List<Biscuit> Biscuits { get; set; }
    }
}