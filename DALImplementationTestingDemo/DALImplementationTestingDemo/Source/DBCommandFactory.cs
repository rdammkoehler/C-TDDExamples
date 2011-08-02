using System;
using System.Data;
using System.Data.Common;

namespace DALImplementationTestingDemo.Source
{
    public interface DBCommandFactory
    {
        DbCommand GetStoredProcCommand(string commandName);
    }
}
