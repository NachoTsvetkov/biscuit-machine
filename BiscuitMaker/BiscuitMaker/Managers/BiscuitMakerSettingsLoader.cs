// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerSettingsLoader.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitMakerSettingsLoader type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Managers
{
    using System.Configuration;
    using BiscuitMaker.Models;

    /// <summary>
    /// The biscuit maker settings loader.
    /// </summary>
    public static class BiscuitMakerSettingsLoader
    {
        /// <summary>
        /// The load from config.
        /// </summary>
        /// <returns>
        /// The <see cref="BiscuitMakerSettings"/>.
        /// </returns>
        public static BiscuitMakerSettings LoadFromConfig()
        {
            var settings = new BiscuitMakerSettings();
            
            var appSettings = ConfigurationManager.AppSettings;

            settings.ConveyorSize = int.Parse(appSettings["ConveyorSize"]);
            settings.OvenMaxTemp = int.Parse(appSettings["OvenMaxTemp"]);
            settings.OvenMinTemp = int.Parse(appSettings["OvenMinTemp"]);
            settings.OvenHeatingRate = int.Parse(appSettings["OvenHeatingRate"]);
            settings.OvenCoolingRate = int.Parse(appSettings["OvenCoolingRate"]);
            settings.ExtruderIndex = int.Parse(appSettings["ExtruderIndex"]);
            settings.StamperIndex = int.Parse(appSettings["StamperIndex"]);
            settings.OvenIndex = int.Parse(appSettings["OvenIndex"]);
            settings.OvenSize = int.Parse(appSettings["OvenSize"]);
            settings.RoomTemperature = int.Parse(appSettings["RoomTemperature"]);
            settings.RevolutionsPerTick = int.Parse(appSettings["RevolutionsPerTick"]);

            return settings;
        }
    }
}
