using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALImplementationTestingDemo.Source
{
    public interface ImportantDataServiceRequest : Request
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
    }
}
