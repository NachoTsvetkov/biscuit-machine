using BiscuitMaker.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public static class OvenManager
    {   
        public static void SetState(BiscuitMaker maker, int currentTemperature, OvenState state)
        {
            var isWorkingTemperature = currentTemperature <= maker.Settings.OvenMaxTemp &&
                currentTemperature >= maker.Settings.OvenMinTemp;

            var newOven = Oven.Create(currentTemperature, state, isWorkingTemperature);
            maker.Components.Remove(maker.FirstOven);
            maker.Components.Add(newOven);
        }

        public static void HandleSiwtchOn(object sender, OnSwitchOnEventArgs e)
        {
            if (e.Maker.FirstOven.State == OvenState.Off)
            {
                OvenManager.SetState(e.Maker, e.Maker.FirstOven.CurrentTemperature, OvenState.Heating);
            }
        }

        public static void HandleClockTick(object sender, OnClockTickEventArgs e)
        {
            var settings = e.Maker.Settings;
            var oven = e.Maker.FirstOven;
            var button = e.Maker.FirstSwitch;
            var conveyor = e.Maker.FirstConveyor;

            var newTemperature = 0;
            var heatPeak = 0;
            var state = button.State == SwitchState.Off && !conveyor.HasBiscuits ? OvenState.Off : oven.State;
            var newState = oven.State;

            switch (state)
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
                    newState = OvenState.Off;
                    break;
                default:
                    throw new ArgumentException("Unknown Oven State");
            }
            
            OvenManager.SetState(e.Maker, newTemperature, newState);
        }
    }
}
