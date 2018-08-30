using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public static class BiscuitMakerSettingsValidator
    {
        public static bool ValidateSettings(BiscuitMakerSettings settings, bool throws = false)
        {
            var errorMessage = "";

            errorMessage += GetErrorMessage(throws, 
                    settings == null && 
                    string.IsNullOrEmpty(errorMessage), 
                "Settings can not be null"
            );

            errorMessage += GetErrorMessage(throws,
                    string.IsNullOrEmpty(errorMessage) &&
                    settings.ConveyorSize <= 2 + settings.OvenSize,
                "Conveyor too small"
            );

            errorMessage += GetErrorMessage(throws,  
                    string.IsNullOrEmpty(errorMessage) &&
                    (settings.ExtruderIndex >= settings.StamperIndex ||
                    settings.StamperIndex >= settings.OvenIndex ||
                    settings.OvenIndex >= (settings.OvenIndex + settings.OvenSize) ||
                    (settings.OvenIndex + settings.OvenSize) >= settings.ConveyorSize), 
                "Invalid component placement"
            );

            errorMessage += GetErrorMessage(throws, 
                    string.IsNullOrEmpty(errorMessage) &&
                    (settings.OvenMaxTemp <= settings.OvenMinTemp ||
                    settings.OvenMaxTemp <= 0 ||
                    settings.OvenMinTemp <= 0 ||
                    settings.OvenHeatingRate <= 0 ||
                    settings.OvenCoolingRate <= 0),
                "Invalid oven temperature settings"
            );

            if (string.IsNullOrEmpty(errorMessage))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string GetErrorMessage(bool throws, bool predicate, string errorMessage)
        {
            if (predicate && throws)
            {
                throw new ArgumentException(errorMessage);
            }

            if (predicate)
            {
                return errorMessage + "; ";
            }

            return "";
        }
    }
}
