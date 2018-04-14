using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;

namespace InvoiceManagement.Module.User
{
    public partial class listuser : System.Web.UI.Page
    {
        Helper oHelper = new Helper(); UserMaster oUserMaster; BAL oBAL;

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
                oHelper.FillRepeater(rptUser, "select * from UserMaster");
            }
        }
        protected void lnkNewUser_Click(object sender, EventArgs e)
        {
            oUserMaster = new UserMaster();
            oUserMaster.Flag = "insert_signup";
            oUserMaster.FullName = txtFullName.Text;
            oUserMaster.Email = txtEmail1.Text;
            oUserMaster.Pwd = txtPwd1.Text;
            oUserMaster.CreatedBy =Convert.ToInt32(Session["UserId"].ToString());
            oBAL = new BAL();
            int i = oBAL.UserMaster(oUserMaster);
            if (i > 0) { oBAL = null; oUserMaster = null; txtFullName.Text = ""; txtEmail1.Text = ""; txtPwd1.Text = ""; oHelper.FillRepeater(rptUser, "select * from UserMaster"); }
        }
    }
}