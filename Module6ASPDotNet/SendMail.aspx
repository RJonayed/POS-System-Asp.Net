<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SendMail.aspx.cs" Inherits="Module6ASPDotNet.SendMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700" CssClass="pnlBackColorCommon">
    <div>
        <asp:Panel ID="Panel2" runat="server" Width="1000" CssClass="clsOnlyFontWithCursor">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="TO:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTo" runat="server" CssClass="clsTextBox" Width="200px" /></td>
                <caption>
                    <br />
                </caption>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Subject:</td>
                <td>
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="clsTextBox" Width="200px"  /></td>
                <caption>
                    <br />
                </caption>
            </tr> 
            <tr>
                <td></td>
            </tr>
            <tr>
                <td valign="top">Body:</td>
                <td>
                    <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" Height="150" Width="200" CssClass="clsTextBoxScroll" /></td>
                <caption>
                    <br />
                </caption>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSend" Text="Send" runat="server" OnClick="SendEmail" style="height: 18px" CssClass="clsButonAddNew" Width="80px" /></td> 
                <caption>
                    &nbsp;&nbsp;
                </caption>
                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblSend" runat="server" Text="........" ForeColor="Maroon" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
            </asp:Panel>
    </div>
        </asp:Panel>
</asp:Content>
