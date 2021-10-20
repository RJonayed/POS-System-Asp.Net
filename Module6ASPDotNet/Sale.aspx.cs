using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Module6ASPDotNet.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class Sale : System.Web.UI.Page
    {
        ClsMain SvCls = new ClsMain();
        ClsMain cm = new ClsMain();
        ClsVar CvCls = new ClsVar();

        double ItemAutoNo = 77;
        string ItemCodeNo = "";
        double PartyAutoNo = 0;
        double PartyCode = 0;
        string VNo = "";
        string DrHeadID = "";
        string CrHeadID = "";
        string AutoRmk = "";
        
      
        protected void Page_Load(object sender, EventArgs e)
        {
            SvCls.cnString = Connection.GetConnectionString();
            SvCls.GblCon.ConnectionString = SvCls.cnString;

            cm.cnString = Connection.GetConnectionString();
            cm.GblCon.ConnectionString = SvCls.cnString;

            ClsVar.GblComId = "1";
            if (Session["LogInUserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }
            
            //ClsVar.GblComId = Session["ComId"].ToString();
            //ClsVar.GblComName = Session["ComName"].ToString();
            //ClsVar.GblAddress = Session["ComAddress"].ToString();
            //ClsVar.GblPcName = Session["PcName"].ToString();
            ClsVar.GblUserCode = Session["LoginUserName"].ToString();


            imageButtonSet();

            if (IsPostBack != true)
            {
                if (ClsVar.GblBarcode == true)
                {

                    CboBarcode.Visible = true;

                    CboSLNo.Visible = false;
                    BtnAddNewSlNo.Visible = false;

                    CboItemName.Visible = false;

                    //CboItemType.Visible = false;
                    //CboUnit.Visible = false;

                    TxtSalePrice.Visible = false;

                    TxtTotal.Visible = false;

                }
                else
                {
                    //lblBarcode.Visible = false;
                    //CboBarcode.Visible = false;

                    CboSLNo.Visible = true;
                    BtnAddNewSlNo.Visible = true;

                    //CboItemName.Visible = true;

                    //CboItemType.Visible = true;
                    //CboUnit.Visible = true;

                    TxtSalePrice.Visible = true;

                    TxtTotal.Visible = true;
                }

                string Qry;
                Qry = "select InvoiceNo from SaleMstr where comid='" + ClsVar.GblComId + "' group by InvoiceNo,SaleDate order by convert(money, InvoiceNo)";
                CboInvoiceNo.DataSource = SvCls.GblDataTable(Qry);
                CboInvoiceNo.DataTextField = "InvoiceNo";
                CboInvoiceNo.DataValueField = "InvoiceNo";
                CboInvoiceNo.DataBind();
                CboInvoiceNo.Items.Add("");
                CboInvoiceNo.Text = "";


                Qry = "Select acctHead from partyinfo where partytype in ('customer','both','client') order by acctHead";
                CboCusName.DataSource = SvCls.GblDataTable(Qry);
                CboCusName.DataTextField = "acctHead";
                CboCusName.DataValueField = "acctHead";
                CboCusName.DataBind();
                CboCusName.Items.Add("");
                CboCusName.Text = "";

                Qry = "select SlNo From Sale where comid='" + ClsVar.GblComId + "' order by SlNo";
                CboSLNo.DataSource = SvCls.GblDataTable(Qry);
                CboSLNo.DataTextField = "SlNo";
                CboSLNo.DataValueField = "SlNo";
                CboSLNo.DataBind();
                CboSLNo.Items.Add("");
                CboSLNo.Text = "";

                Qry = "select distinct menoNo From SaleMstr where comid='" + ClsVar.GblComId + "' order by menoNo desc";
                cboSignName.DataSource = SvCls.GblDataTable(Qry);
                cboSignName.DataTextField = "menoNo";
                cboSignName.DataValueField = "menoNo";
                cboSignName.DataBind();
                cboSignName.Items.Add("");
                cboSignName.Text = "";


                Qry = "select distinct header From SaleMstr where comid='" + ClsVar.GblComId + "' order by header desc";
                cboHeader.DataSource = SvCls.GblDataTable(Qry);
                cboHeader.DataTextField = "header";
                cboHeader.DataValueField = "header";
                cboHeader.DataBind();
                cboHeader.Items.Add("");
                cboHeader.Text = "";

                Qry = "select distinct footer From SaleMstr where comid='" + ClsVar.GblComId + "' order by footer desc";
                cboFooter.DataSource = SvCls.GblDataTable(Qry);
                cboFooter.DataTextField = "footer";
                cboFooter.DataValueField = "footer";
                cboFooter.DataBind();
                cboFooter.Items.Add("");
                cboFooter.Text = "";

                Qry = "select distinct rmk From SaleMstr where comid='" + ClsVar.GblComId + "' order by rmk desc";
                cboNote.DataSource = SvCls.GblDataTable(Qry);
                cboNote.DataTextField = "rmk";
                cboNote.DataValueField = "rmk";
                cboNote.DataBind();
                cboNote.Items.Add("");
                cboNote.Text = "";

                Qry = "select ItemName from Item where comid='" + ClsVar.GblComId + "' order by ItemName";
                CboItemName.DataSource = SvCls.GblDataTable(Qry);
                CboItemName.DataTextField = "ItemName";
                CboItemName.DataValueField = "ItemName";
                CboItemName.DataBind();
                CboItemName.Items.Add("");
                CboItemName.Text = "";

                Qry = "Select ItemType from Item where comid='" + ClsVar.GblComId + "' order by ItemType ";
                CboItemType.DataSource = SvCls.GblDataTable(Qry);
                CboItemType.DataTextField = "ItemType";
                CboItemType.DataValueField = "ItemType";
                CboItemType.DataBind();
                CboItemType.Items.Add("");
                CboItemType.Text = "";

                Qry = "Select unitName as Unit From itemUnit where comid='" + ClsVar.GblComId + "' order by unit ";
                CboUnit.DataSource = SvCls.GblDataTable(Qry);
                CboUnit.DataTextField = "Unit";
                CboUnit.DataValueField = "Unit";
                CboUnit.DataBind();
                CboUnit.Items.Add("");
                CboUnit.Text = "";

                Qry = "Select distinct HeadName from Head order by HeadName";
                CboBankName.DataSource = SvCls.GblDataTable(Qry);
                CboBankName.DataTextField = "HeadName";
                CboBankName.DataValueField = "HeadName";
                CboBankName.DataBind();
                CboBankName.Items.Add("");
                CboBankName.Text = "";

            }
            
        }

        private void imageButtonSet()
        {
            BtnSave.Attributes.Add("onmouseout", "this.src='Images/sav2.png'");
            BtnSave.Attributes.Add("onmouseover", "this.src='Images/sav1.png'");
            BtnDelete.Attributes.Add("onmouseout", "this.src='Images/del2.png'");
            BtnDelete.Attributes.Add("onmouseover", "this.src='Images/del1.png'");
            BtnShow.Attributes.Add("onmouseout", "this.src='Images/retrv1.png'");
            BtnShow.Attributes.Add("onmouseover", "this.src='Images/retrv2.png'");

            BtnAddNew.Attributes.Add("onmouseout", "this.src='Images/plus1.png'");
            BtnAddNew.Attributes.Add("onmouseover", "this.src='Images/plus2old.png'");
            btnExecute.Attributes.Add("onmouseout", "this.src='Images/btnExe2.png'");
            btnExecute.Attributes.Add("onmouseover", "this.src='Images/btnExe1.png'");
            BtnAccOk.Attributes.Add("onmouseout", "this.src='Images/btnPosAcc2.png'");
            BtnAccOk.Attributes.Add("onmouseover", "this.src='Images/btnPosAcc1.png'");
            BtnClearAll.Attributes.Add("onmouseout", "this.src='Images/ref2.png'");
            BtnClearAll.Attributes.Add("onmouseover", "this.src='Images/ref1.png'");
            BtnInvoice.Attributes.Add("onmouseout", "this.src='Images/btnInv2.png'");
            BtnInvoice.Attributes.Add("onmouseover", "this.src='Images/btnInv1.png'");
            BtnCard.Attributes.Add("onmouseout", "this.src='Images/btnCarPay2.png'");
            BtnCard.Attributes.Add("onmouseover", "this.src='Images/btnCarPay1.png'");

            BtnSLNoShow.Attributes.Add("onmouseout", "this.src='Images/retrv1.png'");
            BtnSLNoShow.Attributes.Add("onmouseover", "this.src='Images/retrv2.png'");
            BtnAddNewSlNo.Attributes.Add("onmouseout", "this.src='Images/plus1.png'");
            BtnAddNewSlNo.Attributes.Add("onmouseover", "this.src='Images/plus2old.png'");
        }

        private void VwInGrid()
        {
            string Qry = "select s.SLNo,I.ItemCode,i.ItemName,i.ItemType,i.ItemSize,cast(S.Qty as decimal(10,0))as Qty,cast(s.UnitPrice as decimal(10,0)) as Rate,cast(s.TotPrice as decimal(10,0)) as TotPrice from Sale s ,Item i WHERE I.COMID=S.COMID AND I.autoNo=S.ITEMAutoNo and S.Comid='" + ClsVar.GblComId + "' and s.invoiceno=" + Convert.ToInt32(CboInvoiceNo.Text.Trim()) + " order by s.slno";
            Grd.DataSource = SvCls.GblDataTable(Qry);
            Grd.DataBind();
        }

        protected void BtnAddNew_Click(object sender, ImageClickEventArgs e)
        {
            LebMsg.Visible = false;


            Int32 InvoiceNo = 0;
            SvCls.insertUpdate("delete from salemstr where year(saledate)=1900 and usercode='" + ClsVar.GblUserName + "'");

            SvCls.toGetData("SELECT isnull(max(convert(numeric,InvoiceNo)),0)+1 as cdNo from SaleMstr where comid='" + ClsVar.GblComId + "'");
            if (SvCls.GblRdrToGetData.Read())
            {
                CboInvoiceNo.Items.Add(SvCls.GblRdrToGetData["cdNo"].ToString());
                CboInvoiceNo.Text = SvCls.GblRdrToGetData["cdNo"].ToString();
                InvoiceNo = Convert.ToInt32(SvCls.GblRdrToGetData["cdNo"]);
                //SvCls.GblCon.Close();
            }

            if (CboCusName.Text.Trim() == "")
            {
                CboCusName.Items.Add("Cash Sale");
                CboCusName.Text = "Cash Sale";
            }

            string SelectQry = "Select AUTONO from PARTYINFO WHERE COMID='" + ClsVar.GblComId + "' and PARTYNAME in ('SALES','CASH SALE')";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                SvCls.insertUpdate("INSERT INTO SaleMstr (InvoiceNo,COMID,PARTYAUTO,Saledate,usercode) VALUES (" + Convert.ToInt32(CboInvoiceNo.Text) + ",'" + ClsVar.GblComId + "'," + SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["AUTONO"] + ",convert(datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',103),'" + Session["LoginUserName"].ToString() + "')");
            }
            else
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Party Sale...!!";
                return;
            }

            SvCls.toGetData("Select max(InvoiceNo) as autono from salemstr");
            if (SvCls.GblRdrToGetData.Read())
            {
                txtAutoNo.Text = SvCls.GblRdrToGetData["AUTONO"].ToString();
            }
            else
            {
                LebMsg.Visible = true;
                LebMsg.Text = "Failed...!!";
                return;
            }

            txtItemDet.Text = "";
            txtCName.Text = "";
            txtCMob.Text = "";
            txtCEmail.Text = "";
            txtSaleDate.Text = DateTime.Now.ToString("dd MMM yyyy"); ;
            CboCusName.Text = "Cash Sale";
            CboBarcode.Text = "";
            CboSLNo.Text = "1";
            CboItemName.Text = "";
            CboItemType.Text = "";
            TxtQty.Text = "0";
            CboUnit.Text = "";
            TxtSalePrice.Text = "0";
            TxtTotal.Text = "0";
            txtRmk.Text = "";
            TxtCash.Text = "0";
            TxtDue.Text = "0";
            TxtRefund.Text = "0";
            TxtGrandTotal.Text = "0";
            TxtVat.Text = "0";
            TxtVatAmt.Text = "0";
            TxtDiscount.Text = "0";
            TxtDiscountAmt.Text = "0";
            TxtPayableAmt.Text = "0";
            TxtPaidAmt.Text = "0";
            TxtDueAmt.Text = "0";
            TxtRefundAmt.Text = "0";

            //SelectQry = "Select acctHead  from partyinfo where PARTYNAME in ('sales and service','sales & service','sales & services','sales and services','CASH CUSTOMER','Sales','Cash Sale') AND COMID='" + ClsVar.GblComId + "'";
            //cm.toGetData(SelectQry);
            //if (cm.GblRdrToGetData.Read())
            //{
            //    CboCusName.Text = cm.GblRdrToGetData["acctHead"].ToString();
            //}

            //SelectQry = "select vat from Setting where  comid='" + ClsVar.GblComId + "'";
            //if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            //{
            //    TxtVat.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["vat"].ToString();
            //}
            //else
            //{
            //    TxtVat.Text = "0";
            //}

            if (ClsVar.GblBarcode == true)
            {
                CboBarcode.Focus();
            }
            else
            {
                BtnAddNewSlNo.Focus();
            }

            VwInGrid();

            BtnAddNew.Enabled = false;
            BtnAddNewSlNo.Enabled = true;
            BtnDelete.Enabled = false;
            //BtnSave.Text = "Save";
            BtnSLNoShow.Enabled = false;
            btnColorChange();
            //txtSaleDate.Focus();

            BtnAddNewSlNo_Click(null, null);
        }

        private void btnColorChange()
        {
            if (BtnAccOk.Enabled == true)
            {
                BtnAccOk.ForeColor = Color.White;
            }
            else
            {
                BtnAccOk.ForeColor = ColorTranslator.FromHtml("#33CC33");
            }

            if (BtnAddNewSlNo.Enabled == true)
            {
                BtnAddNewSlNo.ForeColor = Color.White;
            }
            else
            {
                BtnAddNewSlNo.ForeColor = ColorTranslator.FromHtml("#CC0066");
            }

            if (BtnSave.Enabled == true)
            {
                BtnSave.ForeColor = Color.White;
            }
            else
            {
                BtnSave.ForeColor = ColorTranslator.FromHtml("#33CC33");
            }

            if (BtnDelete.Enabled == true)
            {
                BtnDelete.ForeColor = Color.White;
            }
            else
            {
                BtnDelete.ForeColor = ColorTranslator.FromHtml("#FF5050");
            }

            if (BtnAddNew.Enabled == true)
            {
                BtnAddNew.ForeColor = Color.White;
            }
            else
            {
                BtnAddNew.ForeColor = ColorTranslator.FromHtml("#CC0066");
            }

            if (BtnShow.Enabled == true)
            {
                BtnShow.ForeColor = Color.White;
            }
            else
            {
                BtnShow.ForeColor = ColorTranslator.FromHtml("#33CC33");
            }

            if (BtnSLNoShow.Enabled == true)
            {
                BtnSLNoShow.ForeColor = Color.White;
            }
            else
            {
                BtnSLNoShow.ForeColor = ColorTranslator.FromHtml("#33CC33");
            }

        }

        protected void BtnAddNewSlNo_Click(object sender, ImageClickEventArgs e)
        {
            LebMsg.Visible = false;

            txtItemAutono.Text = "";
            txtItemCode.Text = "";


            if (CboCusName.Text == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Party Name...!!";              
            }

            SvCls.toGetData("SELECT isnull(max(convert(numeric,slNo)),0)+1 as cdNo from Sale where InvoiceNo= " + Convert.ToInt32(CboInvoiceNo.Text.Trim()) + " and comid='" + ClsVar.GblComId + "'");
            if (SvCls.GblRdrToGetData.Read())
            {
                CboSLNo.Items.Add(SvCls.GblRdrToGetData["cdNo"].ToString());
                CboSLNo.Text = SvCls.GblRdrToGetData["cdNo"].ToString();
                SvCls.GblCon.Close();
            }


            if (txtItemDet.Text.Trim() != "")
            {
                btnSrch_Click(null, null);
            }


            txtItemDet.Text = "";
            CboItemName.Text = "";
            CboItemType.Text = "";
            TxtQty.Text = "0";
            CboUnit.Text = "";
            TxtSalePrice.Text = "0";
            TxtTotal.Text = "0";
            txtRmk.Text = "";

            TxtCash.Text = "0";
            TxtDue.Text = "0";
            TxtRefund.Text = "0";

            //TxtVat.Text = "0";
            //TxtVatAmt.Text = "0";
            TxtDiscount.Text = "0";
            TxtDiscountAmt.Text = "0";
            TxtPayableAmt.Text = "0";
            TxtPaidAmt.Text = "0";
            TxtDueAmt.Text = "0";
            TxtRefundAmt.Text = "0";

            BtnAddNewSlNo.Enabled = false;
            BtnSave.Enabled = true;
            BtnDelete.Enabled = false;
            BtnSLNoShow.Enabled = false;
            //BtnSave.Text = "Save";
            btnColorChange();
            CboItemName.Focus();

        }

        protected void BtnShow_Click(object sender, ImageClickEventArgs e)
        {
            LebMsg.Visible = false;

            if (CboInvoiceNo.Text == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Invoice No...!!";
                return;
            }

            txtAutoNo.Text = "0";

            string SelectQry = "select s.autono,convert(varchar,s.saledate,106) as sdt,p.AcctHead as Customer,menoNo,cname,cmobile,cemail from SaleMstr s,partyInfo p where s.partyauto=p.autono and s.InvoiceNo =" + Convert.ToInt32(CboInvoiceNo.Text.Trim()) + " and s.Comid ='" + ClsVar.GblComId + "'";
            SvCls.toGetData(SelectQry);
            if (SvCls.GblRdrToGetData.Read())
            {
                txtAutoNo.Text = SvCls.GblRdrToGetData["AutoNo"].ToString();
                txtSaleDate.Text = SvCls.GblRdrToGetData["sdt"].ToString();
                txtCName.Text = SvCls.GblRdrToGetData["cname"].ToString();
                txtCMob.Text = SvCls.GblRdrToGetData["cmobile"].ToString();
                txtCEmail.Text = SvCls.GblRdrToGetData["cemail"].ToString();

                try
                {
                    CboCusName.Text = SvCls.GblRdrToGetData["Customer"].ToString();
                }
                catch
                {
                    CboCusName.Items.Add(SvCls.GblRdrToGetData["Customer"].ToString());
                    CboCusName.Text = SvCls.GblRdrToGetData["Customer"].ToString();
                }
                cboSignName.Text = SvCls.GblRdrToGetData["menoNo"].ToString();
                BtnAddNewSlNo.Enabled = true;
                Grd.Visible = true;

            }

            SelectQry = "select cast(Total as decimal(10,0)) as Total,cast(Payable as decimal(10,0)) as Payable,cast(Paid as decimal(10,0)) as Paid,cast(Due as decimal(10,0)) as Due,cast(Refund as decimal(10,0)) as Refund,cast(Vat as decimal(10,0)) as Vat,cast(TotVat as decimal(10,0)) as TotVat,cast(DisPer as decimal(10,0)) as DisPer,cast(DisCount as decimal(10,0)) as DisCount,PartyAuto,Convert(Varchar,SaleDate,106) as SaleDate,header,footer,rmk from SaleMstr where InvoiceNo =" + Convert.ToInt32(CboInvoiceNo.Text.Trim()) + " and Comid ='" + ClsVar.GblComId + "'";
            SvCls.toGetData(SelectQry);
            if (SvCls.GblRdrToGetData.Read())
            {
                TxtGrandTotal.Text = SvCls.GblRdrToGetData["Total"].ToString();
                TxtPayableAmt.Text = SvCls.GblRdrToGetData["Payable"].ToString();
                TxtPaidAmt.Text = SvCls.GblRdrToGetData["Paid"].ToString();
                TxtDueAmt.Text = SvCls.GblRdrToGetData["Due"].ToString();
                TxtRefundAmt.Text = SvCls.GblRdrToGetData["Refund"].ToString();
                TxtVat.Text = SvCls.GblRdrToGetData["Vat"].ToString();
                TxtVatAmt.Text = SvCls.GblRdrToGetData["TotVat"].ToString();
                TxtDiscount.Text = SvCls.GblRdrToGetData["DisPer"].ToString();
                TxtDiscountAmt.Text = SvCls.GblRdrToGetData["DisCount"].ToString();
                PartyAutoNo = Convert.ToDouble(SvCls.GblRdrToGetData["PartyAuto"]);
                txtSaleDate.Text = SvCls.GblRdrToGetData["Saledate"].ToString();

                TxtCash.Text = SvCls.GblRdrToGetData["Paid"].ToString();
                TxtDue.Text = SvCls.GblRdrToGetData["Due"].ToString();
                TxtRefund.Text = SvCls.GblRdrToGetData["Refund"].ToString();
                try
                {
                    cboFooter.Text = SvCls.GblRdrToGetData["footer"].ToString();
                }
                catch
                {
                    cboFooter.Items.Add(SvCls.GblRdrToGetData["footer"].ToString());
                    cboFooter.Text = SvCls.GblRdrToGetData["footer"].ToString();

                }
                try
                {
                    cboHeader.Text = SvCls.GblRdrToGetData["header"].ToString();
                }
                catch
                {
                    cboHeader.Items.Add(SvCls.GblRdrToGetData["header"].ToString());
                    cboHeader.Text = SvCls.GblRdrToGetData["header"].ToString();

                }

                try
                {
                    cboNote.Text = SvCls.GblRdrToGetData["rmk"].ToString();
                }
                catch
                {
                    cboNote.Items.Add(SvCls.GblRdrToGetData["rmk"].ToString());
                    cboNote.Text = SvCls.GblRdrToGetData["rmk"].ToString();

                }

                BtnAddNewSlNo.Enabled = true;

                BtnAccOk.Enabled = true;

            }
            else
            {
                txtCName.Text = "";
                txtCMob.Text = "";
                txtCEmail.Text = "";
                TxtGrandTotal.Text = "0";
                TxtPayableAmt.Text = "0";
                TxtPaidAmt.Text = "0";
                TxtDueAmt.Text = "0";
                TxtRefundAmt.Text = "0";
                TxtVat.Text = "0";
                TxtVatAmt.Text = "0";
                TxtDiscount.Text = "0";
                TxtDiscountAmt.Text = "0";
                PartyAutoNo = 0;
                txtSaleDate.Text = DateTime.Now.ToString("dd MMM yyyy");

                TxtCash.Text = "0";
                TxtDue.Text = "0";
                TxtRefund.Text = "0";
            }


            //SelectQry = "select acctHead from PartyInfo where Autono =" + PartyAutoNo + " and Comid= '" + ClsVar.GblComId + "'";
            //if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            //{
            //    CboCusName.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["acctHead"].ToString();
            //}
            //else
            //{
            //    CboCusName.Text = "";
            //}

            CalCulation();
            VwInGrid();
            btnColorChange();
        }

        private void CalCulation()
        {
            //{
            //    TxtVat.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["vat"].ToString();
            //}

            string TotalQry = "Select cast(isnull(SUM(TotPrice),0) as decimal(10)) as Tot from Sale where InvoiceNo=" + CboInvoiceNo.Text.Trim() + " and comid ='" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(TotalQry).Tables[0].Rows.Count > 0)
            {
                TxtGrandTotal.Text = SvCls.GblDataSet(TotalQry).Tables[0].Rows[0]["Tot"].ToString();
            }

            TxtVat.Text = "0";
            //TxtVatAmt.Text = (Convert.ToDouble(TxtGrandTotal.Text.Trim()) * Convert.ToDouble(TxtVat.Text.Trim()) / 100).ToString();
            TxtVatAmt.Text = "0";

            if (TxtDiscount.Text.Trim() == "")
            {
                TxtDiscount.Text = "0";
            }

            TxtDiscountAmt.Text = (Convert.ToDouble(TxtGrandTotal.Text.Trim()) * Convert.ToDouble(TxtDiscount.Text.Trim()) / 100).ToString();

            TxtPayableAmt.Text = (Convert.ToDouble(TxtGrandTotal.Text.Trim()) + Convert.ToDouble(TxtVat.Text.Trim()) - Convert.ToDouble(TxtDiscount.Text.Trim())).ToString();

            if (TxtPaidAmt.Text.Trim() == "")
            {
                TxtPaidAmt.Text = "0";
            }

            if (Convert.ToDouble(TxtPaidAmt.Text.Trim()) < Convert.ToDouble(TxtPayableAmt.Text.Trim()))
            {
                TxtDueAmt.Text = (Convert.ToDouble(TxtPayableAmt.Text.Trim()) - Convert.ToDouble(TxtPaidAmt.Text.Trim())).ToString();
                string A = TxtDueAmt.Text;
                TxtDue.Text = A;
            }
            else
            {
                TxtDueAmt.Text = "0";
            }

            if (Convert.ToDouble(TxtPaidAmt.Text.Trim()) > Convert.ToDouble(TxtPayableAmt.Text.Trim()))
            {
                TxtRefundAmt.Text = (Convert.ToDouble(TxtPaidAmt.Text.Trim()) - Convert.ToDouble(TxtPayableAmt.Text.Trim())).ToString();
                string B = TxtRefundAmt.Text;
                TxtRefund.Text = B;
            }
            else
            {
                TxtRefundAmt.Text = "0";
            }
        }

        protected void BtnClearAll_Click(object sender, ImageClickEventArgs e)
        {
            CboInvoiceNo.Text = "";
            txtSaleDate.Text = DateTime.Now.ToString("dd MMM yyyy"); ;
            CboCusName.Text = "";
            CboBarcode.Text = "";
            CboSLNo.Text = "";
            CboItemName.Text = "";
            CboItemType.Text = "";
            TxtQty.Text = "0";
            CboUnit.Text = "";
            TxtSalePrice.Text = "0";
            TxtTotal.Text = "0";
            //TxtRmk.Text = "";
            TxtCash.Text = "0";
            TxtDue.Text = "0";
            TxtRefund.Text = "0";
            TxtGrandTotal.Text = "0";
            TxtVat.Text = "0";
            TxtVatAmt.Text = "0";
            TxtDiscount.Text = "0";
            TxtDiscountAmt.Text = "0";
            TxtPayableAmt.Text = "0";
            TxtPaidAmt.Text = "0";
            TxtDueAmt.Text = "0";
            TxtRefundAmt.Text = "0";
            BtnAddNewSlNo.Enabled = false;
            BtnAddNew.Enabled = true;
            BtnShow.Enabled = true;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            Grd.Visible = false;
            LebMsg.Visible = false;
            BtnSLNoShow.Enabled = false;
            btnColorChange();

        }

        protected void btnSrch_Click(object sender, ImageClickEventArgs e)
        {
            pnlItem.Visible = true;
            PnlMstr.Visible = false;
            PnlPaid.Visible = false;
            pnlInvoice.Visible = false;
            pnlItemAdd.Visible = false;
            pnlItem.Height = 520;
        }
        protected void ShowItemDetFromAutoNo(string itmAtoNo)
        {
            cm.toGetData("select *,cast(saleprice as decimal(10,2)) as slprc from Item where Autono =  "+ itmAtoNo +"  and Comid = '" + ClsVar.GblComId + "'");
            if (cm.GblRdrToGetData.Read())
            {
                txtItemCode.Text = cm.GblRdrToGetData["itemCode"].ToString();

                txtItemDet.Text = "[" + cm.GblRdrToGetData["Brand"].ToString() + "] [" + cm.GblRdrToGetData["ItemName"].ToString() + "]\n[" + cm.GblRdrToGetData["ItemType"].ToString() + "] [" + cm.GblRdrToGetData["ItemSize"].ToString() + "]\n[" + cm.GblRdrToGetData["ItemColor"].ToString() + "]\n Sale Price: " + cm.GblRdrToGetData["slprc"].ToString();
            }
            else
            {
                txtItemCode.Text = "";
                txtItemDet.Text = "";
            }
        }
        protected void BtnSave_Click(object sender, ImageClickEventArgs e)
        {
            string SelectQry;
            string SaveQry;
            string EditQry;
            string Qry = "";

            DateTime dt1;
            DateTime dt2;

            Int32 cnt = 0;

            try
            {
                dt1 = DateTime.Today.AddDays(-3);

                dt2 = Convert.ToDateTime(txtSaleDate.Text.Trim());

                if (dt2 < dt1)
                {
                    LebMsg.Visible = true;
                    //LebMsg.Text = "Access Denied...!!";
                    //return;
                }
            }
            catch { }

            LebMsg.Visible = false;

            if (txtAutoNo.Text.Trim() == "0")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Try Again...!!";
                return;
            }


            if (CboInvoiceNo.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Invoice No...!!";
                return;
            }

            if (CboCusName.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Customer Name...!!";
                return;
            }

            if (CboSLNo.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The SL No...!!";
                return;
            }

            if (CboItemName.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Item Name...!!";
                return;
            }

            //Qry = "select ItemCode,AutoNo from Item where Itemname='" + CboItemName.Text.Trim() + "' and comid='" + ClsVar.GblComId + "'";
            //SvCls.toGetData(Qry);
            //if (SvCls.GblRdrToGetData.Read())
            //{
            //    ItemCodeNo = SvCls.GblRdrToGetData["itemcode"].ToString();
            //    ItemAutoNo = Convert.ToDouble(SvCls.GblRdrToGetData["autono"].ToString());

            //}
            if (txtAutoNo.Text == "")
            {
                txtAutoNo.Text = "1002";
            }

            ItemAutoNo = Convert.ToInt32(txtItemAutono.Text.Trim());
            ItemCodeNo = txtItemCode.Text.Trim();


            Qry = "select PartyCode,AutoNo from PartyInfo where AcctHead='" + CboCusName.Text.Trim() + "' and comid='" + ClsVar.GblComId + "'";
            SvCls.toGetData(Qry);
            if (SvCls.GblRdrToGetData.Read())
            {
                PartyCode = Convert.ToDouble(SvCls.GblRdrToGetData["PartyCode"]);
                PartyAutoNo = Convert.ToDouble(SvCls.GblRdrToGetData["AutoNo"]);
            }

            TxtTotal.Text = (Convert.ToDouble(TxtQty.Text.Trim()) * Convert.ToDouble(TxtSalePrice.Text.Trim())).ToString();

            SelectQry = "Select * from Sale where Slno ='" + CboSLNo.Text.Trim() + "' and comid ='" + ClsVar.GblComId + "' and InvoiceNo=" + CboInvoiceNo.Text.Trim() + "";
            //SaveQry = "insert into Sale(InvoiceNo,SaleDate,SlNo,Qty,UnitPrice,TotPrice,ItemAutoNo,ComId,autoNoFromSaleMstr,rmk)values('" + CboInvoiceNo.Text.Trim() + "',Convert(Datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',103),'" + CboSLNo.Text.Trim()  + "'," + TxtQty.Text.Trim() + "," + TxtSalePrice.Text.Trim() + "," + TxtTotal.Text.Trim() + "," + ItemAutoNo + ",'" + ClsVar.GblComId + "','','" + Session["LoginUserName"] + "','" + txtAutoNo.Text.Trim() + "','" + txtRmk.Text.Trim() + "')";
            SaveQry = "insert into Sale(InvoiceNo,SaleDate,SlNo,Qty,UnitPrice,TotPrice,ItemAutoNo,ComId,usercode,autoNoFromSaleMstr,rmk) values (" + CboInvoiceNo.Text.Trim () + ",Convert(Datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',103),'" + CboSLNo.Text.Trim() + "'," + TxtQty.Text.Trim() + "," + TxtSalePrice.Text.Trim() + "," + TxtTotal.Text.Trim() + "," + ItemAutoNo + ",'" + ClsVar.GblComId + "','" + Session["LoginUserName"] + "'," + txtAutoNo.Text.Trim() + ",'" + txtRmk.Text.Trim() + "')";
            EditQry = "Update Sale set  rmk='" + txtRmk.Text.Trim() + "',  Qty =" + TxtQty.Text.Trim() + ", UnitPrice =" + TxtSalePrice.Text.Trim() + ",TotPrice=" + TxtTotal.Text.Trim() + ",SaleDate=Convert(Datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',103),ItemAutoNo=" + ItemAutoNo + " where autonoFromSaleMstr =" + txtAutoNo.Text.Trim() + " and SLNo =" + CboSLNo.Text.Trim() + "";

            cm.toGetData(SelectQry);
            if (cm.GblRdrToGetData.Read())
            {
                SvCls.insertUpdate(EditQry);
                LebMsg.Visible = true;
                LebMsg.Text = "EDIT SUCCESSFULLY...!!";
                LebMsg.BackColor = System.Drawing.Color.Blue;
                LebMsg.ForeColor = System.Drawing.Color.White;
            }
            else
            {

                SvCls.insertUpdate(SaveQry);
                LebMsg.Visible = true;
                LebMsg.Text = "SAVED SUCCESSFULLY...!!";
                LebMsg.BackColor = System.Drawing.Color.Green;
                LebMsg.ForeColor = System.Drawing.Color.White;
            }

            string TotalQry = "Select isnull(SUM(TotPrice),0) as Tot from Sale where InvoiceNo=" + CboInvoiceNo.Text.Trim() + " and comid ='" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(TotalQry).Tables[0].Rows.Count > 0)
            {
                TxtGrandTotal.Text = SvCls.GblDataSet(TotalQry).Tables[0].Rows[0]["Tot"].ToString();
            }

            Qry = "update SaleMstr set  cname='" + txtCName.Text.Trim() + "',cmobile='" + txtCMob.Text.Trim() + "',cEmail='" + txtCEmail.Text.Trim() + "', saledate=convert(datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text.Trim()) + "',103), partyauto= " + PartyAutoNo + " where InvoiceNo=" + CboInvoiceNo.Text.Trim() + " and ComId= '" + ClsVar.GblComId + "'";
            SvCls.insertUpdate(Qry);


            VwInGrid();

            if (ClsVar.GblBarcode == false)
            {
                BtnAddNewSlNo.Enabled = true;
                BtnAddNewSlNo.Focus();
            }
            else
            {
                CboBarcode.Focus();
            }

            string C = TxtPaidAmt.Text;
            TxtCash.Text = C;
            CalCulation();

            BtnAddNewSlNo.Enabled = true;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = true;
            BtnSLNoShow.Enabled = true;
            BtnAccOk.Enabled = true;

            btnColorChange();

            //BtnAddNewSlNo_Click(null, null);

            CalCulation();

        }

        protected void BtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            string DeleteQry;
            string SelectQry;

            SelectQry = "Select * from Sale where InvoiceNo=" + CboInvoiceNo.Text.Trim() + " and SlNo ='" + CboSLNo.Text.Trim() + "'  and ComId ='" + ClsVar.GblComId + "'";
            DeleteQry = "delete from Sale where InvoiceNo=" + CboInvoiceNo.Text.Trim() + " and SlNo ='" + CboSLNo.Text.Trim() + "'  and ComId ='" + ClsVar.GblComId + "'";

            //if (MessageBox.Show("Do you realy want to delete ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            if (SvCls.DataExist(SelectQry).ToString() == "1")
            {
                SvCls.insertUpdate(DeleteQry);
                LebMsg.Visible = true;
                LebMsg.Text = "DELETE SUCCESSFULLY...!!";
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
            }



            VwInGrid();
            //BtnClearAll_Click(null, null);
        }

        protected void Grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VwInGrid();
            Grd.PageIndex = e.NewPageIndex;
            Grd.DataBind();
        }

        protected void Grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            LebMsg.Visible = false;

            if (CboInvoiceNo.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Invoice No...!!";
                return;

            }

            int index = Convert.ToInt32(e.CommandArgument);
            try
            {
                CboSLNo.Text = Grd.Rows[index].Cells[1].Text;
            }
            catch
            {
                CboSLNo.Items.Add(Grd.Rows[index].Cells[1].Text);
                CboSLNo.Text = Grd.Rows[index].Cells[1].Text;
            }
            BtnSLNoShow_Click(null, null);
            //}
        }
        private void AccountForCashCustomer()
        {
            string SelectQry = "";

            AutoRmk = "Cash Sale of Inv No:" + CboInvoiceNo.Text.Trim() + (ClsVar.GblComId);
            SvCls.insertUpdate("Delete from voucher where autormk='" + AutoRmk + "'");

            SelectQry = "select Headid from head where headname='Cash' and Comid= '" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                DrHeadID = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Headid"].ToString();
            }

            SelectQry = "select headid from head where headname='Sales' and Comid= '" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                CrHeadID = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Headid"].ToString();
            }

            SvCls.toGetData("select isnull(max(convert(int,voucherno)),0)+1 as CodeNo from voucher where isnumeric(voucherno)=1");
            if (SvCls.GblRdrToGetData.Read())
            {
                VNo = SvCls.GblRdrToGetData["CodeNo"].ToString();
                SvCls.GblCon.Close();
            }
            SvCls.insertUpdate("insert into Voucher (VoucherNo,VDate,HeadId,Dr,Cr,VType,Slno,D_c,ComId,NoteRmk,Amount,Rmk,AutoRmk,headid2) values ('" + VNo + "',convert(datetime,substring('" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',1,10),103)," + DrHeadID + "," + TxtPayableAmt.Text.Trim() + ",0,'Debit','1','Dr','" + ClsVar.GblComId + "','Cash Sold in Invoice No " + CboCusName.Text + "'," + TxtPayableAmt.Text.Trim() + ",'Cash Sold in Invoice No:" + CboInvoiceNo.Text + "','" + AutoRmk + "'," + CrHeadID + ")");
            SvCls.insertUpdate("insert into Voucher (VoucherNo,VDate,HeadId,Dr,Cr,VType,Slno,D_c,ComId,NoteRmk,Amount,Rmk,AutoRmk,headid2) values ('" + VNo + "',convert(datetime,substring('" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',1,10),103)," + CrHeadID + ",0," + TxtPayableAmt.Text.Trim() + ",'Credit','2','Cr','" + ClsVar.GblComId + "','Cash Sold in Invoice No " + CboCusName.Text + "'," + TxtPayableAmt.Text.Trim() + ",'Cash Sold in Invoice No:" + CboInvoiceNo.Text + "','" + AutoRmk + "'," + CrHeadID + ")");


        }
        private void AccountCr()
        {
            string SelectQry = "";

            AutoRmk = "" + CboItemName.Text + "Sales" + (ClsVar.GblComId);
            SvCls.insertUpdate("Delete from voucher where autormk='" + AutoRmk + "'");

            SelectQry = "select headid from head where headname='Cash' and Comid= '" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                DrHeadID = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Headid"].ToString();
            }

            SelectQry = "select headid from head where headname='" + CboCusName.Text.Trim() + "' and Comid= '" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                CrHeadID = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Headid"].ToString();
            }

            SvCls.toGetData("select max(convert(int,voucherno))+1 as CodeNo from voucher where isnumeric(voucherno)=1");
            if (SvCls.GblRdrToGetData.Read())
            {
                VNo = SvCls.GblRdrToGetData["CodeNo"].ToString();
                SvCls.GblCon.Close();
            }
            SvCls.insertUpdate("insert into Voucher (VoucherNo,VDate,HeadId,Dr,Cr,VType,Slno,D_c,ComId,NoteRmk,Amount,Rmk,AutoRmk,headid2) values ('" + VNo + "',convert(datetime,substring('" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',1,10),103)," + DrHeadID + "," + TxtPaidAmt.Text.Trim() + ",0,'Debit','1','Dr','" + ClsVar.GblComId + "','Sale'," + TxtPaidAmt.Text.Trim() + ",'Cash Payment By (" + CboCusName.Text + ")','" + AutoRmk + "'," + CrHeadID + ")");
            SvCls.insertUpdate("insert into Voucher (VoucherNo,VDate,HeadId,Dr,Cr,VType,Slno,D_c,ComId,NoteRmk,Amount,Rmk,AutoRmk,headid2) values ('" + VNo + "',convert(datetime,substring('" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',1,10),103)," + CrHeadID + ",0," + TxtPaidAmt.Text.Trim() + ",'Credit','2','Cr','" + ClsVar.GblComId + "','Sale'," + TxtPaidAmt.Text.Trim() + ",'Cash Payment By (" + CboCusName.Text + ")','" + AutoRmk + "'," + CrHeadID + ")");

        }
        private void Account()
        {
            string SelectQry = "";

            AutoRmk = "Sale To " + CboCusName.Text.Trim() + (ClsVar.GblComId);
            SvCls.insertUpdate("Delete from voucher where autormk='" + AutoRmk + "'");

            SelectQry = "select Headid from head where headname='" + CboCusName.Text.Trim() + "' and Comid= '" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                DrHeadID = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Headid"].ToString();
            }

            SelectQry = "select headid from head where headname='Sales' and Comid= '" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                CrHeadID = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Headid"].ToString();
            }

            SvCls.toGetData("select isnull(max(convert(int,voucherno)),0)+1 as CodeNo from voucher where isnumeric(voucherno)=1");
            if (SvCls.GblRdrToGetData.Read())
            {
                VNo = SvCls.GblRdrToGetData["CodeNo"].ToString();
                SvCls.GblCon.Close();
            }
            SvCls.insertUpdate("insert into Voucher (VoucherNo,VDate,HeadId,Dr,Cr,VType,Slno,D_c,ComId,NoteRmk,Amount,Rmk,AutoRmk,headid2) values ('" + VNo + "',convert(datetime,substring('" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',1,10),103)," + DrHeadID + "," + TxtPayableAmt.Text.Trim() + ",0,'Debit','1','Dr','" + ClsVar.GblComId + "','Sales To " + CboCusName.Text + "'," + TxtPayableAmt.Text.Trim() + ",'Sales To " + CboCusName.Text.Trim() + "','" + AutoRmk + "'," + CrHeadID + ")");
            SvCls.insertUpdate("insert into Voucher (VoucherNo,VDate,HeadId,Dr,Cr,VType,Slno,D_c,ComId,NoteRmk,Amount,Rmk,AutoRmk,headid2) values ('" + VNo + "',convert(datetime,substring('" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',1,10),103)," + CrHeadID + ",0," + TxtPayableAmt.Text.Trim() + ",'Credit','2','Cr','" + ClsVar.GblComId + "','Sales To" + CboCusName.Text + "'," + TxtPayableAmt.Text.Trim() + ",'Sales To " + CboCusName.Text.Trim() + "','" + AutoRmk + "'," + CrHeadID + ")");

        }
        protected void BtnSLNoShow_Click(object sender, ImageClickEventArgs e)
        {
            LebMsg.Visible = false;

            if (CboSLNo.Text == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Sl No...!!";
                return;
            }
            string SelectQry = "Select cast(Qty as decimal(10,0))as Qty,cast(UnitPrice as decimal(10,0)) as UnitPrice,cast(TotPrice as decimal(10,0))as TotPrice,ItemAutoNo,rmk from Sale where SlNo ='" + CboSLNo.Text.Trim() + "' and InvoiceNo=" + CboInvoiceNo.Text.Trim() + "";
            SvCls.toGetData(SelectQry);
            if (SvCls.GblRdrToGetData.Read())
            {
                TxtQty.Text = SvCls.GblRdrToGetData["Qty"].ToString();
                TxtSalePrice.Text = SvCls.GblRdrToGetData["UnitPrice"].ToString();
                TxtTotal.Text = SvCls.GblRdrToGetData["TotPrice"].ToString();
                txtRmk.Text = SvCls.GblRdrToGetData["Rmk"].ToString();
                ItemAutoNo = Convert.ToDouble(SvCls.GblRdrToGetData["ItemAutoNo"]);
                txtItemAutono.Text = SvCls.GblRdrToGetData["ItemAutoNo"].ToString();

            }
            else
            {
                TxtQty.Text = "0";
                TxtSalePrice.Text = "0";
                TxtTotal.Text = "0";
                txtRmk.Text = "";
                ItemAutoNo = 0;
            }


            //SelectQry = "select i.ItemName,i.ItemType,u.UnitName as Unit from Item i,itemunit u, where i.unitid=u.unitid and i.comid=u.comid and i.Autono =" + ItemAutoNo ;
            SelectQry = "select i.ItemName,i.ItemType,i.Unit,barcode from Item i where i.Autono =" + ItemAutoNo;
            SvCls.toGetData(SelectQry);
            if (SvCls.GblRdrToGetData.Read())
            {
                CboItemName.Text = SvCls.GblRdrToGetData["ItemName"].ToString();
                CboItemType.Text = SvCls.GblRdrToGetData["ItemType"].ToString();
                try
                {
                    CboUnit.Text = SvCls.GblRdrToGetData["Unit"].ToString();
                }
                catch
                {
                    CboUnit.Items.Add(SvCls.GblRdrToGetData["Unit"].ToString());
                    CboUnit.Text = SvCls.GblRdrToGetData["Unit"].ToString();
                }
                CboBarcode.Text = SvCls.GblRdrToGetData["barcode"].ToString();
            }
            else
            {
                CboItemName.Text = "";
                CboItemType.Text = "";
                CboUnit.Text = "";
                CboBarcode.Text = "";
            }


            ShowItemDetFromAutoNo(ItemAutoNo.ToString());
            BtnSave.Enabled = true;
            //BtnSave.Text = "Edit";
            BtnDelete.Enabled = true;
            BtnAddNew.Enabled = true;
            //btnColorChange();

        }

        protected void chkPad_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnInvoice_Click(object sender, ImageClickEventArgs e)
        {
            LebMsg.Visible = false;

            if (CboInvoiceNo.Text == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Invoice No...!!";
                return;

            }
            ClsVar.GblRptHead1 = "";
            ClsVar.GblSelFor = "";

            ReportDocument cryRpt = new ReportDocument();

            if (chkPad.Checked == true)
            {
                cryRpt.Load(Server.MapPath("~\\CRpt\\Invoice_PAD.rpt"));
            }
            else
            {
                cryRpt.Load(Server.MapPath("~\\CRpt\\Invoice.rpt"));
            }


            if (CboInvoiceNo.Text.Trim() != "")
            {
                ClsVar.GblSelFor = "{Sale.InvoiceNo}=" + CboInvoiceNo.Text.Trim() + "";
            }

            //cryRpt.DataDefinition.FormulaFields["heading"].Text = "'" + ClsVar.GblHeadName + "'";
            //cryRpt.DataDefinition.FormulaFields["CompanyName"].Text = "'" + ClsVar.GblComName + "'";
            //cryRpt.DataDefinition.FormulaFields["Address"].Text = "'" + ClsVar.GblAddress + "'";           

            if (ClsVar.GblSelFor != "")
            {
                cryRpt.RecordSelectionFormula = ClsVar.GblSelFor;
            }

            TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
            TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
            ConnectionInfo crConnectionInfo = new ConnectionInfo();
            Tables CrTables;

            crConnectionInfo.ServerName = ClsVar.gblServerName;
            crConnectionInfo.DatabaseName = ClsVar.gblDataBaseName;
            crConnectionInfo.UserID = ClsVar.gblUserID;
            crConnectionInfo.Password = ClsVar.gblPassword;

            CrTables = cryRpt.Database.Tables;
            foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
            {
                crtableLogoninfo = CrTable.LogOnInfo;
                crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                CrTable.ApplyLogOnInfo(crtableLogoninfo);
            }

            //cryRpt.ReportSource = cryRpt;
            cryRpt.Refresh();

            if (chkMSWrd.Checked == true)
            {
                cryRpt.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, false, "Invoice");
            }
            else
            {
                cryRpt.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, "Invoice");
            }
        }

        protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
        {
            pnlItem.Visible = false;
            PnlMstr.Visible = true;
            PnlPaid.Visible = true;
            pnlInvoice.Visible = true;
            pnlItemAdd.Visible = true;

        }
        protected void VwItemFind()
        {
            string Qry = "Select i.AutoNo,i.ItemCode,i.ItemName as [Name of Item],i.ItemType as [Item Type],cast(i.SalePrice as decimal(10,2)) as SalePrice,i.BarCode,i.Unit from item i where (i.itemname like '%" + txtItemDetForFind.Text.Trim() + "%' or i.itemtype like '%" + txtItemDetForFind.Text.Trim() + "%')  order by i.itemname,i.itemtype";
            grdItemForFind.DataSource = SvCls.GblDataTable(Qry);
            grdItemForFind.DataBind();
        }

        protected void iBtnFind_Click(object sender, ImageClickEventArgs e)
        {
            VwItemFind();
        }

        protected void grdItemForFind_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            try
            {
                txtItemAutono.Text = grdItemForFind.Rows[index].Cells[1].Text;
                txtItemCode.Text = grdItemForFind.Rows[index].Cells[2].Text;
                try
                {
                    CboItemName.Text = grdItemForFind.Rows[index].Cells[3].Text;
                }
                catch
                {
                    CboItemName.Items.Add(grdItemForFind.Rows[index].Cells[3].Text);
                    CboItemName.Text = grdItemForFind.Rows[index].Cells[3].Text;
                }
                lebItemDet.Text = grdItemForFind.Rows[index].Cells[3].Text + " - " + grdItemForFind.Rows[index].Cells[4].Text; ;
                pnlItem.Visible = false;
                PnlMstr.Visible = true;
                PnlPaid.Visible = true;
                pnlItemAdd.Visible = true;
                pnlInvoice.Visible = true;
                TxtQty.Focus();
            }
            catch
            {
                pnlItem.Visible = false;
                PnlMstr.Visible = true;
                PnlPaid.Visible = true;
                pnlItemAdd.Visible = true;
                pnlInvoice.Visible = true;

            }

            ShowItemDetFromAutoNo(txtItemAutono.Text.Trim());

        }

        protected void grdItemForFind_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            VwItemFind();
            grdItemForFind.PageIndex = e.NewPageIndex;
            grdItemForFind.DataBind();
        }

        protected void btnExecute_Click(object sender, ImageClickEventArgs e)
        {
            string SelectQry = "";

            if (CboBarcode.Text.Trim() == "")
            {
                return;
            }

            SelectQry = "select i.ItemName,i.ItemType,u.UnitName as Unit,cast(saleprice as decimal(10,2)) as SP from Item i,itemunit u where i.unitid=u.unitid and i.comid=u.comid and i.barcode ='" + CboBarcode.Text.Trim() + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                CboItemName.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["ItemName"].ToString();
                CboItemType.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["ItemType"].ToString();
                CboUnit.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["Unit"].ToString();
                TxtSalePrice.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["sp"].ToString();
            }
            else
            {
                TxtSalePrice.Text = "";
                CboItemName.Text = "";
                CboItemType.Text = "";
                CboUnit.Text = "";
                LebMsg.Visible = true;
                LebMsg.Text = "Invalid Barcode....!!";

            }
        }

        protected void BtnCard_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void grdItemForFind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grd_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void BtnAccOk_Click(object sender, ImageClickEventArgs e)
        {
            string crHeadId = "";

            LebMsg.Visible = false;
            if (Convert.ToDouble(TxtDueAmt.Text.Trim()) > 0 && CboCusName.Text == "Sale")
            {
                LebMsg.Visible = true;
                LebMsg.Text = "Please Select The Customer Name.\rBecause It Is A Due Sale.";
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                return;
            }


            CalCulation();

            if (CboCusName.Text.Trim().ToLower() == "cash sale" || CboCusName.Text.Trim().ToLower() == "cash sell" || CboCusName.Text.Trim().ToLower() == "cash customer")
            {
                SvCls.toGetData("select headid from head where comid='" + ClsVar.GblComId + "' and headname in ('cash sale','cash sell','cash customer')");
            }
            else
            {
                SvCls.toGetData("select headid from head where comid='" + ClsVar.GblComId + "' and headname in ('sales','sells')");
            }

            if (SvCls.GblRdrToGetData.Read())
            {
                CrHeadID = SvCls.GblRdrToGetData["headid"].ToString();
            }
            else
            {
                LebMsg.Text = "Please Create a Head Name [SALES]";
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                return;
            }

            string Qry = "select PartyCode,AutoNo from PartyInfo where AcctHead='" + CboCusName.Text.Trim() + "' and comid='" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(Qry).Tables[0].Rows.Count > 0)
            {
                PartyCode = Convert.ToDouble(SvCls.GblDataSet(Qry).Tables[0].Rows[0]["PartyCode"]);
                PartyAutoNo = Convert.ToDouble(SvCls.GblDataSet(Qry).Tables[0].Rows[0]["AutoNo"]);
            }

            Qry = "update SaleMstr set  cname='" + txtCName.Text.Trim() + "',cmobile='" + txtCMob.Text.Trim() + "',cEmail='" + txtCEmail.Text.Trim() + "', rmk='" + cboNote.Text.Trim() + "', autoRmk='Auto Voucher from Sales Auto No " + txtAutoNo.Text.Trim() + "',  header='" + cboHeader.Text.Trim() + "',footer='" + cboFooter.Text.Trim() + "', invSubmitDate=convert(datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text.Trim()) + "',103), menoNo='" + cboSignName.Text.Trim() + "', CRHEADID='" + CrHeadID + "', SaleDate=Convert(Datetime,'" + SvCls.toGetDateDDMMYYYY(txtSaleDate.Text) + "',103),discount=" + Convert.ToDouble(TxtDiscountAmt.Text.Trim()) + ",disper=" + Convert.ToDouble(TxtDiscount.Text.Trim()) + ",TotVat=" + Convert.ToDouble(TxtVatAmt.Text.Trim()) + ",Vat=" + Convert.ToDouble(TxtVat.Text.Trim()) + ",Payable=" + Convert.ToDouble(TxtPayableAmt.Text.Trim()) + ",Paid=" + Convert.ToDouble(TxtCash.Text.Trim()) + ",Due=" + Convert.ToDouble(TxtDueAmt.Text.Trim()) + ",Refund=" + Convert.ToDouble(TxtRefundAmt.Text.Trim()) + ",Total=" + Convert.ToDouble(TxtPayableAmt.Text.Trim()) + ",partyauto= " + PartyAutoNo + ",PAYMODE='CASH' where autoNo=" + Convert.ToInt32(txtAutoNo.Text.Trim());
            SvCls.insertUpdate(Qry);

            if (SvCls.GblCon != null && SvCls.GblCon.State != ConnectionState.Closed)
            {
                SvCls.GblCon.Close();
            }

            SvCls.GblCon.ConnectionString = SvCls.cnString;
            SvCls.GblSqlCmd.Connection = SvCls.GblCon;

            SvCls.GblCon.Open();
            SvCls.GblSqlCmd.CommandText = "SpAutoVrFromSales";
            SvCls.GblSqlCmd.CommandType = CommandType.StoredProcedure;

            SvCls.GblSqlCmd.Parameters.Add("@SalesAutoNo", SqlDbType.Int, 10);
            SvCls.GblSqlCmd.Parameters["@SalesAutoNo"].Value = Convert.ToInt32(txtAutoNo.Text.Trim());
            SvCls.GblSqlCmd.Parameters.Add("@comid", SqlDbType.VarChar, 10);
            SvCls.GblSqlCmd.Parameters["@comid"].Value = ClsVar.GblComId;
            SvCls.GblSqlCmd.Parameters.Add("@usercode", SqlDbType.VarChar, 50);
            SvCls.GblSqlCmd.Parameters["@usercode"].Value = Session["LoginUserName"];
            SvCls.GblSqlCmd.Parameters.Add("@CashAmt", SqlDbType.Money, 10);
            SvCls.GblSqlCmd.Parameters["@CashAmt"].Value = Convert.ToDouble(TxtCash.Text.Trim());
            SvCls.GblSqlCmd.ExecuteNonQuery();
            SvCls.GblSqlCmd.Parameters.Clear();
            SvCls.GblCon.Close();

            LebMsg.Visible = true;
            LebMsg.Text = "!!...Done...!!";
            LebMsg.BackColor = System.Drawing.Color.Green;
            LebMsg.ForeColor = System.Drawing.Color.White;
            BtnAccOk.Enabled = false;
            btnColorChange();
        }

        protected void BtnOk_Click(object sender, EventArgs e)
        {

        }
    }
}