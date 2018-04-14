<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="viewinvoice1.aspx.cs" Inherits="InvoiceManagement.Module.Invoice.viewinvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <section class="panel">
            <div class="panel-body invoice">
                <div class="text-center">
                    <h4>|| શ્રી ગણેશાય નમઃ ||</h4>
                </div>
                <div class="invoice-header">
                    <div class="invoice-title col-sm-12 col-md-12 col-xs-12">
                        <%--<h1>invoice</h1>--%>
                    </div>
                    <div class="invoice-info col-sm-12 col-md-12 col-xs-12">
                        <div class="col-sm-4 col-md-4 col-xs-4">
                            <img src="/dist/images/Logo-Symbol-White.jpg" height="100" width="" />
                            <img src="/dist/images/Logo-Text-White.jpg" alt="" height="100" width="200" />
                        </div>
                        <div class="col-sm-4 col-md-4 col-xs-4">
                            <p>
                                <strong>Address:</strong> Shop No. 21 / 22,<br>
                                New Municipal Market,
									Borivali (W), Mumbai - 400 092.<br>
                                <i class="fa fa-envelope-o"></i>: manubhaipandya5@gmail.com
                            </p>
                        </div>
                        <div class="col-sm-4 col-md-4 col-xs-4">
                            <p>
                                <i class="fa fa-phone-square"></i>: 28900418 / 28901729 / 28908169<br>
                                Manubhai Pandya : 9821159981
                                <br>
                                Nitish Pandya : 9870399510
                                <br>
                        </div>
                    </div>
                </div>
                <div class="invoice-info col-sm-12 col-md-12 col-xs-12" style="">
                    <div class="col-sm-4 col-md-4 col-xs-4">
                        <div class="inv-label">
                            <h4>Invoice To:</h4>
                        </div>
                        <h3><span id="lblCustomerName">Neo Pizza</span></h3>
                        <p>
                            <span>Shop No. 121, Neo Pizza,<br>
                                Opp. Moksh Plaza, Borivali (W)<br>
                                Phone: 987654321<br>
                            </span>
                        </p>
                    </div>
                    <div class="col-sm-4 col-md-4 col-xs-4">
                        <div class="inv-label">
                            <h4>Invoice # <span id="lblInvNo" style="color: #767676;">17</span></h4>
                        </div>
                        <div class="inv-label">
                            <h5>Date # <span id="lblInvDate" style="color: #767676;">05-05-2014</span></h5>
                        </div>
                        <div class="checkbox">
                            <span disabled="disabled" style="color: #767676;">
                                <input id="chkMrng" type="checkbox" name="chkMrng" disabled="disabled" /><label for="chkMrng">Morning</label>
                            </span>
                            <br />
                            <span disabled="disabled" style="color: #767676;">
                                <input id="chkAfternoon" type="checkbox" name="chkAfternoon" disabled="disabled" /><label for="chkAfternoon">Afternoon</label>
                            </span>
                            <br />
                            <span disabled="disabled" style="color: #767676;">
                                <input id="chkEvening" type="checkbox" name="chkEvening" disabled="disabled" /><label for="chkEvening">Evening</label>
                            </span>
                        </div>
                    </div>
                    <div class="col-sm-4 col-md-4 col-xs-4">
                        <span class="inv-label">
                            <h4>TOTAL DUE</h4>
                        </span>
                        <h1 class="amnt-value">&#8377<span id="lblTotalDue">100.00</span></h1>
                    </div>
                </div>

                <div>
                    <asp:Repeater ID="rptProduct" runat="server" >
                        <HeaderTemplate>
                            <table class="table table-striped">
                                <thead>
                                    <tr>
                                        <th style="width: 5%">Sr#</th>
                                        <th style="width: 15%">Product</th>
                                        <th style="width: 15%">Qty</th>
                                        <th style="width: 10%">Qty Type</th>
                                        <th style="width: 15%">Rs</th>
                                        <th style="width: 15%">Total</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%# ((RepeaterItem)Container).ItemIndex + 1%></td>
                                <td>
                                    <%# Eval("Column1") %>
                                </td>
                                <td>
                                    <%# Eval("Column2") %>
                                </td>
                                <td>
                                    <%# Eval("Column3") %>
                                </td>
                                <td>
                                    <%# Eval("Column4") %>
                                </td>
                                <td>
                                    <%# Eval("Column5") %>
                                </td>

                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>

                </div>

                <div class="page-break"></div>

                <div class="row">
                    <div class="col-md-6  col-md-offset-6 payment-method">
                        <table class="table table-invoice">
                            <tbody class="invoice-block pull-right">
                                <tr class="unstyled amounts">
                                    <td style="text-align: right;">Sub - Total amount : </td>
                                    <td>&#8377<span id="lblSubTotalAmt">100.00</span></td>
                                </tr>
                                <tr class="unstyled amounts">
                                    <td style="text-align: right;">Transportation Charges :</td>
                                    <td>&#8377<span id="lblTransChgs">0.00</span> </td>
                                </tr>
                                <tr class="unstyled amounts">
                                    <td style="text-align: right;">Grand Total :</td>
                                    <td class="grand-total">&#8377<span id="lblGrandTotal">100.00</span></td>
                                </tr>
                                <tr class="unstyled amounts">
                                    <td style="text-align: right;">Sales Return : </td>
                                    <td>&#8377<span id="lblSalesReturn">0.00</span></td>
                                </tr>
                                <tr class="unstyled amounts">
                                    <td style="text-align: right;">Final Total : </td>
                                    <td>&#8377<span id="lblFinalTotal">100.00</span></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="col-md-12 payment-method" style="margin: 0 0 0 5px">
                        <h4>Payment Method</h4>
                        <p>1. Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                        <p>2. Pellentesque tincidunt pulvinar magna quis rhoncus.</p>
                        <p>3. Cras rhoncus risus vitae congue commodo.</p>
                        <br>
                        <h3 class="inv-label itatic">Thank you for your business</h3>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
