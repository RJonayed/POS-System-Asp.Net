using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using Module6ASPDotNet.DAL;

public class ClsMain
{
    public string GblUserCode;
    public SqlDataReader GblRdrToGetData;
    //public string cnString = "Persist Security Info=False;User ID=sa;Password='';Initial Catalog='HRM';Data Source='ayan';";
    //public string cnString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    //public string cnString = "Persist Security Info=False;User ID=sa;Password='';Initial Catalog='cod';Data Source='XEON';";
    //public SqlConnection GblCon = new SqlConnection("Persist Security Info=False;User ID=sa;Password='" + ClsVar.SqlPassword + "';Initial Catalog='" + ClsVar.DataBaseName + "';Data Source='" + ClsVar.ServerName + "';");
    //public SqlConnection GblCon = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["CodCnString"].ConnectionString);
    public string cnString = Connection.GetConnectionString();
    public SqlConnection GblCon = new SqlConnection();
    public SqlCommand GblSqlCmd = new SqlCommand();
    public ClsVar cv = new ClsVar();
    //GblCon.ConnectionString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["HRMConnectionString"].ConnectionString;
    //public static Int32 GblMonthNo;
    //public static Int32 GblMonthDays;
    //public static string GblFDate;
    //public static string GblLDate;

    public void toGetData(string QryForRetrieve)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }
        //GblCon.ConnectionString = ClsVar.GblCnStr;
        GblCon.Open();
        SqlCommand GblCmd = new SqlCommand(QryForRetrieve, GblCon);
        GblRdrToGetData = GblCmd.ExecuteReader();

    }


    public string GetPermissionSts(string Uid, string scrennNm, string SEVD)
    {
        string sts = "";

        toGetData("select [" + SEVD + "] as fn from [security] where uid='" + Uid + "' and screen='" + scrennNm + "'");
        if (GblRdrToGetData.Read())
        {

            sts = GblRdrToGetData["fn"].ToString().ToLower();

            if (sts == "false" || sts == "0")
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
        else
        {
            return "0";
        }


    }

    public Int32 GblToGetDateDiffDay(string fd, string ld)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        GblCon.Open();
        GblSqlCmd.Connection = GblCon;
        GblSqlCmd.CommandText = "SpTemGetDateDiff";
        GblSqlCmd.CommandType = CommandType.StoredProcedure;
        GblSqlCmd.Parameters.Add("@pcName", SqlDbType.VarChar, 30);
        GblSqlCmd.Parameters["@pcName"].Value = ClsVar.GblPcName;
        GblSqlCmd.Parameters.Add("@fd", SqlDbType.VarChar, 20);
        GblSqlCmd.Parameters["@fd"].Value = fd; //toGetDateDDMMYYYY(txtFromDate.Text.Trim());
        GblSqlCmd.Parameters.Add("@ld", SqlDbType.VarChar, 10);
        GblSqlCmd.Parameters["@ld"].Value = ld;// toGetDateDDMMYYYY(txtToDate.Text.Trim());
        GblSqlCmd.Parameters.Add("@withPayOrNot", SqlDbType.VarChar, 30);
        GblSqlCmd.Parameters["@withPayOrNot"].Value = "";
        GblSqlCmd.Parameters.Add("@typeOfLeave", SqlDbType.VarChar, 30);
        GblSqlCmd.Parameters["@typeOfLeave"].Value = "";
        GblSqlCmd.ExecuteNonQuery();
        GblSqlCmd.Parameters.Clear();
        GblCon.Close();

        toGetData("select totdays from temGetDate where pcname='" + ClsVar.GblPcName + "'");
        if (GblRdrToGetData.Read())
        {
            return Convert.ToInt32(GblRdrToGetData["totdays"].ToString());
        }
        else
        {
            return 0;
        }

    }
    public string toGetServerDt()
    {
        string servDt = "";

        toGetData("select convert(varchar,getdate(),103) as servDt");
        if (GblRdrToGetData.Read())
        {
            servDt = GblRdrToGetData["servDt"].ToString(); //Convert.ToDateTime(GblRdrToGetData["servDt"].ToString()).ToString(ClsVar.gblDtFormatForShow);
        }

        return servDt;
    }
    public string toGetDateDDMMYYYY(string attnDt)
    {
        //if ddmmyyyy
        //ClsVar.gblyFrom = attnDt.Substring(6, 4);
        //ClsVar.gblmFrom = attnDt.Substring(3, 2);
        //ClsVar.gbldFrom = attnDt.Substring(0, 2);

        //if mmddyyyy
        string m = "";
        string mm = "";

        if (attnDt != "")
        {
            mm = attnDt.Substring(3, 3).ToLower();
        }

        if (mm == "jan")
        {
            m = "01";
        }
        if (mm == "feb")
        {
            m = "02";
        }
        if (mm == "mar")
        {
            m = "03";
            //m = attnDt.Substring(3, 2).ToLower();
        }
        if (mm == "apr")
        {
            m = "04";
        }
        if (mm == "may")
        {
            m = "05";
        }
        if (mm == "jun")
        {
            m = "06";
        }
        if (mm == "jul")
        {
            m = "07";
        }
        if (mm == "aug")
        {
            m = "08";
        }
        if (mm == "sep")
        {
            m = "09";
        }
        if (mm == "oct")
        {
            m = "10";
        }
        if (mm == "nov")
        {
            m = "11";
        }
        if (mm == "dec")
        {
            m = "12";
        }

        if (m != "")
        {
            ClsVar.gblToGetDateDDMMYYYY = attnDt.Substring(0, 2) + "/" + m + "/" + attnDt.Substring(7, 4);
        }
        else
        {
            ClsVar.gblToGetDateDDMMYYYY = "";
        }

        //ClsVar.GblMonthNo = Convert.ToInt32(m);
        //ClsVar.gblFromDtStrDMY = ClsVar.gbldFrom + "/" + ClsVar.gblmFrom + "/" + ClsVar.gblyFrom;
        return ClsVar.gblToGetDateDDMMYYYY;

    }

    public void toGetMDYFrom(string attnDt)
    {
        //if ddmmyyyy
        ClsVar.gblyFrom = attnDt.Substring(6, 4);
        ClsVar.gblmFrom = attnDt.Substring(3, 2);
        ClsVar.gbldFrom = attnDt.Substring(0, 2);

        //if mmddyyyy
        //ClsVar.gblyFrom = attnDt.Substring(6, 4);
        //ClsVar.gbldFrom = attnDt.Substring(3, 2);
        //ClsVar.gblmFrom = attnDt.Substring(0, 2);

        ClsVar.gblFromDtStrMDY = ClsVar.gblmFrom + "/" + ClsVar.gbldFrom + "/" + ClsVar.gblyFrom;
        ClsVar.gblFromDtStrDMY = ClsVar.gbldFrom + "/" + ClsVar.gblmFrom + "/" + ClsVar.gblyFrom;

    }

    public void toGetMDYTo(string attnDt)
    {
        //if ddmmyyyy
        ClsVar.gblyTo = attnDt.Substring(6, 4);
        ClsVar.gblmTo = attnDt.Substring(3, 2);
        ClsVar.gbldTo = attnDt.Substring(0, 2);

        //if mmddyyyy
        //ClsVar.gblyTo = attnDt.Substring(6, 4);
        //ClsVar.gbldTo = attnDt.Substring(3, 2);
        //ClsVar.gblmTo = attnDt.Substring(0, 2);

        ClsVar.gblToDtStrMDY = ClsVar.gblmTo + "/" + ClsVar.gbldTo + "/" + ClsVar.gblyTo;
        ClsVar.gblToDtStrDMY = ClsVar.gbldTo + "/" + ClsVar.gblmTo + "/" + ClsVar.gblyTo;


    }
    public string GetDtSelFormulaForDateTwo(string FDt, string LDt)
    {
        string mm = "";
        string m = "";

        if (FDt != "")
        {
            mm = FDt.Substring(3, 3).ToLower();
        }

        if (mm == "jan")
        {
            m = "01";
        }
        if (mm == "feb")
        {
            m = "02";
        }
        if (mm == "mar")
        {
            m = "03";
            //m = attnDt.Substring(3, 2).ToLower();
        }
        if (mm == "apr")
        {
            m = "04";
        }
        if (mm == "may")
        {
            m = "05";
        }
        if (mm == "jun")
        {
            m = "06";
        }
        if (mm == "jul")
        {
            m = "07";
        }
        if (mm == "aug")
        {
            m = "08";
        }
        if (mm == "sep")
        {
            m = "09";
        }
        if (mm == "oct")
        {
            m = "10";
        }
        if (mm == "nov")
        {
            m = "11";
        }
        if (mm == "dec")
        {
            m = "12";
        }
        //string yFrom = FDt.Substring(6, 4);
        //string mFrom = FDt.Substring(3, 2);
        //string dFrom = FDt.Substring(0, 2);
        //string yTo = LDt.Substring(6, 4);
        //string mTo = LDt.Substring(3, 2);
        //string dTo = LDt.Substring(0, 2);

        string yFrom = FDt.Substring(7, 4);
        string mFrom = m;
        string dFrom = FDt.Substring(0, 2);

        if (LDt != "")
        {
            mm = LDt.Substring(3, 3).ToLower();
        }

        if (mm == "jan")
        {
            m = "01";
        }
        if (mm == "feb")
        {
            m = "02";
        }
        if (mm == "mar")
        {
            m = "03";
            //m = attnDt.Substring(3, 2).ToLower();
        }
        if (mm == "apr")
        {
            m = "04";
        }
        if (mm == "may")
        {
            m = "05";
        }
        if (mm == "jun")
        {
            m = "06";
        }
        if (mm == "jul")
        {
            m = "07";
        }
        if (mm == "aug")
        {
            m = "08";
        }
        if (mm == "sep")
        {
            m = "09";
        }
        if (mm == "oct")
        {
            m = "10";
        }
        if (mm == "nov")
        {
            m = "11";
        }
        if (mm == "dec")
        {
            m = "12";
        }

        string yTo = LDt.Substring(7, 4);
        string mTo = m;
        string dTo = LDt.Substring(0, 2);

        //TimeSpan ts = Convert.ToDateTime(txtToDate.Text).Subtract(Convert.ToDateTime(txtFromDate.Text));

        string frmla = "Date(" + yFrom + "," + mFrom + "," + dFrom + ") to Date(" + yTo + "," + mTo + "," + dTo + ")";
        return frmla;
    }

    public string GetMonthNoFromDt(string FDt)
    {
        string mm = "";
        string m = "";

        if (FDt != "")
        {
            mm = FDt.Substring(3, 3).ToLower();
        }

        if (mm == "jan")
        {
            m = "01";
        }
        if (mm == "feb")
        {
            m = "02";
        }
        if (mm == "mar")
        {
            m = "03";
            //m = attnDt.Substring(3, 2).ToLower();
        }
        if (mm == "apr")
        {
            m = "04";
        }
        if (mm == "may")
        {
            m = "05";
        }
        if (mm == "jun")
        {
            m = "06";
        }
        if (mm == "jul")
        {
            m = "07";
        }
        if (mm == "aug")
        {
            m = "08";
        }
        if (mm == "sep")
        {
            m = "09";
        }
        if (mm == "oct")
        {
            m = "10";
        }
        if (mm == "nov")
        {
            m = "11";
        }
        if (mm == "dec")
        {
            m = "12";
        }
        //string yFrom = FDt.Substring(6, 4);
        //string mFrom = FDt.Substring(3, 2);
        //string dFrom = FDt.Substring(0, 2);
        //string yTo = LDt.Substring(6, 4);
        //string mTo = LDt.Substring(3, 2);
        //string dTo = LDt.Substring(0, 2);

        string yFrom = FDt.Substring(7, 4);
        string mFrom = m;
        string dFrom = FDt.Substring(0, 2);

        return m;
    }

    public string GetYearNoFromDt(string FDt)
    {
        string mm = "";
        string m = "";

        if (FDt != "")
        {
            mm = FDt.Substring(3, 3).ToLower();
        }

       
        m = FDt.Substring(7, 4);
      
        return m;
    }


    public void toRunStoredProc(string SPName)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        GblCon.Open();
        SqlCommand GblCmd = new SqlCommand(SPName, GblCon);

        GblCmd.CommandType = CommandType.StoredProcedure;
        //GblCmd.Parameters.Add(new SqlParameter("@D_BaseMedia", SqlDbType.VarChar, 100));
        //GblCmd.Parameters["@D_BaseMedia"].Value = ClsVar.FileName;
        //GblCmd.Parameters.Add(new SqlParameter("@D_BasePath", SqlDbType.VarChar, 300));
        //GblCmd.Parameters["@D_BasePath"].Value = ClsVar.FilePath;
        //GblCmd.Parameters.Add(new SqlParameter("@D_BaseNAme", SqlDbType.VarChar, 30));
        //GblCmd.Parameters["@D_BaseNAme"].Value = ClsVar.DataBaseName;
        GblCmd.ExecuteNonQuery();


    }

    public DataSet GblDataSet(string GblQryForCombo)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        DataSet GblDs = new DataSet();
        SqlDataAdapter GblAdp = new SqlDataAdapter(GblQryForCombo, GblCon);
        GblAdp.Fill(GblDs);
        return GblDs;
    }

    public string GblPCNm()
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        string pcNm = "";

        GblCon.Open();
        //SqlCommand GblCmd = new SqlCommand("select host_name() as pcNm", GblCon);
        //GblRdrToGetData = GblCmd.ExecuteReader();
        //pcNm = GblRdrToGetData["pcNm"].ToString();
        //return pcNm;

        toGetData("select host_name() as pcNm");
        if (GblRdrToGetData.Read())
        {
            pcNm = GblRdrToGetData["pcNm"].ToString();
        }
        return pcNm;
    }

    public DataTable GblDataTable(string GblQryForGrid)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        DataTable GblDt = new DataTable();
        GblCon.Open();
        SqlDataAdapter GblAdp = new SqlDataAdapter(GblQryForGrid, GblCon);
        GblAdp.Fill(GblDt);
        GblCon.Close();
        return GblDt;
    }

    public void GetMonthYear(string MNm, string Yr)
    {
        if (MNm == "January")
        {
            ClsVar.GblMonthNo = 1;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/01/" + Yr;
            ClsVar.GblLDate = "31/01/" + Yr;
        }

        if (MNm == "February")
        {
            ClsVar.GblMonthNo = 2;

            ClsVar.GblMonthDays = 28;
            ClsVar.GblFDate = "01/02/" + Yr;
            ClsVar.GblLDate = "28/02/" + Yr;

            if (Convert.ToInt32(Yr) % 400 == 0 || (Convert.ToInt32(Yr) % 100 != 0 && Convert.ToInt32(Yr) % 4 == 0))
            {
                ClsVar.GblMonthDays = 29;
                ClsVar.GblLDate = "29/02/" + Yr;
            }
        }
        if (MNm == "March")
        {
            ClsVar.GblMonthNo = 3;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/03/" + Yr;
            ClsVar.GblLDate = "31/03/" + Yr;
        }
        if (MNm == "April")
        {
            ClsVar.GblMonthNo = 4;
            ClsVar.GblMonthDays = 30;
            ClsVar.GblFDate = "01/04/" + Yr;
            ClsVar.GblLDate = "30/04/" + Yr;
        }
        if (MNm == "May")
        {
            ClsVar.GblMonthNo = 5;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/05/" + Yr;
            ClsVar.GblLDate = "31/05/" + Yr;
        }
        if (MNm == "June")
        {
            ClsVar.GblMonthNo = 6;
            ClsVar.GblMonthDays = 30;
            ClsVar.GblFDate = "01/06/" + Yr;
            ClsVar.GblLDate = "30/06/" + Yr;
        }
        if (MNm == "July")
        {
            ClsVar.GblMonthNo = 7;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/07/" + Yr;
            ClsVar.GblLDate = "31/07/" + Yr;
        }
        if (MNm == "August")
        {
            ClsVar.GblMonthNo = 8;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/08/" + Yr;
            ClsVar.GblLDate = "31/08/" + Yr;
        }

        if (MNm == "September")
        {
            ClsVar.GblMonthNo = 9;
            ClsVar.GblMonthDays = 30;
            ClsVar.GblFDate = "01/09/" + Yr;
            ClsVar.GblLDate = "30/09/" + Yr;
        }

        if (MNm == "October")
        {
            ClsVar.GblMonthNo = 10;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/10/" + Yr;
            ClsVar.GblLDate = "31/10/" + Yr;
        }

        if (MNm == "November")
        {
            ClsVar.GblMonthNo = 11;
            ClsVar.GblMonthDays = 30;
            ClsVar.GblFDate = "01/11/" + Yr;
            ClsVar.GblLDate = "30/11/" + Yr;
        }
        if (MNm == "December")
        {
            ClsVar.GblMonthNo = 12;
            ClsVar.GblMonthDays = 31;
            ClsVar.GblFDate = "01/12/" + Yr;
            ClsVar.GblLDate = "31/12/" + Yr;
        }
    }
    public void insertUpdate(string GblQry)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        SqlCommand GblCmd = new SqlCommand(GblQry, GblCon);
        GblCon.Open();
        GblCmd.ExecuteNonQuery();
        GblCon.Close();
    }

    public String DataExist(string DataExistQry)
    {
        if (GblCon != null && GblCon.State != ConnectionState.Closed)
        {
            GblCon.Close();
        }

        GblCon.Open();
        SqlCommand GblCmd = new SqlCommand(DataExistQry, GblCon);
        SqlDataReader GblRdr = GblCmd.ExecuteReader();

        if (GblRdr.Read())
        {
            GblCon.Close();
            return "1";
        }
        else
        {
            GblCon.Close();
            return "0";
        }

    }

}








