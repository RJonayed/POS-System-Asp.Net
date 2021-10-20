<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Module6ASPDotNet.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
  <style>  
     body{
            background-image: url('Images/12.jpg');
        }
</style> 
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
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center" class="style1" style="border: thin solid #008080">
                <tr>
                    <td colspan="3" style="border-bottom: thin solid #008080; font-weight: 700; text-align: center;">                       
                        <asp:Label ID="Label1" runat="server" Text="User Registration Form" Font-Bold="true" Font-Size="20"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style6">First Name :
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtfname" runat="server" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtfname" ErrorMessage="First Name!!" ForeColor="Red"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Last Name :
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtlname" runat="server" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtlname" ErrorMessage="Last Name!!" ForeColor="Red"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">City :
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtcity" runat="server" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtcity" ErrorMessage="Select City!!" ForeColor="Red"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Email :
                    </td>
                    <td class="style4">
                        <asp:TextBox ID="txtemail" runat="server" Width="120px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="txtemail" ErrorMessage="Email!!" ForeColor="Red"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ControlToValidate="txtemail" ErrorMessage="invalid email" ForeColor="Red"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style6">Password&nbsp; :</td>
                    <td class="style4">
                        <asp:TextBox ID="txtpassword" runat="server" Width="120px" TextMode="Password"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtpassword" ErrorMessage="Password!!" ForeColor="Red"
                            SetFocusOnError="True"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style5">&nbsp;</td>
                    <td class="style4">
                        <asp:Button ID="btnregistration" runat="server" Text="Register"
                            OnClick="btnregistration_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="style5">&nbsp;</td>
                    <td class="style2" colspan="2">
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="#006600"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
       </form>
</body>
</html>
