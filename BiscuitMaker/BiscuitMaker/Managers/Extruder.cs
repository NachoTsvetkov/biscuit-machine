namespace BiscuitMaker.Managers
{
    using BiscuitMaker.Models;
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.EventArgs;

    public static class Extruder
    {
        public static Biscuit Extrude()
        {
            var biscuit = Biscuit.Create(isExtruded: true);

            return biscuit;
        }
        
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            if (e.Maker.FirstSwitch.State != SwitchState.On)
            {
                return;
            }

            var conveyor = e.Maker.FirstConveyor;
            var extruderIndex = e.Maker.Settings.ExtruderIndex;
            var biscuit = Extruder.Extrude();
            conveyor.Belt.RemoveAt(extruderIndex);
            conveyor.Belt.Insert(extruderIndex, biscuit);
        }
    }
}