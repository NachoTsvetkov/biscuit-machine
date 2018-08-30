using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class OvenManager
    {
        public event EventHandler<OnWorkingTempReachedEventArgs> RaiseWorkingTempReached;
        
        public void ReachWorkingTemp()
        {
            this.RaiseWorkingTempReached?.Invoke(this, new OnWorkingTempReachedEventArgs());
        }
    }
}
