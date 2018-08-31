namespace BiscuitMaker.Models
{
    using System.Collections.Generic;
    using System.Linq;


    public class Conveyor : IBiscuitComponent
    {
        public List<Biscuit> Belt { get; private set; }

        public bool HasBiscuits
        {
            get
            {
                return this.Belt.Any(x => x != null);
            }
        }

        public int Count
        {
            get
            {
                return this.Belt.Count(x => x != null);
            }
        }

        private Conveyor(List<Biscuit> belt)
        {
            this.Belt = belt;
        }

        public static Conveyor Create(List<Biscuit> belt = null, int count = 6)
        {
            if (belt == null)
            {
                belt = new List<Biscuit>();
                for (int i = 0; i < count; i++)
                {
                    belt.Add(null);
                }
            }
            
            return new Conveyor(belt);
        }
    }
}