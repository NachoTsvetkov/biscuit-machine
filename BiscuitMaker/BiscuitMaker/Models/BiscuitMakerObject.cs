// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BiscuitMakerObject.cs" company="NMC">
//   Nacho Tsvetkov
// </copyright>
// <summary>
//   Defines the BiscuitMakerObject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BiscuitMaker.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using BiscuitMaker.Interfaces;
    using BiscuitMaker.Managers;

    /// <summary>
    /// The biscuit maker object.
    /// </summary>
    public class BiscuitMakerObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BiscuitMakerObject"/> class.
        /// </summary>
        /// <param name="components">
        /// The components.
        /// </param>
        /// <param name="settings">
        /// The settings.
        /// </param>
        private BiscuitMakerObject(List<IBiscuitComponent> components, BiscuitMakerSettings settings)
        {
            this.Components = components;
            this.Settings = settings;
        }

        /// <summary>
        /// Gets the components.
        /// </summary>
        public List<IBiscuitComponent> Components { get; private set; }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        public BiscuitMakerSettings Settings { get; private set; }

        /// <summary>
        /// Gets the first conveyor.
        /// </summary>
        public Conveyor FirstConveyor
        {
            get
            {
                return (Conveyor)this.Components.FirstOrDefault(x => x is Conveyor);
            }
        }

        /// <summary>
        /// Gets the first oven.
        /// </summary>
        public Oven FirstOven
        {
            get
            {
                return (Oven)this.Components.FirstOrDefault(x => x is Oven);
            }
        }

        /// <summary>
        /// Gets the first bucket.
        /// </summary>
        public BiscuitBucket FirstBucket
        {
            get
            {
                return (BiscuitBucket)this.Components.FirstOrDefault(x => x is BiscuitBucket);
            }
        }

        /// <summary>
        /// Gets the first switch.
        /// </summary>
        public Switch FirstSwitch
        {
            get
            {
                return (Switch)this.Components.FirstOrDefault(x => x is Switch);
            }
        }

        /// <summary>
        /// Gets the first switcher.
        /// </summary>
        public Switcher FirstSwitcher
        {
            get
            {
                return (Switcher)this.Components.FirstOrDefault(x => x is Switcher);
            }
        }

        /// <summary>
        /// Gets the first time runner.
        /// </summary>
        public TimeRunner FirstTimeRunner
        {
            get
            {
                return (TimeRunner)this.Components.FirstOrDefault(x => x is TimeRunner);
            }
        }

        /// <summary>
        /// Gets the first motor.
        /// </summary>
        public Motor FirstMotor
        {
            get
            {
                return (Motor)this.Components.FirstOrDefault(x => x is Motor);
            }
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="components">
        /// The components.
        /// </param>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <returns>
        /// The <see cref="BiscuitMakerObject"/>.
        /// </returns>
        public static BiscuitMakerObject Create(List<IBiscuitComponent> components, BiscuitMakerSettings settings)
        {
            return new BiscuitMakerObject(components, settings);
        }
    }
}
