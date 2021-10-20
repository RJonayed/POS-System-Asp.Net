using Module6ASPDotNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClsMain cm = new ClsMain();
            cm.cnString = Connection.GetConnectionString();
            cm.GblCon.ConnectionString = cm.cnString;
        }
    }
}