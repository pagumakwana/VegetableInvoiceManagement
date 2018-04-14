using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceManagement.Module.Invoice
{
    public partial class viewinvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ViewStateData"] != null)
                {
                    DataTable dt = (DataTable)Session["ViewStateData"];
                    rptProduct.DataSource = dt;
                    rptProduct.DataBind();
                }
            }
        }
    }
}