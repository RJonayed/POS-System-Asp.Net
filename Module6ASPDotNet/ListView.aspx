<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListView.aspx.cs" Inherits="Module6ASPDotNet.ListView" %>
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
            
        </table>
        <div>
            <asp:Panel ID="Panel2" runat="server" Width="1000" CssClass="pnlBackColorCommon" Height="400">
                <asp:ListView ID="ListView1" runat="server" DataKeyNames="ProductId" DataSourceID="SqlDataSource1" InsertItemPosition="FirstItem">
                    <AlternatingItemTemplate>
                        <li style="background-color: #FFF8DC;">ProductId:
                            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                            <br />
                            ProductName:
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                            <br />
                            PurchaseDate:
                            <asp:Label ID="PurchaseDateLabel" runat="server" Text='<%# Eval("PurchaseDate") %>' />
                            <br />
                            VendorEmail:
                            <asp:Label ID="VendorEmailLabel" runat="server" Text='<%# Eval("VendorEmail") %>' />
                            <br />
                            ImageUrl:
                            <asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Eval("ImageUrl") %>' />
                            <br />
                            CategoryId:
                            <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                            <br />
                            ImageName:
                            <asp:Label ID="ImageNameLabel" runat="server" Text='<%# Eval("ImageName") %>' />
                            <br />
                            Price:
                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                            <br />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </li>
                    </AlternatingItemTemplate>
                    <EditItemTemplate>
                        <li style="background-color: #008A8C; color: #FFFFFF;">ProductId:
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
                            ImageUrl:
                            <asp:TextBox ID="ImageUrlTextBox" runat="server" Text='<%# Bind("ImageUrl") %>' />
                            <br />
                            CategoryId:
                            <asp:TextBox ID="CategoryIdTextBox" runat="server" Text='<%# Bind("CategoryId") %>' />
                            <br />
                            ImageName:
                            <asp:TextBox ID="ImageNameTextBox" runat="server" Text='<%# Bind("ImageName") %>' />
                            <br />
                            Price:
                            <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                            <br />
                            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                        </li>
                    </EditItemTemplate>
                    <EmptyDataTemplate>
                        No data was returned.
                    </EmptyDataTemplate>
                    <InsertItemTemplate>
                        <li style="">ProductName:
                            <asp:TextBox ID="ProductNameTextBox" runat="server" Text='<%# Bind("ProductName") %>' />
                            <br />
                            PurchaseDate:
                            <asp:TextBox ID="PurchaseDateTextBox" runat="server" Text='<%# Bind("PurchaseDate") %>' />
                            <br />
                            VendorEmail:
                            <asp:TextBox ID="VendorEmailTextBox" runat="server" Text='<%# Bind("VendorEmail") %>' />
                            <br />
                            ImageUrl:
                            <asp:TextBox ID="ImageUrlTextBox" runat="server" Text='<%# Bind("ImageUrl") %>' />
                            <br />
                            CategoryId:
                            <asp:TextBox ID="CategoryIdTextBox" runat="server" Text='<%# Bind("CategoryId") %>' />
                            <br />
                            ImageName:
                            <asp:TextBox ID="ImageNameTextBox" runat="server" Text='<%# Bind("ImageName") %>' />
                            <br />
                            Price:
                            <asp:TextBox ID="PriceTextBox" runat="server" Text='<%# Bind("Price") %>' />
                            <br />
                            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                        </li>
                    </InsertItemTemplate>
                    <ItemSeparatorTemplate>
                        <br />
                    </ItemSeparatorTemplate>
                    <ItemTemplate>
                        <li style="background-color: #DCDCDC; color: #000000;">ProductId:
                            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                            <br />
                            ProductName:
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                            <br />
                            PurchaseDate:
                            <asp:Label ID="PurchaseDateLabel" runat="server" Text='<%# Eval("PurchaseDate") %>' />
                            <br />
                            Email:
                            <asp:Label ID="VendorEmailLabel" runat="server" Text='<%# Eval("VendorEmail") %>' />
                            <br />
                            Image:
                            <%--<asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Eval("ImageUrl") %>' />                          --%>
                        <asp:Image ID="Image1" runat="server" style="height:60px;width:70px;" ImageUrl='<%# Eval("ImageUrl") %>'/>
                            <br />
                            CategoryId:
                            <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                            <br />
                            ImageName:
                            <asp:Label ID="ImageNameLabel" runat="server" Text='<%# Eval("ImageName") %>' />
                            <br />
                            Price:
                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                            <br />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </li>
                    </ItemTemplate>
                    <LayoutTemplate>
                        <ul id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <li runat="server" id="itemPlaceholder" />
                        </ul>
                        <div style="text-align: center; background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </LayoutTemplate>
                    <SelectedItemTemplate>
                        <li style="background-color: #008A8C; font-weight: bold; color: #FFFFFF;">ProductId:
                            <asp:Label ID="ProductIdLabel" runat="server" Text='<%# Eval("ProductId") %>' />
                            <br />
                            ProductName:
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                            <br />
                            PurchaseDate:
                            <asp:Label ID="PurchaseDateLabel" runat="server" Text='<%# Eval("PurchaseDate") %>' />
                            <br />
                            VendorEmail:
                            <asp:Label ID="VendorEmailLabel" runat="server" Text='<%# Eval("VendorEmail") %>' />
                            <br />
                            ImageUrl:
                            <asp:Label ID="ImageUrlLabel" runat="server" Text='<%# Eval("ImageUrl") %>' />
                            <br />
                            CategoryId:
                            <asp:Label ID="CategoryIdLabel" runat="server" Text='<%# Eval("CategoryId") %>' />
                            <br />
                            ImageName:
                            <asp:Label ID="ImageNameLabel" runat="server" Text='<%# Eval("ImageName") %>' />
                            <br />
                            Price:
                            <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
                            <br />
                            <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                            <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                        </li>
                    </SelectedItemTemplate>
                </asp:ListView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:db %>" SelectCommand="SELECT [ProductId], [ProductName], [PurchaseDate], [VendorEmail], [ImageUrl], [CategoryId], [ImageName], [Price] FROM [Product]" DeleteCommand="DELETE FROM [Product] WHERE [ProductId] = @ProductId" InsertCommand="INSERT INTO [Product] ([ProductName], [PurchaseDate], [VendorEmail], [ImageUrl], [CategoryId], [ImageName], [Price]) VALUES (@ProductName, @PurchaseDate, @VendorEmail, @ImageUrl, @CategoryId, @ImageName, @Price)" UpdateCommand="UPDATE [Product] SET [ProductName] = @ProductName, [PurchaseDate] = @PurchaseDate, [VendorEmail] = @VendorEmail, [ImageUrl] = @ImageUrl, [CategoryId] = @CategoryId, [ImageName] = @ImageName, [Price] = @Price WHERE [ProductId] = @ProductId">
                    <DeleteParameters>
                        <asp:Parameter Name="ProductId" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="ProductName" Type="String" />
                        <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                        <asp:Parameter Name="VendorEmail" Type="String" />
                        <asp:Parameter Name="ImageUrl" Type="String" />
                        <asp:Parameter Name="CategoryId" Type="Int32" />
                        <asp:Parameter Name="ImageName" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="ProductName" Type="String" />
                        <asp:Parameter Name="PurchaseDate" Type="DateTime" />
                        <asp:Parameter Name="VendorEmail" Type="String" />
                        <asp:Parameter Name="ImageUrl" Type="String" />
                        <asp:Parameter Name="CategoryId" Type="Int32" />
                        <asp:Parameter Name="ImageName" Type="String" />
                        <asp:Parameter Name="Price" Type="Decimal" />
                        <asp:Parameter Name="ProductId" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource><br />
            </asp:Panel>
            <table>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnBack" runat="server" Text="View Option" PostBackUrl="~/AllView.aspx" CssClass="clsButonAddNew" /></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                </table>
        </div>
    </asp:Panel>
</asp:Content>
