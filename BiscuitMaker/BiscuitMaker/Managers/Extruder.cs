namespace BiscuitMaker
{
    public static class Extruder
    {
        public static Biscuit Extrude()
        {
            var biscuit = new Biscuit
            {
                IsExtruded = true
            };

            return biscuit;
        }
    }
}