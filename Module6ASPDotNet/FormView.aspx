<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormView.aspx.cs" Inherits="Module6ASPDotNet.FormView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700" CssClass="pnlBackColorCommon">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" CssClass="clsFormHeading" Text="Form View" Width="1000px"></asp:Label>
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
                                <asp:FormView ID="FormView1" runat="server" AllowPaging="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="ProductId" DataSourceID="SqlDataSource1" GridLines="Both">
                                    <EditItemTemplate>
                                        ProductId:
                                        <asp:Label ID="ProductIdLabel1" runat="server" Text='<%# Eval("ProductId") %>' />
                                        <br />
                                        ProductName:
                                        <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                                        <br />
                                        PurchaseDate:
                                        <asp:TextBox ID="PurchaseDateTextBox" runat="server" Text='<%# Bind("PurchaseDate") %>' />
                                        <br />
                                        VendorEmail:
                                        <asp:TextBox ID="VendorEmailTextBox" runat="server" Text='<%# Bind("VendorEmail") %>' />
                                        <br />
                                        ImageName:
                                        <asp:TextBox ID="ImageNameTextBox" runat="server" Text='<%# Bind("ImageName") %>' />
                                        <br />
                                        ImageUrl:
                                        <asp:TextBox ID="ImageUrlTextBox" runat="server" Text='<%# Bind("ImageUrl") %>' />
                                        <br />
                                        CategoryId:
                                        <asp:TextBox ID="CategoryIdTextBox" runat="server" Text='<%# Bind("CategoryId") %>' />
                                        <br />
                                        Price:
                                        <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                                        <br />
                                        <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                                        &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </EditItemTemplate>
                                    <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <InsertItemTemplate>
                                        ProductName:
                                        <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                                        <br />
                                        PurchaseDate:
                                        <asp:TextBox ID="PurchaseDateTextBox" runat="server" Text='<%# Bind("PurchaseDate") %>' />
                                        <br />
                                        VendorEmail:
                                        <asp:TextBox ID="VendorEmailTextBox" runat="server" Text='<%# Bind("VendorEmail") %>' />
                                        <br />
                                        ImageName:
                                        <asp:TextBox ID="ImageNameTextBox" runat="server" Text='<%# Bind("ImageName") %>' />
                                        <br />
                                        ImageUrl:
                                        <asp:TextBox ID="ImageUrlTextBox" runat="server" Text='<%# Bind("ImageUrl") %>' />
                                        <br />
                                        CategoryId:
                                        <asp:TextBox ID="CategoryIdTextBox" runat="server" Text='<%# Bind("CategoryId") %>' />
                                        <br />
                                        Price:
                                        <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                                        <br />
                                        <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                                        &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                                    </InsertItemTemplate>
                                    <ItemTemplate>
                                        ProductId:
                                        <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                                        <br />
                                        ProductName:
                                        <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Bind("ProductName") %>' />
                                        <br />
                                        PurchaseDate:
                                        <asp:Label ID="PurchaseDateLabel" runat="server" Text='<%# Bind("PurchaseDate") %>' />
                                        <br />
                                        VendorEmail:
                                        <asp:Label ID="VendorEmailLabel" runat="server" Text='<%# Bind("VendorEmail") %>' />
                                        <br />
                                        ImageName:
                                        <asp:Label ID="ImageNameLabel" runat="server" Text='<%# Bind("ImageName") %>' />
                                        <br />
                                        ImageUrl:
                                        <asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Bind("ImageUrl") %>' />
                                        <br />
                                        CategoryId:
                                        <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Bind("CategoryId") %>' />
                                        <br />
                                        Price:
                                        <asp:Label ID="PriceLabel" runat="server" Text='<%# Bind("Price") %>' />
                                        <br />
                                        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                                        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                                        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
                                    </ItemTemplate>
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                </asp:FormView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db %>" DeleteCommand="DELETE FROM [Product] WHERE [ProductId] = @ProductId" InsertCommand="INSERT INTO [Product] ([ProductName], [PurchaseDate], [VendorEmail], [ImageName], [ImageUrl], [CategoryId], [Price]) VALUES (@ProductName, @PurchaseDate, @VendorEmail, @ImageName, @ImageUrl, @CategoryId, @Price)" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [ProductName] = @ProductName, [PurchaseDate] = @PurchaseDate, [VendorEmail] = @VendorEmail, [ImageName] = @ImageName, [ImageUrl] = @ImageUrl, [CategoryId] = @CategoryId, [Price] = @Price WHERE [ProductId] = @ProductId">
                                    <DeleteParameters>
                                        <asp:Parameter Name="ProductId" Type="Int32" />
                                    </DeleteParameters>
                                    <InsertParameters>
                                        <asp:Parameter Name="ProductName" Type="String" />
                                        <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                                        <asp:Parameter Name="VendorEmail" Type="String" />
                                        <asp:Parameter Name="ImageName" Type="String" />
                                        <asp:Parameter Name="ImageUrl" Type="String" />
                                        <asp:Parameter Name="CategoryId" Type="Int32" />
                                        <asp:Parameter Name="Price" Type="Decimal" />
                                    </InsertParameters>
                                    <UpdateParameters>
                                        <asp:Parameter Name="ProductName" Type="String" />
                                        <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                                        <asp:Parameter Name="VendorEmail" Type="String" />
                                        <asp:Parameter Name="ImageName" Type="String" />
                                        <asp:Parameter Name="ImageUrl" Type="String" />
                                        <asp:Parameter Name="CategoryId" Type="Int32" />
                                        <asp:Parameter Name="Price" Type="Decimal" />
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
                            <asp:Button ID="btnBack" runat="server" CssClass="clsButonAddNew" PostBackUrl="~/AllView.aspx" Text="View Option" />
                        </td>
                    </tr>
                    </table>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
