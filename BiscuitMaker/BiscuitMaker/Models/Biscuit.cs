namespace BiscuitMaker.Models
{
    public class Biscuit
    {
        public bool IsExtruded { get; private set; }

        public bool IsStamped { get; private set; }

        public bool IsDone { get; private set; }

        private Biscuit(bool isExtruded = false, bool isStamped = false, bool isDone = false)
        {
            this.IsExtruded = isExtruded;
            this.IsStamped = isStamped;
            this.IsDone = isDone;
        }

        public static Biscuit Create(bool isExtruded = false, bool isStamped = false, bool isDone = false)
        {
            return new Biscuit(isExtruded, isStamped, isDone);
        }
    }
}
