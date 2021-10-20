<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Module6ASPDotNet._default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 21px;
        }
    </style>
     <script type="text/javascript">
       {
           function DisableBackButton() {
               window.history.forward()
           }
           DisableBackButton();
           window.onload = DisableBackButton;
           window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
           window.onunload = function () { void (0) }
       }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="clsContent">

        <table>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label51" runat="server"
                        Text=".." CssClass="clsFormHeading" Width="1000px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1"></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lebGood" runat="server" Text="......." ForeColor="#006600" Font-Bold="True" Width="500px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lebLogIn" runat="server" Text="......." ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>

            <tr>
                <td align="center">
                    <asp:Label ID="lebIp0" runat="server" Font-Names="Tahoma" Font-Size="Small"
                        Text="Account's Summary"></asp:Label>
                </td>
                <td align="center">
                    <asp:Label ID="lebIp1" runat="server" Font-Names="Tahoma" Font-Size="Small"
                        Text="................."></asp:Label>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Panel ID="pnlAttn" runat="server" CssClass="pnlBackColorCommon" Height="400px" Width="400px">
                        <asp:GridView ID="grdAttn" runat="server"
                            Width="390px" CssClass="mydatagrid"
                            RowStyle-CssClass="rows" HeaderStyle-CssClass="header">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="pnlAcct" runat="server" CssClass="pnlBackColorCommon" Height="400px" ScrollBars="Vertical" Width="530px">
                        <asp:GridView ID="grdAcct" runat="server"
                            Width="500px" CssClass="mydatagrid"
                            RowStyle-CssClass="rows" HeaderStyle-CssClass="header">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lebIp" runat="server" Font-Names="Tahoma" Font-Size="Small"
                        Text="..." Visible="False"></asp:Label>
                    <asp:Label ID="lebServerDt" runat="server" Font-Names="Tahoma" Font-Size="Small"
                        Text="..." Visible="False"></asp:Label>
                    <asp:TextBox ID="txtPwd" runat="server" BackColor="#CCFF66" Visible="False" Width="20px"></asp:TextBox>
                </td>
            </tr>

        </table>

    </div>
</asp:Content>
