using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker
{
    public class BiscuitMakerDisplay
    {
        public BiscuitMakerDisplay(BiscuitMaker maker)
        {
            this.Maker = maker;
        }

        public BiscuitMaker Maker { get; }

        public BiscuitMakerSettings Settings
        {
            get
            {
                return this.Maker.Settings;
            }
        }

        public Conveyor Conveyor
        {
            get
            {
                return this.Maker.FirstConveyor;
            }
        }

        public BiscuitBucket Bucket
        {
            get
            {
                return this.Maker.FirstBucket;
            }
        }
    }
}
