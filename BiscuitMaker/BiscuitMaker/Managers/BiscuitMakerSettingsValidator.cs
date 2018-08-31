// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerSettingsValidator.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitMakerSettingsValidator type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using System;
    using BiscuitMaker.Models;

    /// <summary>
    /// The biscuit maker settings validator.
    /// </summary>
    public static class BiscuitMakerSettingsValidator
    {
        /// <summary>
        /// The validate settings.
        /// </summary>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <param name="throws">
        /// The throws.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ValidateSettings(BiscuitMakerSettings settings, bool throws = false)
        {
            var errorMessage = string.Empty;

            errorMessage += GetErrorMessage(
                throws,
                settings == null && string.IsNullOrEmpty(errorMessage),
                "Settings can not be null");

            errorMessage += GetErrorMessage(
                throws,
                settings != null && (string.IsNullOrEmpty(errorMessage) && settings.ConveyorSize <= 2 + settings.OvenSize),
                "Conveyor too small");

            errorMessage += GetErrorMessage(
                throws,
                settings != null && (string.IsNullOrEmpty(errorMessage)
                                     && (settings.ExtruderIndex >= settings.StamperIndex
                                         || settings.StamperIndex >= settings.OvenIndex
                                         || settings.OvenIndex >= (settings.OvenIndex + settings.OvenSize) || (settings.OvenIndex + settings.OvenSize) >= settings.ConveyorSize)),
                "Invalid component placement");

            errorMessage += GetErrorMessage(
                throws,
                settings != null && (string.IsNullOrEmpty(errorMessage)
                                     && (settings.OvenMaxTemp <= settings.OvenMinTemp || settings.OvenMaxTemp <= 0
                                                                                      || settings.OvenMinTemp <= 0
                                                                                      || settings.OvenHeatingRate <= 0
                                                                                      || settings.OvenCoolingRate <= 0)),
                "Invalid oven temperature settings"
            );

            return string.IsNullOrEmpty(errorMessage);
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

            return string.Empty;
        }
    }
}
