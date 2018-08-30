using System.Linq;

namespace BiscuitMaker.Managers
{
    public static class ConveyorManager
    {
        internal static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;

            // Extrude
            var extruderIndex = e.Maker.Settings.ExtruderIndex;
            var biscuit = Extruder.Extrude();
            conveyor.Belt.Insert(extruderIndex, biscuit);

            // Stapm
            var stamperIndex = e.Maker.Settings.StamperIndex;
            var biscuitToBeStampled = conveyor.Belt.ElementAt(stamperIndex);
            var stampedBiscuit = Stamper.Stamp(biscuitToBeStampled);

            conveyor.Belt.Insert(stamperIndex, biscuit);
            conveyor.Belt.RemoveAt(stamperIndex + 1);

            // Add to bucket
            var bucket = e.Maker.FirstBucket;
            var last = conveyor.Belt.LastOrDefault();
            if (last != null)
            {
                bucket.Biscuits.Add(last);
            }

            // shift last 
            conveyor.Belt.Insert(0, null);
            conveyor.Belt.RemoveAt(conveyor.Belt.Count - 1);
        }
    }
}
