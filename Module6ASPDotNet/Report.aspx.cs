using Module6ASPDotNet.DAL;
using Module6ASPDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSRpt_Click(object sender, EventArgs e)
        {
            string path = @"E:\IDB-BiSEWITScholarship\ASP.NETModule_6\Module6ASPDotNet\Module6ASPDotNet\Images\Product\"; ;
            List<ViewObject> products = ProductGateWay.GetProductList(path);
            Session["Data"] = products;
            Response.Redirect("ReportSummary.aspx");
        }
    }
}