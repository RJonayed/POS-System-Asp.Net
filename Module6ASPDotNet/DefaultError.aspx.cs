using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class DefaultError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
                    string selectSQL = "SELECT * FROM Products";
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(selectSQL, con);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Product");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    // Log the exception                      
                    lblMsg.Text = "Something Bad happened, Please contact Administrator!!!!";
                }
                finally
                {

                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            string selectSQL = "Select ProductId as[Product Id],ProductName as[Name],VendorEmail as[Email],c.CategoryName as[Category],cast(Price as decimal(10,2))as Price from Product p,Category c where p.CategoryId=c.CategoryId order by p.ProductId";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(selectSQL, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Product");
            GridView1.DataSource = ds;
            GridView1.DataBind();

            lblMsg.Visible = false;
        }
    }
}
