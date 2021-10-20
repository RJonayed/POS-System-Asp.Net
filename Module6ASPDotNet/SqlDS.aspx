<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SqlDS.aspx.cs" Inherits="Module6ASPDotNet.SqlDS" %>

<%@ Register Src="~/ProductUserControl.ascx" TagPrefix="uc1" TagName="ProductUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <asp:Panel ID="Panel1" runat="server" Width="1000" Height="700px" CssClass="pnlBackColorCommon">
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label51" runat="server" CssClass="clsFormHeading" Text="Product SQL  QRUD" Width="1000px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td></td>
                
            </tr>
        </table>
        <asp:gridview ID="gridview1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="SqlDataSource1" OnRowDeleting="gridview1_RowDeleting" OnRowUpdating="gridview1_RowUpdating" CellPadding="4" Width="980px" ForeColor="#333333" GridLines="None"  >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CausesValidation="false" />
                <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                <asp:TemplateField HeaderText="Product Name" SortExpression="ProductName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("ProductName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Purchase Date" SortExpression="PurchaseDate">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("PurchaseDate") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("PurchaseDate") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Vendor Email" SortExpression="VendorEmail">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("VendorEmail") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("VendorEmail") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image Name" SortExpression="ImageName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("ImageName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("ImageName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Image" SortExpression="ImageUrl">
                    <EditItemTemplate>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" style="height:60px;width:70px;" ImageUrl='<%# Eval("ImageUrl") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Category Id" SortExpression="CategoryId">
                    <EditItemTemplate>
                          <asp:DropDownList ID="ddl1" runat="server" SelectedValue='<%#Bind("CategoryId") %>' DataTextField="CategoryName" DataValueField="CategoryId" DataSourceID="SqlDataSource2"  >
                        </asp:DropDownList>
                     </EditItemTemplate>
                     <ItemTemplate>
                          <asp:DropDownList ID="ddl" runat="server" SelectedValue='<%#Bind("CategoryId") %>' DataTextField="CategoryName" DataValueField="CategoryId" DataSourceID="SqlDataSource2"  Enabled="false" >
                        </asp:DropDownList>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Price") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" ForeColor="White" Font-Bold="True" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#666666" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:gridview>
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
        <asp:SqlDataSource ID="SqlDataSource2" 
            runat="server" 
            ConnectionString="<%$ ConnectionStrings:db %>" 
            SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
        <uc1:ProductUserControl runat="server" ID="ProductUserControl" />
    </div>
        </asp:Panel>
</asp:Content>
