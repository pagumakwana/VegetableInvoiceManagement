using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceManagement.App_Code;
using System.Windows;

namespace InvoiceManagement.Module.Invoice
{
    public partial class listinvoice : System.Web.UI.Page
    {
        Helper oHelper = new Helper();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("/module/account/login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
             if (!IsPostBack)
            {
                oHelper.FillRepeater(rptListInvoice, "select im.invid,im.Invdate,im.invTime,im.address,im.invpath,mit.Transportcharges,mit.Advancepayment,im.createdOnUtc,um.fullname,mit.invtotal,mit.finaltotal,mit.Paymentdue,cm.FullName as clientname from invoicemaster im join mapinvoicetotal mit on mit.ref_invid=im.invid join UserMaster um on im.createdby=um.UserID join ClientMaster cm on cm.ClientID=im.ref_clientid order by im.invid desc");
            }
            
        }
        protected void rptListInvoice_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lbinvid = (Label)e.Item.FindControl("lbinvid") as Label;
            if (e.CommandName.Equals("view"))
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Module/Invoice/viewinvoicereport.aspx?invid=" + lbinvid.Text + "');", true);
                Session["invid"] = lbinvid.Text.Trim();
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Module/Invoice/InvoicePDF.aspx?invid=" + lbinvid.Text + "');", true);
                ////Clears all content output from Buffer Stream
                //Response.ClearContent();
                ////Clears all headers from Buffer Stream
                //Response.ClearHeaders();
                ////Adds an HTTP header to the output stream
                //Response.AddHeader("Content-Disposition", "inline;filename=\"" + filepath + "\"");
                ////Gets or Sets the HTTP MIME type of the output stream
                //Response.ContentType = "application/pdf";
                ////Writes the content of the specified file directory to an HTTP response output stream as a file block
                //Response.WriteFile(filepath);
                ////sends all currently buffered output to the client
                //Response.Flush();
                ////Clears all content output from Buffer Stream
                //Response.Clear();
            }
            else if (e.CommandName.Equals("openfile"))
            {
                
            }
        }
    }
}