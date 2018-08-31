namespace BiscuitMaker.Managers
{
    using BiscuitMaker.Models;

    public static class BiscuitMakerManager
    {
        public static void TurnOn(BiscuitMakerObject maker)
        {
            maker.FirstSwitcher.TurnOn(maker);
        }

        public static void TurnOff(BiscuitMakerObject maker)
        {
            maker.FirstSwitcher.TurnOff(maker);
        }

        public static void Pause(BiscuitMakerObject maker)
        {
            maker.FirstSwitcher.Pause(maker);
        }

        public static void Tick(BiscuitMakerObject maker)
        {
            maker.FirstTimeRunner.Tick(maker);
        }
    }
}
