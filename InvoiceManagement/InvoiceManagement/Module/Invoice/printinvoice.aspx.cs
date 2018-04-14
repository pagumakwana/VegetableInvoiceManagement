using InvoiceManagement.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceManagement.Module.Invoice
{
    public partial class printinvoice : System.Web.UI.Page
    {
        Helper oHelper = new Helper(); int runningTotal = 0;
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
                if (!string.IsNullOrEmpty(Request.QueryString["invid"]))
                {
                    oHelper.FillRepeater(rptbillproduct, "select id.*,pm.ProductNameJoin,um.FullName from Invoicemaster im join invoicedetails id on id.ref_invid=im.invid join productmaster pm on id.Ref_ProductId=pm.productid join UserMaster um on im.createdby=um.UserID where im.invid=" + Request.QueryString["invid"]);

                    DataTable dt = oHelper.GetDataTable("select im.*,cm.* from invoicemaster im join ClientMaster cm on im.Ref_ClientId=cm.ClientID where im.InvID=" + Request.QueryString["invid"].ToString());
                    if (dt.Rows.Count > 0)
                    {
                        lbinvoice.Text = Request.QueryString["invid"].ToString();
                        lbclient.Text = dt.Rows[0]["Fullname"].ToString();
                        string test = dt.Rows[0]["InvDate"].ToString();
                        DateTime dat = DateTime.ParseExact(test, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        lbinvdate.Text = dat.ToString("dd/MM/yyyy").Replace("-", "/");
                        lbadd.Text = dt.Rows[0]["Address"].ToString();
                        lbmob.Text = dt.Rows[0]["Mobile"].ToString();
                        string check1 = dt.Rows[0]["InvTime"].ToString();

                        string[] check = check1.Split(',');

                        for (int i = 0; i < check.Length; i++)
                        {
                            if (check[i].ToString() == "Morning")
                            {
                                imgmcheck.Visible = true;
                                imgmuncehck.Visible = false;
                                //chkmorning.Checked = true;
                            }
                            else if (check[i].ToString() == "Afternoon")
                            {
                                imgacheck.Visible = true;
                                imgauncheck.Visible = false;
                                //chkafternoon.Checked = true;
                            }
                            else if (check[i].ToString() == "Evening")
                            {
                                imgecheck.Visible = true;
                                imgeuncheck.Visible = false;
                                //chkevening.Checked = true;
                            }
                        }

                    }
                }
            }
        }
        protected void rptbillproduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lbsubtotal = (Label)e.Item.FindControl("lbsubtotal");
            Label lbqty = (Label)e.Item.FindControl("lbqty");
            Label lbqtyt = (Label)e.Item.FindControl("lbqtyt");
            HiddenField hfqty = (HiddenField)e.Item.FindControl("hfqty");

            Label lbtransport = (Label)e.Item.FindControl("lbtransport");
            Label lbtotal = (Label)e.Item.FindControl("lbtotal");
            Label lbadvanced = (Label)e.Item.FindControl("lbadvanced");
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                if (lbqtyt.Text == "Kg")
                {
                    //lbqty.Text = hfqty.Value.Substring(0,hfqty.Value.LastIndexOf("."));
                    lbqty.Text = hfqty.Value;
                }
                else if (lbqtyt.Text == "Gram")
                {
                    string am = hfqty.Value;
                    am = am.Substring(am.IndexOf('.') + 1);

                    if (am.Length == 2)
                    {
                        int i = (Convert.ToInt32(am)) * 10;
                        am = i.ToString();
                    }
                    else if (am.Length == 3) { }

                    lbqty.Text = am;

                }
                else { lbqty.Text = hfqty.Value.Substring(0, hfqty.Value.LastIndexOf(".")); }
            }
            //    runningTotal += Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "total"));
            if (e.Item.ItemType == ListItemType.Footer)
            {
                lbsubtotal.Text = string.Format("{0:c}", oHelper.GetValue("select sum(total)as total from InvoiceDetails where Ref_InvId=" + Request.QueryString["invid"], "total"));
                lbadvanced.Text = string.Format("{0:c}", oHelper.GetValue("select sum(Advancepayment)as adv from MapInvoiceTotal where Ref_InvId=" + Request.QueryString["invid"], "adv"));
                lbtransport.Text = string.Format("{0:c}", oHelper.GetValue("select Transportcharges from MapInvoiceTotal where Ref_InvId=" + Request.QueryString["invid"], "Transportcharges"));
                lbtotal.Text = string.Format("{0:c}", oHelper.GetValue("select Paymentdue from MapInvoiceTotal where Ref_InvId=" + Request.QueryString["invid"], "Paymentdue"));
            }
        }
    }
}