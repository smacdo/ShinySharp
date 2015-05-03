using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.REPL
{
    /// <summary>
    ///  Generic REPL reader exception.
    /// </summary>
    public class ReaderException : System.Exception
    {
        public ReaderException()
            : base()
        {
        }

        public ReaderException(string message)
            : base(message)
        {
        }

        public ReaderException(
            string message,
            string lineText,
            int? lineNumber = null,
            int? startCol = null,
            int? endCol = null)
            : base(message)
        {
            LineText = lineText ?? string.Empty;
            LineNumber = lineNumber;
            StartColumn = startCol;
            EndColumn = endCol;
        }

        public ReaderException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///  Get the input text that generated this exception.
        /// </summary>
        public string LineText { get; private set; }

        /// <summary>
        ///  Get the line number in the input text that generated this exception. 
        /// </summary>
        public int? LineNumber { get; private set; }

        /// <summary>
        ///  Get the starting column in the input text that generated this exception.
        /// </summary>
        public int? StartColumn { get; private set; }

        /// <summary>
        ///  Get the ending column in the input text that generated this exception.
        /// </summary>
        public int? EndColumn { get; private set; }
    }

    /// <summary>
    ///  When the REPL reader encounters a token that cnanot be parsed.
    /// </summary>
    public class ReaderInvalidTokenException : ReaderException
    {
        public ReaderInvalidTokenException(
            string message,
            string lineText,
            int? lineNumber = null,
            int? startCol = null,
            int? endCol = null)
            : base(message, lineText, lineNumber, startCol, endCol)
        {
        }
    }

    /// <summary>
    ///  REPL reader could not parse this fixnum value.
    /// </summary>
    public class ReaderInvalidFixnumTokenException : ReaderInvalidTokenException
    {
        public ReaderInvalidFixnumTokenException(
            string lineText,
            int? lineNumber = null,
            int? startCol = null,
            int? endCol = null)
            : base("Invalid fixnum value encountered", lineText, lineNumber, startCol, endCol)
        {
        }
    }

    /// <summary>
    ///  REPL reader does not support given feature.
    /// </summary>
    public class ReaderNotSupportedException : ReaderException
    {
        public ReaderNotSupportedException()
            : base("Shiny REPL reader does not support this feature")
        {
        }

        public ReaderNotSupportedException(string message)
            : base(message)
        {
        }
    }

    public class ReaderFloatNotSupportedException : ReaderNotSupportedException
    {
        public ReaderFloatNotSupportedException()
            : base("Floating point values not supported")
        {
        }
    }
}
