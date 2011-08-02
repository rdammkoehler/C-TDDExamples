using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace StoredProcedureTestingDemo.itest
{
    [TestFixture]
    public class UserNameAccountNumByTypeStoredProcTest
    {
        const string procName = "procUserNameAccountNumByType";
        const string procArgumentName = "@accountType";
        const int procResultTableIndex = 0;
        const string procResultTableUserNameColumnName = "userName";
        const string procResultTableAccountNumberColumnName = "accountNum";

        private DataSet Execute(string procArgumentValue)
        {
            SqlConnection connection = new SqlConnection(ITestSetupFixture.connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure; 
            command.CommandText = procName;

            SqlParameter parameter = command.Parameters.Add(procArgumentName, SqlDbType.VarChar);
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = procArgumentValue;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet result = new DataSet();

            connection.Open();           
            adapter.Fill(result);
            connection.Close();

            result.Tables[0].DefaultView.Sort = procResultTableUserNameColumnName;

            return result;
        }

        [Test]
        public void TestUserNameAccountNumByTypeStoredProc_GivenCheckingReturnsTwoRecords()
        {
            //setup/arrange
            const string procArgumentValue = "Checking";
            const string justinUserName = "justin";
            const string justinAccountNumber = "1234";
            const string saraUserName = "sara";
            const string saraAccountNumber = "9012";

            //execute/act
            DataSet result = Execute(procArgumentValue);

            //assert
            DataRowCollection rows = result.Tables[procResultTableIndex].Rows;
            
            Assert.AreEqual(2, rows.Count);
            //implicit assertion of order
            DataRow justinRow = rows[0];
            DataRow saraRow = rows[1];
            AssertAccount(justinRow, justinUserName, justinAccountNumber);
            AssertAccount(saraRow, saraUserName, saraAccountNumber);
        }

        private void AssertAccount(DataRow row, string expectedUserName, string expectedAccountNum)
        {
            string userName = row[procResultTableUserNameColumnName] as string;
            string accountNum = row[procResultTableAccountNumberColumnName] as string;
            Assert.AreEqual(expectedUserName, userName);
            Assert.AreEqual(expectedAccountNum, accountNum);
        }

        [Test]
        public void TestUserNameAccountNumByTypeStoredProc_GivenSavingsReturnsOneRecord()
        {
            //setup/arrange
            const string procArgumentValue = "Savings";
            const string justinUserName = "justin";
            const string justinAccountNumber = "5678";

            //execute/act
            DataSet result = Execute(procArgumentValue);

            //assert
            DataRowCollection rows = result.Tables[procResultTableIndex].Rows;
            
            Assert.AreEqual(1, rows.Count);
            DataRow row = rows[0];
            string userName = row[procResultTableUserNameColumnName] as string;
            Assert.AreEqual(justinUserName, userName);
            string accountNum = row[procResultTableAccountNumberColumnName] as string;
            Assert.AreEqual(justinAccountNumber, accountNum);
        }

        [Test]
        public void TestUserNameAccountNumByTypeStoredProc_GivenNonExistentAccountTypeReturnsZeroRecords()
        {
            //setup/arrange
            const string procArgumentValue = "";

            //execute/act
            DataSet result = Execute(procArgumentValue);

            //assert
            DataRowCollection rows = result.Tables[procResultTableIndex].Rows;

            Assert.AreEqual(0, rows.Count);
        }

        [Test]
        public void TestUserNameAccountNumByTypeStoredProc_GivenNullThrowsException()
        {
            //setup/arrange
            const string procArgumentValue = null;

            //execute/act
            try
            {
                Execute(procArgumentValue);
                Assert.Fail("Should have gotten an exception");
            }
            catch (SqlException sqle)
            {
                //assert
                Assert.AreEqual("Procedure or function 'procUserNameAccountNumByType' expects parameter '@accountType', which was not supplied.", sqle.Message);
            }
        }
    }
}
