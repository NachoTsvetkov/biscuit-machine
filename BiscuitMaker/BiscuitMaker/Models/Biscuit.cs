// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Biscuit.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the Biscuit type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    /// <summary>
    /// The biscuit.
    /// </summary>
    public class Biscuit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Biscuit"/> class.
        /// </summary>
        /// <param name="isExtruded">
        /// The is extruded.
        /// </param>
        /// <param name="isStamped">
        /// The is stamped.
        /// </param>
        /// <param name="isDone">
        /// The is done.
        /// </param>
        private Biscuit(bool isExtruded = false, bool isStamped = false, bool isDone = false)
        {
            this.IsExtruded = isExtruded;
            this.IsStamped = isStamped;
            this.IsDone = isDone;
        }

        /// <summary>
        /// Gets a value indicating whether is extruded.
        /// </summary>
        public bool IsExtruded { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is stamped.
        /// </summary>
        public bool IsStamped { get; private set; }

        /// <summary>
        /// Gets a value indicating whether is done.
        /// </summary>
        public bool IsDone { get; private set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="isExtruded">
        /// The is extruded.
        /// </param>
        /// <param name="isStamped">
        /// The is stamped.
        /// </param>
        /// <param name="isDone">
        /// The is done.
        /// </param>
        /// <returns>
        /// The <see cref="Biscuit"/>.
        /// </returns>
        public static Biscuit Create(bool isExtruded = false, bool isStamped = false, bool isDone = false)
        {
            return new Biscuit(isExtruded, isStamped, isDone);
        }
    }
}
