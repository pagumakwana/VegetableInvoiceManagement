using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;

namespace InvoiceManagement.Module.Invoice
{
    public partial class invoiceproduct : System.Web.UI.Page
    {
        Helper oHelper = new Helper(); DataTable dtCurrentTable = new DataTable();
        InvoiceDetail oInvoiceDetail; BAL oBAL;
        //private short _tabIndex;
        //public short TabIndex
        //{
        //    get
        //    {
        //        return _tabIndex;
        //    }
        //    set
        //    {
        //        _tabIndex = value;
        //        ddlProduct.TabIndex = (short)(value++);
        //        txtQty.TabIndex = (short)(value++);
        //        ddlQtyType.TabIndex = (short)(value++);
        //        txtRate.TabIndex = (short)(value++);
        //        txtPaise.TabIndex = (short)(value);
        //    }
        //}        

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
                    lbInvoiceNumber.Text = Request.QueryString["invid"].ToString();
                    oHelper.FillRepeater(rptProduct, "select id.*,pm.ProductNameJoin,um.FullName from Invoicemaster im join invoicedetails id on id.ref_invid=im.invid join productmaster pm on id.Ref_ProductId=pm.productid join UserMaster um on im.createdby=um.UserID where im.invid=" + lbInvoiceNumber.Text);
                    oHelper.DropDownFill(ddlProduct, "productmaster", "productid", "ProductNameJoin");
                    lbGrosstotal.Text = oHelper.GetValue("select sum(total) as cnt from invoicedetails where ref_invid=" + lbInvoiceNumber.Text, "cnt");
                }
            }

        }
        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Session["transport"] != null && Session["adv"] != null)
            {
                txttransport.Text = Session["transport"].ToString();
                txtadpayment.Text = Session["adv"].ToString();
            }
        }
        protected void rptProduct_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            oBAL = new BAL();
            HiddenField hdfid = (HiddenField)e.Item.FindControl("hdfid");
            LinkButton lnkEdit = (LinkButton)e.Item.FindControl("lnkEdit");
            LinkButton lnkUpdate = (LinkButton)e.Item.FindControl("lnkUpdate");
            LinkButton lnkCancel = (LinkButton)e.Item.FindControl("lnkCancel");
            LinkButton lnkRemove = (LinkButton)e.Item.FindControl("lnkRemove");
            TextBox txtQtyr = (TextBox)e.Item.FindControl("txtQtyr");
            TextBox txtrater = (TextBox)e.Item.FindControl("txtrater");
            TextBox txtPaiser = (TextBox)e.Item.FindControl("txtPaiser");
            Label lbgqtyr = (Label)e.Item.FindControl("lbgqtyr");
            Label lbqtyper = (Label)e.Item.FindControl("lbqtyper");
            Label lbrater = (Label)e.Item.FindControl("lbrater");
            Label lbpaiser = (Label)e.Item.FindControl("lbpaiser");

            if (e.CommandName.Equals("remove"))
            {
                oInvoiceDetail = new InvoiceDetail();
                oInvoiceDetail.Flag = "delete_Invoiceproduct";
                oInvoiceDetail.InvProdDetId = Convert.ToInt32(hdfid.Value);
                int i = oBAL.InvoiceDetail(oInvoiceDetail);
                if (i > 0)
                {
                    oHelper.FillRepeater(rptProduct, "select id.*,pm.ProductNameJoin,um.FullName from Invoicemaster im join invoicedetails id on id.ref_invid=im.invid join productmaster pm on id.Ref_ProductId=pm.productid join UserMaster um on im.createdby=um.UserID where im.invid=" + lbInvoiceNumber.Text + " order by id.InvProdDetId desc");
                    oHelper.DropDownFill(ddlProduct, "productmaster", "productid", "ProductNameJoin");
                }
            }
            else if (e.CommandName.Equals("edit"))
            {
                lnkEdit.Visible = false;
                lnkRemove.Visible = false;
                lnkUpdate.Visible = true;
                lnkCancel.Visible = true;
                txtQtyr.Visible = true;
                txtrater.Visible = true;
                txtPaiser.Visible = true;
                txtQtyr.Text = lbgqtyr.Text;
                txtrater.Text = lbrater.Text;
                txtPaiser.Text = lbpaiser.Text;
                lbgqtyr.Visible = false;
                lbrater.Visible = false;
                lbpaiser.Visible = false;
                lbqtyper.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "tablescript();", true);
            }
            else if (e.CommandName.Equals("update"))
            {
                oInvoiceDetail = new InvoiceDetail();
                oInvoiceDetail.Flag = "update_Invoiceproduct";
                oInvoiceDetail.InvProdDetId = Convert.ToInt32(hdfid.Value);
                oInvoiceDetail.QtyType = lbqtyper.Text;
                oInvoiceDetail.GrossQty = txtQtyr.Text;
                oInvoiceDetail.Rate = Convert.ToInt32(txtrater.Text);

                if (txtPaiser.Text.Trim() != "")
                    oInvoiceDetail.Paise = Convert.ToDecimal(txtPaiser.Text) / 100;
                else
                    oInvoiceDetail.Paise = Convert.ToDecimal(0.00);
                string[] TotalKG = txtQtyr.Text.Split('+');
                int total = 0;
                decimal totkg = 0;
                decimal count = 0;
                if (lbqtyper.Text == "Kg")
                {
                    foreach (string value in TotalKG)
                    {
                        totkg = totkg + Convert.ToDecimal(value.Trim());
                    }
                    count = ((Convert.ToDecimal(txtrater.Text) + (oInvoiceDetail.Paise)) * totkg);
                    oInvoiceDetail.Total = count;
                    oInvoiceDetail.TotalQty = totkg;
                }
                else if (lbqtyper.Text == "Gram")
                {
                    foreach (string value in TotalKG)
                    {
                        string value1 = "0." + value;
                        totkg = totkg + Convert.ToDecimal(value1.Trim());
                    }
                    count = ((Convert.ToDecimal(txtrater.Text) + (oInvoiceDetail.Paise)) * totkg);
                    oInvoiceDetail.Total = count;
                    oInvoiceDetail.TotalQty = totkg;
                }
                else
                {

                    foreach (string value in TotalKG)
                    {
                        total = total + Convert.ToInt32(value);
                    }
                    count = ((Convert.ToDecimal(txtrater.Text) + (oInvoiceDetail.Paise)) * total);
                    oInvoiceDetail.Total = count;
                    oInvoiceDetail.TotalQty = total;
                }





                oInvoiceDetail.Amount = Convert.ToDecimal(txtrater.Text) + (oInvoiceDetail.Paise);
                oBAL = new BAL();
                int i = oBAL.InvoiceDetail(oInvoiceDetail);
                if (i > 0)
                {

                    oBAL = null; oInvoiceDetail = null;
                    if (!string.IsNullOrEmpty(Request.QueryString["invid"]))
                    {
                        lbInvoiceNumber.Text = Request.QueryString["invid"].ToString();
                        lbGrosstotal.Text = oHelper.GetValue("select sum(total) as cnt from invoicedetails where ref_invid=" + lbInvoiceNumber.Text, "cnt");
                        oHelper.FillRepeater(rptProduct, "select id.*,pm.ProductNameJoin,um.FullName from Invoicemaster im join invoicedetails id on id.ref_invid=im.invid join productmaster pm on id.Ref_ProductId=pm.productid join UserMaster um on im.createdby=um.UserID where im.invid=" + lbInvoiceNumber.Text + " order by id.InvProdDetId desc");
                        oHelper.DropDownFill(ddlProduct, "productmaster", "productid", "ProductNameJoin");
                    }
                    ddlProduct.SelectedIndex = 0;
                    ddlQtyType.SelectedIndex = 0;
                    txtQty.Text = "";
                    txtRate.Text = "";
                    txtPaise.Text = "";
                }
                lnkEdit.Visible = true;
                lnkRemove.Visible = true;
                lnkUpdate.Visible = false;
                lnkCancel.Visible = false;
                lbqtyper.Visible = false;
                txtQtyr.Visible = false;
                txtrater.Visible = false;
                txtPaiser.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "tablescript();", true);
            }
            else if (e.CommandName.Equals("cancel"))
            {
                lnkEdit.Visible = true;
                lnkRemove.Visible = true;
                lnkUpdate.Visible = false;
                lnkCancel.Visible = false;
                txtQtyr.Visible = false;
                txtrater.Visible = false;
                txtPaiser.Visible = false;
                lbgqtyr.Visible = true;
                lbrater.Visible = true;
                lbpaiser.Visible = true;
                lbqtyper.Visible = true;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "script", "tablescript();", true);
            }
        }
        protected void lnkAdd_Click(object sender, EventArgs e)
        {
            oInvoiceDetail = new InvoiceDetail();
            oInvoiceDetail.Flag = "insert_InvoiceDetails";
            oInvoiceDetail.Ref_InvId = Convert.ToInt32(lbInvoiceNumber.Text);
            oInvoiceDetail.Ref_ProductId = Convert.ToInt32(ddlProduct.SelectedValue);
            oInvoiceDetail.QtyType = ddlQtyType.SelectedItem.Text;
            oInvoiceDetail.GrossQty = txtQty.Text;
            oInvoiceDetail.Rate = Convert.ToInt32(txtRate.Text);

            if (txtPaise.Text.Trim() != "")
                oInvoiceDetail.Paise = Convert.ToDecimal(txtPaise.Text) / 100;
            else
                oInvoiceDetail.Paise = Convert.ToDecimal(0.00);
            string[] TotalKG = txtQty.Text.Split('+');
            int total = 0;
            decimal totkg = 0;
            decimal count = 0;
            if (ddlQtyType.SelectedItem.Text == "Kg")
            {
                foreach (string value in TotalKG)
                {
                    totkg = totkg + Convert.ToDecimal(value.Trim());
                }
                count = ((Convert.ToDecimal(txtRate.Text) + (oInvoiceDetail.Paise)) * totkg);
                oInvoiceDetail.Total = count;
                oInvoiceDetail.TotalQty = totkg;
            }
            else if (ddlQtyType.SelectedItem.Text == "Gram")
            {
                foreach (string value in TotalKG)
                {
                    string value1 = "0." + value;
                    totkg = totkg + Convert.ToDecimal(value1.Trim());
                }
                count = ((Convert.ToDecimal(txtRate.Text) + (oInvoiceDetail.Paise)) * totkg);
                oInvoiceDetail.Total = count;
                oInvoiceDetail.TotalQty = totkg;
            }
            else
            {

                foreach (string value in TotalKG)
                {
                    total = total + Convert.ToInt32(value);
                }
                count = ((Convert.ToDecimal(txtRate.Text) + (oInvoiceDetail.Paise)) * total);
                oInvoiceDetail.Total = count;
                oInvoiceDetail.TotalQty = total;
            }





            oInvoiceDetail.Amount = Convert.ToDecimal(txtRate.Text) + (oInvoiceDetail.Paise);
            oBAL = new BAL();
            int i = oBAL.InvoiceDetail(oInvoiceDetail);
            if (i > 0)
            {
                lbGrosstotal.Text = oHelper.GetValue("select sum(total) as cnt from invoicedetails where ref_invid=" + lbInvoiceNumber.Text, "cnt");
                oBAL = null; oInvoiceDetail = null;
                if (!string.IsNullOrEmpty(Request.QueryString["invid"]))
                {
                    lbInvoiceNumber.Text = Request.QueryString["invid"].ToString();
                    oHelper.FillRepeater(rptProduct, "select id.*,pm.ProductNameJoin,um.FullName from Invoicemaster im join invoicedetails id on id.ref_invid=im.invid join productmaster pm on id.Ref_ProductId=pm.productid join UserMaster um on im.createdby=um.UserID where im.invid=" + lbInvoiceNumber.Text);
                    oHelper.DropDownFill(ddlProduct, "productmaster", "productid", "ProductNameJoin");
                }
                ddlProduct.SelectedIndex = 0;
                ddlQtyType.SelectedIndex = 0;
                txtQty.Text = "";
                txtRate.Text = "";
                txtPaise.Text = "";
            }
        }
        protected void lnkNext_Click(object sender, EventArgs e)
        {
            
            oInvoiceDetail = new InvoiceDetail();
            oInvoiceDetail.Flag = "insert_mapInvoiceDetails";
            oInvoiceDetail.Ref_InvId = Convert.ToInt32(lbInvoiceNumber.Text);
            if (txttransport.Text == "")
                oInvoiceDetail.Transportcharges = 0;
            else
                oInvoiceDetail.Transportcharges = Convert.ToDecimal(txttransport.Text);

            oInvoiceDetail.InvTotal = Convert.ToDecimal(lbGrosstotal.Text);
            oInvoiceDetail.FinalTotal = oInvoiceDetail.InvTotal + oInvoiceDetail.Transportcharges;

            if (txtadpayment.Text == "")
                oInvoiceDetail.Advancepayment = 0;
            else
                oInvoiceDetail.Advancepayment = Convert.ToDecimal(txtadpayment.Text);
            oInvoiceDetail.Paymentdue = oInvoiceDetail.FinalTotal - oInvoiceDetail.Advancepayment;
            Session["transport"] = txttransport.Text.Trim();
            Session["adv"] = txtadpayment.Text.Trim();
            oBAL = new BAL();
            int i = oBAL.InvoiceDetail(oInvoiceDetail);
            if (i > 0)
            {
                oBAL = null; oInvoiceDetail = null;
                Session["invid"] = lbInvoiceNumber.Text.Trim();

                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Module/Invoice/InvoicePDF.aspx?invid=" + lbInvoiceNumber.Text.Trim() + "','_blank');", true);
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Module/Invoice/viewinvoice.aspx?invid=" + lbInvoiceNumber.Text.Trim() + "','_blank');", true);

                Response.Redirect("/Module/Invoice/viewinvoice.aspx?invid=" + lbInvoiceNumber.Text);
            }
        }
        //public void setintial()
        //{

        //    dtCurrentTable.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("product", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("qty", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("totalqty", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("qtytype", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("rate", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("paise", typeof(string)));
        //    dtCurrentTable.Columns.Add(new DataColumn("total", typeof(string)));
        //    ViewState["CurrentTable"] = dtCurrentTable;

        //}
    }
}