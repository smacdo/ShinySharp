using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scott.Shiny.ConsoleShellApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var session = new ConsoleReplSession();
            session.Run();
        }
    }
}
