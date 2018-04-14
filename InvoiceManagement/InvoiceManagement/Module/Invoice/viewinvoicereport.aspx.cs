using CrystalDecisions.CrystalReports.Engine;
using InvoiceManagement.App_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InvoiceManagement.Module.Invoice
{
    public partial class viewinvoicereport : System.Web.UI.Page
    {
        public int invoiceid; Helper oHelper = new Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string FileName; string FileName1;
                try
                {

                    int invid = Convert.ToInt32(Request.QueryString["invid"]);
                    if (Request.QueryString["flg"] == "1")
                    {
                        string fpath = oHelper.GetValue("select invpath from invoicemaster where invid=" + invid, "invpath");
                        Response.Redirect(fpath, false);
                    }
                    else
                    {
                        //FileName = Session["nInvNo"].ToString();
                        string strdate = oHelper.GetValue("select invdate from invoicemaster where invid=" + invid, "invdate");
                        string clientname = oHelper.GetValue("select cm.Fullname from invoicemaster im join clientmaster cm on im.ref_clientid=cm.clientid where im.invid=" + invid, "Fullname");
                        //string dateString, format;
                        //format = "dd-MMM-yyyy";
                        //DateTime result;
                        //CultureInfo provider = CultureInfo.InvariantCulture;
                        //result = DateTime.ParseExact(strdate, format, provider);

                        DateTime dtdate = DateTime.Parse(strdate);
                        //DateTime dtdate = DateTime.ParseExact(strdate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        string billdate = dtdate.ToString("dd-MMM-yyyy");
                        string billdate1 = dtdate.ToString("Y");
                        string billdate2 = dtdate.ToString("dd-MM-yyyy");
                        FileName = "InvoiceNo_" + Request.QueryString["invid"] + ".pdf";
                        FileName1 = "InvoiceNo_" + Request.QueryString["invid"] + " " + clientname + " " + billdate2 + ".pdf";

                        ReportDocument doc = new ReportDocument();
                        doc.Load(Server.MapPath("invoicereport.rpt"));
                        doc.SetDatabaseLogon("", "", "localhost", "VegCMSDB", false);
                        doc.SetParameterValue("@invid", Request.QueryString["invid"]);
                        //doc.SetParameterValue("var_nInvoiceNo", "10");
                        CrystalReportViewer1.ReportSource = doc;
                        CrystalDecisions.Shared.DiskFileDestinationOptions dfo = new CrystalDecisions.Shared.DiskFileDestinationOptions();
                        string dt = DateTime.Now.ToString("dd-MMM-yyyy");
                        string filep = Server.MapPath("~\\pdf\\" + billdate + "\\");
                        string filep1 = @"D:\\new manubhai file\\bill\\" + billdate1.Replace(",", "") + "\\";
                        if (!Directory.Exists(filep))
                            Directory.CreateDirectory(filep);
                        dfo.DiskFileName = filep + FileName;
                        string filepath = dfo.DiskFileName;
                        FileInfo fi = new FileInfo(filepath);
                        if (!fi.Exists)
                        {
                            doc.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dfo.DiskFileName);
                            //MemoryStream memoryStream = new MemoryStream();
                            //Stream exportStream = doc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                            //exportStream.CopyTo(memoryStream);
                            //string fpath = Server.MapPath("~/pdf/'" + billdate + "'/" + FileName);
                            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/pdf/');", true);
                            if (!Directory.Exists(filep1))
                                Directory.CreateDirectory(filep1);

                            File.Copy(filep + FileName, filep1 + FileName1);
                            //fi.CopyTo(filep1 + FileName);
                            Response.Redirect("~\\pdf\\" + billdate + "\\" + FileName, false);
                        }
                        else
                        {
                            int invid1 = Convert.ToInt32(Request.QueryString["invid"]);
                            Response.Redirect("/Module/Invoice/viewinvoicereport.aspx?invid=" + invid1 + "&flg=1");
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}