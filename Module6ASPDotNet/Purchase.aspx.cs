using Module6ASPDotNet.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Module6ASPDotNet
{
    public partial class Purchase : System.Web.UI.Page
    {
        ClsMain SvCls = new ClsMain();
        ClsVar CvCls = new ClsVar();
        ClsMain cm = new ClsMain();

        double ItemAutoNo = 0;
        string ItemCodeNo = "";
        double PartyAutoNo = 0;
        double PartyCode = 0;
        string VNo = "";
        string DrHeadID = "";
        string CrHeadID = "";
        string AutoRmk = "";
        string FacExp = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            imageButtonSet();



            SvCls.cnString = Connection.GetConnectionString();
            SvCls.GblCon.ConnectionString = SvCls.cnString;

            cm.cnString = Connection.GetConnectionString();
            cm.GblCon.ConnectionString = cm.cnString;

            ClsVar.GblComId = "1";
            if (Session["LogInUserName"] == null)
            {
                Response.Redirect("LogIn.aspx");
            }           
            ClsVar.GblUserCode = Session["LoginUserName"].ToString();

            if (txtQty.Text.Trim() == "")
            {
                txtQty.Text = "0";
            }
            if (txtPurchasePrice.Text.Trim() == "")
            {
                txtPurchasePrice.Text = "0";
            }

            try
            {
                if (Convert.ToDouble(txtQty.Text.Trim()) > 0 && (Convert.ToDouble(txtPurchasePrice.Text.Trim()) == 0 || txtPurchasePrice.Text.Trim() == ""))
                {
                    txtPurchasePrice.Focus();
                }
                else
                {
                    txtSlNoRmk.Focus();
                }
            }
            catch (Exception rr)
            {
                LebMsg.Visible = true;
                LebMsg.Text = rr.Message;
            }
            if (IsPostBack != true)
            {

                string Qry;
                Qry = "select PurchaseCode from Purchase order by PurchaseCode";
                cboPurchaseCode.DataSource = SvCls.GblDataTable(Qry);
                cboPurchaseCode.DataTextField = "PurchaseCode";
                cboPurchaseCode.DataValueField = "PurchaseCode";
                cboPurchaseCode.DataBind();
                cboPurchaseCode.Items.Add("");
                cboPurchaseCode.Text = "";

                //Qry = "select distinct MemoNo from Purchase order by MemoNo";
                //cboManualMamoNo.DataSource = SvCls.GblDataTable(Qry);
                //cboManualMamoNo.DataTextField = "MemoNo";
                //cboManualMamoNo.DataValueField = "MemoNo";
                //cboManualMamoNo.DataBind();
                //cboManualMamoNo.Items.Add("");
                //cboManualMamoNo.Text = "";

                //Qry = "select headname MemoNo from head where comid='" + ClsVar.GblComId + "' and (type in ('cash in hand','cash') or type like 'Bank A%') order by MemoNo";
                //cboCrHead.DataSource = SvCls.GblDataTable(Qry);
                //cboCrHead.DataTextField = "MemoNo";
                //cboCrHead.DataValueField = "MemoNo";
                //cboCrHead.DataBind();
                //cboCrHead.Items.Add("");
                //cboCrHead.Text = "";

                Qry = "select PartyName from PartyInfo where partytype in ('supplier','both','vendor') order by PartyName";
                cboPartyName.DataSource = SvCls.GblDataTable(Qry);
                cboPartyName.DataTextField = "PartyName";
                cboPartyName.DataValueField = "PartyName";
                cboPartyName.DataBind();
                cboPartyName.Items.Add("");
                cboPartyName.Text = "";

                Qry = "select SlNo From Purchase order by SlNo";
                cboSlNo.DataSource = SvCls.GblDataTable(Qry);
                cboSlNo.DataTextField = "SlNo";
                cboSlNo.DataValueField = "SlNo";
                cboSlNo.DataBind();
                cboSlNo.Items.Add("");
                cboSlNo.Text = "";

                Qry = "select ItemName from Item order by ItemName";
                cboItemName.DataSource = SvCls.GblDataTable(Qry);
                cboItemName.DataTextField = "ItemName";
                cboItemName.DataValueField = "ItemName";
                cboItemName.DataBind();
                cboItemName.Items.Add("");
                cboItemName.Text = "";

                Qry = "Select distinct ItemType from Item order by ItemType ";
                cboItemType.DataSource = SvCls.GblDataTable(Qry);
                cboItemType.DataTextField = "ItemType";
                cboItemType.DataValueField = "ItemType";
                cboItemType.DataBind();
                cboItemType.Items.Add("");
                cboItemType.Text = "";

                //Qry = "Select unitid as Unit From itemUnit  where comid='" + ClsVar.GblComId + "' order by unit ";
                //cboUnit.DataSource = SvCls.GblDataTable(Qry);
                //cboUnit.DataTextField = "Unit";
                //cboUnit.DataValueField = "Unit";
                //cboUnit.DataBind();
                //cboUnit.Items.Add("");
                //cboUnit.Text = "";

                VwInGridAcc();
                //btnColorChange();

            }

        }

        private void VwInGridAcc()
        {
            string Qry = "select P.PurchaseCode as Pur_Code,convert(varchar,p.PurchaseDate,103) as Pur_Date,pt.PartyName,cast(p.TotalPrice as decimal(10,0)) as TotalPrice ,p.Post from Purchasemstr p,partyinfo pt  where pt.autono=p.partyautono order by P.purchasedate desc,p.PurchaseCode desc";
            GrdAcc.DataSource = SvCls.GblDataTable(Qry);
            GrdAcc.DataBind();
        }

        private void VwInGridAll()
        {
            string Qry = "Select p.SLNo,i.ItemName as [Name of Item],i.ItemType as [Item Type],cast(p.Qty as decimal(10,2)) as Qty ,i.UnitId as Unit,cast(P.UnitPrice as decimal(10,0)) as UnitPrice ,cast(p.TotalPrice as decimal(10,0)) as TotalPrice,p.BarCode,cast(p.SalePrice as decimal(10,0)) as SalePrice from Purchase p,item i where p.slno='" + cboSlNo.Text.Trim() + "' order by p.slno";
            Grd.DataSource = SvCls.GblDataTable(Qry);
            Grd.DataBind();
            //LebTotRow.Text = "Total : " + SvCls.GblDataTable(Qry).Rows.Count;
        }
        private void imageButtonSet()
        {
            iBtnFind.Attributes.Add("onmouseout", "this.src='Images/sear2.png'");
            iBtnFind.Attributes.Add("onmouseover", "this.src='Images/sear1.png'");
            //iBtnItmFind.Attributes.Add("onmouseout", "this.src='Images/sear2.png'");
            //iBtnItmFind.Attributes.Add("onmouseover", "this.src='Images/sear1.png'");
            iBtnClose.Attributes.Add("onmouseout", "this.src='Images/cls2.png'");
            iBtnClose.Attributes.Add("onmouseover", "this.src='Images/cls1.png'");

            BtnAddNew.Attributes.Add("onmouseout", "this.src='Images/plus1.png'");
            BtnAddNew.Attributes.Add("onmouseover", "this.src='Images/plus2old.png'");

            BtnShow.Attributes.Add("onmouseout", "this.src='Images/retrv1.png'");
            BtnShow.Attributes.Add("onmouseover", "this.src='Images/retrv2.png'");

            BtnAddNewSlNo.Attributes.Add("onmouseout", "this.src='Images/plus1.png'");
            BtnAddNewSlNo.Attributes.Add("onmouseover", "this.src='Images/plus2old.png'");

            BtnSLNoShow.Attributes.Add("onmouseout", "this.src='Images/retrv1.png'");
            BtnSLNoShow.Attributes.Add("onmouseover", "this.src='Images/retrv2.png'");

            //iBtnFind.Attributes.Add("onmouseout", "this.src='Images/fnd1.png'");
            //iBtnFind.Attributes.Add("onmouseover", "this.src='Images/fnd2.png'");

            iBtnItmFind.Attributes.Add("onmouseout", "this.src='Images/fnd1.png'");
            iBtnItmFind.Attributes.Add("onmouseover", "this.src='Images/fnd2.png'");
        }

        protected void iBtnFind_Click(object sender, ImageClickEventArgs e)
        {
            VwItemFind();
        }

        protected void iBtnClose_Click(object sender, ImageClickEventArgs e)
        {
            pnlItem.Visible = false;
            pnlMstr.Visible = true;
            pnlLeft.Visible = true;
            pnlPurFind.Visible = true;
            txtQty.Focus();
        }
        protected void VwItemFind()
        {
            string Qry = "Select i.AutoNo,i.ItemCode,i.ItemName as [Name of Item],i.ItemType as [Item Type],cast(i.SalePrice as decimal(10,2)) as SalePrice,i.BarCode,i.Unit from item i where (i.itemname like '%" + txtItemDetForFind.Text.Trim() + "%' or i.itemtype like '%" + txtItemDetForFind.Text.Trim() + "%')  order by i.itemname,i.itemtype";
            grdItemForFind.DataSource = SvCls.GblDataTable(Qry);
            grdItemForFind.DataBind();
        }
        protected void grdItemForFind_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            try
            {
                txtItemAutono.Text = grdItemForFind.Rows[index].Cells[1].Text;
                txtItemCode.Text = grdItemForFind.Rows[index].Cells[2].Text;
                lebItemDet.Text = grdItemForFind.Rows[index].Cells[3].Text + " - " + grdItemForFind.Rows[index].Cells[4].Text; ;


                string unt = "";

                if (grdItemForFind.Rows[index].Cells[7].Text.Trim() == "&nbsp;")
                {
                    unt = "";
                }
                else
                {
                    unt = grdItemForFind.Rows[index].Cells[7].Text.Trim();
                }

                try
                {
                    cboUnit.Text = unt;
                }
                catch
                {
                    cboUnit.Items.Add(unt);
                    cboUnit.Text = unt;
                    pnlItem.Visible = false;
                }

                pnlItem.Visible = false;
                pnlLeft.Visible = true;
                pnlRight.Visible = true;

                pnlMstr.Visible = true;
                pnlPurFind.Visible = false;

                ShowItemDetFromAutoNo(txtItemAutono.Text.Trim());

                txtQty.Focus();
            }
            catch
            { }
        }

        protected void grdItemForFind_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void BtnAddNew_Click(object sender, ImageClickEventArgs e)
        {
            Int32 PurchaseCode = 0;

            //SvCls.insertUpdate("delete from PURCHASEmstr where isnull(purchaseDate,convert(datetime,'01/01/1900',103))=convert(datetime,'01/01/1900',103) and totalprice=0 and pcname='" + Session["PcName"].ToString() + "' and usercode='" + Session["LoginUserName"].ToString() + "'");
           // SvCls.insertUpdate("delete from PURCHASEmstr where autono not in (select autonoFromMstrTbl from purchase)");

            SvCls.toGetData("SELECT isnull(max(convert(numeric,PurchaseCode)),0)+1 as cdNo from Purchase");
            if (SvCls.GblRdrToGetData.Read())
            {
                cboPurchaseCode.Items.Add(SvCls.GblRdrToGetData["cdNo"].ToString());
                cboPurchaseCode.Text = SvCls.GblRdrToGetData["cdNo"].ToString();
                PurchaseCode = Convert.ToInt32(SvCls.GblRdrToGetData["cdNo"]);
                SvCls.GblCon.Close();
            }

            //string SelectQry = "Select AUTONO from PARTYINFO WHERE PARTYNAME='cash PURCHASE'";
            //if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            //{
            //    SvCls.insertUpdate("INSERT INTO PURCHASEmstr (PurchaseCode,PARTYAUTONO,purchasedate) VALUES (" + Convert.ToInt32(PurchaseCode) + "," + SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["AUTONO"] + ",convert(datetime,'" + txtPurDate.Text + "',103),'" + Session["LoginUserName"].ToString() + "')");
            //}
            //else
            //{
            //    LebMsg.BackColor = System.Drawing.Color.Red;
            //    LebMsg.ForeColor = System.Drawing.Color.White;
            //    LebMsg.Visible = true;
            //    LebMsg.Text = "Please Enter The Party Cash Purchase...!!";
            //    return;
            //}


            SvCls.toGetData("select ItemAutoNo from purchase where usercode='" + Session["LoginUserName"].ToString() + "' and purchasecode=" + Convert.ToInt32(cboPurchaseCode.Text.Trim()));
            if (SvCls.GblRdrToGetData.Read())
            {
                txtAutoNo.Text = SvCls.GblRdrToGetData["ItemAutoNo"].ToString();
            }

            BtnAddNew.Enabled = false;
            BtnAddNewSlNo.Enabled = true;
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            BtnShow.Enabled = false;
            cboItemName.Text = "";
            cboItemType.Text = "";
            txtQty.Text = "0";
            cboUnit.Text = "";
            txtPurchasePrice.Text = "0";
            txtSalePrice.Text = "0";
            txtSlNoRmk.Text = "";
            txtCash.Text = "0";
            txtDue.Text = "0";
            txtGrandTotal.Text = "0";
            LebMsg.Visible = false;
            Grd.Visible = false;
            //btnColorChange();
            cboPartyName.Text = "";
            txtItemDet.Text = "";
            cboSlNo.Text = "";
            txtItemCode.Text = "";
            txtItemDet.Text = "";
            txtTotal.Text = "";
            txtPurDate.Focus();
        }

        protected void btnAllPurchase_Click(object sender, ImageClickEventArgs e)
        {
            pnlPurFind.Visible = true;
            pnlMstr.Visible = false;
            pnlItem.Visible = false;
            pnlRight.Visible = false;
            pnlLeft.Visible = false;
            pnlPurFind.Height = 500;
        }

        protected void BtnAddNewSlNo_Click(object sender, ImageClickEventArgs e)
        {
            txtItemAutono.Text = "0";
            txtItemCode.Text = "0";
            cboItemName.Text = "";
            cboItemType.Text = "";
            txtQty.Text = "0";
            cboUnit.Text = "";
            txtPurchasePrice.Text = "0";
            txtSalePrice.Text = "0";
            txtSlNoRmk.Text = "";
            txtCash.Text = "0";
            txtDue.Text = "0";
            txtGrandTotal.Text = "0";
            txtTotal.Text = "";
            txtShopInQty.Text = "0";
            txtStoreInQty.Text = "0";
            LebMsg.Visible = false;

            SvCls.toGetData("SELECT isnull(max(convert(numeric,slNo)),0)+1 as cdNo from Purchase where PurchaseCode=" + cboPurchaseCode.Text.Trim() + "");
            if (SvCls.GblRdrToGetData.Read())
            {
                cboSlNo.Items.Add(SvCls.GblRdrToGetData["cdNo"].ToString());
                cboSlNo.Text = SvCls.GblRdrToGetData["cdNo"].ToString();
                SvCls.GblCon.Close();
            }

            BtnAddNewSlNo.Enabled = false;
            BtnSave.Enabled = true;
            BtnDelete.Enabled = false;

            //btnColorChange();
        }

        protected void BtnSLNoShow_Click(object sender, ImageClickEventArgs e)
        {
            if (cboSlNo.Text == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Sl No...!!";
                return;
            }

            string ChkMnuBar = "";

            string SelectQry = "Select cast(Qty as Decimal (10,2)) as Qty,cast(UnitPrice as decimal(10,2)) as UnitPrice,cast(SalePrice as decimal(10,2)) as SalePrice,PSlNo,convert(varchar,ExprDate,103) as ExprDate ,manualBarcode,Barcode,ItemAutoNo,cast(storeQty as decimal(10,0)) as storeQt,cast(shopQty as decimal(10,0)) as ShopQt  from Purchase where SlNo ='" + cboSlNo.Text.Trim() + "'";
            SvCls.toGetData(SelectQry);

            if (SvCls.GblRdrToGetData.Read())
            {
                txtQty.Text = SvCls.GblRdrToGetData["Qty"].ToString();
                txtPurchasePrice.Text = SvCls.GblRdrToGetData["UnitPrice"].ToString();
                txtSalePrice.Text = SvCls.GblRdrToGetData["SalePrice"].ToString();
                txtSlNoRmk.Text = SvCls.GblRdrToGetData["PSlNo"].ToString();
                txtWarrntyDate.Text = SvCls.GblRdrToGetData["ExprDate"].ToString();
                ChkMnuBar = SvCls.GblRdrToGetData["manualBarcode"].ToString();
                txtMaualBarcode.Text = SvCls.GblRdrToGetData["Barcode"].ToString();
                ItemAutoNo = Convert.ToDouble(SvCls.GblRdrToGetData["ItemAutoNo"]);
                txtItemAutono.Text = SvCls.GblRdrToGetData["ItemAutoNo"].ToString();
                txtStoreInQty.Text = SvCls.GblRdrToGetData["storeQt"].ToString();
                txtShopInQty.Text = SvCls.GblRdrToGetData["shopQt"].ToString();

                //BtnSave.Text = "Edit";
                BtnSave.Enabled = true;
                BtnDelete.Enabled = true;
                BtnAddNew.Enabled = true;
                cboPurchaseCode.Enabled = false;
                BtnShow.Enabled = false;
            }
            else
            {

                txtStoreInQty.Text = "";
                txtShopInQty.Text = "";

                txtQty.Text = "0";
                txtPurchasePrice.Text = "0";
                txtSalePrice.Text = "0";
                txtSlNoRmk.Text = "";
                txtMaualBarcode.Text = "";
                txtWarrntyDate.Text = "";
                ItemAutoNo = 0;
            }

            if (ChkMnuBar == "1")
            {
                chkMaualBarcode.Checked = true;
            }
            else
            {
                chkMaualBarcode.Checked = false;
            }

            if (txtWarrntyDate.Text.Trim() == "01/01/1900")
            {
                txtWarrntyDate.Text = "";
            }

            ShowItemDetFromAutoNo(txtItemAutono.Text.Trim());
            calculation();
        }

        private void calculation()
        {
            if (txtQty.Text.Trim() == "")
            {
                txtQty.Text = "0";
            }
            if (txtPurchasePrice.Text.Trim() == "")
            {
                txtPurchasePrice.Text = "0";
            }
            if (txtTotal.Text.Trim() == "")
            {
                txtTotal.Text = "0";
            }

            txtTotal.Text = (Convert.ToDouble(txtQty.Text.Trim()) * Convert.ToDouble(txtPurchasePrice.Text.Trim())).ToString();
        }

        private void ShowItemDetFromAutoNo(string itmAtoNo)
        {
            cm.toGetData("select *,cast(saleprice as decimal(10,2)) as slprc from Item where Autono = " + itmAtoNo + "");
            if (cm.GblRdrToGetData.Read())
            {
                txtItemCode.Text = cm.GblRdrToGetData["itemCode"].ToString();
                cboItemName.Text = cm.GblRdrToGetData["ItemName"].ToString();
                cboItemType.Text = cm.GblRdrToGetData["ItemType"].ToString();
                try
                {
                    cboUnit.Text = cm.GblRdrToGetData["Unit"].ToString();
                }
                catch
                {
                    cboUnit.Items.Add(cm.GblRdrToGetData["Unit"].ToString());
                    cboUnit.Text = cm.GblRdrToGetData["Unit"].ToString();
                }

                txtMaualBarcode.Text = cm.GblRdrToGetData["barcode"].ToString();

                txtItemDet.Text = "[" + cm.GblRdrToGetData["Brand"].ToString() + "] [" + cm.GblRdrToGetData["ItemName"].ToString() + "]\n[" + cm.GblRdrToGetData["ItemType"].ToString() + "] [" + cm.GblRdrToGetData["ItemSize"].ToString() + "]\n[" + cm.GblRdrToGetData["ItemColor"].ToString() + "]\n Sale Price: " + cm.GblRdrToGetData["slprc"].ToString();
            }
            else
            {
                txtItemCode.Text = "";
                txtItemDet.Text = "";
            }
        }

        protected void BtnItemShow_Click(object sender, ImageClickEventArgs e)
        {
            if (cboItemName.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Item Name...!!";
                return;
            }

            string SelectQry = "select ItemType,UnitId as Unit from item  where itemname='" + cboItemName.Text.Trim() + "' and comid='" + ClsVar.GblComId + "'";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                cboItemType.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["ItemType"].ToString();
                cboUnit.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["unit"].ToString();
            }
            else
            {
                cboItemType.Text = "";
                cboUnit.Text = "";
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string SelectQry;
            string SaveQry;
            string EditQry;
            string Qry = "";
            string Barcode = "";

            if (cboPurchaseCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Purchase Code...!!";
                return;
            }

            if (cboPartyName.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Party Name...!!";
                return;
            }

            if (cboSlNo.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Sl No...!!";
                return;
            }

            if (txtItemCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter or Search The Valid Item Code...!!";
                txtItemCode.Focus();
                return;
            }

            if (txtItemAutono.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter or Search The Valid Item Code...!!";
                iBtnFind.Focus();
                return;
            }

            DateTime dt1;
            DateTime dt2;

            Int32 cnt = 0;

            try
            {
                dt1 = DateTime.Today.AddDays(-3);

                dt2 = Convert.ToDateTime(txtPurDate.Text.Trim());

                //if (dt2 < dt1)
                //{
                //    LebMsg.Visible = true;
                //    LebMsg.Text = "Access Denied...!!";
                //    return;
                //}
            }
            catch { }           

            Qry = "select PartyCode,AutoNo from PartyInfo where PartyName='" + cboPartyName.Text.Trim() + "' and partytype in ('vendor','supplier','both')";
            if (SvCls.GblDataSet(Qry).Tables[0].Rows.Count > 0)
            {
                PartyCode = Convert.ToDouble(SvCls.GblDataSet(Qry).Tables[0].Rows[0]["PartyCode"]);
                PartyAutoNo = Convert.ToDouble(SvCls.GblDataSet(Qry).Tables[0].Rows[0]["AutoNo"]);
            }

            if (chkMaualBarcode.Checked == true)
            {
                Barcode = cboPurchaseCode.Text.Trim() + cboSlNo.Text.Trim();
            }
            else
            {
                Barcode = "";
            }

            if (txtWarrntyDate.Text.Trim() == "")
            {
                txtWarrntyDate.Text = "01/01/1900";
            }
            if (txtPurchasePrice.Text.Trim() == "")
            {
                txtPurchasePrice.Text = "0";
            }
            if (txtSalePrice.Text.Trim() == "")
            {
                txtSalePrice.Text = "0";
            }

            if (txtShopInQty.Text.Trim() == "")
            {
                txtShopInQty.Text = "0";
            }
            if (txtStoreInQty.Text.Trim() == "")
            {
                txtStoreInQty.Text = "0";
            }

            txtGrandTotal.Text = (Convert.ToDouble(txtQty.Text.Trim()) * Convert.ToDouble(txtPurchasePrice.Text.Trim())).ToString();

            SelectQry = "Select * from Purchase where Slno ="+ cboSlNo.Text.Trim() + " and ItemCode ='" + txtItemCode.Text.Trim() + "'";
            SaveQry = "insert into Purchase(itemautono,autonoFromMstrTbl,PurchaseCode,PurchaseDate,PartyCode,SlNo,ItemCode,Qty,UnitPrice,SalePrice,PSlNo,ExprDate,TotalPrice,Barcode,ManualBarcode,ComId,usercode,pcname,storeqty,shopQty) values('"+ txtItemAutono.Text.Trim() +"','" + txtAutoNo.Text.Trim() + "','" + cboPurchaseCode.Text.Trim() + "',Convert(Datetime,'" + txtPurDate.Text + "',103),'" + PartyCode + "','" + cboSlNo.Text.Trim() + "','" + txtItemCode.Text.Trim() + "','" + txtQty.Text.Trim() + "','" + txtPurchasePrice.Text.Trim() + "','" + txtSalePrice.Text.Trim() + "','" + txtSlNoRmk.Text.Trim() + "',Convert(Datetime,'" + txtWarrntyDate.Text + "',103),'" + txtGrandTotal.Text.Trim() + "','" + Barcode + "','" + Convert.ToInt32(chkMaualBarcode.Checked) + "','" + ClsVar.GblComId + "','" + Session["LoginUserName"].ToString() + "','" + ClsVar.GblPcName + "','" + txtStoreInQty.Text.Trim() + "','" + txtShopInQty.Text.Trim() +"')";
            EditQry = "Update Purchase set storeqty=" + txtStoreInQty.Text.Trim() + ",shopQty=" + txtShopInQty.Text.Trim() + ", Qty =" + Convert.ToDouble(txtQty.Text.Trim()) + ", UnitPrice =" + Convert.ToDouble(txtPurchasePrice.Text.Trim()) + ", SalePrice =" + Convert.ToDouble(txtSalePrice.Text.Trim()) + ", PSlNo ='" + txtSlNoRmk.Text.Trim() + "',PartyCode =" + PartyCode + ",ItemCode ='" + ItemCodeNo + "', TotalPrice=" + Convert.ToDouble(txtGrandTotal.Text.Trim()) + ",PurchaseDate=Convert(Datetime,'" + txtPurDate.Text + "',103),ExprDate=Convert(Datetime,'" + txtWarrntyDate.Text + "',103),Barcode='" + Barcode + "',ManualBarcode=" + Convert.ToInt32(chkMaualBarcode.Checked) + ",ItemAutoNo=" + ItemAutoNo + ",pcname='" + ClsVar.GblPcName + "',usercode='" + ClsVar.GblUserCode + "' where SLNo ='" + cboSlNo.Text.Trim() + "' and ItemCode ='" + txtItemCode.Text.Trim() + "' and autonoFromMstrTbl=" + ItemAutoNo +"";

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

            string TotalQry = "Select cast(isnull(SUM(TOTALPRICE),0) as decimal (10,0)) as Tot from Purchase where PurchaseCode='" + cboPurchaseCode.Text.Trim() + "'";
            if (SvCls.GblDataSet(TotalQry).Tables[0].Rows.Count > 0)
            {
                txtGrandTotal.Text = SvCls.GblDataSet(TotalQry).Tables[0].Rows[0]["Tot"].ToString();
            }

            Qry = "update purchasemstr set MEMONO='" + cboManualMamoNo.Text.Trim() + "',totalprice=" + Convert.ToDouble(txtGrandTotal.Text.Trim()) + ",partyautono= " + PartyAutoNo + ",purchasedate=Convert(Datetime,'" + txtPurDate.Text + "',103) where purchasecode=" + cboPurchaseCode.Text.Trim() + "";
            SvCls.insertUpdate(Qry);

            SvCls.insertUpdate("update purchase set barcode=autobarcode where manualBarcode=0");
            if (txtSalePrice.Text.Trim() != "" && txtSalePrice.Text.Trim() != "0" && txtSalePrice.Text.Trim() != "0.00")
            {
                SvCls.insertUpdate("update item set saleprice=" + txtSalePrice.Text.Trim() + " where autono=" + ItemAutoNo);
            }

            VwInGridAll();
            PostTo();


            BtnSave.Enabled = false;
            BtnDelete.Enabled = true;
            BtnAddNewSlNo.Enabled = true;
            BtnAddNew.Enabled = true;           
        }

        private void PostTo()
        {
            GrdAcc.DataSource = SvCls.GblDataTable("select P.PurchaseCode as Pur_Code,convert(varchar,p.PurchaseDate,103) as Pur_Date,pt.PartyName,cast(p.TotalPrice as decimal (10,2)) as TotPrice,p.Post from Purchasemstr p,partyinfo pt  where pt.autono=p.partyautono order by P.purchasedate desc,p.PurchaseCode desc");
            GrdAcc.DataBind();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            string DeleteQry;
            string SelectQry;

            SelectQry = "Select * from Purchase where SlNo ='" + cboSlNo.Text.Trim() + "'";
            DeleteQry = "delete from Purchase where SlNo ='" + cboSlNo.Text.Trim() + "'";

            //if (MessageBox.Show("Do you realy want to delete ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)

            if (SvCls.DataExist(SelectQry).ToString() == "1")
            {
                SvCls.insertUpdate(DeleteQry);
                LebMsg.Visible = true;
                LebMsg.Text = "DELETE SUCCESSFULLY...!!";
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
            }

            string TotalQry = "Select isnull(SUM(TOTALPRICE),0) as Tot from Purchase where autonofromMstrTbl=" + Convert.ToInt32(txtAutoNo.Text.Trim());
            if (SvCls.GblDataSet(TotalQry).Tables[0].Rows.Count > 0)
            {
                txtGrandTotal.Text = SvCls.GblDataSet(TotalQry).Tables[0].Rows[0]["Tot"].ToString();
            }


            SvCls.insertUpdate(" update purchasemstr set MEMONO='" + cboManualMamoNo.Text + "', totalprice=" + Convert.ToDouble(txtGrandTotal.Text.Trim()) + ", partyautono=" + PartyAutoNo + ", purchasedate=convert(datetime,'" + txtPurDate.Text + "',103) where autono=" + Convert.ToInt32(txtAutoNo.Text.Trim()));

            BtnClearAll_Click(null, null);
            VwInGridAll();
        }

        protected void BtnClearAll_Click(object sender, ImageClickEventArgs e)
        {
            cboPurchaseCode.Text = "";
            txtPurDate.Text = "";
            cboPartyName.Text = "";
            cboSlNo.Text = "";
            cboItemName.Text = "";
            cboItemType.Text = "";
            txtQty.Text = "0";
            cboUnit.Text = "";
            txtPurchasePrice.Text = "0";
            txtSalePrice.Text = "0";
            txtSlNoRmk.Text = "";
            txtWarrntyDate.Text = "";
            txtCash.Text = "0";
            txtDue.Text = "0";
            txtGrandTotal.Text = "0";
            txtMaualBarcode.Text = "";
            chkMaualBarcode.Checked = false;
            ChkFacExp.Checked = false;
            LebMsg.Visible = true;
            Grd.Visible = false;
            //GrdAcc.Visible = false;
            //BtnSave.Text = "Save";
            BtnSave.Enabled = false;
            BtnDelete.Enabled = false;
            BtnShow.Enabled = true;
            BtnSLNoShow.Enabled = false;
            BtnAddNewSlNo.Enabled = false;
        }

        protected void Grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (cboPurchaseCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Purchase Code...!!";
                return;

            }

            BtnShow_Click(null, null);

            int index = Convert.ToInt32(e.CommandArgument);
            cboSlNo.Text = Grd.Rows[index].Cells[1].Text;
            BtnSLNoShow_Click(null, null);

        }

        protected void BtnPostToAcc_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void BtnShow_Click(object sender, ImageClickEventArgs e)
        {
            LebMsg.Visible = false;

            if (cboPurchaseCode.Text == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Purchase Code...!!";
                return;
            }

            string SelectQry = "select convert(varchar,PurchaseDate,106) as PurchaseDate,PartyAutoNo,memono,cast(cash as decimal(10,0))as cash,cast(Due as decimal(10,0))as Due,cast(totalprice as decimal(10,0)) as totalprice,AutoNo from Purchasemstr where PurchaseCode =" + Convert.ToInt32(cboPurchaseCode.Text.Trim()) + "";
            SvCls.toGetData(SelectQry);
            if (SvCls.GblRdrToGetData.Read())
            {
                txtPurDate.Text = SvCls.GblRdrToGetData["purchasedate"].ToString();
                PartyAutoNo = Convert.ToDouble(SvCls.GblRdrToGetData["PartyAutoNo"]);
                try
                {
                    cboManualMamoNo.Text = SvCls.GblRdrToGetData["memono"].ToString();
                }
                catch
                {
                    cboManualMamoNo.Items.Add(SvCls.GblRdrToGetData["memono"].ToString());
                    cboManualMamoNo.Text = SvCls.GblRdrToGetData["memono"].ToString();
                }

                txtCash.Text = SvCls.GblRdrToGetData["cash"].ToString();
                txtDue.Text = SvCls.GblRdrToGetData["Due"].ToString();
                txtGrandTotal.Text = SvCls.GblRdrToGetData["totalprice"].ToString();
                //FacExp = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["factoryExp"].ToString();
                txtAutoNo.Text = SvCls.GblRdrToGetData["AutoNo"].ToString();


                BtnAddNewSlNo.Enabled = true;


            }
            else
            {

                txtAutoNo.Text = "";
                txtPurDate.Text = "";
                txtCash.Text = "0";
                txtDue.Text = "0";
                txtGrandTotal.Text = "0";
                cboManualMamoNo.Text = "";
                PartyAutoNo = 0;
            }

            //cboManualMamoNo.Text = "";
            cboSlNo.Text = "";
            cboItemName.Text = "";
            cboItemType.Text = "";
            txtQty.Text = "0";
            cboUnit.Text = "";
            txtPurchasePrice.Text = "0";
            txtSalePrice.Text = "0";
            txtSlNoRmk.Text = "";
            txtMaualBarcode.Text = "";
            txtWarrntyDate.Text = "";
            BtnSLNoShow.Enabled = true;

            if (FacExp == "1")
            { ChkFacExp.Checked = true; }
            else
            { ChkFacExp.Checked = false; }

            SelectQry = "select partyname,acctHead from PartyInfo where Autono =" + PartyAutoNo + "";
            if (SvCls.GblDataSet(SelectQry).Tables[0].Rows.Count > 0)
            {
                cboPartyName.Text = SvCls.GblDataSet(SelectQry).Tables[0].Rows[0]["partyname"].ToString();
            }
            else
            {
                cboPartyName.Text = "";
            }

            VwInGridAll();
            //btnColorChange();
        }

        protected void btnPostToAcc_Click1(object sender, EventArgs e)
        {
            string SelectQry = "";
            string Qry = "";

            if (cboPurchaseCode.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Purchase Code...!!";
                return;
            }


            if (cboPartyName.Text.Trim() == "")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Enter The Supplier Name...!!";
                return;
            }


            if (cboCrHead.Text.Trim() == "" && Convert.ToDouble(txtCash.Text.Trim()) > 0)
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Please Select the Payment Source...!!";
                cboCrHead.Focus();
                return;
            }

            DateTime dt1;
            DateTime dt2;

            Int32 cnt = 0;

            try
            {
                dt1 = DateTime.Today.AddDays(-3);

                dt2 = Convert.ToDateTime(txtPurDate.Text.Trim());

                //if (dt2 < dt1)
                //{
                //    LebMsg.Visible = true;
                //    LebMsg.Text = "Access Denied...!!";
                //    return;
                //}
            }
            catch { }

            double dueRefund = 0;
            double due = 0;
            double Refund = 0;
            double realCashAmt = 0;

            dueRefund = Convert.ToDouble(txtGrandTotal.Text.Trim()) - Convert.ToDouble(txtCash.Text.Trim());
            due = Convert.ToDouble(txtGrandTotal.Text.Trim()) - Convert.ToDouble(txtCash.Text.Trim());
            Refund = Convert.ToDouble(txtCash.Text.Trim()) - Convert.ToDouble(txtGrandTotal.Text.Trim());


            if (Convert.ToDouble(txtCash.Text.Trim()) > 0)
            {
                if (Convert.ToDouble(txtCash.Text.Trim()) > Convert.ToDouble(txtGrandTotal.Text.Trim()))
                {
                    realCashAmt = Convert.ToDouble(txtGrandTotal.Text.Trim());

                }
                else
                {
                    realCashAmt = Convert.ToDouble(txtCash.Text.Trim());
                }

            }


            txtCashForVr.Text = realCashAmt.ToString();

            if (dueRefund > 0)
            {
                lebDue.Text = "Due";
                txtDue.Text = due.ToString();
            }
            else
            {
                lebDue.Text = "Refund";
                txtDue.Text = Refund.ToString();
            }

            if (lebDue.Text == "Due" && cboPartyName.Text.Trim().ToLower() == "cash purchase")
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Full Payment Required, Because Its a Cash Purchase...!!";

                return;
            }

            //if (Convert.ToInt32(txtCash.Text.Trim()) > 0 && Convert.ToString(cboPartyName.Text.Trim()) == "Purchase")
            //{
            //    MessageBox.Show("You Have To Post Full Payment.\rBecause It Is A Cash Purchase.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            Qry = "select PartyCode,AutoNo from PartyInfo where PartyName='" + cboPartyName.Text.Trim() + "' and partytype in ('vendor','supplier','both')";
            if (SvCls.GblDataSet(Qry).Tables[0].Rows.Count > 0)
            {
                PartyCode = Convert.ToDouble(SvCls.GblDataSet(Qry).Tables[0].Rows[0]["PartyCode"]);
                PartyAutoNo = Convert.ToDouble(SvCls.GblDataSet(Qry).Tables[0].Rows[0]["AutoNo"]);
            }
            else
            {
                LebMsg.BackColor = System.Drawing.Color.Red;
                LebMsg.ForeColor = System.Drawing.Color.White;
                LebMsg.Visible = true;
                LebMsg.Text = "Invalid Supplier...!!";

                return;

            }


            Qry = "update purchasemstr set partyAutoNo=" + PartyAutoNo + ", crHead='" + cboCrHead.Text.Trim() + "', Post='POSTED',Cash=" + Convert.ToDouble(txtCash.Text.Trim()) + ",Due=" + Convert.ToDouble(txtDue.Text.Trim()) + ",totalprice=" + Convert.ToDouble(txtGrandTotal.Text.Trim()) + " where PurchaseCode='" + cboPurchaseCode.Text.Trim() + "'";
            SvCls.insertUpdate(Qry);

            //AccountDr();



            //if (Convert.ToDouble (txtCash.Text.Trim()) > 0)
            //{
            //    AccountCr();
            //}



            PostTo();




            LebMsg.BackColor = System.Drawing.Color.Red;
            LebMsg.ForeColor = System.Drawing.Color.White;
            LebMsg.Visible = true;
            LebMsg.Text = "C..O...M...P..L..E..T..E..D";
        }

        protected void GrdAcc_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            cboPurchaseCode.Text = GrdAcc.Rows[index].Cells[1].Text;
            BtnShow_Click(null, null);
            Grd.Visible = true;
            //btnColorChange();
            //BtnSLNoShow_Click(null, null);
            pnlMstr.Visible = true;
            pnlLeft.Visible = true;
            pnlRight.Visible = true;
            pnlPurFind.Visible = false;
        }

        protected void iBtnItmFind_Click(object sender, ImageClickEventArgs e)
        {
            txtPurchasePrice.Text = "";
            txtQty.Text = "";
            txtTotal.Text = "";
            txtSlNoRmk.Text = "";

            pnlMstr.Visible = false;
            pnlPurFind.Visible = false;
            pnlItem.Height = 450;
            grdItemForFind.PageSize = 20;
            pnlLeft.Visible = false;
            pnlRight.Visible = false;
            pnlItem.Visible = true;
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            double qty = 0;
            double unitPrice = 0;

            try
            {
                qty = Convert.ToDouble(txtQty.Text.Trim());
                unitPrice = Convert.ToDouble(txtPurchasePrice.Text.Trim());
            }

            catch { }
            txtTotal.Text = (qty * unitPrice).ToString();
        }

        protected void txtPurchasePrice_TextChanged(object sender, EventArgs e)
        {
            double qty = 0;
            double unitPrice = 0;

            try
            {
                qty = Convert.ToDouble(txtQty.Text.Trim());
                unitPrice = Convert.ToDouble(txtPurchasePrice.Text.Trim());
            }

            catch { }
            txtTotal.Text = (qty * unitPrice).ToString();
        }

        protected void GrdAcc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
