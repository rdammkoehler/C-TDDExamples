using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DALImplementationTestingDemo.Source
{
    abstract public class AData
    {
        //Step-2
        virtual public void AddParameter(DbCommand command, string name, DbType type, object value)
        {
            //no-op, this is only an example
        }

        //Step-3
        virtual public DataSet ExecuteDataSet(DbCommand command)
        {
            //no-op, this is only an example
            return null;
        }

    }
}
