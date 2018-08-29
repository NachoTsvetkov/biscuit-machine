using System;

namespace BiscuitMaker
{
    public class Oven : IBiscuitComponent
    {
        public event EventHandler<OnWorkingTempReachedEventArgs> OnWorkingTempReached;
    }
}