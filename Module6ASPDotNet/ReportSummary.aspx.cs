using CrystalDecisions.Shared;
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
    public partial class ReportSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["Data"] != null)
            //{
            //    var list = Session["Data"] as List<Product1>;
            //    StockSummary report = new StockSummary();
            //    report.SetDataSource(list);
            //    CrystalReportViewer1.ReportSource = report;
            //}

            string path = Server.MapPath("/");

            List<ViewObject> products = ProductGateWay.GetProductList(path); ;

            Session["Data"] = products;
            //Response.Redirect("ReportViewPage.aspx");
            if (Session["Data"] != null)
            {

                var list = Session["Data"] as List<ViewObject>;
                StockSummary reportObj = new StockSummary();
                reportObj.SetDataSource(list);
                CrystalReportViewer1.ReportSource = reportObj;
                reportObj.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "User Info");

            }
        }
    }

    }