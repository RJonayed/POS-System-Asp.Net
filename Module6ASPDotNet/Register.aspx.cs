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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //message.Text = "Hello " + txtUserName.Text + " ! ";
            //message.Text = message.Text + " <br/> You have successfuly Registered with the following details.";
            //ShowUserName.Text = txtUserName.Text;
            //ShowEmail.Text = txtEmail.Text;
            //if (RadioButton1.Checked)
            //{
            //    ShowGender.Text = RadioButton1.Text;
            //}
            //else ShowGender.Text = RadioButton2.Text;
            //var courses = "";
            
            //ShowUserNameLabel.Text = "User Name";
            //ShowEmailIDLabel.Text = "Email ID";
            //ShowGenderLabel.Text = "Gender";
            //txtUserName.Text = "";
            //txtEmail.Text = "";
            //RadioButton1.Checked = false;
            //RadioButton2.Checked = false;
        }

        protected void btnregistration_Click(object sender, EventArgs e)
        {
            lblmsg.Text = "";
            SqlConnection SQLConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\IDB-BiSEWITScholarship\ASP.NETModule_6\Module6ASPDotNet\Module6ASPDotNet\App_Data\MyDB.mdf; Integrated Security=True");
            SqlDataAdapter SQLAdapter = new SqlDataAdapter("Insert into LoginUser(UserName,Password,ComID)values('" + txtfname.Text.Trim() + "','" + txtpassword.Text.Trim() + "','" + txtemail.Text.Trim() + "')", SQLConn);
            DataTable DT = new DataTable();
            SQLAdapter.Fill(DT);

            //SqlConnection SQLConn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\IDB-BiSEWITScholarship\ASP.NETModule_6\Module6ASPDotNet\Module6ASPDotNet\App_Data\MyDB.mdf; Integrated Security=True");
            //SqlDataAdapter SQLAAdapter = new SqlDataAdapter("select * from LoginUser where UserName='" + txtfname.Text.Trim() + "',Password='" + txtpassword.Text.Trim() + "',ComID='" + txtemail.Text.Trim() + "'", SQLConn);
            //DataTable DTT = new DataTable();
            //SQLAAdapter.Fill(DTT);
            
                lblmsg.Text = "Registration Done!!";
                txtfname.Text = "";
                txtlname.Text = "";
                txtemail.Text = "";
                txtcity.Text = "";
                txtfname.Focus();
                Response.Redirect("Login.aspx");
            }
        }
    }
    

