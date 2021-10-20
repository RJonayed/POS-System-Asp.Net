<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiView.aspx.cs" Inherits="Module6ASPDotNet.MultiView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700" CssClass="pnlBackColorCommon">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" CssClass="clsFormHeading" Text="Multi View" Width="1000px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>

                </td>
            </tr>
        </table>
        <div>
            <asp:Panel ID="Panel2" runat="server" Width="1000" CssClass="pnlBackColorCommon">
                <table>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server" Width="1000" CssClass="pnlBackColorCommon">
                                <asp:MultiView ID="MultiView1" runat="server">
                                </asp:MultiView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" CssClass="clsButonAddNew" PostBackUrl="~/AllView.aspx" Text="View Option" />
                        </td>
                    </tr>
                    </table>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
