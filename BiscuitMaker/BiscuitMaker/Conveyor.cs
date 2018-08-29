using System;

namespace BiscuitMaker
{
    public class Conveyor : IBiscuitComponent
    {
        public Conveyor()
        {
        }

        internal EventHandler<OnMotorPulseEventArgs> OnPulse()
        {
            throw new NotImplementedException();
        }
    }
}