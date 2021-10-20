<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sale.aspx.cs" Inherits="Module6ASPDotNet.Sale" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleOne.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            var gridHeader = $('#<%=Grd.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=Grd.ClientID%> tr th').each(function (i) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHead").append(gridHeader);
                    $('#GHead').css('position', 'absolute');
                    $('#GHead').css('top', $('#<%=Grd.ClientID%>').offset().top);
                });
    </script>


    <script type="text/javascript" language="javascript">
        $(document).ready(function () {
            var gridHeader3 = $('#<%=grdItemForFind.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader3).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=grdItemForFind.ClientID%> tr th').each(function (k) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (k + 1) + ")", gridHeader3).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHeadItemFnd").append(gridHeader3);
                    $('#GHeadItemFnd').css('position', 'absolute');
                    $('#GHeadItemFnd').css('top', $('#<%=grdItemForFind.ClientID%>').offset().top);


                });
    </script>


    <style type="text/css">
        .style2 {
            height: 26px;
        }

        .style3 {
        }

        .style5 {
            width: 241px;
        }

        .style7 {
        }

        .auto-style1 {
            height: 17px;
        }

        .auto-style2 {
            width: 122px;
        }

        .auto-style4 {
            width: 7px;
        }

        .auto-style5 {
            width: 88px;
        }
        .auto-style6 {
            width: 241px;
            height: 74px;
        }
        .auto-style7 {
            width: 80px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clsContent">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label52" runat="server"
                        Text="Sales" CssClass="clsFormHeading" Width="1000px"></asp:Label>

                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="Green" class="clsPageHeaderColor"></td>
            </tr>
            <tr>
                <td align="center" bgcolor="Green" class="clsPageHeaderColor">
                    <asp:Panel ID="pnl1" runat="server" BackColor="#FFCCFF" Width="200px" Visible="False">
                        <div style="background-color: aqua">
                            <asp:TextBox ID="CboBarcode" runat="server" BorderStyle="Solid" Font-Bold="False" Font-Names="IDAutomationHC39M" Font-Size="Smaller" Height="40px" onblur="this.style.backgroundColor='white'" onfocus="this.style.backgroundColor='#CCFFCC'" TabIndex="7" Width="160px"></asp:TextBox>
                            <asp:ImageButton ID="btnExecute" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/btnExe2.png" OnClick="btnExecute_Click" />
                            <asp:ImageButton ID="BtnCard" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/btnCarPay2.png" OnClick="BtnCard_Click" Visible="False" Width="120px" />
                        </div>

                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td align="center" class="style3">

                    <asp:Panel ID="pnlItem" runat="server" Height="200px" Width="1000px" Visible="False" BorderColor="#CCCCCC" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:Label ID="Label66" runat="server" Text="Enter the Search Keyword like Item Name, Brand, Size etc." CssClass="clsFldHeading" Width="320px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtItemDetForFind" runat="server" CssClass="clsTextBox" Width="200px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="iBtnFind" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/sear2.png" OnClick="iBtnFind_Click" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="iBtnClose" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/cls2.png" OnClick="iBtnClose_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">

                                    <asp:GridView ID="grdItemForFind" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AlternatingRowStyle-CssClass="altRows"
                                        Width="990px" OnRowCommand="grdItemForFind_RowCommand"
                                        OnSelectedIndexChanged="grdItemForFind_SelectedIndexChanged" OnPageIndexChanging="grdItemForFind_PageIndexChanging">
                                        <Columns>
                                            <asp:CommandField ShowSelectButton="True" />
                                        </Columns>

                                    </asp:GridView>

                                </td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td align="center" class="style3">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" class="style3">

                    <asp:Panel ID="PnlMstr" runat="server" Height="70px" Width="1000px"
                        CssClass="pnlBackColorLeft" BorderColor="#CCCCCC" BorderStyle="Solid">
                        <table class="style1">
                            <tr>
                                <td align="left" colspan="2">
                                    <asp:Label ID="Label84" runat="server" CssClass="clsFldHeading" Text="Invoice No" Width="80px"></asp:Label>
                                </td>
                                <td align="left" colspan="2">&nbsp;</td>
                                <td align="left">
                                    <asp:Label ID="Label85" runat="server" CssClass="clsFldHeading" Text="Sale Date" Width="80px"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblCustomer" runat="server" CssClass="clsFldHeading" Text="Customer" Width="90px"></asp:Label>
                                </td>
                                <td align="left" class="auto-style4">
                                    <asp:Label ID="Label89" runat="server" CssClass="clsFldHeading" Text="Name" Width="130px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label90" runat="server" CssClass="clsFldHeading" Text="Mobile No" Width="100px"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:Label ID="Label91" runat="server" CssClass="clsFldHeading" Text="EMail" Width="100px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:ComboBox ID="CboInvoiceNo" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="1" Width="80px" RenderMode="Block">
                                    </asp:ComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:ImageButton ID="BtnAddNew" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/plus1.png" OnClick="BtnAddNew_Click" Width="30px" />
                                </td>
                                <td align="left">
                                    <asp:ImageButton ID="BtnShow" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/retrv1.png" OnClick="BtnShow_Click" Width="30px" />
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtSaleDate" runat="server" CssClass="clsTextBox" TabIndex="2" Width="80px"></asp:TextBox>
                                    <asp:CalendarExtender ID="ceRefunDate" runat="server" Format="dd MMM yyyy" TargetControlID="txtSaleDate" />
                                </td>
                                <td align="left">
                                    <asp:ComboBox ID="CboCusName" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="3" Width="300px" RenderMode="Block">
                                    </asp:ComboBox>
                                </td>
                                <td align="left" class="auto-style4">
                                    <asp:TextBox ID="txtCName" runat="server" CssClass="clsTextBox" TabIndex="7" Width="130px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCMob" runat="server" CssClass="clsTextBox" TabIndex="7" Width="100px"></asp:TextBox>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtCEmail" runat="server" CssClass="clsTextBox" TabIndex="7" Width="100px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5">
                                    <asp:TextBox ID="txtItemAutono" runat="server" CssClass="clsTextBox" TabIndex="7" Visible="False" Width="60px"></asp:TextBox>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:ComboBox ID="CboItemType" runat="server" AutoCompleteMode="Append" BackColor="White" BorderColor="#66FF66" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" TabIndex="5" Visible="False" Width="80px">
                                    </asp:ComboBox>
                                    <asp:ComboBox ID="CboItemName" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="6" Visible="False" Width="30px">
                                    </asp:ComboBox>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:ComboBox ID="CboUnit" runat="server" AutoCompleteMode="Append" BackColor="White" BorderColor="#66FF66" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" TabIndex="7" Visible="False" Width="60px">
                                    </asp:ComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="5">&nbsp;</td>
                                <td align="left" colspan="2">&nbsp;</td>
                                <td align="left" colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td align="center" class="style3">
                    <asp:Panel ID="pnlItemAdd" runat="server" BackColor="#F2FBFF" Height="300px" Width="1000px" CssClass="pnlBackColorCommon" BorderColor="#CCCCCC" BorderStyle="Groove">
                        <table class="style1">
                            <tr>
                                <td colspan="2" align="left">
                                    <asp:Label ID="Label86" runat="server" CssClass="clsFldHeading" Text="SL No" Width="50px"></asp:Label>
                                </td>
                                <td align="left" colspan="2">&nbsp;</td>
                                <td colspan="2" align="left">
                                    <asp:Label ID="Label87" runat="server" CssClass="clsFldHeading" Text="Item Description" Width="220px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label88" runat="server" CssClass="clsFldHeading" Text="Qty" Width="60px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label92" runat="server" Text="Rate" Width="60px" CssClass="clsFldHeading"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label94" runat="server" Text="Total" Width="70px" CssClass="clsFldHeading"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label93" runat="server" Text="Remarks" Width="250px" CssClass="clsFldHeading"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5" align="left">
                                    <asp:ComboBox ID="CboSLNo" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="1" Width="60px" RenderMode="Block">
                                    </asp:ComboBox>
                                </td>
                                <td colspan="2">
                                    <asp:ImageButton ID="BtnAddNewSlNo" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/plus1.png" OnClick="BtnAddNewSlNo_Click" Width="30px" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="BtnSLNoShow" runat="server" CssClass="clsImageBtn" Height="20px" ImageUrl="~/Images/retrv1.png" OnClick="BtnSLNoShow_Click" Width="30px" />
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtItemCode" runat="server" CssClass="clsTextBox" TabIndex="7" Width="220px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnSrch" runat="server" CssClass="auto-style7" ImageUrl="~/Images/fnd1.png" OnClick="btnSrch_Click" Width="30px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtQty" runat="server" CssClass="clsTextBox" TabIndex="7" Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtSalePrice" runat="server" CssClass="clsTextBox" TabIndex="8" Width="60px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtTotal" runat="server" CssClass="clsTextBox" Enabled="False" TabIndex="8" Width="70px" BackColor="#E6E6E6"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRmk" runat="server" CssClass="clsTextBox" TabIndex="8" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="TxtPaidAmt" runat="server" BackColor="#009900" BorderColor="#33CC33" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" Height="15px" TabIndex="6" Visible="False" Width="20px">0</asp:TextBox>
                                    <asp:TextBox ID="TxtDueAmt" runat="server" BackColor="#009900" BorderColor="#33CC33" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" Height="15px" TabIndex="6" Visible="False" Width="20px">0</asp:TextBox>
                                    <asp:TextBox ID="TxtRefund" runat="server" BackColor="Green" BorderColor="#33CC33" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" Height="15px" TabIndex="6" Visible="False" Width="20px"></asp:TextBox>
                                    <asp:ComboBox ID="CboPayMode" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="2" Visible="False" Width="50px">
                                    </asp:ComboBox>
                                    <asp:TextBox ID="txtAutoNo" runat="server" BackColor="Green" BorderColor="#33CC33" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" Height="15px" TabIndex="6" Width="20px" Visible="False"></asp:TextBox>
                                </td>
                                <td colspan="2" align="left">
                                    <asp:TextBox ID="txtItemDet" runat="server" CssClass="clsTextBox" Height="60px" ReadOnly="True" TabIndex="10" TextMode="MultiLine" Width="220px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="BtnItemReturn" runat="server" BackColor="#3399FF" BorderStyle="None" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" Height="15px" Text="*Item Ret" Visible="False" Width="67px" />
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:ImageButton ID="BtnSave" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/sav2.png" OnClick="BtnSave_Click" />
                                    &nbsp;<asp:ImageButton ID="BtnDelete" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/del2.png" OnClick="BtnDelete_Click" />
                                    &nbsp;<asp:ImageButton ID="BtnClearAll" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/ref2.png" OnClick="BtnClearAll_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="10">
                                    <div id="GHead" style="width: 983px;"></div>
                                    <div style="height: 130px; width: 995px; overflow: scroll; overflow-x: hidden;">
                                        <asp:GridView ID="Grd" runat="server" AlternatingRowStyle-CssClass="altRows" CssClass="mydatagrid" HeaderStyle-CssClass="header" OnRowCommand="Grd_RowCommand" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" Width="980px" OnSelectedIndexChanged="Grd_SelectedIndexChanged1" OnPageIndexChanging="Grd_PageIndexChanging">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="center" class="style3">
                    <asp:Label ID="LebMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" Height="16px" Text="....." Visible="False" Width="324px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style6">

                    <asp:Panel ID="PnlPaid" runat="server" Height="80px" Width="1000px"
                        CssClass="pnlBackColorCommon" BorderColor="#CCCCCC" BorderStyle="Solid">

                        <table>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="Label70" runat="server" BackColor="#9D9DBD" Font-Bold="True"
                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px"
                                        Text="GRAND TOTAL" Width="90px"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="Label71" runat="server" BackColor="#9D9DBD" Font-Bold="True"
                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px" Text="VAT"
                                        Width="79px"></asp:Label>
                                </td>
                                <td class="auto-style1">
                                    <asp:Label ID="Label72" runat="server" BackColor="#9D9DBD" Font-Bold="True"
                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px"
                                        Text="DISCOUNT" Width="79px"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="Label73" runat="server" BackColor="#9D9DBD" Font-Bold="True"
                                        Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px"
                                        Text="PAYABLE AMOUNT" Width="105px"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="Label95" runat="server" BackColor="#9D9DBD" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px" Text="PAID" Width="90px"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="Label96" runat="server" BackColor="#FF5E5E" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px" Text="DUE" Width="79px"></asp:Label>
                                </td>
                                <td class="auto-style2">
                                    <asp:Label ID="Label76" runat="server" BackColor="#9D9DBD" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px" Text="REFUND" Width="79px"></asp:Label>
                                </td>
                                <td class="auto-style2" rowspan="2">
                                    <asp:ImageButton ID="BtnAccOk" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/btnPosAcc2.png" OnClick="BtnAccOk_Click" Width="120px" />
                                </td>
                                <td class="auto-style2" rowspan="2">
                                    <asp:ImageButton ID="BtnInvoice" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/btnInv2.png" OnClick="BtnInvoice_Click" Width="100px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TxtGrandTotal" runat="server"
                                        CssClass="clsTextBox" TabIndex="12" Width="90px" Enabled="False" BackColor="#E6E6E6">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtVat" runat="server"
                                        CssClass="clsTextBox"
                                        TabIndex="12" Width="20px">0</asp:TextBox>
                                    &nbsp;<asp:TextBox ID="TxtVatAmt" runat="server"
                                        CssClass="clsTextBox"
                                        TabIndex="13" Width="45px">0</asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtDiscount" runat="server"
                                        CssClass="clsTextBox"
                                        TabIndex="14" Width="20px">0</asp:TextBox>
                                    &nbsp;<asp:TextBox ID="TxtDiscountAmt" runat="server"
                                        CssClass="clsTextBox" TabIndex="15" Width="40px">0</asp:TextBox>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="TxtPayableAmt" runat="server"
                                        CssClass="clsTextBox" TabIndex="16" Width="105px" Enabled="False" BackColor="#E6E6E6">0</asp:TextBox>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="TxtCash" runat="server" CssClass="clsTextBox" TabIndex="17" Width="90px"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="TxtDue" runat="server" CssClass="clsTextBox" Enabled="False" TabIndex="18" Width="80px" BackColor="#E6E6E6"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="TxtRefundAmt" runat="server" CssClass="clsTextBox" Enabled="False" TabIndex="19" Width="79px" BackColor="#E6E6E6">0</asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label ID="lebCardNo" runat="server" BackColor="#9D9DBD" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px" Text="Enter Card No in case of Card Card Payment)" Width="260px" Visible="False"></asp:Label>
                                </td>
                                <td class="style7">
                                    <asp:TextBox ID="TxtCardNo" runat="server" CssClass="clsTextBox" Height="15px" TabIndex="21" Width="120px" Visible="False"></asp:TextBox>
                                </td>
                                <td class="style7">
                                    <asp:Label ID="lebBankName" runat="server" BackColor="#9D9DBD" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" Height="15px" Text="PAYMENT SOURCE" Width="100px"></asp:Label>
                                </td>
                                <td class="style7" colspan="2">
                                    <asp:ComboBox ID="CboBankName" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="22" Width="200px" RenderMode="Block">
                                        <asp:ListItem>Cash Sale</asp:ListItem>
                                    </asp:ComboBox>
                                </td>
                                <td class="style7">
                                    <asp:CheckBox ID="chkMSWrd" runat="server" BorderStyle="None" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt" Text="OPEN IN MS DOC" Visible="False" />
                                </td>
                                <td class="style7">
                                    <asp:CheckBox ID="chkPad" runat="server" BorderStyle="None" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt" Text="INVOICE " OnCheckedChanged="chkPad_CheckedChanged" />
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td align="left" class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7" colspan="2">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                                <td class="style7">&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                </td>
            </tr>
            <tr>
                <td class="style3" align="center">
                    <asp:Panel ID="pnlInvoice" runat="server" Height="70px" Width="1000px" BorderColor="#CCCCCC" BorderStyle="Solid" Visible="False">
                        <table class="style1">
                            <tr>
                                <td align="center">
                                    <asp:Label ID="lblTotal0" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="18px" Text="Signed By" Width="70px" Visible="False"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lebHeder" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="18px" Text="Header" Width="70px" Visible="False"></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblTotal2" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="18px" Text="Footer" Width="70px" Visible="False"></asp:Label>
                                    <asp:Button ID="BtnOk" runat="server" BackColor="#009900" BorderColor="#009900" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="White" OnClick="BtnOk_Click" TabIndex="23" Text="Get Note" Width="60px" Visible="False" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="lblTotal3" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="18px" Text="A/C Note" Width="70px" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ComboBox ID="cboSignName" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="22" Width="170px" RenderMode="Block" Visible="False">
                                    </asp:ComboBox>
                                </td>
                                <td>
                                    <asp:ComboBox ID="cboHeader" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="22" Width="200px" RenderMode="Block" Visible="False">
                                    </asp:ComboBox>
                                </td>
                                <td>
                                    <asp:ComboBox ID="cboFooter" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="22" Width="200px" RenderMode="Block" Visible="False">
                                    </asp:ComboBox>
                                </td>
                                <td>
                                    <asp:ComboBox ID="cboNote" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="22" Width="200px" RenderMode="Block" Visible="False">
                                    </asp:ComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

            <tr>
                <td class="style3" align="center">
                    <asp:Label ID="lebItemDet" runat="server" Font-Bold="True" Font-Names="Tahoma"
                        Font-Size="8pt" Height="15px" Text="......" Width="340px"></asp:Label>
                </td>
            </tr>

            <tr>
                <td class="style3" align="left">
                    <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
                    <%--<cr:crystalreportviewer id="crv" runat="server" autodatabind="true" />--%>
                </td>
            </tr>

        </table>

    </div>

</asp:Content>
