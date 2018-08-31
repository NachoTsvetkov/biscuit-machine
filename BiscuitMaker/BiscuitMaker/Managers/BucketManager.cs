using BiscuitMaker.EventArgs;

namespace BiscuitMaker.Managers
{
    using BiscuitMaker.Models;
    using System.Linq;

    public class BucketManager
    {
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;
            var bucket = e.Maker.FirstBucket;
            var last = conveyor.Belt.LastOrDefault();

            if (last == null) return;

            var biscuit = Biscuit.Create(
                isExtruded: last.IsExtruded,
                isStamped: last.IsStamped,
                isDone: true
            );

            bucket.Biscuits.Add(biscuit);
        }
    }
}
