using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiscuitMaker.Managers
{
    public class TimeRunner : IBiscuitComponent
    {
        public event EventHandler<OnClockTickEventArgs> RaiseClockTick;

        public void Tick(BiscuitMaker maker)
        {
            this.RaiseClockTick?.Invoke(this, new OnClockTickEventArgs { Maker = maker });
        }
    }
}
