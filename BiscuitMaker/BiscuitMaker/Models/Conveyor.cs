// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Conveyor.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Conveyor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using BiscuitMaker.Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The conveyor.
    /// </summary>
    public class Conveyor : IBiscuitComponent
    {
        /// <summary>
        /// Gets the belt.
        /// </summary>
        public List<Biscuit> Belt { get; private set; }

        /// <summary>
        /// Gets a value indicating whether has biscuits.
        /// </summary>
        public bool HasBiscuits
        {
            get
            {
                return this.Belt.Any(x => x != null);
            }
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get
            {
                return this.Belt.Count(x => x != null);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Conveyor"/> class.
        /// </summary>
        /// <param name="belt">
        /// The belt.
        /// </param>
        private Conveyor(List<Biscuit> belt)
        {
            this.Belt = belt;
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="belt">
        /// The belt.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// The <see cref="Conveyor"/>.
        /// </returns>
        public static Conveyor Create(List<Biscuit> belt = null, int count = 6)
        {
            if (belt != null)
            {
                return new Conveyor(belt);
            }

            belt = new List<Biscuit>();
            for (var i = 0; i < count; i++)
            {
                belt.Add(null);
            }

            return new Conveyor(belt);
        }
    }
}