<%@ Page Title="M | New Invoice" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="newinvoice.aspx.cs" Inherits="InvoiceManagement.Module.Invoice.newinvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="/plugins/datepicker/datepicker3.css" />
    <script src="/plugins/datepicker/bootstrap-datepicker.js"></script>
      <link href="/Plugins/jquery-ui-1.12.1/jquery-ui.min.css" rel="stylesheet" />
     <script src="/Plugins/jquery-ui-1.12.1/jquery-ui.min.js"></script>
    <link href="/plugins/bootstrap-multiselect-master/dist/css/bootstrap-multiselect.css" rel="stylesheet" />
    <script src="/plugins/bootstrap-multiselect-master/dist/js/bootstrap-multiselect.js"></script>
    <script>
        $(function () {
            $("[id$=txtclient]").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: '/Logics/ClientService.asmx/GetCustomers',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('-')[0],
                                    val: item.split('-')[1]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                },
                minLength: 1
            });
        });
    </script>
    <div class="row">
        <div class="col-md-5">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">New Item</h3>
                </div>
                <div class="box-body">
                    <div class="row">
                        <div class="col-md-12">&nbsp;</div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-inline">
                            <label class="col-md-4">Date :</label>
                            <div class="col-md-6">

                                <div class="input-group date">
                                    <div class="input-group-addon">
                                        <i class="glyphicon glyphicon-calendar"></i>
                                    </div>
                                    <input type="text" class="form-control pull-right" id="datepicker" name="datepicker" />
                                </div>
                                <asp:Label ID="lbdate" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="form-group">
                            <label class="col-md-4">Bill Time :</label>
                            <div class="col-md-6">

                                <asp:ListBox ID="lsttime" runat="server" SelectionMode="Multiple">
                                    <asp:ListItem Text="Morning" Value="1" />
                                    <asp:ListItem Text="Afternoon" Value="2" />
                                    <asp:ListItem Text="Evening" Value="3" />
                                </asp:ListBox>
                                <asp:Label ID="lbTime" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                            </div>
                        </div>
                    </div>
                    <br />
                     <div class="row">
                        <div class="form-group">
                            <label class="col-md-4">Client Name : </label>
                            <div class="col-md-8">
                                <asp:HiddenField ID="hfCustomerId" runat="server" />
                                <asp:TextBox ID="txtclient" runat="server"></asp:TextBox>
                                <asp:Label ID="lberror" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="row" style="display:none;">
                        <div class="form-group">
                            <label class="col-md-4">Client Name : </label>
                            <div class="col-md-8">
                                <asp:UpdatePanel ID="upnl" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="select2" Width="70%">
                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                        </asp:DropDownList>
                                        <a class="btn btn-primary btn-sm" href="#modelgenerate" data-toggle="modal"><i class="glyphicon glyphicon-user"></i>&nbsp;Add</a>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Label ID="lbClientvalid" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                            </div>
                        </div>
                    </div>

                    <br />
                    <div class="row">

                        <div class="form-group">

                            <label class="col-md-4">Address : </label>
                            <div class="col-md-6">

                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                                <asp:Label ID="lbaddress" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="box-footer">

                    <div class="text-right">
                        <asp:LinkButton ID="lnkCreate" runat="server" CssClass="btn btn-primary" OnClick="lnkCreate_Click" OnClientClick="return newinvoicevalid();"><i class="glyphicon glyphicon-pencil"></i> Next</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modelgenerate" role="dialog" data-backdrop="false">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-green-gradient with-border">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Charges</h4>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upnl1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <label for="txtClientName">Client Name :</label>&nbsp;<asp:Label ID="lbclientname" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                <asp:TextBox ID="txtClientName" runat="server" type="text" class="form-control" placeholder="Enter FullName"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtMobile">Mobile :</label>&nbsp;<asp:Label ID="lbmobile" runat="server" ForeColor="Red" CssClass="text-bold-300"> </asp:Label>
                                <asp:TextBox ID="txtMobile" runat="server" type="text" class="form-control" placeholder="Enter Mobile Number"></asp:TextBox>
                            </div>
                            <asp:LinkButton ID="lnkNewClient" runat="server" CssClass="btn btn-primary" OnClick="lnkNewClient_Click" OnClientClick="return newclient();">Add Client</asp:LinkButton>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <script>
        $(document).ready(function () {
            $('#datepicker').datepicker({ autoclose: true, dateFormat: 'dd-mm-yy' });

            $('[id*=lsttime]').multiselect({
                includeSelectAllOption: true
            });
        });
        function newinvoicevalid() {
            var txtVal = $('#datepicker').val();
            //var options = $('#lsttime > option:selected');
            if (txtVal == "" || document.getElementById("<%=txtclient.ClientID %>").value == "" || document.getElementById("<%=txtAddress.ClientID %>").value == "") {
                if (txtVal == "") {
                    document.getElementById("<%=lbdate.ClientID %>").innerHTML = "Please select date first.";
                    $('#datepicker').focus();
                    //return false;
                } else {
                    document.getElementById("<%=lbdate.ClientID %>").innerHTML = "";
                }
                if (document.getElementById("<%=txtclient.ClientID %>").value == "") {
                    document.getElementById("<%=lberror.ClientID %>").innerHTML = "Please type clientname.";
                    document.getElementById("<%=txtclient.ClientID %>").focus();
                    //return false;
                } else {
                    document.getElementById("<%=lberror.ClientID %>").innerHTML = "";
                }
                if (document.getElementById("<%=txtAddress.ClientID %>").value == "") {
                    document.getElementById("<%=lbaddress.ClientID %>").innerHTML = "Address can not be blank.";
                    document.getElementById("<%=txtAddress.ClientID %>").focus();

                } else {
                    document.getElementById("<%=lbaddress.ClientID %>").innerHTML = "";
                }

                <%-- if (options.length == 0) {
                    document.getElementById("<%=lbTime.ClientID %>").innerHTML = "Please select time.";
                }--%>
                return false;
            } else {

                return true;
            }
        }
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
           <%-- if (document.getElementById("<%=txtMobile.ClientID %>").value == "") {
                document.getElementById("<%=lbmobile.ClientID %>").innerHTML = "Mobile number can not be blank";
                document.getElementById("<%=txtMobile.ClientID %>").focus();
                return false;
            }--%>

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
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $(".select2").select2();
                }
            });
        }
    </script>
</asp:Content>
