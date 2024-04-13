using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDB.Brokers.Logging
{
    internal interface ILoggingBroker
    {
        void LogInforamation(string message);
        void LogError(string userMessage);
        void LogSuccessUser(string message);
    }
}

