// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitBucket.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitBucket type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    using System.Collections.Generic;
    using BiscuitMaker.Interfaces;

    /// <inheritdoc />
    /// <summary>
    /// The biscuit bucket.
    /// </summary>
    public class BiscuitBucket : IBiscuitComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiscuitBucket"/> class.
        /// </summary>
        /// <param name="biscuits">
        /// The biscuits.
        /// </param>
        private BiscuitBucket(List<Biscuit> biscuits)
        {
            this.Biscuits = biscuits;
        }

        /// <summary>
        /// Gets the biscuits.
        /// </summary>
        public List<Biscuit> Biscuits { get; private set; }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="biscuits">
        /// The biscuits.
        /// </param>
        /// <returns>
        /// The <see cref="BiscuitBucket"/>.
        /// </returns>
        public static BiscuitBucket Create(List<Biscuit> biscuits = null)
        {
            if (biscuits == null)
            {
                biscuits = new List<Biscuit>();
            }

            return new BiscuitBucket(biscuits);
        }
    }
}