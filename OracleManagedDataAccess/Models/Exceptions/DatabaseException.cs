using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OracleManagedDataAccess.Models.Exceptions
{
    public class DatabaseException:BaseException
    {
        public DatabaseException()
        {
        }

        public DatabaseException(string message)
            : base(message)
        {
        }

        public DatabaseException(string message, bool showError)
            : base(message, showError) { }

        public DatabaseException(string messageToLog, string messageToUser)
            : base("DatabaseException: " + messageToLog, messageToUser)
        {
        }
    }
}