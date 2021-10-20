<%@ Page Title="Purchae" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Module6ASPDotNet.Purchase" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="StyleOne.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/jquery-1.7.1.js"></script>

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
            var gridHeader2 = $('#<%=GrdAcc.ClientID%>').clone(true); // Here Clone Copy of Gridview with style
                    $(gridHeader2).find("tr:gt(0)").remove(); // Here remove all rows except first row (header row)
                    $('#<%=GrdAcc.ClientID%> tr th').each(function (j) {
                        // Here Set Width of each th from gridview to new table(clone table) th 
                        $("th:nth-child(" + (j + 1) + ")", gridHeader2).css('width', ($(this).width()).toString() + "px");
                    });
                    $("#GHeadPur").append(gridHeader2);
                    $('#GHeadPur').css('position', 'absolute');
                    $('#GHeadPur').css('top', $('#<%=GrdAcc.ClientID%>').offset().top);


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
        }

        .style5 {
        }

        .style7 {
            height: 21px;
        }

        .style13 {
            height: 22px;
        }

        .auto-style2 {
            height: 282px;
        }

        .auto-style3 {
            width: 4px;
        }

        .auto-style4 {
            height: 27px;
        }
        .auto-style5 {
            font-family: Tahoma;
            font-size: 10pt;
            font-weight: bold;
            color: forestgreen;
            border-top-left-radius: 5px;
            border-top-right-radius: 5px;
            border-bottom-left-radius: 5px;
            border-bottom-right-radius: 5px;
            border: thin solid forestgreen;
            background-color: #C4FFC4;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="clsContent">
            <table class="style1">                           
                <tr>
                    <td align="center" class="clsPageHeaderColor" colspan="2">
                        <asp:Label ID="Label52" runat="server"
                            Text="Purchase Details" CssClass="clsFormHeading" Width="1000px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5" colspan="2">
                        <asp:Panel ID="Panel1" runat="server" BackColor="#66FF66" Width="800px" Visible="False">
                            <asp:TextBox ID="txtItemAutono" runat="server" Width="70px" Font-Bold="True"
                                Font-Names="Tahoma" Font-Size="8pt" TabIndex="13" BorderStyle="Solid"
                                BorderColor="#33CC33" Height="15px"></asp:TextBox>
                            <asp:ComboBox ID="cboItemType" runat="server" AutoCompleteMode="Append"
                                BackColor="White" BorderColor="#66FF66" BorderStyle="Solid"
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                onblur="this.style.backgroundColor='white'"
                                onfocus="this.style.backgroundColor='#CCFFCC'" TabIndex="5" Width="180px">
                            </asp:ComboBox>
                            <asp:ComboBox ID="cboItemName" runat="server" AutoCompleteMode="Append"
                                BackColor="White" BorderColor="#66FF66" BorderStyle="Solid"
                                Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt"
                                onblur="this.style.backgroundColor='white'"
                                onfocus="this.style.backgroundColor='#CCFFCC'" TabIndex="4" Width="180px">
                            </asp:ComboBox>
                            <asp:TextBox ID="txtCashForVr" runat="server" BorderColor="#33CC33" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="15px" onblur="this.style.backgroundColor='white'" onfocus="this.style.backgroundColor='#CCFFCC'" TabIndex="127" Width="70px"></asp:TextBox>
                            <asp:CheckBox ID="chkMaualBarcode" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#0066FF" Text=" MB" Visible="False" />
                            <asp:TextBox ID="txtMaualBarcode" runat="server" CssClass="clsTextBox" TabIndex="127" Visible="False" Width="100px"></asp:TextBox>
                            <asp:ComboBox ID="cboUnit" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="7" Width="60px">
                            </asp:ComboBox>
                            <asp:TextBox ID="txtSalePrice" runat="server" CssClass="clsTextBox" TabIndex="9" Width="70px"></asp:TextBox>
                            <asp:TextBox ID="txtWarrntyDate" runat="server" CssClass="clsTextBox" TabIndex="10" Width="76px"></asp:TextBox>
                            <asp:CalendarExtender ID="txtWarrntyDate_CalendarExtender" runat="server" Format="dd MMM yyyy" TargetControlID="txtWarrntyDate" />
                            <asp:CheckBox ID="ChkWarEnd" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="Warrnty End" />
                            <asp:ImageButton ID="BtnBarCode" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/btnBar2.png" />
                            <asp:CheckBox ID="ChkFacExp" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="Fac" Visible="False" />
                            <asp:TextBox ID="txtAutoNo" runat="server" BorderColor="#33CC33" BorderStyle="Solid" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="15px" TabIndex="127" Visible="False" Width="100px"></asp:TextBox>
                            <asp:Label ID="lebItemDet" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="15px" Text="......" Width="340px"></asp:Label>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style5" colspan="2">

                        <asp:Panel ID="pnlPurFind" runat="server" Width="1000px" Height="500px" Visible="False">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="LblHeading" runat="server" CssClass="clsPageHeding" Text="Already Purchased Details......"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div id="GHeadPur" style="width: 983px;"></div>
                                        <div style="height: 400px; width: 1000px; overflow: scroll; overflow-x: hidden;">
                                            <asp:GridView ID="GrdAcc" runat="server" HorizontalAlign="Left"
                                                CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AlternatingRowStyle-CssClass="altRows"
                                                OnRowCommand="GrdAcc_RowCommand" Width="950px" HeaderStyle-HorizontalAlign="Left" OnSelectedIndexChanged="GrdAcc_SelectedIndexChanged">
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
                    <td align="left" class="style5" colspan="2">

                        <asp:Panel ID="pnlItem" runat="server" Height="500px" Width="1000px" Visible="False" BorderColor="#CCCCCC" BorderStyle="Solid">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label66" runat="server" Text="Enter the Search Keyword like Item Name, Brand, Size etc." CssClass="clsFldHeading" Width="350px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtItemDetForFind" runat="server" CssClass="clsTextBox" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="iBtnFind" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/Ref2.png" OnClick="iBtnFind_Click" />
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="iBtnClose" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/cls2.png" OnClick="iBtnClose_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <div id="GHeadItemFnd" style="width: 983px;"></div>
                                        <div style="height: 400px; width: 1000px; overflow: scroll; overflow-x: hidden;">
                                            <asp:GridView ID="grdItemForFind" runat="server"
                                                CssClass="mydatagrid" PagerStyle-CssClass="pager" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AlternatingRowStyle-CssClass="altRows"
                                                Width="980px" OnRowCommand="grdItemForFind_RowCommand"
                                                OnSelectedIndexChanged="grdItemForFind_SelectedIndexChanged">
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
                    <td colspan="2">
                        <asp:Panel ID="pnlMstr" runat="server" Height="80px" Width="1000px" BorderColor="#CCCCCC" BorderStyle="Solid">
                            <table class="style1">
                                <tr>
                                    <td align="left" colspan="3">
                                        <asp:Label ID="Label84" runat="server" CssClass="clsFldHeading" Text="Purchase Code" Width="120px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label53" runat="server" CssClass="clsFldHeading" Text="Purchase Date" Width="120px"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label65" runat="server" CssClass="clsFldHeading" Text="Memo No" Width="120px"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="Label54" runat="server" CssClass="clsFldHeading" Text="Party Name" Width="400px"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:ComboBox ID="cboPurchaseCode" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" Width="80px">
                                        </asp:ComboBox>
                                    </td>
                                    <td align="left">
                                        <asp:ImageButton ID="BtnAddNew" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/plus1.png" OnClick="BtnAddNew_Click" ToolTip="Click Here To Add New Purchase Entry of New Memo" Width="30px" TabIndex="1" />
                                    </td>
                                    <td align="left">
                                        <asp:ImageButton ID="BtnShow" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/retrv1.png" OnClick="BtnShow_Click" ToolTip="Click here to show details of the Purchase Code" Width="30px" TabIndex="2" />
                                    </td>
                                    <td align="left">
                                        <asp:TextBox ID="txtPurDate" runat="server" CssClass="clsTextBox" TabIndex="3" Width="80px"></asp:TextBox>
                                        <asp:CalendarExtender ID="ceRefunDate" runat="server" Format="dd MMM yyyy" TargetControlID="txtPurDate" />
                                    </td>
                                    <td align="left">
                                        <asp:ComboBox ID="cboManualMamoNo" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="4" Width="100px">
                                        </asp:ComboBox>
                                    </td>
                                    <td align="left">
                                        <asp:ComboBox ID="cboPartyName" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="5" Width="350px">
                                            <asp:ListItem>Cash Purchase</asp:ListItem>
                                        </asp:ComboBox>
                                    </td>
                                    <td align="left">
                                        <asp:ImageButton ID="btnAllPurchase" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/allpurchase.png" OnClick="btnAllPurchase_Click" Width="100px" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="auto-style2" colspan="2">
                        <asp:Panel ID="pnlLeft" runat="server" CssClass="pnlBackColorCommon" BorderStyle="Solid"
                            Height="280px" Width="1000px" BorderColor="#CCCCCC">
                            <table class="style1">
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="Label86" runat="server" Text="SL No" Width="100px" CssClass="clsFldHeading"></asp:Label>
                                    </td>
                                    <td align="left" colspan="2">
                                        <asp:Label ID="Label87" runat="server" CssClass="clsFldHeading" Text="Item Description" Width="150px"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label88" runat="server" CssClass="clsFldHeading" Text="Qty" Width="60px"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label89" runat="server" Text="Rate" Width="50px" CssClass="clsFldHeading"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label90" runat="server" Text="Total" Width="60px" CssClass="clsFldHeading"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="Label91" runat="server" CssClass="clsFldHeading" Text="Product SL No/Remarks" Width="200px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style4">
                                        <asp:ComboBox ID="cboSlNo" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="1" Width="60px">
                                        </asp:ComboBox>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:ImageButton ID="BtnAddNewSlNo" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/plus1.png" OnClick="BtnAddNewSlNo_Click" ToolTip="Click here to add new item in the purchase list of the above purchase code." Width="30px" TabIndex="6" />
                                    </td>
                                    <td class="auto-style4">
                                        <asp:ImageButton ID="BtnSLNoShow" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/retrv1.png" OnClick="BtnSLNoShow_Click" ToolTip="Click here to show details of the item of that SL No." Width="30px" TabIndex="7" />
                                    </td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtItemCode" runat="server" CssClass="clsTextBox" TabIndex="8" Width="200px"></asp:TextBox>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:ImageButton ID="iBtnItmFind" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/fnd1.png" OnClick="iBtnItmFind_Click" Width="30px" TabIndex="9" />
                                    </td>
                                    <td class="auto-style4" align="center">
                                        <asp:TextBox ID="txtQty" runat="server" CssClass="clsTextBox" TabIndex="10" Width="70px" OnTextChanged="txtQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td class="auto-style4" align="center">
                                        <asp:TextBox ID="txtPurchasePrice" runat="server" CssClass="clsTextBox" TabIndex="11" Width="70px" OnTextChanged="txtPurchasePrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td class="auto-style4">
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="clsTextBox" TabIndex="12" Width="70px" OnTextChanged="txtQty_TextChanged" AutoPostBack="True" BackColor="#E6E6E6" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="auto-style4" align="center">
                                        <asp:TextBox ID="txtSlNoRmk" runat="server" CssClass="clsTextBox" TabIndex="13" Width="200px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" rowspan="2">
                                        <asp:ImageButton ID="BtnItemShow" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/Show2.png" OnClick="BtnItemShow_Click" Visible="False" />
                                    </td>
                                    <td colspan="2" rowspan="2">
                                        <asp:TextBox ID="txtItemDet" runat="server" CssClass="clsTextBox" Height="60px" TabIndex="10" TextMode="MultiLine" Width="200px" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td colspan="2" rowspan="2">         
                                        <asp:Panel ID="pnlSave" runat="server" Height="30px" Width="280px">
                                            <table class="style1">
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="BtnSave" runat="server" OnClick="BtnSave_Click" TabIndex="42" Text="Save" Width="65px" CssClass="clsButonSave" />
                                                    </td>
                                                    <td align="center">&nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="clsButonDelete" OnClick="BtnDelete_Click" TabIndex="43" Text="Delete" Width="65px" />
                                                    </td>
                                                    <td align="center">
                                                        <asp:ImageButton ID="BtnClearAll" runat="server" CssClass="clsImageBtn" ImageUrl="~/Images/ref2.png" OnClick="BtnClearAll_Click" TabIndex="16" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtStoreInQty" runat="server" CssClass="clsTextBox" TabIndex="13" Width="80px" Visible="False"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtShopInQty" runat="server" CssClass="clsTextBox" TabIndex="13" Width="80px" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">&nbsp;</td>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="9">
                                        <asp:Panel ID="pntGrid" runat="server" Height="105px" Width="1000px" ScrollBars="Vertical">

                                            <asp:GridView ID="Grd" runat="server"
                                                CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AlternatingRowStyle-CssClass="altRows"
                                                OnRowCommand="Grd_RowCommand" Width="900px">

                                                <Columns>
                                                    <asp:CommandField ShowSelectButton="True" />
                                                </Columns>

                                            </asp:GridView>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="7">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="style7" colspan="2">
                        <asp:Panel ID="pnlRight" runat="server" CssClass="pnlBackColorCommon" Height="60px"
                            Width="1000px" BorderStyle="Solid">
                            <table class="style1">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label92" runat="server" Text="Grand Total" Width="70px" CssClass="clsFldHeading"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtGrandTotal" runat="server" CssClass="clsTextBox" TabIndex="127" Width="70px" BackColor="#E6E6E6" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label93" runat="server" CssClass="clsFldHeading" Text="Cash Paid" Width="70px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtCash" runat="server" CssClass="clsTextBox" TabIndex="127" Width="70px"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Label ID="lebDue" runat="server" CssClass="clsFldHeading" Text="Due" Width="60px"></asp:Label>
                                    </td>
                                    <td class="auto-style3">
                                        <asp:TextBox ID="txtDue" runat="server" CssClass="clsTextBox" TabIndex="127" Width="70px" BackColor="#E6E6E6" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td align="right">
                                        <asp:Label ID="Label95" runat="server" Text="Payment Source" Width="100px" CssClass="clsFldHeading"></asp:Label>
                                    </td>
                                    <td align="left">
                                        <asp:ComboBox ID="cboCrHead" runat="server" AutoCompleteMode="Append" CssClass="clsComboBox" TabIndex="2" Width="220px" RenderMode="Block">
                                            <asp:ListItem>Cash In Hand</asp:ListItem>
                                        </asp:ComboBox>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnPostToAcc" runat="server" CssClass="clsButonSave" OnClick="btnPostToAcc_Click1" TabIndex="42" Text="Post AC" Width="65px" />
                                    </td>
                                </tr>

                            </table>

                        </asp:Panel>


                    </td>
                </tr>
                <tr>
                    <td align="center" class="style7" colspan="2">
                        <asp:Label ID="LebMsg" runat="server"
                            Text="....." Font-Bold="True"
                            Font-Names="Tahoma" Font-Size="Small" Width="300px" Visible="False"
                            Height="16px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style7" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style2" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td align="left" class="style2">&nbsp;</td>
                    <td align="left" class="style2">&nbsp;</td>
                </tr>                      
            </table>
        </div>
</asp:Content>
