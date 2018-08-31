namespace BiscuitMakerConsole
{
    using BiscuitMaker;
    using BiscuitMaker.Managers;
    using System;
    using System.Timers;

    class Program
    {
        static void Main(string[] args)
        {
            var settings = BiscuitMakerSettingsLoader.LoadFromConfig();
            var maker = BiscuitMakerFactory.Create(settings);
            var display = new BiscuitMakerConsoleDisplay(maker);

            display.Render();

            var timer = new Timer
            {
                Interval = 1000,
                Enabled = true,
                AutoReset = true,
            };

            timer.Elapsed += (s, e) =>
            {
                BiscuitMakerManager.Tick(maker);
                display.Render();
            };

            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case 'o':
                        BiscuitMakerManager.TurnOn(maker);
                        break;
                    case 'p':
                        BiscuitMakerManager.Pause(maker);
                        break;
                    case 'f':
                        BiscuitMakerManager.TurnOff(maker);
                        break;
                    case 'q':
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }

                display.Render();

            } while (key.KeyChar != 'q');
        }
    }
}
