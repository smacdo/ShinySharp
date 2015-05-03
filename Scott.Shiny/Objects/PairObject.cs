using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents a pair value.
    /// </summary>
    public class PairObject : SObject, IEquatable<PairObject>
    {
        private SObject mCar;
        private SObject mCdr;

        /// <summary>
        ///  Construct a new pair object.
        /// </summary>
        /// <param name="car">First pair object.</param>
        /// <param name="cdr">Second pair object.</param>
        public PairObject(SObject car, SObject cdr)
        {
            if (car == null)
            {
                throw new ArgumentNullException("car");
            }

            if (cdr == null)
            {
                throw new ArgumentNullException("cdr");
            }

            mCar = car;
            mCdr = cdr;
        }

        /// <summary>
        ///  Get or set the first element in the pair.
        /// </summary>
        public SObject Car
        {
            get { return mCar; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                mCar = value;
            }
        }

        /// <summary>
        ///  Get or set the second element in the pair.
        /// </summary>
        public SObject Cdr
        {
            get { return mCdr; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                mCdr = value;
            }
        }

        /// <summary>
        ///  Determine whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, false otherwise.</returns>
        public bool Equals(PairObject obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return Car.Equals(obj.Car) && Cdr.Equals(obj.Cdr);
        }

        /// <summary>
        ///  Determine whether the given object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as PairObject);
        }

        /// <summary>
        ///  Get a hashcode for the object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            // TODO: This is not the correct way to do it.
            return base.GetHashCode();
        }

        /// <summary>
        ///  Return this value as a printable pair value.
        /// </summary>
        /// <returns>Printable pair value.</returns>
        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("(");
            Write(output);
            output.Append(")");

            return output.ToString();
        }

        /// <summary>
        ///  Helper method to correctly and possibly recursively print this pair object.
        /// </summary>
        /// <param name="output">String output builder.</param>
        private void Write(StringBuilder output)
        {
            output.Append(Car);

            var cdrPair = mCdr as PairObject;
            
            if (cdrPair != null)
            {
                output.Append(" ");
                cdrPair.Write(output);
            }
            else if (mCdr is EmptyListObject)
            {
                // Don't need to print anything...
            }
            else
            {
                output.Append(" . ");
                output.Append(mCdr);
            }
        }
    }
}
