using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;

namespace InvoiceManagement.Module.Account
{
    public partial class login : System.Web.UI.Page
    {
        UserMaster oUserMaster; BAL oBAL;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkLogin_Click(object sender, EventArgs e)
        {
            oUserMaster = new UserMaster();
            oUserMaster.Email = txtEmail.Text.Trim();
            oUserMaster.Pwd = txtPwd.Text.Trim();
            oBAL = new BAL();
            int i = oBAL.UserLogin(oUserMaster);
            if (i > 0) { oBAL = null; oUserMaster = null; Response.Redirect("~/Module/Report/dashboard.aspx"); }
            else { lbuname.Visible = true; }

        }
    }
}