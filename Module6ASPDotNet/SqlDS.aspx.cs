using Module6ASPDotNet.DAL;
using Module6ASPDotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class SqlDS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductUserControl.opType = "SQLDS";
            if (Session["Product"] != null)
            {
                Product1 obj = (Product1)Session["Product"];
                InsertProduct(obj);
                Session["Product"] = null;
            }
        }

        private void InsertProduct(Product1 obj)
        {
            SqlDataSource1.InsertParameters["ProductName"].DefaultValue = obj.ProductName;
            SqlDataSource1.InsertParameters["PurchaseDate"].DefaultValue = obj.PurchaseDate.ToShortDateString();
            SqlDataSource1.InsertParameters["VendorEmail"].DefaultValue = obj.VendorEmail;
            SqlDataSource1.InsertParameters["ImageName"].DefaultValue = obj.ImageName;
            SqlDataSource1.InsertParameters["ImageUrl"].DefaultValue = obj.ImageUrl;
            SqlDataSource1.InsertParameters["CategoryId"].DefaultValue = obj.CategoryId.ToString();
            SqlDataSource1.InsertParameters["Price"].DefaultValue = obj.Price.ToString();
            SqlDataSource1.Insert();
        }

      
        private void DeleteExistingImage(string imagename)
        {
            string path = Server.MapPath("~/Images/" + imagename);
            FileInfo fileObj = new FileInfo(path);
            if (fileObj.Exists)
            {
                fileObj.Delete();
            }
        }

        protected void gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int productId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString());
            FileUpload up = (FileUpload)gridview1.Rows[e.RowIndex].FindControl("FileUpload1");
            string imagename = ProductGateWay.ImageName(productId);
            DeleteExistingImage(imagename);
            string fileUrl = "~/Images/";
            string newImageName = "";
            if (up.HasFile)
            {
                newImageName = up.FileName;
                fileUrl += newImageName;
                up.SaveAs(Server.MapPath(fileUrl));
            }
            DropDownList dl = (DropDownList)gridview1.Rows[e.RowIndex].FindControl("ddl1");
            int cateId = Convert.ToInt32(dl.SelectedValue);
            TextBox txt = gridview1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
            txt.Text = newImageName;
            string productName = (gridview1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text;
            string purchaseDate = (gridview1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox).Text;
            string vendorEmail = (gridview1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox).Text;
            string price = (gridview1.Rows[e.RowIndex].FindControl("TextBox7") as TextBox).Text;            
            UpdateSql(newImageName, fileUrl, productId, cateId, productName,purchaseDate, vendorEmail, price);
        }

        private void UpdateSql(string newImageName, string fileUrl, int productId, int cateId,string productName, string purchaseDate, string vendorEmail,string price)
        {            
            SqlDataSource1.UpdateCommand = "Update [Product] set ProductName='"+ productName + "', PurchaseDate=convert(datetime,'" + purchaseDate+"',103), VendorEmail='"+ vendorEmail + "', ImageName='"+ newImageName + "', ImageUrl='"+ fileUrl + "', CategoryId='"+ cateId + "',Price='"+ price + "' where ProductId='"+ productId + "'" ;
            int affraw_update = SqlDataSource1.Update();
            SqlDataSource1.Dispose();
        }

       

        protected void gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(gridview1.DataKeys[e.RowIndex].Value.ToString());
            string imagename = ProductGateWay.ImageName(productId);
            DeleteExistingImage(imagename);
        }

       
    }
}