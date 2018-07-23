using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Models.Exceptions
{
    [Serializable]
    public class BaseException:ApplicationException
    {
        public string MessageToUser { get; set; }
        public string MessageToLog { get; set; }
        public bool ShowError { get; set; }

        public BaseException()
        {
            ShowError = true;
        }

        public BaseException(string message)
            : base(message)
        {
            ShowError = true;
            MessageToLog = message;
            MessageToUser = message;
        }

        public BaseException(string message, bool showError)
            : base(message)
        {
            ShowError = showError;
            MessageToLog = message;
            MessageToUser = message;
        }

        public BaseException(string messageToLog, string messageToUser)
            : base(messageToLog)
        {
            ShowError = true;
            MessageToLog = messageToLog;
            MessageToUser = messageToUser;
        }
    }
}