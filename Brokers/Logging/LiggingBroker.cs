using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Brokers.Logging
{
    internal class LiggingBroker : ILoggingBroker
    {
        public void LogInforamation(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        public void LogError(string userMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(userMessage);
            Console.ResetColor();
        }
        public void LogSuccessUser(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
