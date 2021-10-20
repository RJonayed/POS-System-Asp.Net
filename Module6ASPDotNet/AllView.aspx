<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllView.aspx.cs" Inherits="Module6ASPDotNet.AllView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700" CssClass="pnlBackColorCommon">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" CssClass="clsFormHeading" Text="List View" Width="1000px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="Panel3" runat="server" Width="990" Height="40">
                        <asp:Button ID="btnListView" runat="server" Text="List View" CssClass="clsButonAddNew" OnClick="btnListView_Click" Width="150px" />&nbsp;&nbsp;
                        <asp:Button ID="btnDtls" runat="server" Text="Details View" CssClass="clsButonAddNew" Width="150px" OnClick="btnDtls_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnForm" runat="server" Text="Form View" CssClass="clsButonAddNew" Width="150px" OnClick="btnForm_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnMultiView" runat="server" Text="Multi View" CssClass="clsButonAddNew" Width="150px" OnClick="btnMultiView_Click" Visible="False" />
                    </asp:Panel>
                </td>
            </tr>
        </table>
        <div>
            <asp:Panel ID="Panel2" runat="server" Width="1000" CssClass="pnlBackColorCommon">
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
