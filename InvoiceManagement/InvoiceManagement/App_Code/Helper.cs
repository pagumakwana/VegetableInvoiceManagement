using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using InvoiceManagement.Logics;

namespace InvoiceManagement.App_Code
{
    public class Helper
    {
        SQL oSQL;

        //02/05/2017 User Login added by pragnesh
        public bool FillRepeater(Repeater Repeater, string Query)
        {
            bool check = false;

            oSQL = new SQL(); oSQL.ds.Clear();
            try
            {
                oSQL.Con = new SqlConnection(oSQL.StrCon);
                oSQL.Cmd = new SqlCommand(Query, oSQL.Con);
                oSQL.Con.Open();
                oSQL.Sda = new SqlDataAdapter(oSQL.Cmd);
                oSQL.Sda.Fill(oSQL.ds);
                Repeater.DataSource = oSQL.ds;
                Repeater.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oSQL.Con.Dispose();
                oSQL.Con.Close();
                oSQL.Con.Dispose();
            }

            return check;
        }
        //Fill DropDown
        public void DropDownFill(DropDownList DropDownList, string TableName, string Id, string ColumnName)
        {
            oSQL = new SQL();
            DropDownList.Items.Clear();
            oSQL.Query = "select * from " + TableName;
            using (oSQL.Con = new SqlConnection(oSQL.StrCon))
            {
                using (oSQL.Cmd = new SqlCommand(oSQL.Query, oSQL.Con))
                {
                    oSQL.Con.Open();
                    oSQL.Sdr = oSQL.Cmd.ExecuteReader();
                    while (oSQL.Sdr.Read())
                    {
                        ListItem item = new ListItem();
                        item.Value = oSQL.Sdr[Id].ToString();
                        item.Text = oSQL.Sdr[ColumnName].ToString();
                        DropDownList.Items.Add(item);
                    }
                    DropDownList.Items.Insert(0, new ListItem("Select", "0"));
                    oSQL.Sdr.Close();
                    oSQL.Con.Close();
                }
            }
        }

        public DataTable GetDataTable(string Query)
        {
            oSQL = new SQL();
            DataTable _DataTable = new DataTable();
            using (oSQL.Con = new SqlConnection(oSQL.StrCon))
            {
                using (oSQL.Cmd = new SqlCommand(Query, oSQL.Con))
                {
                    oSQL.Sda = new SqlDataAdapter(oSQL.Cmd);
                    _DataTable.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    try
                    {
                        oSQL.Sda.Fill(_DataTable);
                    }
                    catch (Exception _Exception)
                    {
                        return null;
                    }
                }
            }

            return _DataTable;
        }

        public string GetValue(string Query, string Columname)
        {
            string val = "";
            oSQL = new SQL();
            oSQL.Query = Query;
            using (oSQL.Con = new SqlConnection(oSQL.StrCon))
            {
                using (oSQL.Cmd = new SqlCommand(oSQL.Query, oSQL.Con))
                {
                    oSQL.Con.Open();
                    oSQL.Sdr = oSQL.Cmd.ExecuteReader();
                    while (oSQL.Sdr.Read())
                    {
                        val = oSQL.Sdr[Columname].ToString();
                    }
                }
            }
            return val;
        }
    }
}