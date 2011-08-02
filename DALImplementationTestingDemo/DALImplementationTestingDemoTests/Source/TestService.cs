using NUnit.Framework;
using NMock2;
using System;
using System.Data;

namespace DALImplementationTestingDemo.Source
{
    [TestFixture]
    public class TestService
    {
        //Step 5: Mocking the DAL for Service Implementation Tests
        [Test]
        public void TestGetImportantData_EnsureDALInvocation()
        {
            //setup/arrange
            DateTime fromDate = DateTime.Now.Subtract(new TimeSpan(30,0,0,0));
            DateTime toDate = DateTime.Now;
            Request request = new ImportantDataServiceRequestImpl();
            ImportantDataServiceRequest importantRequest = (ImportantDataServiceRequest)request;
            importantRequest.FromDate = fromDate;
            importantRequest.ToDate = toDate;
            DataSet response = new DataSet();
            Mockery mockery = new Mockery();
            Data mockData = mockery.NewMock<Data>();
            Expect.Once.On(mockData).Method("GetImportantDataWithDateRange").With(fromDate, toDate).Will(Return.Value(response));
            ImportantDataService service = new ImportantDataServiceImpl(mockData);

            //execute/act
            service.GetImportantData(request);

            //assert
            mockery.VerifyAllExpectationsHaveBeenMet();
        }

        //Step 6: Test Exception Handeling
        [Test]
        public void TestGetImportantData_ExceptionHandeling()
        {
            //setup/arrange
            DateTime fromDate = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));
            DateTime toDate = DateTime.Now;
            Request request = new ImportantDataServiceRequestImpl();
            ImportantDataServiceRequest importantRequest = (ImportantDataServiceRequest)request;
            importantRequest.FromDate = fromDate;
            importantRequest.ToDate = toDate;
            DataSet response = new DataSet();
            Mockery mockery = new Mockery();
            Data mockData = mockery.NewMock<Data>();
            Expect.Once.On(mockData).Method("GetImportantDataWithDateRange").With(fromDate, toDate).Will(Throw.Exception(new Exception()));
            ImportantDataService service = new ImportantDataServiceImpl(mockData);

            //execute/act
            try
            {
                service.GetImportantData(request);
                //assert
                Assert.Fail("An Exception should have been thrown");
            }
            catch (ServiceException e)
            {
                Assert.AreEqual("The Service Invocation Failed", e.Message);                
            }

            mockery.VerifyAllExpectationsHaveBeenMet();
        }
    }
}
