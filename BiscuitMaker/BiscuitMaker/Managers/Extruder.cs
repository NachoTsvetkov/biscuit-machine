namespace BiscuitMaker
{
    public static class Extruder
    {
        public static Biscuit Extrude()
        {
            var biscuit = Biscuit.Create(isExtruded: true);

            return biscuit;
        }
    }
}