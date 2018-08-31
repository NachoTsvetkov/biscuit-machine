namespace BiscuitMaker.Models
{
    using BiscuitMaker.Enumerations;
    using BiscuitMaker.Interfaces;

    public class Switch : IBiscuitComponent
    {
        public SwitchState State { get; set; }

        private Switch(SwitchState state)
        {
            this.State = state;
        }

        public static Switch Create(SwitchState state = SwitchState.Off)
        {
            return new Switch(state);
        }
    }
}