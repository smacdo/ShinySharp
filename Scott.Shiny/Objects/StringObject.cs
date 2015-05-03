using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents a string.
    /// </summary>
    public class StringObject : TemplatedValueObject<string>
    {
        /// <summary>
        ///  Construct a new string object with the given value.
        /// </summary>
        /// <param name="value">String value to use.</param>
        public StringObject(string value)
            : base(value)
        {
        }

        /// <summary>
        ///  Get a string representation of this object.
        /// </summary>
        /// <returns>Printable string value.</returns>
        public override string ToString()
        {
            var output = Value
                .Replace("\\", "\\\\")
                .Replace("\r\n", "\\n")
                .Replace("\n", "\\n")
                .Replace("\"", "\\\"");

            return string.Format(CultureInfo.CurrentCulture, "\"{0}\"", output);
        }
    }
}
