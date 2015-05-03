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
    /// <remarks>
    ///  TODO: Pull out the private reader functions for unit testing.
    /// </remarks>
    public class Reader
    {
        public const char DefaultCommentCharacter = ';';

        private readonly char[] mInputText;
        private int mReadPos = 0;
        private SessionContext mContext;

        /// <summary>
        ///  Constructor.
        /// </summary>
        /// <param name="inputText">Shiny code to read.</param>
        public Reader(string inputText, SessionContext context)
        {
            if (inputText == null)
            {
                throw new ArgumentNullException("inputText");
            }

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            CommentCharacter = DefaultCommentCharacter;
            mInputText = inputText.ToCharArray();
            mContext = context;
        }

        /// <summary>
        ///  Get or set the comment character.
        /// </summary>
        public char CommentCharacter { get; set; }
        
        /// <summary>
        ///  Get the number of characters in the input text.
        /// </summary>
        public int InputTextLength
        {
            get { return mInputText.Length; }
        }

        /// <summary>
        ///  Get the current line number being read.
        /// </summary>
        public int CurrentLine { get; private set; }

        /// <summary>
        ///  Get the current column being read.
        /// </summary>
        public int CurrentColumn { get; private set; }

        /// <summary>
        ///  Read a shiny expression and return an object representing what was read.
        /// </summary>
        /// <remarks>
        ///  This is pretty nasty and not unit tested. That should be changed.
        /// </remarks>
        /// <returns>Expression object.</returns>
        public SObject Read()
        {
            SObject result = null;

            // Don't bother reading whitespace since it means nothing.
            SkipWhitespace();

            // Get the first character of the incoming token and advance the read cursor.
            char c = GetNextCharacter();
            bool hasNextChar = HasNextCharacter();
            char nextCharacter = (hasNextChar ? PeekNextCharacter() : '\0');
            
            if (Char.IsNumber(c) || ((c == '-' || c == '+') && hasNextChar && Char.IsNumber(nextCharacter)))
            {
                // PARSING: Number.
                PutBackCharacter();
                result = ReadNumber();
            }
            else if (c == '#')
            {
                if (hasNextChar && nextCharacter == '\\')
                {
                    // TODO: Implement read character.
                }
                else
                {
                    // PARSING: Bool.
                    result = ReadBool();
                }
            }

            return result;
        }

        /// <summary>
        ///  Read a number from the input stream.
        /// </summary>
        /// <remarks>
        ///  TODO: Check and support overflow (both INT_MAX and INT_MIN).
        ///  TODO: Suport floating point values.
        /// </remarks>
        /// <returns>Number that was read.</returns>
        private SObject ReadNumber()
        {
            bool isNegative = false;
            bool isValidNumber = false;
            bool isReadingValue = true;
            int runningValue = 0;
            int charactersRead = 0;
            int startCol = CurrentColumn;

            while (HasNextCharacter() && isReadingValue)
            {
                char c = GetNextCharacter();

                if (Char.IsDigit(c))
                {
                    isValidNumber = true;
                    runningValue = runningValue * 10 + c - '0';
                }
                else if (c == '-' && charactersRead == 0)
                {
                    isNegative = true;
                }
                else if (c == '+' && charactersRead == 0)
                {
                    isNegative = false;
                }
                else if (c == '.')
                {
                    throw new ReaderFloatNotSupportedException();
                }
                else if (IsDelimitter(c))
                {
                    PutBackCharacter();
                    isReadingValue = false;
                }
                else
                {
                    isValidNumber = false;
                    break;
                }

                charactersRead += 1;
            }

            if (isValidNumber)
            {
                int modifier = (isNegative ? -1 : 1);
                return new FixnumObject(runningValue * modifier);
            }
            else
            {
                throw new ReaderInvalidFixnumTokenException(
                    GetCurrentLine(),
                    CurrentLine,
                    startCol,
                    CurrentColumn);
            }
        }

        /// <summary>
        ///  Read a number from the input stream.
        /// </summary>
        /// <remarks>
        ///  TODO: Check and support overflow (both INT_MAX and INT_MIN).
        ///  TODO: Suport floating point values.
        /// </remarks>
        /// <returns>Number that was read.</returns>
        private SObject ReadBool()
        {
            char c = GetNextCharacter();
            BoolObject result = null;

            switch (c)
            {
                case 'T':
                case 't':
                    result = mContext.True;
                    break;

                case 'F':
                case 'f':
                    result = mContext.False;
                    break;

                default:
                    throw new ReaderInvalidBoolTokenException(GetCurrentLine());
            }

            if (!PeekIsNextCharacterDelimiter())
            {
                throw new ReaderInvalidBoolTokenException(GetCurrentLine());
            }

            return result;
        }

        /// <summary>
        ///  Gets the contents of the current line for debugging purposes. Does not modify the state of the reader.
        /// </summary>
        /// <returns>Contents of the current line.</returns>
        private string GetCurrentLine()
        {
            int initialPosition = mReadPos;
            int lineStart = mReadPos - 1;
            int lineEnd = Math.Min(mReadPos, mInputText.Length - 1);

            while (lineStart > 0)
            {
                char c = mInputText[lineStart--];

                if (c == '\n')
                {
                    lineStart += 1;
                    break;
                }
            }

            while (lineEnd < mInputText.Length)
            {
                char c = mInputText[lineEnd++];

                if (c == '\r' || c == '\n')
                {
                    break;
                }
            }

            return new string(mInputText, lineStart, lineEnd - lineStart);
        }

        /// <summary>
        ///  Move the reader from the current position past any whitespace characters.
        /// </summary>
        private void SkipWhitespace()
        {
            bool inComment = false;

            while (HasNextCharacter())
            {
                var c = GetNextCharacter();

                // Check if this is the start of a comment. Comment nesting is not support.
                if (c == CommentCharacter)
                {
                    inComment = true;
                    continue;
                }

                // If the reader is currently inside of a comment, continue reading everything until the reader gets
                // to the next line.
                if (inComment)
                {
                    if (c == '\n')
                    {
                        inComment = false;
                    }

                    continue;
                }

                // Obviously the reader should consume whitespace characters.
                if (Char.IsWhiteSpace(c))
                {
                    continue;
                }

                // This is not a whitespace character! Put the character back and return to the caller.
                PutBackCharacter();
                break;
            }
        }

        /// <summary>
        ///  Check if there are more characters to consume from the input stream.
        /// </summary>
        /// <returns>True if there are more characters, false otherwise.</returns>
        private bool HasNextCharacter()
        {
            return mReadPos < InputTextLength;
        }

        /// <summary>
        ///  Peek at the next character in the input stream without advancing the read cursor.
        /// </summary>
        /// <returns>Next character in the input stream.</returns>
        private char PeekNextCharacter()
        {
            return mInputText[mReadPos];
        }

        /// <summary>
        ///  Get the next character in the input stream and advance the read cursor.
        /// </summary>
        /// <returns>Next character in the input stream.</returns>
        private char GetNextCharacter()
        {
            char c = mInputText[mReadPos++];

            // TODO: Handle \t and other characters.
            if (c == '\n')
            {
                CurrentLine += 1;
                CurrentColumn = 0;
            }
            else
            {
                CurrentColumn += 1;
            }

            return c;
        }

        /// <summary>
        ///  Put a consumed character back into the input stream and move the read cursor backward.
        /// </summary>
        private void PutBackCharacter()
        {
            // What character are we putting back?
            char c = mInputText[mReadPos - 1];

            // TODO: Need to handle all cases and test that we handled them properly.
            if (c == '\n')
            {
                CurrentLine--;
                throw new NotSupportedException("Moving past line end not support yet");
                // TODO: Where is the current column? bleh.
            }

            CurrentColumn -= 1;
            mReadPos -= 1;
        }

        /// <summary>
        ///  Check if the next character is a delimiter.
        /// </summary>
        /// <returns></returns>
        private bool PeekIsNextCharacterDelimiter()
        {
            if (HasNextCharacter())
            {
                return IsDelimitter(PeekNextCharacter());
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        ///  Check if the character is considered a delimitter value by the reader.
        /// </summary>
        /// <param name="c">Character to check.</param>
        /// <returns>True if the character is a delimitter value, false otherwise.</returns>
        public static bool IsDelimitter(char c)
        {
            return Char.IsWhiteSpace(c) || c == '\0' || c == '(' || c == ')' || c == '"' || c == ';';
        }
    }
}
