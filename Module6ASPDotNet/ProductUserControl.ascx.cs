using Module6ASPDotNet.DAL;
using Module6ASPDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class ProductUserControl : System.Web.UI.UserControl
    {  
        public string opType = "EF";
        ClsMain SvCls = new ClsMain();
        public static string mm = "";
        public static string yy = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Now.ToString("dd MMM yyyy");
                LaodddlCategory();
            }
            ShowImage();
        }
        private void ShowImage()
        {
            if (FileUpload1.HasFile)
            {
                string imageName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                HiddenImageName.Value = imageName;
                string filePath = "~/Images/" + imageName;
                HiddenImageUrl.Value = filePath;
                FileUpload1.SaveAs(Server.MapPath(filePath));
                Image1.ImageUrl = filePath;
            }
        }
        private void LaodddlCategory()
        {
            DataTable dt = ProductGateWay.Getcategories();

            DataRow dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "-Select-" };
            dt.Rows.InsertAt(dr, 0);

            ddlCategory.DataSource = dt;
            ddlCategory.DataTextField = dt.Columns["categoryName"].ToString();
            ddlCategory.DataValueField = dt.Columns["categoryId"].ToString();
            ddlCategory.DataBind();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            //if (Calendar1.Visible)
            //{Calendar1.Visible = false; }
            //else{ Calendar1.Visible = true; }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            
        }
        protected void btnCateSave_Click(object sender, EventArgs e)
        {
            Category obj = new Category();
            obj.CategoryName = txtCategory.Text;
            ProductGateWay.Savecategory(obj.CategoryName);
            txtCategory.Text = "";
            LaodddlCategory();
        }
        protected void btnSaveProduct_Click(object sender, EventArgs e)
        {
            Product1 obj = new Product1();
            obj.ProductName = txtProductName.Text;
            obj.PurchaseDate = Convert.ToDateTime(txtDate.Text);
            obj.VendorEmail = txtEmail.Text;
            obj.ImageName = HiddenImageName.Value;
            obj.ImageUrl = HiddenImageUrl.Value;
            obj.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            obj.Price = Convert.ToDecimal(txtPrice.Text);
            //Entity
            if (opType == "EF")
            {
                Product obj1 = new Product();
                obj1.ProductName = txtProductName.Text;
                obj1.PurchaseDate = Convert.ToDateTime(txtDate.Text);
                obj1.VendorEmail = txtEmail.Text;
                obj1.ImageName = HiddenImageName.Value;
                obj1.ImageUrl = HiddenImageUrl.Value;
                obj1.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                obj1.Price = Convert.ToDecimal(txtPrice.Text);
                ProductEFGetWay efObj = new ProductEFGetWay();
                efObj.InserProduct(obj1);
                Response.Redirect("EntityCrud");
            }
            if (opType == "ObjDS")
            {
                ProductGateWay.SaveProduct(obj.ProductName, obj.PurchaseDate, obj.VendorEmail, obj.ImageName, obj.ImageUrl, obj.Price, obj.CategoryId);
                Response.Redirect("ObjCrud");
            }
            else if (opType == "SQLDS")
            {
                Session["Product"] = obj;
                Response.Redirect("SqlCrud");
            }
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            mm = SvCls.GetMonthNoFromDt(txtDate.Text);
            yy = SvCls.GetYearNoFromDt(txtDate.Text);
        }
    }
}