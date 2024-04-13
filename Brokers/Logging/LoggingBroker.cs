using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FileDB.Brokers.Logging
{
    internal class LoggingBroker : ILoggingBroker
    {
        public void LogInforamation(string message)=>
            Console.WriteLine(message);

        public void LogError(string userMessage) =>
            Console.WriteLine(userMessage);

        public void LogSuccessUser(string message)=>
            Console.WriteLine(message);
    }
}
