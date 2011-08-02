using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALImplementationTestingDemo.Source
{
    public class ImportantDataServiceImpl : ImportantDataService
    {
        public Data DataDAL { get; set; }
        public ImportantDataServiceImpl(Data data)
        {
            DataDAL = data;
        }

        #region ImportantDataService Members

        public void GetImportantData(Request request)
        {
            try
            {
                ImportantDataServiceRequest importantRequest = (ImportantDataServiceRequest)request;
                DataDAL.GetImportantDataWithDateRange(importantRequest.FromDate, importantRequest.ToDate);
            }
            catch (Exception e)
            {
                throw new ServiceException();
            }
        }

        #endregion
    }
}
