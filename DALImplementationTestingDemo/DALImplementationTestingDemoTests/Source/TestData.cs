using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace DALImplementationTestingDemo.Source
{
    [TestFixture]
    public class TestData
    {
        //step-1: manually creating a mock object
        [Test]
        public void TestGetImportantDataWithDateRange_RequestsCorrectStoredProc()
        {
            //setup/arrange
            DbCommand command = new MockDbCommand();
            DBCommandFactory cmdFactory = new MockDBCommandFactory();
            MockDBCommandFactory mockCmdFactory = (MockDBCommandFactory)cmdFactory;
            mockCmdFactory.RespondTo("procImportantDataByRange").With(command);
            Data dataDAL = new DataImpl(mockCmdFactory);

            //execute/act
            dataDAL.GetImportantDataWithDateRange(DateTime.Now, DateTime.Now);

            //assert
            mockCmdFactory.VerifyExpectations();
        }

        //step-2: using a sub-class to intercept calls to a parent class
        class Intercept
        {
            public string MethodName { get; set; }
            public object[] Args { get; set; }
            public Intercept(string method, params object[] arguments)
            {
                MethodName = method;
                Args = arguments;
            }

        }
        class InterceptingData : DataImpl
        {
            public List<Intercept> intercepts = new List<Intercept>();
            public DataSet ExecuteDataSetReturnValue { get; set; }

            public InterceptingData(DBCommandFactory factory) : base(factory)
            {
                //no-op
            }

            //Step-2
            override public void AddParameter(DbCommand command, string name, DbType type, object value)
            {
                intercepts.Add(new Intercept("AddParameter", command, name, type, value));
                //ignore
            }

            //Step-3
            override public DataSet ExecuteDataSet(DbCommand command)
            {
                intercepts.Add(new Intercept("ExecuteDataSet", command));
                //Step-4
                return ExecuteDataSetReturnValue;
            }

        }

        [Test]
        public void TestGetImportantDataWithDateRange_ParametersAreAdded()
        {
            //setup/arrange
            DbCommand command = new MockDbCommand();
            DBCommandFactory cmdFactory = new MockDBCommandFactory();
            MockDBCommandFactory mockCmdFactory = (MockDBCommandFactory)cmdFactory;
            mockCmdFactory.RespondTo("procImportantDataByRange").With(command);
            Data dataDAL = new InterceptingData(mockCmdFactory);
            InterceptingData interceptingDataDAL = (InterceptingData)dataDAL;
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;

            //execute/act
            dataDAL.GetImportantDataWithDateRange(fromDate, toDate);
            
            //assert
            Assert.AreEqual(3, interceptingDataDAL.intercepts.Count); //because of step 3 we had to update this from 2 to 3
            Intercept fromDateAddParameterInterception = interceptingDataDAL.intercepts[0];
            Assert.AreEqual("AddParameter", fromDateAddParameterInterception.MethodName);
            Assert.AreSame(command, fromDateAddParameterInterception.Args[0]);
            Assert.AreEqual("@FromDate", fromDateAddParameterInterception.Args[1]);
            Assert.AreEqual(DbType.String, fromDateAddParameterInterception.Args[2]);
            Assert.AreEqual(fromDate, fromDateAddParameterInterception.Args[3]);
            
            Intercept toDateAddParameterInterception = interceptingDataDAL.intercepts[1];
            Assert.AreEqual("AddParameter", toDateAddParameterInterception.MethodName);
            Assert.AreSame(command, toDateAddParameterInterception.Args[0]); 
            Assert.AreEqual("@ToDate", toDateAddParameterInterception.Args[1]);
            Assert.AreEqual(DbType.String, toDateAddParameterInterception.Args[2]);
            Assert.AreEqual(toDate, toDateAddParameterInterception.Args[3]);
            
        }

        //Step-3: Additional Call interceptions
        [Test]
        public void TestGetImportantDataWithDateRange_ExecuteDataSetIsCalled()
        {
            //setup/arrange
            DbCommand command = new MockDbCommand();
            DBCommandFactory cmdFactory = new MockDBCommandFactory();
            MockDBCommandFactory mockCmdFactory = (MockDBCommandFactory)cmdFactory;
            mockCmdFactory.RespondTo("procImportantDataByRange").With(command);
            Data dataDAL = new InterceptingData(mockCmdFactory);
            InterceptingData interceptingDataDAL = (InterceptingData)dataDAL;
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;

            //execute/act
            dataDAL.GetImportantDataWithDateRange(fromDate, toDate);

            //assert
            Intercept executeDataSetInterception = interceptingDataDAL.intercepts[2];
            Assert.AreEqual("ExecuteDataSet", executeDataSetInterception.MethodName);
            Assert.AreSame(command, executeDataSetInterception.Args[0]);
            
        }

        //Step-4: Check return type/value
        [Test]
        public void TestGetImportantDataWithDateRange_ReturnesData()
        {
            //setup/arrange
            DbCommand command = new MockDbCommand();
            DBCommandFactory cmdFactory = new MockDBCommandFactory();
            MockDBCommandFactory mockCmdFactory = (MockDBCommandFactory)cmdFactory;
            mockCmdFactory.RespondTo("procImportantDataByRange").With(command);
            Data dataDAL = new InterceptingData(mockCmdFactory);
            InterceptingData interceptingDataDAL = (InterceptingData)dataDAL;
            DateTime fromDate = DateTime.Now;
            DateTime toDate = DateTime.Now;
            DataSet testData = new DataSet();
            interceptingDataDAL.ExecuteDataSetReturnValue = testData;

            //execute/act
            DataSet returnValue = dataDAL.GetImportantDataWithDateRange(fromDate, toDate);

            //assert
            Assert.AreSame(testData, returnValue);
        }

    }
}
