namespace BiscuitMaker
{
    public static class Extruder
    {
        public static Biscuit Extrude()
        {
            var biscuit = Biscuit.Create(isExtruded: true);

            return biscuit;
        }
        
        public static void HandleMotorPulse(object sender, OnMotorPulseEventArgs e)
        {
            var conveyor = e.Maker.FirstConveyor;
            var extruderIndex = e.Maker.Settings.ExtruderIndex;
            var biscuit = Extruder.Extrude();
            conveyor.Belt.RemoveAt(extruderIndex);
            conveyor.Belt.Insert(extruderIndex, biscuit);
        }
    }
}