namespace BiscuitMaker
{
    using BiscuitMaker.Models;
    
    /// <summary>
    /// Simple facade for displaying current state. To be consumed and extended wherever
    /// </summary>
    public class BiscuitMakerDisplay
    {
        /// <summary>
        /// Initializes new instance of the <see cref=BiscuitMakerDisplay /> class.
        /// </summary>
        /// <param name="maker">The maker to be displayed</param>
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
