namespace BiscuitMaker
{
    public class Extruder : IBiscuitComponent
    {
        public Biscuit Extrude()
        {
            var biscuit = new Biscuit
            {
                IsExtruded = true
            };

            return biscuit;
        }
    }
}