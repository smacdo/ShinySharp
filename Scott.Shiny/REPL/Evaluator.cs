using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scott.Shiny.Objects;

namespace Scott.Shiny.REPL
{
    /// <summary>
    ///  Evaluates Shiny expressions.
    /// </summary>
    public class Evaluator
    {
        /// <summary>
        ///  Constructor.
        /// </summary>
        public Evaluator()
        {

        }

        /// <summary>
        ///  Evaluate and return the result of the given expression.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <returns>Result of evaluating the expression.</returns>
        public SObject Evaluate(SObject expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            return expression;
        }
    }
}
