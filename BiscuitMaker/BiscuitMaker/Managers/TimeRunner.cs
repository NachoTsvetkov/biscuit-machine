using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker.Managers
{
    public class TimeRunner
    {
        public event EventHandler<OnClockTickEventArgs> RaiseClockTick;

        public void Tick()
        {
            this.RaiseClockTick?.Invoke(this, new OnClockTickEventArgs());
        }
    }
}
