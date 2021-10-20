using Module6ASPDotNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class _default : System.Web.UI.Page
    {
        ClsMain SvCls = new ClsMain();
        ClsVar CvCls = new ClsVar();
        protected void Page_Load(object sender, EventArgs e)
        {
            lebIp1.Visible = true;

            if (Session["LogInUserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            //ClsVar.GblComId = Session["ComId"].ToString();
            //ClsVar.GblComName = Session["ComName"].ToString();
            //ClsVar.GblAddress = Session["ComAddress"].ToString();
            //ClsVar.GblPcName = Session["PcName"].ToString();
            //ClsVar.GblUserCode = Session["LoginUserName"].ToString();
            //ClsVar.GblUserName = Session["LoginUserName"].ToString();

            string greetings = "";
            Int32 hrr = 0;


            txtPwd.Text = ClsVar.GblPcName;
            lebIp.Text = ClsVar.GblUserCode.ToUpper() + " HAS LOG IN FROM " + ClsVar.GblPcName;

            try
            {
                SvCls.cnString = Connection.GetConnectionString();
                SvCls.GblCon.ConnectionString = SvCls.cnString;

                SvCls.toGetData("select convert(varchar,getdate(),106) as servDt");
                if (SvCls.GblRdrToGetData.Read())
                {
                    lebServerDt.Text = SvCls.GblRdrToGetData["servDt"].ToString(); //Convert.ToDateTime(GblRdrToGetData["servDt"].ToString()).ToString(ClsVar.gblDtFormatForShow);
                }


                SvCls.toGetData("select datepart(hh, getdate()) as h");
                if (SvCls.GblRdrToGetData.Read())
                {
                    hrr = Convert.ToInt32(SvCls.GblRdrToGetData["h"].ToString());
                }

                if (hrr < 12)
                {
                    greetings = "GOOD MORNING ";
                }

                if (hrr >= 12 && hrr < 16)
                {
                    greetings = "GOOD AFTER NOON ";
                }

                if (hrr >= 16)
                {
                    greetings = "GOOD EVENING ";
                }

                //greetings = "GOOD MORNING ";
                lebGood.Text = greetings + ClsVar.GblUserName.ToUpper() + "!!";



                //lebServerDt.Text = SvCls.toGetServerDt().ToString();

                //lebServerDt.Text = SvCls.to
            }
            catch (Exception hm)
            {
                lebServerDt.Text = hm.Message;
            }

            try
            {

                SvCls.toGetData("select convert(varchar,i,108) i,convert(varchar,o,108) as o,whr,wmnt from VwFirstLogin where username='" + Session["LoginUserName"].ToString() + "' and attndate=convert(datetime,'" + lebServerDt.Text.Trim() + "',106)");
                if (SvCls.GblRdrToGetData.Read())
                {
                    lebLogIn.Text = "Today Your First Login Time at office is : " + SvCls.GblRdrToGetData["i"].ToString() + ", Last Login Time is : " + SvCls.GblRdrToGetData["o"].ToString() + ", Duration: " + SvCls.GblRdrToGetData["whr"].ToString() + "hr " + SvCls.GblRdrToGetData["wmnt"].ToString() + "mnt";
                }
            }
            catch { }
        }
    }
}