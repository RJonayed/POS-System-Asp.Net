using Module6ASPDotNet.DAL;
using Module6ASPDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class EntityCrud : System.Web.UI.Page
    {
        ProductEFGetWay Dbobj = new ProductEFGetWay();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadEfGridView();
            }
        }

        private void LoadEfGridView()
        {
            List<Product> data = Dbobj.GetProductList().ToList();
            if (data.Count > 0)
            {
                GridViewEF.DataSource = data;
            }
            else
            {
                GridViewEF.DataSource = null;
            }
            GridViewEF.DataBind();
        }

        protected void GridViewEF_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewEF.EditIndex = e.NewEditIndex;
            LoadEfGridView();

        }

        protected void GridViewEF_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewEF.EditIndex = -1;
            LoadEfGridView();

        }

        protected void GridViewEF_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt16(GridViewEF.DataKeys[e.RowIndex].Value);
            FileUpload up =(FileUpload)GridViewEF.Rows[e.RowIndex].FindControl("FileUpload1");
            string ImageName = ProductGateWay.ImageName(id);
            string filUrl = "~/Images/";
            string newImageName = "";
            if (up.HasFile)
            {
                newImageName = up.FileName;
                filUrl += newImageName;
                up.SaveAs(Server.MapPath(filUrl));
            }

            Product obj1 = new Product(); ;
            obj1.ProductId = id;
            obj1.ProductName = e.NewValues["ProductName"].ToString();
            obj1.PurchaseDate = Convert.ToDateTime(e.NewValues["PurchaseDate"].ToString());
            obj1.VendorEmail = e.NewValues["VendorEmail"].ToString();
            obj1.ImageName = newImageName;
            obj1.ImageUrl = filUrl;
            obj1.Price = Convert.ToDecimal(e.NewValues["Price"].ToString());
            obj1.CategoryId = Convert.ToInt32(e.NewValues["CategoryId"]);
            Dbobj.UpdateProduct(obj1);
            GridViewEF.EditIndex = -1;
            LoadEfGridView();

            //int id = Convert.ToInt32(GridViewEp.DataKeys[e.RowIndex].Value);
            //FileUpload up = (FileUpload)GridViewEp.Rows[e.RowIndex].FindControl("FileUpload1");
            //string imagename = CustomerGateWay.GetImageName(id);
            //DeleteExistingImage(imagename);
            //string fileUrl = "~/Images/";
            //string newImageName = "";
            //if (up.HasFile)
            //{
            //    newImageName = up.FileName;
            //    fileUrl += newImageName;
            //    up.SaveAs(Server.MapPath(fileUrl));
            //}        
        }

        protected void GridViewEF_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(GridViewEF.DataKeys[e.RowIndex].Value);
            String ImageName = ProductGateWay.ImageName(id);
            Dbobj.DeleteProduct(id);
            LoadEfGridView();
        }
       
        protected void GridViewEF_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEF.PageIndex = e.NewPageIndex;
            LoadEfGridView();
        }
    }
}