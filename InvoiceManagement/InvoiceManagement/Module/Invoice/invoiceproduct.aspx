<%@ Page Title="M | Invoice Products" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="invoiceproduct.aspx.cs" Inherits="InvoiceManagement.Module.Invoice.invoiceproduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <%-- <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>--%>
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Invoice #<asp:Label ID="lbInvoiceNumber" runat="server"></asp:Label></h3>
                    <div class="box-tools">
                        <a id="btnprevious" class="btn btn-primary" onclick="test1();" style="display: none;"><i class="glyphicon glyphicon-file"></i>Previous</a>
                        <a id="btnnext" class="btn btn-primary" onclick="test();"><i class="glyphicon glyphicon-file"></i>Next</a>
                    </div>
                </div>
                <div class="box-body">
                    <div id="div1">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="col-md-3">
                                        <label>Product :</label>
                                        <div class="form-group">
                                            <asp:DropDownList ID="ddlProduct" runat="server" CssClass="select2" Width="100%" TabIndex="0"></asp:DropDownList>
                                            <asp:Label ID="lblproduct" runat="server" ForeColor="Red" CssClass="text-bold-300"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-group">
                                            <label>Gross Qty :</label>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TabIndex="1"></asp:TextBox>
                                            <asp:Label ID="lbQty" runat="server" ForeColor="Red" CssClass="text-bold-300"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div class="form-group">
                                            <label>Qty Type :</label>
                                            <asp:DropDownList ID="ddlQtyType" runat="server" CssClass="select2" Width="100%" TabIndex="2">
                                                <asp:ListItem Text="Kg" Value="Kg"></asp:ListItem>
                                                <asp:ListItem Text="Gram" Value="Gram"></asp:ListItem>
                                                <asp:ListItem Text="Pc" Value="Pc"></asp:ListItem>
                                                <asp:ListItem Text="Judi" Value="Judi"></asp:ListItem>
                                                <asp:ListItem Text="Dozen" Value="Dozen"></asp:ListItem>
                                                <asp:ListItem Text="Box" Value="Box"></asp:ListItem>
                                            </asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Rate :</label>
                                            <asp:TextBox ID="txtRate" runat="server" CssClass="form-control" TabIndex="3"></asp:TextBox>
                                            <asp:Label ID="lbrate" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <label>Paise :</label>
                                            <asp:TextBox ID="txtPaise" runat="server" CssClass="form-control" MaxLength="2" placeholder="00" TabIndex="4"></asp:TextBox>
                                            <asp:Label ID="lbpaise" runat="server" ForeColor="Red" CssClass="text-bold-300"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <div style="padding-top: 20px;">
                                            <asp:LinkButton ID="lnkAdd" runat="server" CssClass="btn btn-primary" OnClick="lnkAdd_Click" TabIndex="5" OnClientClick="return newproductvalid();"><i class="glyphicon glyphicon-plus"></i> Add</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                        <hr />
                        <asp:UpdatePanel ID="upnl" runat="server">
                            <ContentTemplate>
                                <asp:Repeater ID="rptProduct" runat="server" OnItemCommand="rptProduct_ItemCommand">
                                    <HeaderTemplate>
                                        <table class="table table-striped table-bordered zero-configuration1" width="100%">
                                            <thead>
                                                <tr>
                                                    <%--<th style="width: 5%" class="text-center">Sr#</th>--%>
                                                    <th style="width: 30%" class="text-left">Product</th>
                                                    <th style="width: 10%" class="text-center">Qty</th>
                                                    <th style="width: 10%" class="text-center">Rs</th>
                                                    <th style="width: 10%" class="text-center">Paise</th>
                                                    <th style="width: 10%" class="text-center">Total</th>
                                                    <th class="text-center">Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <asp:HiddenField ID="hdfid" runat="server" Value='<%# Eval("InvProdDetId") %>' />
                                            <%--<td class="text-center"><%# ((RepeaterItem)Container).ItemIndex + 1%></td>--%>
                                            <td class="text-left"><%# Eval("ProductNameJoin") %></td>
                                            <td class="text-center">
                                                <asp:Label ID="lbgqtyr" runat="server" Text='<%# Eval("GrossQty") %>'></asp:Label>
                                                &nbsp;<asp:Label ID="lbqtyper" runat="server" Text='<%# Eval("QtyType") %>'></asp:Label>
                                                <asp:TextBox ID="txtQtyr" runat="server" Visible="false" CssClass="form-control"></asp:TextBox>
                                            </td>

                                            <td class="text-center">
                                                <asp:Label ID="lbrater" runat="server" Text='<%# Eval("rate") %>'></asp:Label><asp:TextBox ID="txtrater" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                                            <td class="text-center">
                                                <asp:Label ID="lbpaiser" runat="server" Text='<%# Eval("paise") %>'></asp:Label><asp:TextBox ID="txtPaiser" runat="server" Visible="false" CssClass="form-control"></asp:TextBox></td>
                                            <td class="text-center"><%# Eval("Total") %></td>
                                            <td class="text-center">
                                                <asp:UpdatePanel ID="upnl" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="lnkEdit" runat="server" CssClass="btn btn-default btn-xs" CommandName="edit"><i class="glyphicon glyphicon-pencil"></i> Edit</asp:LinkButton>
                                                        <asp:LinkButton ID="lnkUpdate" runat="server" CssClass="btn btn-default btn-xs" CommandName="update" Visible="false"><i class="glyphicon glyphicon-pencil"></i> Update</asp:LinkButton>
                                                        <asp:LinkButton ID="lnkCancel" runat="server" CssClass="btn btn-default btn-xs" CommandName="cancel" Visible="false"><i class="glyphicon glyphicon-remove"></i> Cancel</asp:LinkButton>
                                                        <asp:LinkButton ID="lnkRemove" runat="server" CssClass="btn btn-default btn-xs" CommandName="remove"><i class="glyphicon glyphicon-trash"></i> Remove</asp:LinkButton>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:AsyncPostBackTrigger ControlID="lnkEdit" />
                                                        <asp:PostBackTrigger ControlID="lnkUpdate" />
                                                        <asp:PostBackTrigger ControlID="lnkCancel" />
                                                        <asp:AsyncPostBackTrigger ControlID="lnkRemove" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
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
                    <div id="div2" style="display:none;">
                        <asp:UpdatePanel ID="upnl1" runat="server">
                        <ContentTemplate>
                            <div class="form-group">
                                <h3>Gross Total :
                            <asp:Label ID="lbGrosstotal" runat="server"></asp:Label></h3>
                            </div>
                            <div class="form-group">
                                <label>Transportation charges :</label>
                                <asp:TextBox ID="txttransport" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>Advance payment / Sales Return :</label>
                                <asp:TextBox ID="txtadpayment" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="text-right">
                                <asp:LinkButton ID="lnkNext" runat="server" OnClick="lnkNext_Click" CssClass="btn btn-primary">Okay, Generate Bill</asp:LinkButton>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    <div class="modal fade modal" id="modelgenerate" role="dialog" data-backdrop="false">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header bg-green-gradient with-border">
                    <button type="button" class="close" data-dismiss="modal" onclick="clearfield();">&times;</button>
                    <h4 class="modal-title">Charges</h4>
                </div>
                <div class="modal-body">
                   
                </div>
            </div>
        </div>
    </div>
    <script src="/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>
        $(".zero-configuration").DataTable();
        function tablescript() {
            $(".zero-configuration").DataTable();
            $(".select2").select2();
        }
        function test() {
            $("#div1").css("display", "none");
            $("#div2").css("display", "block");
            $("#btnprevious").css("display", "block");
            $("#btnnext").css("display", "none");
        }
        function test1() {
            $("#div2").css("display", "none");
            $("#div1").css("display", "block");
            $("#btnprevious").css("display", "none");
            $("#btnnext").css("display", "block");
        }

        function newproductvalid() {
            if (document.getElementById("<%=ddlProduct.ClientID %>").value == "0" || document.getElementById("<%=txtQty.ClientID %>").value == "" || document.getElementById("<%=txtRate.ClientID %>").value == "") {
                if (document.getElementById("<%=ddlProduct.ClientID %>").value == "0") {
                    document.getElementById("<%=lblproduct.ClientID %>").innerHTML = "Please select product.";
                    document.getElementById("<%=ddlProduct.ClientID %>").focus();
                    //return false;
                } else {
                    document.getElementById("<%=lblproduct.ClientID %>").innerHTML = "";
                }
                if (document.getElementById("<%=txtQty.ClientID %>").value == "") {
                    document.getElementById("<%=lbQty.ClientID %>").innerHTML = "Please enter Qty";
                    document.getElementById("<%=txtQty.ClientID %>").focus();
                    //return false;
                } else {
                    document.getElementById("<%=lbQty.ClientID %>").innerHTML = "";
                }
                if (document.getElementById("<%=txtRate.ClientID %>").value == "") {
                    document.getElementById("<%=lbrate.ClientID %>").innerHTML = "Please enter Rate";
                    document.getElementById("<%=txtRate.ClientID %>").focus();
                    //return false;
                } else {
                    document.getElementById("<%=lbrate.ClientID %>").innerHTML = "";
                }
                <%--if (document.getElementById("<%=txtPaise.ClientID %>").value == "") {
                document.getElementById("<%=lbaddress.ClientID %>").innerHTML = "Please enter rate in 2 digits";
                document.getElementById("<%=txtPaise.ClientID %>").focus();
                return false;
            }--%>
                return false;
            } else {
                ocument.getElementById("<%=ddlProduct.ClientID %>").focus();
                return true;
            }

        }
        function clearfield() {
            document.getElementById("<%=txttransport.ClientID %>").value = "";
            document.getElementById("<%=txtadpayment.ClientID %>").value = "";
        }
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        if (prm != null) {
            prm.add_endRequest(function (sender, e) {
                if (sender._postBackSettings.panelsToUpdate != null) {
                    $(".zero-configuration").DataTable();
                    $(".select2").select2();
                } else {

                }
            })
        }
        $(".select2").select2();

    </script>
</asp:Content>
