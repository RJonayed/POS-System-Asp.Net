using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class AllView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnListView_Click(object sender, EventArgs e)
        {
            Response.Redirect("List");
        }

        protected void btnDtls_Click(object sender, EventArgs e)
        {
            Response.Redirect("Details");
        }

        protected void btnForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormView");
        }

        protected void btnMultiView_Click(object sender, EventArgs e)
        {
            Response.Redirect("MultiView");
        }
    }
}