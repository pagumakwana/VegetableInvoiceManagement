<%@ Page Title="M | List Client" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="listclient.aspx.cs" Inherits="InvoiceManagement.Module.Client.listclient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="/plugins/pnotify-master/dist/pnotify.css" rel="stylesheet" />
    <script src="/plugins/pnotify-master/dist/pnotify.js"></script>
    <div class="row">
        <div class="col-md-4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">New Client</h3>
                        </div>
                        <div role="form">
                            <div class="box-body">
                                <div class="form-group">
                                    <label for="txtClientName">Client Name :</label>&nbsp;<asp:Label ID="lbclientname" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                    <asp:TextBox ID="txtClientName" runat="server" type="text" class="form-control" placeholder="Enter FullName"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtMobile">Mobile :</label>&nbsp;<asp:Label ID="lbmobile" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                    <asp:TextBox ID="txtMobile" runat="server" type="text" class="form-control" placeholder="Enter Mobile Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="box-footer text-right">
                                <asp:LinkButton ID="lnkNewClient" runat="server" CssClass="btn btn-primary" OnClick="lnkNewClient_Click" OnClientClick="return newclient();">Add Client</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="col-md-8">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="box box-primary">
                        <div class="box-header with-border">
                            <h3 class="box-title">Client List</h3>
                        </div>
                        <div role="form">
                            <div class="box-body">
                                <asp:Repeater ID="rptClient" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-hover table-bordered zero-configuration" width="100%">
                                            <thead>
                                                <tr>
                                                    <th style="width: 5%">Sr#</th>
                                                    <th style="width: 15%">Full Name</th>
                                                    <th style="width: 15%">Mobile</th>
                                                    <th style="width: 10%">Date</th>
                                                    <th style="width: 15%">Added By</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# ((RepeaterItem)Container).ItemIndex + 1%></td>
                                            <td><%# Eval("FullName") %></td>
                                            <td><%# Eval("Mobile") %></td>
                                            <td><%# Eval("Createdonutc") %> </td>
                                            <td><%# Eval("username") %></td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </tbody>
                                 </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <script src="/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>
        $(".zero-configuration").DataTable();
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $(".zero-configuration").DataTable();
                    //clientadd();
                }
            })
        }
        function clientadd() {
           var test = new PNotify({
                title: 'Success',
                text: 'Client added successfully.',
                type: 'success'
            });
        }
    </script>
    <script>
        function newclient() {
            document.getElementById("<%=lbclientname.ClientID %>").innerHTML = "";
            document.getElementById("<%=lbmobile.ClientID %>").innerHTML = "";
            var digits = "0123456789";
            var temp;
            if (document.getElementById("<%=txtClientName.ClientID %>").value == "" && document.getElementById("<%=txtMobile.ClientID %>").value == "") {
                if (document.getElementById("<%=txtClientName.ClientID %>").value == "") {
                    document.getElementById("<%=lbclientname.ClientID %>").innerHTML = "Clientname can not be blank";
                    document.getElementById("<%=txtClientName.ClientID %>").focus();

                }
               <%-- if (document.getElementById("<%=txtMobile.ClientID %>").value == "") {
                    document.getElementById("<%=lbmobile.ClientID %>").innerHTML = "Mobile number can not be blank";
                    if (document.getElementById("<%=txtClientName.ClientID %>").value != "") {
                        document.getElementById("<%=txtMobile.ClientID %>").focus();
                    }

                }--%>
                return false;
            }
            if (document.getElementById("<%=txtClientName.ClientID %>").value == "") {
                document.getElementById("<%=lbclientname.ClientID %>").innerHTML = "Clientname can not be blank";
                document.getElementById("<%=txtClientName.ClientID %>").focus();
                return false;
            }
            if (document.getElementById("<%=txtMobile.ClientID %>").value == "") {
                document.getElementById("<%=lbmobile.ClientID %>").innerHTML = "Mobile number can not be blank";
                document.getElementById("<%=txtMobile.ClientID %>").focus();
                return false;
            }

            for (var i = 0; i < document.getElementById("<%=txtMobile.ClientID %>").value.length; i++) {
                temp = document.getElementById("<%=txtMobile.ClientID%>").value.substring(i, i + 1);
                if (digits.indexOf(temp) == -1) {
                    document.getElementById("<%=lbmobile.ClientID %>").innerHTML = "Please enter correct number";
                    document.getElementById("<%=txtMobile.ClientID%>").focus();
                    return false;
                }
            }
            return true;
        }
    </script>
</asp:Content>
