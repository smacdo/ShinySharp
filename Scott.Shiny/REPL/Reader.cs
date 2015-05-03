using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scott.Shiny.Objects;

namespace Scott.Shiny.REPL
{
    /// <summary>
    ///  REPL reader.
    /// </summary>
    public class Reader
    {
        private readonly char[] mInputText;

        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="inputText">Shiny code to read.</param>
        public Reader(string inputText)
        {
            if (inputText == null)
            {
                throw new ArgumentNullException("inputText");
            }

            mInputText = inputText.ToCharArray();
        }

        /// <summary>
        ///  Read a shiny expression and return an object representing what was read.
        /// </summary>
        /// <returns>Expression object.</returns>
        public SObject Read()
        {
            return new SObject();
        }
    }
}
