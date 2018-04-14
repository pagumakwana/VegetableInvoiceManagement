using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace InvoiceManagement.Logics
{
    //26/04/2017 SQL entity added by pragnesh
    #region SQL
    public class SQL
    {
        public SqlConnection Con { get; set; }
        public SqlCommand Cmd = new SqlCommand();
        public SqlDataAdapter Sda;
        public SqlDataReader Sdr;
        public DataSet ds = new DataSet();
        public string StrCon = ConfigurationManager.ConnectionStrings["proteam"].ToString();
        public string Query { get; set; }
    }
    #endregion
}
