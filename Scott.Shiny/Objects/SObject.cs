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
    ///  Base class for value types that are equatable and comparable.
    /// </summary>
    /// <typeparam name="TValue">Value type of the object.</typeparam>
    public abstract class TemplatedValueObject<TValue> : 
        SObject,
        IEquatable<TemplatedValueObject<TValue>>,
        IComparable<TemplatedValueObject<TValue>>
        where TValue : IEquatable<TValue>, IComparable<TValue>
    {
        /// <summary>
        ///  Templated object constructor.
        /// </summary>
        /// <param name="value">Value to store.</param>
        protected TemplatedValueObject(TValue value)
        {
            Value = value;
        }

        /// <summary>
        ///  Get or set this template object's value.
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        ///  Compare this object with another object and return a value that indicates if the current instance precedes
        /// follows or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(TemplatedValueObject<TValue> obj)
        {
            if (ReferenceEquals(obj, null))
            {
                throw new ArgumentException("obj is null or of the wrong type");
            }

            return Value.CompareTo(obj.Value);
        }

        /// <summary>
        ///  Compare this object with another object and return a value that indicates if the current instance precedes
        /// follows or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared.</returns>
        public int CompareTo(object obj)
        {
            return CompareTo(obj as TemplatedValueObject<TValue>);
        }

        /// <summary>
        ///  Determine whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, false otherwise.</returns>
        public bool Equals(TemplatedValueObject<TValue> obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            else
            {
                return ReferenceEquals(this, obj) || Value.Equals(obj.Value);
            }
        }

        /// <summary>
        ///  Determine whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as TemplatedValueObject<TValue>);
        }

        /// <summary>
        ///  Get a hashcode for the object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }

    /// <summary>
    ///  Represents a singleton shiny object.
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
