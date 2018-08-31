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

            this.RenderUtils();
            this.RenderBisquits();
            this.RenderBeltFrame();

            Console.WriteLine();
            this.RenderState();
            this.RenderSettigns();
            this.RenderMenu();

        }

        private void RenderUtils()
        {
            var utils = new StringBuilder(Margin);

            //Render Extruder
            FillWithWhiteSpace(utils, 0, this.Settings.ExtruderIndex);
            utils.Append("e");

            //Render Stamper
            FillWithWhiteSpace(utils, this.Settings.ExtruderIndex + 1, this.Settings.StamperIndex);
            utils.Append("s");

            //Render Stamper
            FillWithWhiteSpace(utils, this.Settings.StamperIndex + 1, this.Settings.OvenIndex);
            
            for (int i = 0; i < this.Settings.OvenSize; i++)
            {
                utils.Append("_");
            }

            Console.WriteLine(utils);
        }

        private void FillWithWhiteSpace(StringBuilder utils,int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                utils.Append(" ");
            }
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

            beltFrame.Append($"|{ this.Bucket.Biscuits.Count}|");

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
