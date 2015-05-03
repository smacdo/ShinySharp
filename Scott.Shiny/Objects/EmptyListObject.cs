using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents the empty list.
    /// </summary>
    public class EmptyListObject : SingletonObject
    {
        /// <summary>
        ///  Construct a new empty list object.
        /// </summary>
        public EmptyListObject()
        {
        }

        /// <summary>
        ///  Get a string representation of the empty list object.
        /// </summary>
        /// <returns>Printable empty list value.</returns>
        public override string ToString()
        {
            return "()";
        }
    }
}
