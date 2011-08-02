using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALImplementationTestingDemo.Source
{
    public class ImportantDataServiceRequestImpl : ImportantDataServiceRequest
    {
        #region ImportantDataServiceRequest Members

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        #endregion
    }
}
