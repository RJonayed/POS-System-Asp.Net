<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Party.aspx.cs" Inherits="Module6ASPDotNet.Party" Title="Supplier Information"  %>
<%--<%@ Page Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="Party.aspx.cs" Inherits="Party" Title="Supplier Information" %>--%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clsContent">          
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server"
                        Text="Customer/Supplier Information" CssClass="clsFormHeading" Width="1000px"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Panel ID="Panel1" runat="server" CssClass="pnlBackColorCommon" Width="1000px">
                        <table class="style1">
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label60" runat="server" CssClass="clsFldHeading" Text="Code" Width="120px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label83" runat="server" CssClass="clsFldHeading" Text="Name" Width="120px"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label84" runat="server" CssClass="clsFldHeading" Text="Address" Width="120px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label85" runat="server" CssClass="clsFldHeading" Text="Phone" Width="120px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:ComboBox ID="CboPartyCode" runat="server" AutoCompleteMode="Append" BorderWidth="1px" CssClass="clsComboBox" TabIndex="19" Width="60px" AutoPostBack="True" OnSelectedIndexChanged="CboPartyCode_SelectedIndexChanged">
                                    </asp:ComboBox>
                                </td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="txtPartyName" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="5" Width="280px"></asp:TextBox>
                                </td>
                                <td class="auto-style3" colspan="2">
                                    <asp:TextBox ID="CboPartyAdd" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="5" Width="280px"></asp:TextBox>
                                </td>
                                <td class="auto-style3">
                                    <asp:TextBox ID="txtPhone" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="4" Width="280px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="BtnAddNew" runat="server" CssClass="clsButonAddNew" OnClick="BtnAddNew_Click" TabIndex="102" Text="Add New" Width="90px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label86" runat="server" CssClass="clsFldHeading" Text="EMail ID" Width="80px"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label87" runat="server" CssClass="clsFldHeading" Text="Contact Person" Width="120px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label88" runat="server" CssClass="clsFldHeading" Text="Remarks" Width="120px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtFaxEmail" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="5" Width="280px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtConPerson" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="8" Width="280px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRmk" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="9" Width="280px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td colspan="2">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Label ID="Label89" runat="server" CssClass="clsFldHeading" Text="Contract Amount (If any)" Width="200px"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="Label90" runat="server" CssClass="clsFldHeading" Text="Opening Balance" Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label91" runat="server" CssClass="clsFldHeading" Text="Till Date" Width="150px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtContAmt" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="6" Width="90px"></asp:TextBox>
                                    <asp:TextBox ID="txtDiscount" runat="server" BorderWidth="1px" CssClass="clsTextBox" Height="16px" TabIndex="6" Width="80px" Visible="False"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOpBal" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="7" Width="90px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkCr" runat="server" BorderStyle="None" BorderWidth="1px" Font-Bold="False" Font-Names="Tahoma" Font-Size="9pt" Height="17px" TabIndex="131" Text="Credit" Width="80px" />
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOpBalDate" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="126" Width="100px"></asp:TextBox>
                                    <asp:CalendarExtender ID="ceOpBalDate" runat="server" Format="dd MMM yyyy" TargetControlID="txtOpBalDate" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Panel ID="Panel2" runat="server" CssClass="pnlBackColorCommon">
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:Button ID="BtnSave" runat="server" CssClass="clsButonSave" OnClick="BtnSave_Click" TabIndex="42" Text="Save" Width="65px" />
                                    &nbsp;<asp:Button ID="BtnDelete" runat="server" CssClass="clsButonDelete" OnClick="BtnDelete_Click" TabIndex="43" Text="Delete" Width="65px" />
                                </td>
                                <td align="center">
                                    <asp:Label ID="LebTotRow" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Text="....."></asp:Label>
                                </td>
                                <td align="center">
                                    <asp:Label ID="LebMsg" runat="server" Font-Bold="True" Font-Names="Tahoma" Font-Size="Small" CssClass="clsMsgLabel" Text="....." Visible="False" Width="300px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" CssClass="pnlBackColorCommon" Width="1000px" Height="200px" ScrollBars="Vertical">
                        <asp:GridView ID="Grd" runat="server"
                            CssClass="mydatagrid" HeaderStyle-CssClass="header" AlternatingRowStyle-CssClass="altRows" RowStyle-CssClass="rows"
                            OnRowCommand="Grd_RowCommand"
                            Width="900px" OnSelectedIndexChanged="Grd_SelectedIndexChanged" OnPageIndexChanging="Grd_PageIndexChanging">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>

            <tr>
                <td></td>
            </tr>

            <tr>
                <td></td>
            </tr>

            <tr>
                <td>
                    <asp:TextBox ID="txtCrLimit" runat="server" BorderWidth="1px" CssClass="clsTextBox" TabIndex="6" Width="80px" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtPartyAutoNo" runat="server" BorderColor="#33CC33" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" Font-Names="Tahoma" Font-Size="8pt" Height="16px" TabIndex="6" Visible="False" Width="90px"></asp:TextBox>
                    <asp:ImageButton ID="BtnShow" runat="server" CssClass="clsImageBtn" OnClick="BtnShow_Click" Visible="False" />
                    <asp:ComboBox ID="CboPartyType" runat="server" AutoCompleteMode="Append" BorderWidth="1px" CssClass="clsComboBox" TabIndex="2" Width="80px">
                        <asp:ListItem>Supplier</asp:ListItem>
                        <asp:ListItem>Customer</asp:ListItem>
                    </asp:ComboBox>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
