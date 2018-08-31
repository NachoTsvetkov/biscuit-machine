namespace BiscuitMaker.Managers
{
    using System.Configuration;
    using BiscuitMaker.Models;

    public static class BiscuitMakerSettingsLoader
    {
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
