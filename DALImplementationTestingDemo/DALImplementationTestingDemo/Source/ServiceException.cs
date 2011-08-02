using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALImplementationTestingDemo.Source
{
    public class ServiceException : Exception
    {
        public ServiceException() : base("The Service Invocation Failed")
        {
            //no-op
        }
    }
}
