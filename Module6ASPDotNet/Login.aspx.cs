using Module6ASPDotNet.DAL;
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
    public partial class Login : System.Web.UI.Page
    {
        ClsMain SvCls = new ClsMain();
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32 curDy = DateTime.Today.Day;
            string slno = "1";
            Int32 fromDay = 0;
            Int32 toDay = 0;

            SvCls.cnString = Connection.GetConnectionString(); /*System.Web.Configuration.WebConfigurationManager.ConnectionStrings["PPLCnString"].ConnectionString;*/
            SvCls.GblCon.ConnectionString = SvCls.cnString;
            Int32 dd = DateTime.Now.Second;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(SvCls.cnString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from LoginUser where UserName='" + txtUserName.Text.Trim() + "' and Password= '" + txtPassword.Text.Trim() + "'", con);
            cmd.Parameters.AddWithValue("@username", txtUserName.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string SelectQry;
                SelectQry = "select * from LoginUser  where UserName='" + txtUserName.Text.Trim() + "' and Password= '" + txtPassword.Text.Trim() + "'";
                SvCls.toGetData(SelectQry);
                if (SvCls.GblRdrToGetData.Read())
                {
                    ClsVar.GblUserCode = SvCls.GblRdrToGetData["UserCode"].ToString();
                    ClsVar.GblUserName = SvCls.GblRdrToGetData["UserName"].ToString();
                    Session["EmpIdForInd"] = SvCls.GblRdrToGetData["UserName"].ToString();
                }

                Session["LogInUserName"] = txtUserName.Text.Trim();
                Session["CurUserName"] = txtUserName.Text.Trim();

                ClsVar.logRmk = "Log In";
                Response.Redirect("default.aspx");
            }
            lblMsg.Text = "Invalid User Name/Password";
        }
    }

    }
