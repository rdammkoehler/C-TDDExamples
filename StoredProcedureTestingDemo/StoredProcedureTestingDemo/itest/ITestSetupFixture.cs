using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace StoredProcedureTestingDemo.itest
{
    [SetUpFixture]
    public class ITestSetupFixture
    {
        //used ONLY for the create/drop db script
        public const string masterDBConnectionString = @"Data Source=BUTCHERBAY\SQLEXPRESS;Initial Catalog=master;Integrated Security=True";

        //connectionString would ideally be externalized into the app.config
        public const string connectionString = @"Data Source=BUTCHERBAY\SQLEXPRESS;Initial Catalog=StoredProcedureDemoDB;Integrated Security=True";

        //ideally this value would be externalized into the app.config
        public const string dbProjectHome = @"C:\Documents and Settings\Rich\My Documents\Visual Studio 2008\Projects\StoredProcedureTestingDemo\SqlServerDB\";

        /// <summary>
        /// Setup the data that will be used in ALL the tests in this namespace.
        /// Note: The downside to this configuration of the test is that the data
        /// is externalized from the test code. The upside is that the externalized
        /// data can be used for other purposes. However, because there is less
        /// code when using externalized data the advantage to this approach is
        /// apparent in the time savings.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            ExecuteScript(masterDBConnectionString, dbProjectHome + "createStoredProcedureDemoDB.sql");
            ExecuteScript(dbProjectHome + "createStoredProcedureDemoDBTables.sql");
            ExecuteScript(dbProjectHome + "insertAccountTypes.sql");
            ExecuteScript(dbProjectHome + "insertUsers.sql");
            ExecuteScript(dbProjectHome + "insertAccounts.sql");
            ExecuteScript(dbProjectHome + "createProcUserNameAccountNumByType.sql");
        }

        private void ExecuteScript(string scriptFileName)
        {
            ExecuteScript(connectionString, scriptFileName);
        }

        private void ExecuteScript(string aConnectionString, string scriptFileName)
        {
            string script = new StreamReader(scriptFileName).ReadToEnd();
            SqlConnection connection = new SqlConnection(aConnectionString);
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = script;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// Teardown (or remove) the test data after ALL tests are done.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            ExecuteScript(dbProjectHome + "dropProcUserNameAccountNumByType.sql");
            DeleteAll("Account");
            DeleteAll("[User]"); //gotta box the name or the client pukes
            DeleteAll("AccountType");
            ExecuteScript(dbProjectHome + "dropStoredProcedureDemoDBTables.sql");
            ExecuteScript(masterDBConnectionString, dbProjectHome + "dropStoredProcedureDemoDB.sql");
        }

        private void DeleteAll(string tableName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from " + tableName;
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
