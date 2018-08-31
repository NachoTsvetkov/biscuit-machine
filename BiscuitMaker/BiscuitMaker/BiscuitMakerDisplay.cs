namespace BiscuitMaker
{
    using BiscuitMaker.Models;

    public class BiscuitMakerDisplay
    {
        public BiscuitMakerDisplay(BiscuitMakerObject maker)
        {
            this.Maker = maker;
        }

        public BiscuitMakerObject Maker { get; }

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

        public Switch Switch
        {
            get
            {
                return this.Maker.FirstSwitch;
            }
        }

        public Oven Oven
        {
            get
            {
                return this.Maker.FirstOven;
            }
        }
    }
}
