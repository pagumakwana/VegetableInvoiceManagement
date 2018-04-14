using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;

namespace InvoiceManagement.Module.Client
{
    public partial class listclient : System.Web.UI.Page
    {
        Helper oHelper = new Helper(); ClientMaster oClientMaster; BAL oBAL;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("/module/account/login.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oHelper.FillRepeater(rptClient, "select cm.*,um.FullName as username from ClientMaster cm inner join UserMaster um on um.UserID=cm.CreatedBy");
            }
        }
        protected void lnkNewClient_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text.Trim() == "")
                txtMobile.Text = "N/A";
            oClientMaster = new ClientMaster();
            oClientMaster.Flag = "insert_client";
            oClientMaster.FullName = txtClientName.Text;
            oClientMaster.Mobile = txtMobile.Text.Trim();
            oClientMaster.CreatedBy = Convert.ToInt32(Session["UserID"].ToString());
            oBAL = new BAL();
            int i = oBAL.ClientMasterDetails(oClientMaster);
            if (i > 0)
            {
                oBAL = null; oClientMaster = null;
                txtClientName.Text = "";
                txtMobile.Text = "";
                oHelper.FillRepeater(rptClient, "select cm.*,um.FullName as username from ClientMaster cm inner join UserMaster um on um.UserID=cm.CreatedBy");
                //0Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "clientadd()", true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "MyFun1", "clientadd();", true);
            }

        }
    }
}