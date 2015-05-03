using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.Objects
{
    /// <summary>
    ///  Represents a singleton boolean value.
    /// </summary>
    public abstract class BoolObject : SingletonObject
    {
        /// <summary>
        ///  Bool constructor.
        /// </summary>
        protected BoolObject()
        {
        }
    }

    /// <summary>
    ///  True boolean value.
    /// </summary>
    public class TrueBoolObject : BoolObject
    {
        public override string ToString()
        {
            return "#t";
        }
    }


    /// <summary>
    ///  False boolean value.
    /// </summary>
    public class FalseBoolObject : BoolObject
    {
        public override string ToString()
        {
            return "#f";
        }
    }
}
