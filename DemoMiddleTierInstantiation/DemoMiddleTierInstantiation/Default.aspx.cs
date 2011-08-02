using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace DemoMiddleTierInstantiation
{
    public partial class _Default : System.Web.UI.Page
    {
        MiddleTier.BusinessObject businessObject = new MiddleTier.BusinessObject();

        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Page_Load");
        }
    }
}
