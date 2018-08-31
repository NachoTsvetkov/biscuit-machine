// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BucketManager.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BucketManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using System.Linq;

    using BiscuitMaker.EventArgs;
    using BiscuitMaker.Models;

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
