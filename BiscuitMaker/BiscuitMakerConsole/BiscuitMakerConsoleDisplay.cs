namespace BiscuitMakerConsole
{
    using System;
    using System.Text;
    using BiscuitMaker;
    using BiscuitMaker.Models;

    class BiscuitMakerConsoleDisplay : BiscuitMakerDisplay
    {
        public string Margin { get; set; }
        public BiscuitMakerConsoleDisplay(BiscuitMakerObject maker) : base(maker)
        {
            this.Margin = "   ";
        }

        public void Render()
        {
            Console.Clear();

            this.RenderExtruder();
            this.RenderStamper();
            this.RenderOven(); 
            this.RenderBisquits();
            this.RenderBeltFrame();

            Console.WriteLine();
            this.RenderState();
            this.RenderSettigns();
            this.RenderMenu();

        }

        private void RenderStamper()
        {
            var stamper = new StringBuilder(Margin);
            for (int i = 0; i < this.Settings.StamperIndex; i++)
            {
                stamper.Append(" ");
            }

            stamper.Append("s");

            Console.WriteLine(stamper);
        }

        private void RenderExtruder()
        {
            var extruder = new StringBuilder(Margin);
            for (int i = 0; i < this.Settings.ExtruderIndex; i++)
            {
                extruder.Append(" ");
            }

            extruder.Append("e");

            Console.WriteLine(extruder);
        }

        private void RenderOven()
        {
            var oven = new StringBuilder(Margin);
            for (int i = 0; i < this.Settings.OvenIndex; i++)
            {
                oven.Append(" ");
            }

            for (int i = 0; i < this.Settings.OvenSize; i++)
            {
                oven.Append("_");
            }
            
            Console.WriteLine(oven);
        }

        private void RenderBisquits()
        {
            var bisquits = new StringBuilder(Margin);
            for (int i = 0; i < this.Conveyor.Belt.Count; i++)
            {
                bisquits.Append(this.Conveyor.Belt[i] == null ? " " : "=");
            }

            Console.WriteLine(bisquits);
        }

        private void RenderBeltFrame()
        {
            var beltFrame = new StringBuilder(Margin);
            for (int i = 0; i < this.Conveyor.Belt.Count; i++)
            {
                beltFrame.Append("-");
            }

            Console.WriteLine(beltFrame);
        }

        private void RenderSettigns()
        {
            Console.WriteLine($"Settings: ");
            Console.WriteLine($"Oven");
            Console.WriteLine($"- Min: { this.Settings.OvenMinTemp } / Max: { this.Settings.OvenMaxTemp }");
            Console.WriteLine($"- Heating: { this.Settings.OvenHeatingRate } / Cooling: { this.Settings.OvenCoolingRate }");
            Console.WriteLine($"Room Temp - { this.Settings.RoomTemperature } ");

        }

        private void RenderState()
        {
            Console.WriteLine($"State: ");
            Console.WriteLine($"Switch - { this.Switch.State }");
            Console.WriteLine($"Oven");
            Console.WriteLine($"- State: { this.Oven.State }");
            Console.WriteLine($"- Temp: { this.Oven.CurrentTemperature }"); 
            Console.WriteLine($"- Is Working Temp: {this.Oven.IsWorkingTemperature}"); 
            Console.WriteLine($"Bisquits baked - { this.Bucket.Biscuits.Count }");
            Console.WriteLine($"Bisquits baking - { this.Conveyor.Count }");
        }

        private void RenderMenu()
        {
            Console.WriteLine("Press o for On, p for Pause, f for Off or q for Exit ");
        }
    }
}
