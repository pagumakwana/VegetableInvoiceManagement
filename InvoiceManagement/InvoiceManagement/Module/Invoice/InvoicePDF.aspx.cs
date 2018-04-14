using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;

namespace InvoiceManagement.Module.Invoice
{
    public partial class InvoicePDF : System.Web.UI.Page
    {
        Helper oHelper = new Helper();
        protected void Page_Load(object sender, EventArgs e)
        {
            GeneratePdf();
        }
        //private static PdfPCell ImageCell(string path, float scale, int align)
        //{
        //    iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(@"H:\VegCMS\InvoiceManagement\InvoiceManagement\dist\images\Logo.jpg");
        //    image.ScalePercent(scale);
        //    image.ScaleToFitHeight = false;
        //    PdfPCell cell = new PdfPCell(image);
        //    cell.BorderColor = BaseColor.BLACK;
        //    //cell.VerticalAlignment = PdfPCell.ALIGN_TOP;
        //    //cell.HorizontalAlignment = align;
        //    //cell.PaddingBottom = 0f;
        //    //cell.PaddingTop = 0f;
        //    return cell;
        //}

        public void GeneratePdf()
        {
            int invid = Convert.ToInt32(Session["invid"].ToString());
            string path = ""; string invdate = "", invtime = "", address = "", qtytype = "", grossqty = "";
            int totalqty = 0; string clientname = ""; string mobile = "";
            //DataTable dt = oHelper.GetDataTable("select * from InvoiceDetails where Ref_invid = 1");
            ////DataTable dt = new DataTable();
            DataTable dtinvclient = oHelper.GetDataTable("select id.*,pm.ProductNameJoin,um.FullName from Invoicemaster im join invoicedetails id on id.ref_invid=im.invid join productmaster pm on id.Ref_ProductId=pm.productid join UserMaster um on im.createdby=um.UserID where im.invid=" + invid);
            DataTable dtinv = oHelper.GetDataTable("select im.*,cm.* from invoicemaster im join ClientMaster cm on im.Ref_ClientId=cm.ClientID where im.InvID=" + invid);
            //DataTable dtinv = oHelper.GetDataTable("select * from InvoiceMaster im inner join invoicedetails id on id.Ref_invid = im.Invid where im.Invid = " + invid);
            if (dtinv.Rows.Count > 0)
            {
                foreach (DataRow dr in dtinv.Rows)
                {
                    invdate = dr["InvDate"].ToString();
                    invtime = dr["InvTime"].ToString().Replace(",", "<br/>");
                    clientname = dr["Fullname"].ToString();
                    address = dr["Address"].ToString();
                    mobile = dr["Mobile"].ToString();
                }

            }
            Document document = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
            Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, BaseColor.BLACK);
            string filepath = @"P:\Sample\invdate\";
            FileInfo file = new FileInfo(filepath);
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
                path = filepath + invid + ".pdf";
            }
            else
            {
                path = filepath + invid + ".pdf";
            }
            MemoryStream memstream = new MemoryStream();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
            document.Open();
            PdfPTable table; PdfPCell cell; Phrase phrase; PdfImage image;


            table = new PdfPTable(2);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.2f, 0.8f });
            table.SpacingAfter = 7f;
            table.DefaultCell.Border = Rectangle.LEFT_BORDER;
            table.DefaultCell.Border = Rectangle.RIGHT_BORDER;
            table.DefaultCell.Border = Rectangle.TOP_BORDER;
            table.DefaultCell.Border = Rectangle.BOTTOM_BORDER;
            //Company Logo
            //iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance("");
            //img.setScaleToFitHeight(false);
            //cell = ImageCell("", 10f, PdfPCell.ALIGN_CENTER);
            iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(@"P:\Projects\InvoiceManagement\InvoiceManagement\dist\images\newlogo.png");
            img.ScaleToFitHeight = false;
            //img.Width = 10f;
            //img.Height = 10f;
            cell = new PdfPCell();
            cell.AddElement(img);
            cell.BorderColor = BaseColor.BLACK;
            cell.Border = 2;
            cell.Border = 4;
            cell.Border = 8;
            cell.Border = 1;
            cell.Border = 2;
            cell.Rowspan = 2;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            //Company Name and Address
            phrase = new Phrase();
            phrase.Add(new Chunk("MANUBHAI FRESH VEGETABLE SUPPLIERS", FontFactory.GetFont("Arial", 16, Font.BOLD, BaseColor.BLACK)));
            //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            //cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Border = 2;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 8f;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.VerticalAlignment = 1;
            //cell.VerticalAlignment = 1;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Shop No. 21/22 New Municipal Market, Opp.Railway Station,\nBorivali-West, Mumbai-400092, Tel No:- 022-28901729/28900418/28908169\nManubhai Pandya:- 09821159981/ Nitish Pandya:- 09870399510\nEmail:- manubhaipandya5@gmail.com", FontFactory.GetFont("Arial", 10, Font.BOLD, BaseColor.BLACK)));
            //cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
            //cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Border = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 8f;
            cell.PaddingBottom = 4f;
            //cell.VerticalAlignment = 1;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.5f, 0.3f, 0.3f, 0.3f });
            table.SpacingAfter = 7f;



            phrase = new Phrase();
            phrase.Add(new Chunk("Date : " + invdate + "\n\n", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            phrase.Add(new Chunk("Invoice No. : " + invid + "\n\n", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = 1;
            //cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            cell.VerticalAlignment = 1;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Party Name : " + clientname, FontFactory.GetFont("Arial", 10, Font.BOLD)));
            phrase.Add(new Chunk(" \n\n", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            phrase.Add(new Chunk("Address : " + address, FontFactory.GetFont("Arial", 10, Font.BOLD)));
            phrase.Add(new Chunk(" \n\n", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.NoWrap = false;
            cell.MinimumHeight = 15f;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            //phrase = new Phrase();
            //phrase.Add(new Chunk("Time \n\n", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            //phrase.Add(new Chunk(" \n\n", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            //cell = new PdfPCell();
            //cell.AddElement(phrase);
            //cell.MinimumHeight = 15f;
            //cell.HorizontalAlignment = 1;
            ////cell.PaddingLeft = 4f;
            //cell.PaddingRight = 4f;
            //cell.PaddingTop = 4f;
            //cell.PaddingBottom = 4f;
            //table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Time : " + invtime + "\n\n", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            phrase.Add(new Chunk(" \n\n", FontFactory.GetFont("Arial", 10, Font.NORMAL)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = 1;
            //cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);
            document.Add(table);

            table = new PdfPTable(4);
            table.TotalWidth = 500f;
            table.LockedWidth = true;
            table.SetWidths(new float[] { 0.5f, 0.3f, 0.3f, 0.3f });
            table.SpacingAfter = 7f;
            table.SplitLate = false;

            phrase = new Phrase();
            phrase.Add(new Chunk("Vegetable Name", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.MinimumHeight = 15f;
            cell.HorizontalAlignment = 1;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Gross Quantity", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.HorizontalAlignment = 1;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Net Quantity", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.HorizontalAlignment = 1;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);


            phrase = new Phrase();
            phrase.Add(new Chunk("Gross Total", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.HorizontalAlignment = 1;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            string subtotal = string.Format("{0:c}", oHelper.GetValue("select sum(total)as total from InvoiceDetails where Ref_InvId=" + Request.QueryString["invid"], "total"));
            string advanced = string.Format("{0:c}", oHelper.GetValue("select sum(Advancepayment)as adv from MapInvoiceTotal where Ref_InvId=" + Request.QueryString["invid"], "adv"));
            string transport = string.Format("{0:c}", oHelper.GetValue("select Transportcharges from MapInvoiceTotal where Ref_InvId=" + Request.QueryString["invid"], "Transportcharges"));
            string paydue = string.Format("{0:c}", oHelper.GetValue("select Paymentdue from MapInvoiceTotal where Ref_InvId=" + Request.QueryString["invid"], "Paymentdue"));

            foreach (DataRow dr in dtinvclient.Rows)
            {
                phrase = new Phrase();
                phrase.Add(new Chunk(dr["ProductNameJoin"].ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell = new PdfPCell();
                cell.AddElement(phrase);
                cell.HorizontalAlignment = 0;
                cell.PaddingLeft = 4f;
                cell.PaddingRight = 4f;
                cell.PaddingTop = 4f;
                cell.PaddingBottom = 4f;
                table.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(dr["GrossQty"].ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell = new PdfPCell();
                cell.AddElement(phrase);
                cell.HorizontalAlignment = 0;
                cell.PaddingLeft = 4f;
                cell.PaddingRight = 4f;
                cell.PaddingTop = 4f;
                cell.PaddingBottom = 4f;
                table.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(dr["TotalQty"].ToString() + dr["QtyType"].ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell = new PdfPCell();
                cell.AddElement(phrase);
                cell.HorizontalAlignment = 0;
                cell.PaddingLeft = 4f;
                cell.PaddingRight = 4f;
                cell.PaddingTop = 4f;
                cell.PaddingBottom = 4f;
                table.AddCell(cell);

                phrase = new Phrase();
                phrase.Add(new Chunk(dr["Total"].ToString(), FontFactory.GetFont("Arial", 10, Font.BOLD)));
                cell = new PdfPCell();
                cell.AddElement(phrase);
                cell.HorizontalAlignment = 0;
                cell.PaddingLeft = 4f;
                cell.PaddingRight = 4f;
                cell.PaddingTop = 4f;
                cell.PaddingBottom = 4f;
                table.AddCell(cell);
            }


            phrase = new Phrase();
            phrase.Add(new Chunk("Gross Total : " + subtotal, FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Transport Charges : " + transport, FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Sales Return/Advance : "+advanced, FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("Final Amount : " + paydue, FontFactory.GetFont("Arial", 12, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            phrase = new Phrase();
            phrase.Add(new Chunk("", FontFactory.GetFont("Arial", 10, Font.BOLD)));
            cell = new PdfPCell();
            cell.AddElement(phrase);
            cell.Colspan = 3;
            cell.HorizontalAlignment = 2;
            cell.PaddingLeft = 4f;
            cell.PaddingRight = 4f;
            cell.PaddingTop = 4f;
            cell.PaddingBottom = 4f;
            table.AddCell(cell);

            document.Add(table);



            document.Close();

            ShowPdf(path);

        }


        public void ShowPdf(string filepath)
        {
            //Clears all content output from Buffer Stream
            Response.ClearContent();
            //Clears all headers from Buffer Stream
            Response.ClearHeaders();
            //Adds an HTTP header to the output stream
            Response.AddHeader("Content-Disposition", "inline;filename=\"" + filepath + "\"");
            //Gets or Sets the HTTP MIME type of the output stream
            Response.ContentType = "application/pdf";
            //Writes the content of the specified file directory to an HTTP response output stream as a file block
            Response.WriteFile(filepath);
            //sends all currently buffered output to the client
            Response.Flush();
            //Clears all content output from Buffer Stream
            Response.Clear();
        }

    }
}