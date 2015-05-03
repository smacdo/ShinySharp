using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents a Shiny Fixnum object value.
    /// </summary>
    public class FixnumObject : SObject, IComparable<FixnumObject>, IEquatable<FixnumObject>
    {
        /// <summary>
        ///  Fixnum value constructor.
        /// </summary>
        /// <param name="value">Integer value to initialize this fixnum with.</param>
        public FixnumObject(int value)
        {
            Value = value;
        }

        /// <summary>
        ///  Get or set this fixnum's value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        ///  Compare this Fixnum object to another Fixnum object.
        /// </summary>
        /// <param name="other">The other fixnum object to compare to.</param>
        /// <returns>Result of the comparison.</returns>
        public int CompareTo(FixnumObject other)
        {
            if (ReferenceEquals(other, null))
            {
                throw new InvalidOperationException("Other instance is null");
            }

            return Value.CompareTo(other.Value);
        }

        /// <summary>
        ///  Compare this Fixnum object to another Fixnum object.
        /// </summary>
        /// <param name="other">The other fixnum object to compare to.</param>
        /// <returns>Result of the comparison.</returns>
        public int CompareTo(object other)
        {
            return CompareTo(other as FixnumObject);
        }

        /// <summary>
        ///  Check if this fixnum equals another fixnum.
        /// </summary>
        /// <param name="other">The fixnum to check for equality against.</param>
        /// <returns>True if the fixnums are equal, false otherwise.</returns>
        public bool Equals(FixnumObject other)
        {
            if (ReferenceEquals(other, null))
            {
                return false;
            }

            return ReferenceEquals(this, other) || Value.Equals(other.Value);
        }

        /// <summary>
        ///  Check if this fixnum equals another fixnum.
        /// </summary>
        /// <param name="other">The fixnum to check for equality against.</param>
        /// <returns>True if the fixnums are equal, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as FixnumObject);
        }

        /// <summary>
        ///  Get fixnum hashcode.
        /// </summary>
        /// <returns>Hashcode of fixnum.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        ///  String value of this fixnum.
        /// </summary>
        /// <returns>Fixnum string value.</returns>
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
