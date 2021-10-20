using Module6ASPDotNet.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class Party : System.Web.UI.Page
    {
        ClsMain SvCls = new ClsMain();
        ClsVar CvCls = new ClsVar();
        string SaveText = "";
        string DeleteText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LogInUserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }

            //ClsVar.GblComId = Session["ComId"].ToString();
            //ClsVar.GblComName = Session["ComName"].ToString();
            //ClsVar.GblAddress = Session["ComAddress"].ToString();
            //ClsVar.GblPcName = Session["PcName"].ToString();
            ClsVar.GblUserCode = Session["LoginUserName"].ToString();

            SvCls.cnString = Connection.GetConnectionString();
            SvCls.GblCon.ConnectionString = SvCls.cnString;
            if (IsPostBack != true)
            {

                string Qry;
                Qry = "select PartyCode from PartyInfo where partyname not in ('sales','purchase','cash sale','sell','cash purchase') and comid='" + ClsVar.GblComId + "' order by convert(money,PartyCode) ";
                CboPartyCode.DataSource = SvCls.GblDataTable(Qry);
                CboPartyCode.DataTextField = "PartyCode";
                CboPartyCode.DataValueField = "PartyCode";
                CboPartyCode.DataBind();
                CboPartyCode.Items.Add("");
                CboPartyCode.Text = "";


                VwInGrid();
                BtnAddNew.Focus();
                imageButtonSet();
            }
        }

        private void VwInGrid()
        {
            string Qry = "select PartyCode,PartyName,PartyType,MobileNo As Phone,Email,ContactPerson from PartyInfo /*where partyname not in ('sales','purchase','cash sale','sell','cash purchase') and partyType in ('supplier') order by partyname*/";
            Grd.DataSource = SvCls.GblDataTable(Qry);
            Grd.DataBind();
            LebTotRow.Text = "Total : " + SvCls.GblDataTable(Qry).Rows.Count;
        }

        private void imageButtonSet()
        {
            BtnSave.Attributes.Add("onmouseout", "this.src='Images/sav2.png'");
            BtnSave.Attributes.Add("onmouseover", "this.src='Images/sav1.png'");
            BtnDelete.Attributes.Add("onmouseout", "this.src='Images/del2.png'");
            BtnDelete.Attributes.Add("onmouseover", "this.src='Images/del1.png'");
            BtnShow.Attributes.Add("onmouseout", "this.src='Images/Show2.png'");
            BtnShow.Attributes.Add("onmouseover", "this.src='Images/Show1.png'");
            BtnAddNew.Attributes.Add("onmouseout", "this.src='Images/AddN2.png'");
            BtnAddNew.Attributes.Add("onmouseover", "this.src='Images/AddN1.png'");
        }

        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            txtPartyName.Text = "";
            txtRmk.Text = "";
            txtDiscount.Text = "";
            CboPartyAdd.Text = "";
            //CboPartyType.Text = "";
            txtFaxEmail.Text = "";
            txtConPerson.Text = "";
            txtOpBal.Text = "";
            txtPhone.Text = "";
            txtContAmt.Text = "";
            txtOpBalDate.Text = "";
            LebMsg.Visible = false;
            txtPartyName.Focus();


            SvCls.toGetData("SELECT isnull(max(convert(numeric,PartyCode)),100)+1 as cdNo from PartyInfo where partyname not in ('sales','purchase','cash sale','sell','cash purchase') and comid='" + ClsVar.GblComId + "'");
            if (SvCls.GblRdrToGetData.Read())
            {
                CboPartyCode.Items.Add(SvCls.GblRdrToGetData["cdNo"].ToString());
                CboPartyCode.Text = SvCls.GblRdrToGetData["cdNo"].ToString();
                SvCls.GblCon.Close();
                CboPartyCode.Enabled = false;
            }
            //SaveQry = "insert into Partyinfo(PartyCode,PartyName,PartyType,Address,MobileNO,Email,ContactPerson,contractMoney,DisPerc,Rmk,ComId,opbal)values('" +
            //         CboPartyCode.Text.Trim() + "','" + CboPartyName.Text + "','" + CboPartyType.Text.Trim() + "','" + CboPartyAdd.Text.Trim() + "','" +
            //         txtPhone.Text.Trim() + "','" + txtFaxEmail.Text.Trim() + "','" + txtConPerson.Text.Trim() + "'," + Convert.ToDouble(txtContAmt.Text.Trim()) + "," + Convert.ToDouble(txtDiscount.Text.Trim()) + ",'" + txtRmk.Text.Trim() + "','" + ClsVar.GblComId + "'," + Convert.ToDouble(txtOpBal.Text.Trim()) + ")";

            BtnAddNew.Enabled = false;
            BtnSave.Enabled = true;
            BtnDelete.Enabled = false;
            ///SaveText  = "Save";
            BtnShow.Enabled = false;
        }

        protected void BtnShow_Click(object sender, ImageClickEventArgs e)
        {
            if (CboPartyCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Party Code No...!!";
                return;
            }

            string Qry = "select * from PartyInfo where PartyCode='" + CboPartyCode.Text.Trim() + "'  and ComId='" + ClsVar.GblComId + "' ";
            if (SvCls.DataExist(Qry) == "1")
            {

                SvCls.toGetData("SELECT PartyName,PartyType,Address,MobileNo,Email,cast(Disperc as decimal(10,0)) as DisPerc,cast(contractMoney as decimal(10,0)) as ContractMoney,ContactPerson,Rmk,cast(opbal as decimal(10,0)) as OpBal,DrCr,convert(varchar,opbaldate,103) as OpBalDate,autono,cast(crlimit as decimal(10)) as CrLimit from PartyInfo where PartyCode='" + CboPartyCode.Text.Trim() + "' and ComId='" + ClsVar.GblComId + "' ");
                if (SvCls.GblRdrToGetData.Read())
                {
                    txtPartyAutoNo.Text = SvCls.GblRdrToGetData["autoNo"].ToString();
                    try
                    {
                        txtPartyName.Text = SvCls.GblRdrToGetData["PartyName"].ToString();
                    }
                    catch (Exception ee)
                    {
                        //txtPartyName.Items.Add(SvCls.GblRdrToGetData["PartyName"].ToString());
                        txtPartyName.Text = SvCls.GblRdrToGetData["PartyName"].ToString();
                    }

                    try
                    {
                        CboPartyType.Text = SvCls.GblRdrToGetData["PartyType"].ToString();
                    }
                    catch (Exception ee)
                    {
                        CboPartyType.Items.Add(SvCls.GblRdrToGetData["PartyType"].ToString());
                        CboPartyType.Text = SvCls.GblRdrToGetData["PartyType"].ToString();
                    }

                    try
                    {
                        CboPartyAdd.Text = SvCls.GblRdrToGetData["Address"].ToString();
                    }
                    catch (Exception ee)
                    {
                        //CboPartyAdd.Items.Add(SvCls.GblRdrToGetData["Address"].ToString());
                        CboPartyAdd.Text = SvCls.GblRdrToGetData["Address"].ToString();
                    }


                    //CboPartyType.Text = SvCls.GblRdrToGetData["PartyType"].ToString();
                    //CboPartyAdd.Text = SvCls.GblRdrToGetData["Address"].ToString();
                    txtPhone.Text = SvCls.GblRdrToGetData["MobileNo"].ToString();
                    txtFaxEmail.Text = SvCls.GblRdrToGetData["Email"].ToString();
                    txtDiscount.Text = SvCls.GblRdrToGetData["Disperc"].ToString();
                    txtOpBal.Text = SvCls.GblRdrToGetData["opBal"].ToString();
                    txtContAmt.Text = SvCls.GblRdrToGetData["ContractMoney"].ToString();
                    txtConPerson.Text = SvCls.GblRdrToGetData["ContactPerson"].ToString();
                    txtRmk.Text = SvCls.GblRdrToGetData["Rmk"].ToString();
                    txtCrLimit.Text = SvCls.GblRdrToGetData["CrLimit"].ToString();


                    if (SvCls.GblRdrToGetData["opbaldate"].ToString().ToLower() == "01/01/1900")
                    {
                        txtOpBalDate.Text = "";
                    }
                    else
                    {
                        txtOpBalDate.Text = SvCls.GblRdrToGetData["opbaldate"].ToString();
                    }

                    if (SvCls.GblRdrToGetData["drcr"].ToString().ToLower() == "cr")
                    {
                        chkCr.Checked = true;
                    }
                    else
                    {
                        chkCr.Checked = false;
                    }
                    SvCls.GblCon.Close();
                }
            }

            else
            {
                chkCr.Checked = false;
                txtPartyName.Text = "";
                CboPartyType.Text = "";
                CboPartyAdd.Text = "";
                txtPhone.Text = "";
                txtFaxEmail.Text = "";
                txtDiscount.Text = "";
                txtOpBal.Text = "";
                txtConPerson.Text = "";
                txtCrLimit.Text = "";
                txtRmk.Text = "";
                txtContAmt.Text = "";

            }

            VwInGrid();
            LebMsg.Visible = false;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string SelectQry;
            string SaveQry;
            string EditQry;
            string DrCr = "dr";
            LebMsg.Visible = true;

            if (chkCr.Checked)
            {
                DrCr = "cr";
            }
            else
            {
                DrCr = "dr";
            }
            if (CboPartyCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Party Code No...!!";
                return;
            }

            if (txtPartyName.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Party Name...!!";
                return;
            }

            //if (CboPartyType.Text.Trim() == "")
            //{
            //    LebMsg.BackColor = System.Drawing.Color.Red;
            //    LebMsg.ForeColor = System.Drawing.Color.White;
            //    LebMsg.Visible = true;
            //    LebMsg.Text = "Please Select The Party Type...!!";
            //    CboPartyType.Focus();
            //    return;
            //}

            if (txtDiscount.Text.Trim() == "")
            {
                txtDiscount.Text = "0";
            }

            if (txtContAmt.Text.Trim() == "")
            {
                txtContAmt.Text = "0";
            }

            if (txtOpBal.Text.Trim() == "")
            {
                txtOpBal.Text = "0";
            }


            if (txtOpBal.Text.Trim() != "0" && txtOpBalDate.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                txtOpBalDate.Focus();
                LebMsg.Text = "Please Enter The Opening Balance Date...!!";
                return;
            }


            if (SaveText.ToLower() == "save")
            {
                SvCls.toGetData("SELECT partycode From partyinfo where partyname='" + txtPartyName.Text.Trim() + "' and ComId= '" + ClsVar.GblComId + "'");
                if (SvCls.GblRdrToGetData.Read())
                {
                    //txtEmpAutoNo.Text = SvCls.GblRdrToGetData["empAutoNo"].ToString();
                    LebMsg.Visible = true;
                    LebMsg.Text = "Already Exist This Party Name...!!";
                    LebMsg.BackColor = System.Drawing.Color.Red;
                    LebMsg.ForeColor = System.Drawing.Color.White;
                    txtPartyName.Focus();
                    return;
                }

            }

            string opBalDate = "01/01/1900";

            if (txtOpBalDate.Text.Trim() != "")
            {
                opBalDate = txtOpBalDate.Text.Trim();
            }

            if (txtCrLimit.Text.Trim() == "")
            {
                txtCrLimit.Text = "0";
            }
            SelectQry = "select * from Partyinfo where PartyCode='" + CboPartyCode.Text.Trim() + "' and Comid='" + ClsVar.GblComId + "'";

            SaveQry = "insert into Partyinfo(PartyCode,PartyName,PartyType,Address,MobileNO,Email,ContactPerson,contractMoney,DisPerc,Rmk,ComId,opbal,usercode,drcr,opbalDate,crLimit,pcname) values('" +
                      CboPartyCode.Text.Trim() + "','" + txtPartyName.Text + "','" + CboPartyType.Text.Trim() + "','" + CboPartyAdd.Text.Trim() + "','" +
                      txtPhone.Text.Trim() + "','" + txtFaxEmail.Text.Trim() + "','" + txtConPerson.Text.Trim() + "'," + Convert.ToDouble(txtContAmt.Text.Trim()) + "," + Convert.ToDouble(txtDiscount.Text.Trim()) + ",'" + txtRmk.Text.Trim() + "','" + ClsVar.GblComId + "'," + Convert.ToDouble(txtOpBal.Text.Trim()) + ",'" + Session["LogInUserName"] + "','" + DrCr + "',convert(datetime,'" + opBalDate + "',103)," + Convert.ToDouble(txtCrLimit.Text.Trim()) + ",'" + ClsVar.GblPcName + "')";

            EditQry = "Update Partyinfo set crLimit=" + Convert.ToDouble(txtCrLimit.Text.Trim()) + ", opbal=" + Convert.ToDouble(txtOpBal.Text.Trim()) + ", ContactPerson='" + txtConPerson.Text.Trim() + "',contractMoney=" + Convert.ToDouble(txtContAmt.Text.Trim()) + ",PartyName='" + txtPartyName.Text.Trim() + "',PartyType='" + CboPartyType.Text.Trim() + "',Address='" + CboPartyAdd.Text.Trim() + "',MobileNo='" +
                       txtPhone.Text.Trim() + "',Email= '" + txtFaxEmail.Text.Trim() + "',rmk='" + txtRmk.Text + "',DisPerc=" + txtDiscount.Text + ",drcr='" + DrCr + "',opbaldate=convert(datetime,'" + opBalDate + "',103),pcname='" + ClsVar.GblPcName + "' where PartyCode ='" + CboPartyCode.Text.Trim() + "' and ComId='" + ClsVar.GblComId + "'";

            if (SvCls.DataExist(SelectQry).ToString() == "0")
            {
                SvCls.insertUpdate(SaveQry);
                LebMsg.Visible = true;
                LebMsg.Text = "SAVE SUCCESSFULLY...!!";
                LebMsg.BackColor = System.Drawing.Color.Green;
                LebMsg.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                if (SaveText.ToLower() == "save")
                {
                    LebMsg.Visible = true;
                    LebMsg.Text = "Already Exist This Party Code...!!";
                    LebMsg.BackColor = System.Drawing.Color.Red;
                    LebMsg.ForeColor = System.Drawing.Color.White;
                    return;
                }
                SvCls.insertUpdate(EditQry);
                LebMsg.Visible = true;
                LebMsg.Text = "EDIT SUCCESSFULLY...!!";
                LebMsg.BackColor = System.Drawing.Color.Green;
                LebMsg.ForeColor = System.Drawing.Color.White;
            }


            SvCls.toGetData("SELECT autono from PartyInfo where PartyCode='" + CboPartyCode.Text.Trim() + "' and ComId='" + ClsVar.GblComId + "' ");
            if (SvCls.GblRdrToGetData.Read())
            {
                txtPartyAutoNo.Text = SvCls.GblRdrToGetData["autoNo"].ToString();
            }

           // AccHeadCreate();
            //if (txtOpBal.Text.Trim()!="0")
            //{
            //    EnterOpBal();
            //}

            VwInGrid();
            BtnAddNew.Enabled = true;
            BtnAddNew.Focus();
            BtnSave.Enabled = false;
            ///SaveText  = "Save";
            BtnDelete.Enabled = true;
            BtnAddNew.Enabled = true;
            BtnShow.Enabled = true;

            if (txtOpBalDate.Text.Trim() == "01/01/1900")
            {
                txtOpBalDate.Text = "";
            }
        }

        private void AccHeadCreate()
        {
            if (SvCls.GblCon != null && SvCls.GblCon.State != ConnectionState.Closed)
            {
                SvCls.GblCon.Close();
            }

            SvCls.GblCon.ConnectionString = SvCls.cnString;
            SvCls.GblSqlCmd.Connection = SvCls.GblCon;

            SvCls.GblCon.Open();
            SvCls.GblSqlCmd.CommandText = "SpCreatePartyHead";
            SvCls.GblSqlCmd.CommandType = CommandType.StoredProcedure;

            SvCls.GblSqlCmd.Parameters.Add("@PartyAutoNo", SqlDbType.Int, 10);
            SvCls.GblSqlCmd.Parameters["@PartyAutoNo"].Value = Convert.ToInt32(txtPartyAutoNo.Text.Trim());
            SvCls.GblSqlCmd.Parameters.Add("@comid", SqlDbType.VarChar, 10);
            SvCls.GblSqlCmd.Parameters["@comid"].Value = ClsVar.GblComId;
            SvCls.GblSqlCmd.Parameters.Add("@usercode", SqlDbType.VarChar, 50);
            SvCls.GblSqlCmd.Parameters["@usercode"].Value = Session["LoginUserName"];
            SvCls.GblSqlCmd.Parameters.Add("@pcName", SqlDbType.VarChar, 50);
            SvCls.GblSqlCmd.Parameters["@pcName"].Value = ClsVar.GblPcName;
            SvCls.GblSqlCmd.ExecuteNonQuery();
            SvCls.GblSqlCmd.Parameters.Clear();
            SvCls.GblCon.Close();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string SelectQry;
            string DeleteQry;
            LebMsg.Visible = false;

            if (CboPartyCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Select The Party Code No...!!";
                return;
            }

            SelectQry = "select * from Partyinfo where PartyCode='" + CboPartyCode.Text + "' and comid='" + ClsVar.GblComId + "'";
            DeleteQry = "delete from Partyinfo where PartyCode='" + CboPartyCode.Text + "' and comid='" + ClsVar.GblComId + "'";
            if (SvCls.DataExist(SelectQry).ToString() == "1")
            {
                SvCls.insertUpdate(DeleteQry);
                CboPartyCode.Text = "";
                txtPartyName.Text = "";
                txtRmk.Text = "";
                txtDiscount.Text = "";
                CboPartyAdd.Text = "";
                //CboPartyType.Text = "Both";
                txtFaxEmail.Text = "";
                txtConPerson.Text = "";
                txtOpBal.Text = "";
                txtPhone.Text = "";
                LebMsg.Visible = false;
            }
            else
            {
                LebMsg.Visible = true;
                LebMsg.Text = "No Record Found to Delete...!!";
                return;
            }
            VwInGrid();

            BtnAddNew.Enabled = true;
            BtnAddNew.Focus();
            BtnSave.Enabled = false;
            ///SaveText  = "Save";
            BtnDelete.Enabled = false;
            BtnShow.Enabled = true;
            //btnColorChange();
        }

        protected void Grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VwInGrid();
            Grd.PageIndex = e.NewPageIndex;
            Grd.DataBind();
        }

        protected void Grd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            String tm = "";

            int index = Convert.ToInt32(e.CommandArgument);
            try
            {
                tm = Grd.Rows[index].Cells[1].Text;
                CboPartyCode.Text = Grd.Rows[index].Cells[1].Text;
                txtPartyName.Text = Grd.Rows[index].Cells[2].Text;

                BtnShow_Click(null, null);
                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddNew.Enabled = true;
               // btnColorChange();
            }
            catch { }
            
        }

        protected void CboPartyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnShow_Click(null, null);
        }
    }
}