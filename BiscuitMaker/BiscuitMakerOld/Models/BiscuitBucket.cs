using System.Collections.Generic;

namespace BiscuitMaker
{
    public class BiscuitBucket : IBiscuitComponent
    {
        public List<Biscuit> Biscuits { get; private set; }

        private BiscuitBucket(List<Biscuit> biscuits)
        {
            this.Biscuits = biscuits;
        }

        public static BiscuitBucket Create(List<Biscuit> biscuits = null)
        {
            if (biscuits == null)
            {
                biscuits = new List<Biscuit>();
            }

            return new BiscuitBucket(biscuits);
        }
    }
}