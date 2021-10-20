<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="Module6ASPDotNet.Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblHeading" runat="server" Text="Report Option" CssClass="clsTableHeaderFontCenter" Width="990" BackColor="#666666" Font-Bold="true" Font-Size="10"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <table class="auto-style1">
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnPRt" runat="server" Text="Product Informtion" CssClass="clsButonAddNew" Width="200px" />&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnSRpt" runat="server" CssClass="clsButonAddNew" OnClick="btnSRpt_Click" Text="Stock Summary" Width="200px" />&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnLager" runat="server" CssClass="clsButonAddNew" Text="Date Wise Sale" Width="200px" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
