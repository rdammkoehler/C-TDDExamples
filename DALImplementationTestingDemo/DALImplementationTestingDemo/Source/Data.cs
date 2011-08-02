using System;
using System.Data;
using System.Data.Common;

namespace DALImplementationTestingDemo.Source
{
    //Step-5: Convert Data to an interface to make mockable
    public interface Data
    {
        DataSet GetImportantDataWithDateRange(DateTime from, DateTime to);
    }

    public class DataImpl : AData, Data
    {
        public DBCommandFactory CommandFactory { get; set; }

        //note use of constructor injection
        public DataImpl(DBCommandFactory factory)
        {
            CommandFactory = factory;
        }

        //Step-1+
        //Step-4 causes return value to change from void to DataSet
        public DataSet GetImportantDataWithDateRange(DateTime from, DateTime to)
        {
            //step 1
            DbCommand command = CommandFactory.GetStoredProcCommand("procImportantDataByRange");
            //step 2
            AddParameter(command, "@FromDate", DbType.String, from);
            AddParameter(command, "@ToDate", DbType.String, to);
            //step 3
            DataSet dataSet = ExecuteDataSet(command);
            //step 4
            return dataSet;
        }
    }
}
