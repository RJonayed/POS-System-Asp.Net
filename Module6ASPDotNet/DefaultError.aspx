<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DefaultError.aspx.cs" Inherits="Module6ASPDotNet.DefaultError" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700" CssClass="pnlBackColorCommon">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label51" runat="server" CssClass="clsFormHeading" Text="Custon Error Handling" Width="1000px"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="Panel3" runat="server" Width="1000" Height="250px" CssClass="pnlBackColorCommon">
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" />
                                <EditRowStyle BackColor="#7C6F57" />
                                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#E3EAEB" />
                                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                                <SortedAscendingHeaderStyle BackColor="#246B61" />
                                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                                <SortedDescendingHeaderStyle BackColor="#15524A" />
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblMsg" runat="server" Text="........." ForeColor="Maroon"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <tb>                       
                    </tb>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Text="Clear Error" CssClass="clsButonAddNew" OnClick="btnClear_Click" /></td>
                </tr>
            </table>
        </div>
    </asp:Panel>
</asp:Content>
