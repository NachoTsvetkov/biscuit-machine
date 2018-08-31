namespace BiscuitMaker.Managers
{
    using BiscuitMaker.Models;

    public static class ConveyorManager
    {
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;

            // ToDo: Set Extruder and Stapmer to work async
            Extruder.HandleMotorPulse(sender, e);
            Stamper.HandleMotorPulse(sender, e);
            BucketManager.HandleMotorPulse(sender, e);
            
            RollBelt(conveyor);
        }

        private static void RollBelt(Conveyor conveyor)
        {
            conveyor.Belt.Insert(0, null);
            conveyor.Belt.RemoveAt(conveyor.Belt.Count - 1);
        }
    }
}
