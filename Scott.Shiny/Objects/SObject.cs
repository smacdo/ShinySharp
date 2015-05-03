using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Base class for all ShinySharp objects.
    /// </summary>
    public abstract class SObject
    {
    }

    /// <summary>
    ///  Represents a singleton sharp object.
    /// </summary>
    public abstract class SingletonObject : SObject, IEquatable<SingletonObject>
    {
        /// <summary>
        ///  Default constructor.
        /// </summary>
        protected SingletonObject()
        {
        }

        /// <summary>
        ///  Get hashcode for singleton instance.
        /// </summary>
        /// <returns>Hashcode for singleton instance.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        ///  Check if this singleton object is the same as the given value.
        /// </summary>
        /// <param name="other">The other value to check for equality.</param>
        /// <returns>True if they are the same, false otherwise.</returns>
        public bool Equals(SingletonObject other)
        {
            // Singleton objects can only be equal to themselves, so this method call is nothing more than a reference
            // check.
            return ReferenceEquals(this, other);
        }

        /// <summary>
        ///  Check if this singleton object is the same as the given value.
        /// </summary>
        /// <param name="other">The other value to check for equality.</param>
        /// <returns>True if they are the same, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            // Singleton objects can only be equal to themselves, so this method call is nothing more than a reference
            // check.
            return ReferenceEquals(this, obj);
        }
    }
}
