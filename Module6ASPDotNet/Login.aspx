<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Module6ASPDotNet.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/site.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <style>
        body{
            background-image: url('Images/29.jpg');
        }
    </style>
</head>
<body>    
     <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-12 col-md-12 col-sm-12">
                    <%--<img alt="" src="Images/icon.ico" />--%>
                    <h2>
                     <asp:Label ID="lblComName" runat="server" Text="RJ SHOP LIMITED" ForeColor="White"></asp:Label></h2>
                </div>
            </div>
        </div>
        <div>
            <div class="form-group row">
                <div class="offset-3 col-6 offset-3">

                    <div class="col-xs-2">
                        <label for="exampleInputEmail1" class="form-label"><h3>User Name/Email ID</h3></label>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" aria-describedby="emailHelp" placeholder="User Name/ID" Width="320px"></asp:TextBox>
                    </div>
                    <div class="col-xs-2">
                        <label for="exampleInputPassword1" class="form-label"><h3>Password</h3></label>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password" Width="320px"></asp:TextBox>
                    </div>
                    <asp:Button type="button" ID="btnLog" runat="server" CssClass="btn btn-primary btn-sm" OnClick="Button1_Click" Text="Sign In"/>
                    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Register.aspx" Font-Bold="True" Font-Size="15pt" ForeColor="Black">Register here..</asp:LinkButton>
                    <%--<asp:Button ID="btnRegister" runat="server" CssClass="btn btn-secondary btn-sm"  Text="Register" OnClick="btnRegister_Click" />--%>
                    <asp:CheckBox ID="chkRmd" runat="server" Text="Remember Me" Font-Bold="True" Font-Size="15pt"/>
                    <asp:Label ID="lblMsg" runat="server" Text="......"></asp:Label>
                </div>               
            </div>
        </div>
    </form>   
</body>
</html>
