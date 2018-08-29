using System;
using System.Collections.Generic;

namespace BiscuitMaker
{
    public class Conveyor : IBiscuitComponent
    {
        public List<Biscuit> Belt { get; private set; }

        public int Count
        {
            get
            {
                return this.Belt.Count;
            }
        }

        private Conveyor(int count)
        {
            this.Belt = new List<Biscuit>();
            for (int i = 0; i < count; i++)
            {
                this.Belt.Add(null);
            }
        }

        public static Conveyor CreateConveyor(int count)
        {
            return new Conveyor(count);
        }
    }
}