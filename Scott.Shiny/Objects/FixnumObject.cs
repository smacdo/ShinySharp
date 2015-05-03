using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents a 32 bit signed integer value.
    /// </summary>
    public class FixnumObject : TemplatedValueObject<int>
    {
        /// <summary>
        ///  Construct a new fixnum value.
        /// </summary>
        /// <param name="value">Integer value to use.</param>
        public FixnumObject(int value)
            : base(value)
        {
            Value = value;
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
