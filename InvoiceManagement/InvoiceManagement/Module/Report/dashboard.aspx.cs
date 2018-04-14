using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceManagement.Module.Report
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null)
            //{
            //    Response.Redirect("/module/account/login.aspx");
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}