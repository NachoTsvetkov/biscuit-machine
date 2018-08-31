namespace BiscuitMaker.Managers
{
    using System.Linq;
    using BiscuitMaker.Models;
    using BiscuitMaker.EventArgs;

    public static class Stamper
    {
        public static Biscuit Stamp(Biscuit biscuit)
        {
            if (biscuit == null)
            {
                return null;
            }

            var newBiscuit = Biscuit.Create(
                isExtruded: biscuit.IsExtruded,
                isStamped: true,
                isDone: biscuit.IsDone
            );

            return newBiscuit;
        }
        
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;
            var stamperIndex = e.Maker.Settings.StamperIndex;
            var biscuitToBeStamped = conveyor.Belt.ElementAt(stamperIndex);
            var stampedBiscuit = Stamper.Stamp(biscuitToBeStamped);

            conveyor.Belt.Insert(stamperIndex, stampedBiscuit);
            conveyor.Belt.RemoveAt(stamperIndex + 1);
        }
    }
}