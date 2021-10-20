<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailsView.aspx.cs" Inherits="Module6ASPDotNet.DetailsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700" CssClass="pnlBackColorCommon">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" CssClass="clsFormHeading" Text="Details View" Width="1000px"></asp:Label>
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
                            <asp:Panel ID="Panel3" runat="server" CssClass="pnlBackColorCommon" Width="1000px">
                                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ProductId" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" Height="50px" Width="125px">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <Fields>
                                        <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                                        <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                                        <asp:BoundField DataField="PurchaseDate" HeaderText="PurchaseDate" SortExpression="PurchaseDate" />
                                        <asp:BoundField DataField="VendorEmail" HeaderText="VendorEmail" SortExpression="VendorEmail" />
                                        <asp:BoundField DataField="ImageName" HeaderText="ImageName" SortExpression="ImageName" />
                                        <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                                        <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" SortExpression="CategoryId" />
                                        <asp:BoundField DataField="ImageUrl" HeaderText="ImageUrl" SortExpression="ImageUrl" />
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                                    </Fields>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                </asp:DetailsView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db %>" DeleteCommand="DELETE FROM [Product] WHERE [ProductId] = @ProductId" InsertCommand="INSERT INTO [Product] ([ProductName], [PurchaseDate], [VendorEmail], [ImageName], [Price], [CategoryId], [ImageUrl]) VALUES (@ProductName, @PurchaseDate, @VendorEmail, @ImageName, @Price, @CategoryId, @ImageUrl)" SelectCommand="SELECT [ProductId], [ProductName], [PurchaseDate], [VendorEmail], [ImageName], [Price], [CategoryId], [ImageUrl] FROM [Product]" UpdateCommand="UPDATE [Product] SET [ProductName] = @ProductName, [PurchaseDate] = @PurchaseDate, [VendorEmail] = @VendorEmail, [ImageName] = @ImageName, [Price] = @Price, [CategoryId] = @CategoryId, [ImageUrl] = @ImageUrl WHERE [ProductId] = @ProductId">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ProductId" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="ProductName" Type="String" />
                                        <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                                        <asp:Parameter Name="VendorEmail" Type="String" />
                                        <asp:Parameter Name="ImageName" Type="String" />
                                        <asp:Parameter Name="Price" Type="Decimal" />
                                        <asp:Parameter Name="CategoryId" Type="Int32" />
                                        <asp:Parameter Name="ImageUrl" Type="String" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ProductName" Type="String" />
                                        <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                                        <asp:Parameter Name="VendorEmail" Type="String" />
                                        <asp:Parameter Name="ImageName" Type="String" />
                                        <asp:Parameter Name="Price" Type="Decimal" />
                                        <asp:Parameter Name="CategoryId" Type="Int32" />
                                        <asp:Parameter Name="ImageUrl" Type="String" />
                                        <asp:Parameter Name="ProductId" Type="Int32" />
                                    </UpdateParameters>
                                </asp:SqlDataSource>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" CssClass="clsButonAddNew" OnClick="btnBack_Click" PostBackUrl="~/AllView.aspx" Text="View Option" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
