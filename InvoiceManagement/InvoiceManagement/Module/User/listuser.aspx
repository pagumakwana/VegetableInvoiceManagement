<%@ Page Title="M | List User" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="listuser.aspx.cs" Inherits="InvoiceManagement.Module.User.listuser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <div class="row">
        <!-- left column -->
        <div class="col-md-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">New User</h3>
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->
                        <div role="form">
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtFullName">Full Name :</label>&nbsp;<asp:Label ID="lbname" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                    <asp:TextBox ID="txtFullName" runat="server" type="text" class="form-control" placeholder="Enter FullName"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtEmail1">Email :</label>&nbsp;<asp:Label ID="lbemail" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                    <asp:TextBox ID="txtEmail1" runat="server" type="text" class="form-control" placeholder="Enter Email"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtPwd1">Password :</label>&nbsp;<asp:Label ID="lbpwd" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                    <asp:TextBox ID="txtPwd1" runat="server" type="password" class="form-control" placeholder="Enter Password"></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.box-body -->

                            <div class="box-footer text-right">
                                <asp:LinkButton ID="lnkNewUser" runat="server" CssClass="btn btn-primary" OnClick="lnkNewUser_Click" OnClientClick="return usercreate();">Add User</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <!--/.col (left) -->
        <!-- left column -->
        <div class="col-md-8">
            <!-- general form elements -->
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">User list</h3>
                </div>
                <div class="box-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:Repeater ID="rptUser" runat="server">
                                <HeaderTemplate>
                                    <table class="table table-striped table-hover table-bordered zero-configuration" width="100%">
                                        <thead>
                                            <tr>
                                                <th style="width: 5%">Sr#</th>
                                                <th style="width: 20%">Full Name</th>
                                                <th style="width: 25%">Email</th>
                                                <th style="width: 15%">Password</th>
                                                <th style="width: 15%">Date</th>
                                                <th style="width: 20%">Added By</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# ((RepeaterItem)Container).ItemIndex + 1%></td>
                                        <td><%# Eval("FullName") %></td>
                                        <td><%# Eval("Email") %></td>
                                        <td><%# Eval("Pwd") %></td>
                                        <td><%# Eval("Createdonutc","{0:dd-MM-yyyy}") %> </td>
                                        <td><%# Eval("CreatedBy") %></td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                 </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script src="/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $(".zero-configuration").DataTable();

                }
            })
        }
        $(".zero-configuration").DataTable();
        function usercreate() {

            var emailid = document.getElementById("<%=txtEmail1.ClientID %>").value;
            var pwd = document.getElementById("<%=txtPwd1.ClientID %>").value;
            var emailPat = /^(\".*\"|[A-Za-z]\w*)@(\[\d{1,3}(\.\d{1,3}){3}]|[A-Za-z]\w*(\.[A-Za-z]\w*)+)$/;
            if (document.getElementById("<%=txtFullName.ClientID %>").value == "") {
                document.getElementById("<%=lbname.ClientID %>").innerHTML = "Fullname can not be blank";
                document.getElementById("<%=txtPwd1.ClientID %>").focus();
                return false;
            }
            var matchArray = emailid.match(emailPat);
            if (document.getElementById("<%=txtEmail1.ClientID %>").value == "") {
               document.getElementById("<%=lbemail.ClientID %>").innerHTML = "Email id can not be blank";
               document.getElementById("<%=txtEmail1.ClientID %>").focus();
               return false;
           }
           if (matchArray == null) {
               document.getElementById("<%=lbemail.ClientID %>").innerHTML = "Your email address seems incorrect. Please try again.";
               document.getElementById("<%=txtEmail1.ClientID %>").focus();
               return false;
           }
           if (document.getElementById("<%=txtPwd1.ClientID %>").value == "") {
                document.getElementById("<%=lbpwd.ClientID %>").innerHTML = "Password can not be blank";
                document.getElementById("<%=txtPwd1.ClientID %>").focus();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
