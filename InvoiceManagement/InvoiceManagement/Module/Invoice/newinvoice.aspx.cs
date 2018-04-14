using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;
using System.Globalization;
using System.Collections;

namespace InvoiceManagement.Module.Invoice
{
    public partial class newinvoice : System.Web.UI.Page
    {
        Helper oHelper = new Helper(); InvoiceMaster oInvoiceMaster; ClientMaster oClientMaster; BAL oBAL;
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
                oHelper.DropDownFill(ddlClient, "ClientMaster", "ClientId", "FullName");
        }
        protected void lnkCreate_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(Session["UserID"].ToString()))
            {
                string test = hfCustomerId.Value;
                if (string.IsNullOrEmpty(test))
                {
                    oClientMaster = new ClientMaster();
                    oClientMaster.Flag = "insert_client";
                    oClientMaster.FullName = txtclient.Text;
                    oClientMaster.Mobile = txtMobile.Text;
                    oClientMaster.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                    oBAL = new BAL();
                    int id = oBAL.ClientMasterDetails(oClientMaster);
                    if (id > 0)
                    {
                        oBAL = null; oClientMaster = null;
                        txtClientName.Text = "";
                        txtMobile.Text = "";
                        oHelper.DropDownFill(ddlClient, "ClientMaster", "ClientId", "FullName");
                        int getindex = ddlClient.Items.IndexOf(ddlClient.Items.FindByValue(id.ToString()));
                        ddlClient.SelectedIndex = getindex;
                    }
                }
                string time = "";
                foreach (ListItem item in lsttime.Items)
                {
                    if (item.Selected)
                    {
                        if (time != "")
                            time += "," + item;
                        else
                            time = item.ToString();
                    }
                }
                oInvoiceMaster = new InvoiceMaster();
                oInvoiceMaster.Flag = "insert_Invoicemaster";
                int clientid = Convert.ToInt32(oHelper.GetValue("select * from clientmaster where FullName='" + txtclient.Text.Trim() + "'", "ClientId"));
                oInvoiceMaster.Ref_ClientId = clientid;
                if (Request.Form["datepicker"].ToString() != "")
                    oInvoiceMaster.InvDate = Request.Form["datepicker"].ToString();
                else
                    oInvoiceMaster.InvDate = DateTime.Now.ToString("dd/MM/yyyy").Replace("-", "/");
                oInvoiceMaster.InvTime = time;
                oInvoiceMaster.Address = txtAddress.Text.Trim();
                oInvoiceMaster.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
                string invdate = oInvoiceMaster.InvDate;
                oBAL = new BAL();
                int i = oBAL.InvoiceMaster(oInvoiceMaster);
                if (i > 0)
                {
                    oBAL = null; oInvoiceMaster = null;
                    oInvoiceMaster = new InvoiceMaster();
                    oInvoiceMaster.Flag = "update_Invoicemaster";
                    oInvoiceMaster.InvID = i;
                    DateTime dtdate = DateTime.Parse(invdate);
                    string billdate = dtdate.ToString("dd-MMM-yyyy");
                    oInvoiceMaster.InvPath = "~/pdf/" + billdate + "/InvoiceNo_" + oInvoiceMaster.InvID+".pdf";
                    oInvoiceMaster.InvoiceFullpath = Server.MapPath(oInvoiceMaster.InvPath);
                    oBAL = new BAL();
                    int P = oBAL.InvoiceMaster(oInvoiceMaster);
                    if (P > 0)
                    {
                        oBAL = null; oInvoiceMaster = null;
                        Response.Redirect("/Module/Invoice/invoiceproduct.aspx?invid=" + P);
                    }
                    
                }
            }
        }
        protected void lnkNewClient_Click(object sender, EventArgs e)
        {
            oClientMaster = new ClientMaster();
            oClientMaster.Flag = "insert_client";
            oClientMaster.FullName = txtClientName.Text;
            oClientMaster.Mobile = txtMobile.Text;
            oClientMaster.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
            oBAL = new BAL();
            int i = oBAL.ClientMasterDetails(oClientMaster);
            if (i > 0)
            {
                oBAL = null; oClientMaster = null;
                txtClientName.Text = "";
                txtMobile.Text = "";
                oHelper.DropDownFill(ddlClient, "ClientMaster", "ClientId", "FullName");
                int getindex = ddlClient.Items.IndexOf(ddlClient.Items.FindByValue(i.ToString()));
                ddlClient.SelectedIndex = getindex;
            }

        }
    }
}