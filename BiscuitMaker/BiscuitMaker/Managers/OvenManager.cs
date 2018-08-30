using BiscuitMaker.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public class OvenManager : IBiscuitComponent
    {
        public event EventHandler<OnWorkingTempReachedEventArgs> RaiseWorkingTempReached;
        
        public void ReachWorkingTemp()
        {
            this.RaiseWorkingTempReached?.Invoke(this, new OnWorkingTempReachedEventArgs());
        }

        public static void SetState(BiscuitMaker maker, int currentTemperature, OvenState state)
        {
            var newOven = Oven.Create(currentTemperature, state);
            maker.Components.Remove(maker.FirstOven);
            maker.Components.Add(newOven);
        }

        internal void HandleSiwtchOn(object sender, OnSwitchOnEventArgs e)
        {
            OvenManager.SetState(e.Maker, e.Maker.FirstOven.CurrentTemperature, OvenState.Heating);
        }

        internal void HandleSiwtchOff(object sender, OnSwitchOffEventArgs e)
        {
            OvenManager.SetState(e.Maker, e.Maker.FirstOven.CurrentTemperature, OvenState.Off);
        }

        internal void HandleClockTick(object sender, OnClockTickEventArgs e)
        {
            var settings = e.Maker.Settings;
            var oven = e.Maker.FirstOven;

            var newTemperature = 0;
            var heatPeak = 0;
            var newState = oven.State;

            switch (oven.State)
            {
                case OvenState.Heating:
                    heatPeak = oven.CurrentTemperature + settings.OvenHeatingRate;
                    newTemperature = Math.Min(heatPeak, settings.OvenMaxTemp);

                    if (heatPeak >= settings.OvenMaxTemp)
                    {
                        newState = OvenState.Cooling;
                    }

                    break;
                case OvenState.Cooling:
                    heatPeak = oven.CurrentTemperature - settings.OvenCoolingRate;
                    newTemperature = Math.Max(heatPeak, settings.OvenMinTemp);
                    
                    if (heatPeak <= settings.OvenMinTemp)
                    {
                        newState = OvenState.Heating;
                    }
                    break;
                case OvenState.Off:
                    heatPeak = oven.CurrentTemperature - settings.OvenCoolingRate;
                    newTemperature = Math.Max(heatPeak, settings.RoomTemperature);
                    break;
                default:
                    throw new ArgumentException("Unknown Oven State");
            }
            
            OvenManager.SetState(e.Maker, newTemperature, newState);
        }
    }
}
