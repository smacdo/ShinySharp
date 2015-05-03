using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scott.Shiny.Objects;
using Scott.Shiny.REPL;

namespace Scott.Shiny.ConsoleShellApp
{
    /// <summary>
    ///  A simple console (command line) driven read/evaluate/print loop implementation.
    /// </summary>
    /// <remarks>
    ///  TODO: There are a lot of console specific commands in here. Consider refactoring those methods out.
    /// </remarks>
    public class ConsoleReplSession
    {
        public const string DefaultInputPrompt = "> ";
        public const ConsoleColor DefaultColor = ConsoleColor.White;
        public const ConsoleColor InputPromptColor = ConsoleColor.DarkGreen;

        private ConsoleColor mLastColor = DefaultColor;

        /// <summary>
        ///  Default constructor.
        /// </summary>
        public ConsoleReplSession()
        {
            InputPrompt = DefaultInputPrompt;
            CurrentColor = DefaultColor;
        }

        /// <summary>
        ///  Get or set string representing the user input prompt.
        /// </summary>
        public string InputPrompt { get; set; }

        /// <summary>
        ///  Get or set the current console color.
        /// </summary>
        public ConsoleColor CurrentColor { get; set; }

        /// <summary>
        ///  Runs the REPL until the user quits.
        /// </summary>
        public void Run()
        {
            OnStarted();

            while (true)
            {
                var userInput = ReadUserInput(DefaultInputPrompt);
                var parsedExpression = Read(userInput);
                var result = Evaluate(parsedExpression);
                WriteResult(result);
            }
        }

        /// <summary>
        ///  Reads user input.
        /// </summary>
        /// <param name="prompt">String to show when prompting for user input.</param>
        private string ReadUserInput(string prompt)
        {
            if (prompt == null)
            {
                throw new ArgumentNullException("prompt");
            }

            WriteConsole(prompt, InputPromptColor);
            return Console.ReadLine();
        }

        /// <summary>
        ///  Read user input and convert it into an executable expression.
        /// </summary>
        /// <param name="input">User input.</param>
        /// <returns>Shiny object containing the user's expression.</returns>
        private SObject Read(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            var reader = new Reader(input);
            return reader.Read();
        }

        /// <summary>
        ///  Evaluate a shiny expression.
        /// </summary>
        /// <param name="expression">Expression to evaluate.</param>
        /// <returns>Result of evaluating the expression.</returns>
        private SObject Evaluate(SObject expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            var evaluator = new Evaluator();
            return evaluator.Evaluate(expression);
        }

        /// <summary>
        ///  Write the result of a shiny evaluation.
        /// </summary>
        /// <param name="result">Result to write.</param>
        private void WriteResult(SObject result)
        {
            Console.WriteLine(result.ToString());
        }

        /// <summary>
        ///  Write optionally color coded text to the console.
        /// </summary>
        /// <param name="text">Text to output in console.</param>
        /// <param name="color">Optional color to display text in.</param>
        private void WriteConsole(string text, ConsoleColor? color = null)
        {
            if (color.HasValue)
            {
                SetConsoleColor(color.Value);
                Console.Write(text);
                ResetConsoleColor();
            }
            else
            {
                Console.Write(text);
            }
        }

        /// <summary>
        ///  Set the console's text color.
        /// </summary>
        /// <param name="color">Color of the text on console.</param>
        private void SetConsoleColor(ConsoleColor color)
        {
            mLastColor = CurrentColor;
            CurrentColor = color;

            Console.ForegroundColor = color;
        }

        /// <summary>
        ///  Reset console color to last used value.
        /// </summary>
        private void ResetConsoleColor()
        {
            CurrentColor = mLastColor;
            Console.ForegroundColor = CurrentColor;
        }

        /// <summary>
        ///  Called when the session is started.
        /// </summary>
        private void OnStarted()
        {
            Console.WriteLine("Welcome to Shiny#, a simple Scheme inspired language. Use crtl+c to exit.");
        }
    }
}
