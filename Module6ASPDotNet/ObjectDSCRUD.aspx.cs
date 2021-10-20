using Module6ASPDotNet.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class ObjectDSCRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ProductUserControl.opType = "ObjDS";
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int productId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            FileUpload up = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");
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
            DropDownList dl = (DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddl1");
            int cateId = Convert.ToInt32(dl.SelectedValue);
            ProductGateWay.UpdateImageById(newImageName, fileUrl, productId, cateId);
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
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int productId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
            string imagename = ProductGateWay.ImageName(productId);
            DeleteExistingImage(imagename);
        }
    }
}