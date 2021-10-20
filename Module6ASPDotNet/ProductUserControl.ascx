
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductUserControl.ascx.cs" Inherits="Module6ASPDotNet.ProductUserControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<link href="menu.css" rel="stylesheet" />
<link href="StyleOne.css" rel="stylesheet" />
<style> .img{height:70px; width:60px;}
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        height: 21px;
    }
    .auto-style3 {
        width: 265px;
    }
    </style>
<table class="auto-style1">
    <asp:HiddenField ID="HiddenImageName" runat="server" />
    <asp:HiddenField ID="HiddenImageUrl" runat="server" />
    <tr>
        <td  colspan="3"><h2>Category CRUD</h2></td>
        <td></td>
    </tr>
    <tr>
        <td >Category Name</td>
        <td>
            <asp:TextBox ID="txtCategory" runat="server" CssClass="clsTextBox" Width="150px"></asp:TextBox>
        </td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td ></td>
        <td>
            <asp:Button ID="btnCateSave" runat="server" Text="Save" Width="91px" OnClick="btnCateSave_Click" CausesValidation="false" CssClass="clsButonSave" />
        </td>
        <td class="auto-style3">
        </td>
        <td class="auto-style2">
        </td>
    </tr>
    <tr>
        <td >&nbsp;</td>
        <td>&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>    
    <tr>
        <td >
            <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtProductName" runat="server" CssClass="clsTextBox" Width="150px"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Purchase Date"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtDate" runat="server" CssClass="clsTextBox" Width="150px" OnTextChanged="txtDate_TextChanged"></asp:TextBox>
            <asp:CalendarExtender ID="ceOpBalDate" runat="server" Format="dd MMM yyyy" TargetControlID="txtDate"></asp:CalendarExtender>
        </td>
    </tr>  
    <tr>
        <td >
            <asp:Label ID="Label4" runat="server" Text="Confirm Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="clsTextBox" Width="150px"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Vendor Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtConfirmEmil" runat="server" CssClass="clsTextBox" Width="150px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td >&nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td >
            <asp:Label ID="Label6" runat="server" Text="Product Image"></asp:Label>
        </td>
        <td >
            <asp:Image ID="Image1" runat="server" class="img" />
            <asp:FileUpload ID="FileUpload1" runat="server" onchange="if(confirm('upload'+this.value+'?')) this.form.submit()" CssClass="clsButon"  />
        </td>
        <td >
            <br />
        </td>
        <td >
            &nbsp;</td>
    </tr>
    <tr>
        <td >
            <asp:Label ID="Label5" runat="server" Text="Category"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
            </asp:DropDownList> &nbsp;&nbsp;
            <asp:CompareValidator ControlToValidate="ddlCategory" ID="CompareValidator1"
                 ErrorMessage="Please select a category"
                    runat="server" Display="Dynamic" 
                 Operator="NotEqual" ValueToCompare="0" Type="Integer" />
        </td>
        <td class="auto-style3">
            &nbsp;&nbsp;
            </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td >
            <asp:Label ID="Label7" runat="server" Text="Product Price"></asp:Label>
        </td>
        <td >
            <asp:TextBox ID="txtPrice" runat="server" CssClass="clsTextBox" Width="150px"></asp:TextBox>
        </td>
        <td >
        </td>
        <td >
            </td>
    </tr>
     <tr>
        <td >&nbsp;</td>
        <td >
            <asp:Button ID="btnSaveProduct" runat="server" Text="save" Width="80px" OnClick="btnSaveProduct_Click" CssClass="clsButonSave" />&nbsp;&nbsp;
            <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80px" CssClass="clsButonRefresh" />
         </td>
        <td class="auto-style3" >
            &nbsp;&nbsp;
            </td>
        <td >
            &nbsp;</td>
    </tr>
</table>