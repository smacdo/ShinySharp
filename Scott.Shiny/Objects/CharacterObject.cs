using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents a single character value.
    /// </summary>
    public class CharacterObject : TemplatedValueObject<char>
    { 
        /// <summary>
        ///  Construct a new character object with the given value.
        /// </summary>
        /// <param name="value">Character value to use.</param>
        public CharacterObject(char value)
            : base(value)
        {
        }

        /// <summary>
        ///  Return this value as a printable character value.
        /// </summary>
        /// <returns>Printable character value.</returns>
        public override string ToString()
        {
            switch (Value)
            {
                case '\n':
                    return "#\\newline";

                case ' ':
                    return "#\\space";

                case '\t':
                    return "#\\tab";

                default:
                    return string.Format("#\\{0}", Value);
            }
        }
    }
}
