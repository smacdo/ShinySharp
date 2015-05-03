using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scott.Shiny.Objects;

namespace Scott.Shiny.REPL
{
    /// <summary>
    ///  Contains information local to the current REPL session.
    /// </summary>
    public class SessionContext
    {
        /// <summary>
        ///  Constructor. Initialize the session context.
        /// </summary>
        public SessionContext()
        {
            EmptyList = new EmptyListObject();
            False = new FalseBoolObject();
            True = new TrueBoolObject();
        }

        /// <summary>
        ///  Get the empty list singleton.
        /// </summary>
        public EmptyListObject EmptyList { get; private set; }

        /// <summary>
        ///  Get the false bool singleton.
        /// </summary>
        public FalseBoolObject False { get; private set; }

        /// <summary>
        ///  Get the true bool singleton.
        /// </summary>
        public TrueBoolObject True { get; private set; }
    }
}
