<%@ Page Title="M | List Invoice" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="listinvoice.aspx.cs" Inherits="InvoiceManagement.Module.Invoice.listinvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="/plugins/datatables/dataTables.bootstrap.css" rel="stylesheet" />
    <link href="/plugins/font-awesome-4.7.0/css/font-awesome.min.css" rel="stylesheet" />
    <div class="row">
        <div class="col-md-12">
            <div class="box box-primary">
                <div class="box-header with-border">
                    <h3 class="box-title">Invoice Details</h3>
                </div>
                <div class="box-body">
                    <asp:Repeater ID="rptListInvoice" runat="server" OnItemCommand="rptListInvoice_ItemCommand">
                        <HeaderTemplate>
                            <table class="table table-striped table-bordered table-responsive" width="100%">
                                <thead>
                                    <tr>
                                        <%--<th class="text-center">Sr#</th>--%>
                                        <th class="text-left" width="5%">Invoice Number</th>
                                        <th class="text-center">Client Name</th>
                                        <th class="text-center">Address</th>
                                        <%-- <th class="text-center">Transport Charges</th>
                                    <th class="text-center">Advanced Pay</th>
                                    <th class="text-center">Payment due</th>
                                    <th class="text-center">Gross Total</th>--%>
                                        <th class="text-right">Final Total</th>
                                        <th class="text-center">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <%--<td class="text-center"><%# ((RepeaterItem)Container).ItemIndex + 1%></td>--%>
                                <td class="text-left">#<asp:Label ID="lbinvid" runat="server" Text='<%# Eval("InvId") %>'></asp:Label>
                                </td>
                                <td class="text-center"><%# Eval("clientname") %></td>
                                <td class="text-center"><%# Eval("address") %></td>
                                <%-- <td class="text-center"><i class="fa fa-rupee"></i>&nbsp;<%# Eval("Transportcharges") %></td>
                            <td class="text-center"><i class="fa fa-rupee"></i>&nbsp;<%# Eval("Advancepayment") %></td>
                            <td class="text-center"><i class="fa fa-rupee"></i>&nbsp;<%# Eval("Paymentdue") %></td>
                            <td class="text-center"><i class="fa fa-rupee"></i>&nbsp;<%# Eval("InvTotal") %></td>--%>
                                <td class="text-right"><i class="fa fa-rupee"></i>&nbsp;<%# Eval("FinalTotal") %></td>
                                <td class="text-center">
                                    <asp:UpdatePanel ID="upnl" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lnkView" runat="server" CssClass="btn btn-default btn-xs" CommandName="view" Visible="false"><i class="glyphicon glyphicon-eye-open"></i>&nbsp;View details</asp:LinkButton>
                                            <a href="/Module/Invoice/viewinvoicereport.aspx?invid=<%# Eval("InvId") %>&flg=1" target="_blank" class="btn btn-default btn-xs"><i class="glyphicon glyphicon-eye-open"></i>&nbsp;View</a>
                                            <%-- <a href="printinvoice.aspx?invid=<%# Eval("InvId") %>" target="_blank" class="btn btn-default btn-xs"><i class="glyphicon glyphicon-print"></i>&nbsp;Print</a>--%>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="lnkView" />
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
                </div>

            </div>
        </div>
    </div>
    <script src="/plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="/plugins/datatables/dataTables.bootstrap.min.js"></script>
    <script>
        $(".zero-configuration").DataTable();
    </script>
</asp:Content>
