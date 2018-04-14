<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="InvoiceManagement.Module.Account.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title >M | Log in</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="/plugins/iCheck/square/blue.css" />
</head>
<body class="hold-transition login-page" style="overflow-y: hidden;">
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
                <a href="login.aspx"><b>M</b>Vegetable suppliers</a>
            </div>
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Sign in to start your session</p>
                <asp:Label ID="lbuname" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                <div class="form-group has-feedback">
                    
                    <asp:TextBox ID="txtEmail" runat="server" type="email" CssClass="form-control" placeholder="Email"></asp:TextBox>
                    <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                </div>
                <asp:Label ID="lbpwd" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                <div class="form-group has-feedback">
                    
                    <asp:TextBox ID="txtPwd" runat="server" type="password" class="form-control" placeholder="Password"></asp:TextBox>
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class="col-xs-8">
                        <div class="checkbox icheck">
                            <label>
                                <input type="checkbox">
                                Remember Me
           
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-xs-4">
                        <asp:LinkButton ID="lnkLogin" runat="server" CssClass="btn btn-primary btn-block btn-flat" OnClick="lnkLogin_Click" OnClientClick="return login();">Sign In</asp:LinkButton>
                    </div>
                    <!-- /.col -->
                </div>


                <%--<a href="#">I forgot my password</a><br>--%>
            </div>
            <!-- /.login-box-body -->
        </div>
        <!-- /.login-box -->

    </form>
    <!-- jQuery 2.2.3 -->
    <script src="/plugins/jQuery/jquery-2.2.3.min.js"></script>
    <!-- Bootstra.6 -->
    <script src="/bootstrap/js/bootstrap.min.js"></script>
    <!-- iCheck -->
    <script src="/plugins/iCheck/icheck.min.js"></script>
    <script>
        $(function () {
            $('input').iCheck({
                checkboxClass: 'icheckbox_square-blue',
                radioClass: 'iradio_square-blue',
                increaseArea: '20%' // optional
            });
        });
        function login() {
            
            var emailid = document.getElementById("<%=txtEmail.ClientID %>").value;
            var pwd = document.getElementById("<%=txtPwd.ClientID %>").value;
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            
            var matchArray = emailid.match(emailPat);
            if (document.getElementById("<%=txtEmail.ClientID %>").value == "") {
                document.getElementById("<%=lbuname.ClientID %>").innerHTML = "Email id can not be blank";
                document.getElementById("<%=txtEmail.ClientID %>").focus();
                 return false;
            }
            if (matchArray == null) {
                document.getElementById("<%=lbuname.ClientID %>").innerHTML = "Your email address seems incorrect. Please try again.";
                document.getElementById("<%=txtEmail.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=txtPwd.ClientID %>").value == "") {
                document.getElementById("<%=lbpwd.ClientID %>").innerHTML = "Password can not be blank";
                document.getElementById("<%=txtPwd.ClientID %>").focus();
                return false;
            }
            return true;
        }
</script>
</body>
</html>
