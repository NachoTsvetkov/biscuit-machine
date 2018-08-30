using System;
using System.Collections.Generic;
using System.Text;

namespace BiscuitMaker.Managers
{
    public static class BiscuitMakerSettingsValidator
    {
        internal static bool AreValid(BiscuitMakerSettings settings, bool throws = false)
        {
            var errorMessage = "";

            errorMessage += GetErrorMessage(throws, 
                    settings == null && 
                    string.IsNullOrEmpty(errorMessage), 
                "Settings can not be null"
            );

            errorMessage += GetErrorMessage(throws, 
                    settings.ConveyorSize <= 2 + settings.OvenSize && 
                    string.IsNullOrEmpty(errorMessage),
                "Conveyor too small"
            );

            errorMessage += GetErrorMessage(throws, 
                    settings.ExtruderIndex >= settings.SamperIndex ||
                    settings.SamperIndex >= settings.OvenIndex ||
                    settings.OvenIndex >= (settings.OvenIndex + settings.OvenSize) ||
                    (settings.OvenIndex + settings.OvenSize) >= settings.ConveyorSize && 
                    string.IsNullOrEmpty(errorMessage), 
                "Invalid component placement"
            );

            errorMessage += GetErrorMessage(throws,
                    settings.OvenMaxTemp <= settings.OvenMinTemp ||
                    settings.OvenMaxTemp <= 0 ||
                    settings.OvenMinTemp <= 0 ||
                    settings.OvenHeatingRate <= 0 ||
                    settings.OvenCoolingRate <= 0 &&
                    string.IsNullOrEmpty(errorMessage),
                "Invalid oven temperature settings placement"
            );

            throw new NotImplementedException();
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
