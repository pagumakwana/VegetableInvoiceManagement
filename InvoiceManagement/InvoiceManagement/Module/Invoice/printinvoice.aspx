<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printinvoice.aspx.cs" Inherits="InvoiceManagement.Module.Invoice.printinvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title>M | Print Invoice</title>
    <!-- Tell the browser to be responsive to screen width -->
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <!-- Bootstrap 3.3.6 -->
    <link rel="stylesheet" href="/bootstrap/css/bootstrap.min.css" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css" />
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="/dist/css/AdminLTE.min.css" />
    <%--<link rel="stylesheet" href="/plugins/iCheck/square/red.css" />--%>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<%--onload="javascript:print()"--%>
<body onload="javascript:print()">

    <form id="form1" runat="server">
        <!-- Main content -->
        <section id="pdfdiv" class="invoice row">
            <div class="col-md-8">
                <!-- title row -->
                <div class="row">
                    <div class="col-xs-12">

                        <div class="page-header" style="border: none; padding: 0px;">
                            <div class="text-center">
                                <h5>|| શ્રીગણેશાય નમઃ ||  || શ્રી હનુમંતેય નમ: || </h5>
                            </div>
                        </div>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- info row -->
                <div class="row" style="padding-top: 0px;">
                    <div class="col-md-12" style="padding-top: 0px;">
                        <table class="table no-border" style="margin-top:-15px;">
                            <tbody>
                              <%--  <tr><td colspan="2" class="text-center" style="padding:2px;margin:1px;"> <h5>|| શ્રીગણેશાય નમઃ ||  || શ્રી હનુમંતેય નમ: || </h5></td></tr>--%>
                                <tr>
                                    <td>
                                        <img src="/dist/images/mlogo.jpg" height="110" width="100" /></td>
                                    <td style="padding-left: 0px;">
                                        <div class=""><span style="font-size: 35px; font-family: 'Segoe UI';"><b>Manubhai </b></span><span style="font-size: 25px;">"Fresh Vegetable Supplier's"</span></div>

                                        <div>
                                            <small style="width: 400px; word-wrap: break-word;">Shop No. 21/22 Vegetable Municipal Market,&nbsp;
                                        Opp.Railway Station, Borivali-West, Mumbai: 400092.</small><br />
                                            <small style="width: 400px; word-wrap: break-word;">Phone: 02228901729/28900418/28908169
                                        Email: manubhaipandya5@gmail.com</small><br />
                                            <small class="" style="width: 400px; word-wrap: break-word;">Manubhai Pandya - 9821159981 | Nitish Pandya - 9870399510</small>
                                        </div>

                                    </td>
                                </tr>

                            </tbody>
                        </table>
                        <table class="table">
                            <tbody>
                                <tr style="border: 1px solid; border-bottom: 0px;">
                                     <td width="55%" style="border: 1px solid; border-bottom: 0px;">
                                        <address>
                                            <strong style="font-size: 18px;">Name :</strong>
                                            <asp:Label ID="lbclient" runat="server"></asp:Label><br />
                                            <strong style="font-size: 18px;">Address :</strong>&nbsp;<asp:Label ID="lbadd" runat="server"></asp:Label>
                                            <br />
                                            <b>Phone:</b>&nbsp;<asp:Label ID="lbmob" runat="server"></asp:Label><br>
                                        </address>
                                    </td>
                                    
                                   
                                    <td class="text-center" width="20%" style="border: 1px solid; border-bottom: 0px;">
                                        <div style="padding-left: 0px; margin-top: 10px;">
                                            <%--  <label>
                                            <input type="checkbox" id="chkmorning" runat="server" disabled="disabled" />--%>
                                            <asp:Image ID="imgmuncehck" runat="server" ImageUrl="/dist/images/uncheck.png" Style="height: 12px; width: 12px;" />
                                            <asp:Image ID="imgmcheck" runat="server" ImageUrl="/dist/images/check.png" Visible="false" Style="height: 12px; width: 12px;" />
                                            &nbsp;Morning
           
                                              <%--  </label>--%>
                                        </div>
                                        <div style="padding-left: 8px; margin-top: 10px;">
                                            <%--  <label>
                                                    <input type="checkbox" id="chkafternoon" runat="server" disabled="disabled" />--%>
                                            <asp:Image ID="imgauncheck" runat="server" ImageUrl="/dist/images/uncheck.png" Style="height: 12px; width: 12px;" />
                                            <asp:Image ID="imgacheck" runat="server" ImageUrl="/dist/images/check.png" Visible="false" Style="height: 12px; width: 12px;" />
                                            &nbsp;Afternoon
                                               <%-- </label>--%>
                                        </div>
                                        <div style="padding-left: 0px; margin-top: 10px;">
                                            <%--    <label>
                                                    <input type="checkbox" id="chkevening" runat="server" disabled="disabled" />--%>
                                            <asp:Image ID="imgeuncheck" runat="server" ImageUrl="/dist/images/uncheck.png" Style="height: 12px; width: 12px;" />
                                            <asp:Image ID="imgecheck" runat="server" ImageUrl="/dist/images/check.png" Visible="false" Style="height: 12px; width: 12px;" />
                                            &nbsp;Evening
           
                                               <%-- </label>--%>
                                        </div>
                                    </td>
                                    <td width="25%" style="border: 1px solid; border-bottom: 0px;">
                                        <span class="text-bold" style="font-size: large;">Invoice :
                    <asp:Label ID="lbinvoice" runat="server"></asp:Label>
                                        </span>
                                        <div style="border-bottom: 0px solid; margin-top: 10px;"></div>
                                        <span class="text-bold" style="font-size: large;">Date :
                    <asp:Label ID="lbinvdate" runat="server"></asp:Label></span>


                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:Repeater ID="rptbillproduct" runat="server" OnItemDataBound="rptbillproduct_ItemDataBound">
                            <HeaderTemplate>
                                <table class="table" style="border: 1px solid; margin-top: -20px;">
                                    <thead>
                                        <tr style="border: 1px solid;">
                                            <%--<th style="border: 1px solid;">Sr#</th>--%>
                                            <th style="border: 1px solid;" width="30%">Product</th>
                                            <th style="border: 1px solid;" class="text-center" width="40%">Gross Qty</th>
                                            <th style="border: 1px solid;" class="text-right" width="15%">Total Qty</th>
                                            <%--<th>Amount</th>--%>
                                            <th style="border: 1px solid;" class="text-right" width="15%">Amount</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr style="border: 1px solid;">
                                    <asp:HiddenField ID="hfqty" runat="server" Value='<%# Eval("TotalQty") %>' />
                                    <%--<td style="border: 1px solid;"><%# ((RepeaterItem)Container).ItemIndex + 1%></td>--%>
                                    <td style="border: 1px solid;padding:2px;margin:1px;" width="30%"><%# Eval("ProductNameJoin") %></td>
                                    <td style="border: 1px solid;padding:2px;margin:1px;" class="text-center" width="30%"><%# Eval("GrossQty") %></td>
                                    <td style="border: 1px solid;padding:2px;margin:1px;" class="text-right" width="15%">
                                        <asp:Label ID="lbqty" runat="server"></asp:Label>
                                        &nbsp<asp:Label ID="lbqtyt" runat="server" Text='<%#Eval("Qtytype") %>'></asp:Label></td>
                                    <%--<td><i class="fa fa-rupee"></i>&nbsp;<%# Eval("Amount") %></td>--%>
                                    <td style="border: 1px solid;padding:2px;margin:1px;" class="text-right" width="20%"><i class="fa fa-rupee"></i>&nbsp;<%# Eval("Total") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                    </table>
                             <!-- /.row -->

                                <div class="row">
                                    <!-- accepted payments column -->
                                    <div class="col-xs-5">

                                        <p class="text-muted well well-sm no-shadow" style="margin-top: 5px;">
                                            Note: Accept Payments by Cheque/Cash.
       
                                        </p>
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-xs-7">


                                        <div class="table-responsive"  style="margin-top:-18px;">
                                            <table class="table" style="border: 0px solid;">
                                                 <tr style="border: 0px solid;">
                                                    <th style="border: 1px solid;border-top:0px;padding:2px;margin:1px;">Transportation Charges:</th>
                                                    <td style="border: 1px solid;border-top:0px;padding:2px;margin:1px;" class="text-right">
                                                        <i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lbtransport" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr style="border: 1px solid;">
                                                    <th style="width: 70%; border: 1px solid;padding:2px;margin:1px;">Subtotal:</th>
                                                    <td style="border: 1px solid;padding:2px;margin:1px;" class="text-right">
                                                        <i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lbsubtotal" runat="server"></asp:Label></td>
                                                </tr>
                                                 <tr style="border: 1px solid;">
                                                    <th style="width: 70%; border: 1px solid;padding:2px;margin:1px;">Advance payment / Sales Return:</th>
                                                    <td style="border: 1px solid;padding:2px;margin:1px;" class="text-right">
                                                        <i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lbadvanced" runat="server"></asp:Label></td>
                                                </tr>
                                               
                                               
                                                <tr style="border: 1px solid;">
                                                    <th style="border: 1px solid;padding:2px;margin:1px;">Total:</th>
                                                    <td style="border: 1px solid;padding:2px;margin:1px;" class="text-right">
                                                        <i class="fa fa-rupee"></i>&nbsp;<asp:Label ID="lbtotal" runat="server" Font-Size="Large"></asp:Label></td>
                                                </tr>
                                            </table>
                                            <div class="text-center">
                                                <b>Authority signature</b>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- /.col -->
                                </div>
                                <!-- /.row -->
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </section>
        <!-- /.content -->
        <script> $(function () {
     $('input').iCheck({
         checkboxClass: 'icheckbox_square-blue',
         radioClass: 'iradio_square-blue',
         increaseArea: '20%' // optional
     });
 });</script>
    </form>
</body>
</html>
