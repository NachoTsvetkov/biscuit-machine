// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConveyorManager.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the ConveyorManager type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using BiscuitMaker.EventArgs;
    using BiscuitMaker.Models;

    /// <summary>
    /// The conveyor manager.
    /// </summary>
    public static class ConveyorManager
    {
        /// <summary>
        /// The handle motor pulse.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;

            // ToDo: Set Extruder and Stamper to work async
            Extruder.HandleMotorPulse(sender, e);
            Stamper.HandleMotorPulse(sender, e);
            BucketManager.HandleMotorPulse(sender, e);
            
            RollBelt(conveyor);
        }

        /// <summary>
        /// The roll belt.
        /// </summary>
        /// <param name="conveyor">
        /// The conveyor.
        /// </param>
        private static void RollBelt(Conveyor conveyor)
        {
            conveyor.Belt.Insert(0, null);
            conveyor.Belt.RemoveAt(conveyor.Belt.Count - 1);
        }
    }
}
