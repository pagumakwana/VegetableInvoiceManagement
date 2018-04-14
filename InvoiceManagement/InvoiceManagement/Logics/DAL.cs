using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using InvoiceManagement.App_Code;
using InvoiceManagement.Logics;

namespace InvoiceManagement.Logics
{
    public class DAL
    {
        SQL oSQL;

        //25/04/2017 Employee Register added by pragnesh
        #region UserMaster
        public int UserMaster(UserMaster oUserMaster)
        {
            int id = 0;
            oSQL = new SQL();
            try
            {
                oSQL.Con = new SqlConnection(oSQL.StrCon);
                oSQL.Cmd = new SqlCommand();
                oSQL.Cmd.CommandType = CommandType.StoredProcedure;
                oSQL.Cmd.CommandText = "sp_User";
                oSQL.Cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                oSQL.Cmd.Parameters.AddWithValue("@Flag", oUserMaster.Flag.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@UserID", "");
                oSQL.Cmd.Parameters.AddWithValue("@FullName", oUserMaster.FullName.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@Email", oUserMaster.Email.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@Pwd", oUserMaster.Pwd.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@CreatedBy", oUserMaster.CreatedBy);
                oSQL.Cmd.Connection = oSQL.Con;

                oSQL.Con.Open();
                oSQL.Cmd.ExecuteNonQuery();
                id = Convert.ToInt32(oSQL.Cmd.Parameters["@id"].Value);
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
            return id;
        }
        #endregion

        //30/04/2017 User Login added by pragnesh
        #region UserLogin
        public int UserLogin(UserMaster oUserMaster)
        {
            int id = 0;
            oSQL = new SQL();
            try
            {
                oSQL.Query = "select Email,Pwd,UserID,FullName from UserMaster where Email='" + oUserMaster.Email + "' and Pwd='" + oUserMaster.Pwd + "'";
                oSQL.Con = new SqlConnection(oSQL.StrCon);
                oSQL.Cmd = new SqlCommand(oSQL.Query, oSQL.Con);
                oSQL.Cmd.Connection = oSQL.Con;
                oSQL.Con.Open();
                oSQL.Sdr = oSQL.Cmd.ExecuteReader();
                if (oSQL.Sdr.HasRows)
                {
                    while (oSQL.Sdr.Read())
                    {
                        HttpContext.Current.Session["UserID"] = oSQL.Sdr["UserID"].ToString();
                        HttpContext.Current.Session["UserName"] = oSQL.Sdr["FullName"].ToString();
                    }
                    id = 1;
                }
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
            return id;
        }
        #endregion

        //25/04/2017 Employee Register added by pragnesh
        #region ClientMasterDetails
        public int ClientMasterDetails(ClientMaster oClientMaster)
        {
            int id = 0;
            oSQL = new SQL();
            try
            {
                oSQL.Con = new SqlConnection(oSQL.StrCon);
                oSQL.Cmd = new SqlCommand();
                oSQL.Cmd.CommandType = CommandType.StoredProcedure;
                oSQL.Cmd.CommandText = "sp_Client";
                oSQL.Cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                oSQL.Cmd.Parameters.AddWithValue("@Flag", oClientMaster.Flag.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@ClientId", "");
                oSQL.Cmd.Parameters.AddWithValue("@FullName", oClientMaster.FullName.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@Mobile", oClientMaster.Mobile.Trim());
                oSQL.Cmd.Parameters.AddWithValue("@CreatedBy", oClientMaster.CreatedBy);
                oSQL.Cmd.Connection = oSQL.Con;

                oSQL.Con.Open();
                oSQL.Cmd.ExecuteNonQuery();
                id = Convert.ToInt32(oSQL.Cmd.Parameters["@id"].Value);
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
            return id;
        }
        #endregion

        //07/05/2017 InvoiceMaster added by pragnesh
        #region InvoiceMaster
        public int InvoiceMaster(InvoiceMaster oInvoiceMaster)
        {
            int id = 0;
            oSQL = new SQL();
            try
            {
                oSQL.Con = new SqlConnection(oSQL.StrCon);
                oSQL.Cmd = new SqlCommand();
                oSQL.Cmd.CommandType = CommandType.StoredProcedure;
                oSQL.Cmd.CommandText = "sp_Invoice";
                oSQL.Cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                if (oInvoiceMaster.Flag.Equals("insert_Invoicemaster"))
                {
                    oSQL.Cmd.Parameters.AddWithValue("@Flag", oInvoiceMaster.Flag.Trim());
                    oSQL.Cmd.Parameters.AddWithValue("@InvID", "");
                    oSQL.Cmd.Parameters.AddWithValue("@Ref_ClientId", oInvoiceMaster.Ref_ClientId);
                    oSQL.Cmd.Parameters.AddWithValue("@InvDate", oInvoiceMaster.InvDate.Trim());
                    oSQL.Cmd.Parameters.AddWithValue("@InvTime", oInvoiceMaster.InvTime.Trim());
                    oSQL.Cmd.Parameters.AddWithValue("@Address", oInvoiceMaster.Address.Trim());

                    oSQL.Cmd.Parameters.AddWithValue("@CreatedBy", oInvoiceMaster.CreatedBy);
                }
                else if (oInvoiceMaster.Flag.Equals("update_Invoicemaster"))
                {
                    oSQL.Cmd.Parameters.AddWithValue("@Flag", oInvoiceMaster.Flag.Trim());
                    oSQL.Cmd.Parameters.AddWithValue("@InvID", oInvoiceMaster.InvID);
                    oSQL.Cmd.Parameters.AddWithValue("@InvPath", oInvoiceMaster.InvPath);
                    oSQL.Cmd.Parameters.AddWithValue("@InvFullPath", oInvoiceMaster.InvoiceFullpath);
                }
                oSQL.Cmd.Connection = oSQL.Con;
                oSQL.Con.Open();
                oSQL.Cmd.ExecuteNonQuery();
                id = Convert.ToInt32(oSQL.Cmd.Parameters["@id"].Value);
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
            return id;
        }
        #endregion

        //07/05/2017 InvoiceDetail added by pragnesh
        #region InvoiceDetail
        public int InvoiceDetail(InvoiceDetail oInvoiceDetail)
        {
            int id = 0;
            oSQL = new SQL();
            try
            {
                //
                oSQL.Con = new SqlConnection(oSQL.StrCon);

                //oSQL.Cmd.CommandType = CommandType.StoredProcedure;
                //oSQL.Cmd.CommandText = "sp_InvoiceDetail";
                if (oInvoiceDetail.Flag.Equals("insert_InvoiceDetails"))
                {
                    oSQL.Cmd = new SqlCommand("INSERT INTO  InvoiceDetails(Ref_InvId, Ref_ProductId,QtyType, GrossQty, TotalQty, Rate, Paise, Total,Amount) VALUES ('" + oInvoiceDetail.Ref_InvId + "', '" + oInvoiceDetail.Ref_ProductId + "','" + oInvoiceDetail.QtyType + "','" + oInvoiceDetail.GrossQty + "', '" + oInvoiceDetail.TotalQty + "', '" + oInvoiceDetail.Rate + "','" + oInvoiceDetail.Paise + "', '" + oInvoiceDetail.Total + "','" + oInvoiceDetail.Amount + "')", oSQL.Con);

                    //oSQL.Cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //oSQL.Cmd.Parameters.AddWithValue("@InvProdDetId", "");
                    //oSQL.Cmd.Parameters.AddWithValue("@Flag", oInvoiceDetail.Flag.Trim());
                    //oSQL.Cmd.Parameters.AddWithValue("@Ref_InvId", oInvoiceDetail.Ref_InvId);
                    //oSQL.Cmd.Parameters.AddWithValue("@Ref_ProductId", oInvoiceDetail.Ref_ProductId);
                    //oSQL.Cmd.Parameters.AddWithValue("@GrossQty", oInvoiceDetail.GrossQty);
                    //oSQL.Cmd.Parameters.AddWithValue("@QtyType", oInvoiceDetail.QtyType);
                    //oSQL.Cmd.Parameters.AddWithValue("@TotalQty", oInvoiceDetail.TotalQty);
                    //oSQL.Cmd.Parameters.AddWithValue("@Rate", oInvoiceDetail.Rate);
                    //oSQL.Cmd.Parameters.AddWithValue("@Paise", oInvoiceDetail.Paise);
                    //oSQL.Cmd.Parameters.AddWithValue("@Total", oInvoiceDetail.Total);
                }
                else if (oInvoiceDetail.Flag.Equals("insert_mapInvoiceDetails"))
                {
                    oSQL.Cmd = new SqlCommand("INSERT INTO  MapInvoiceTotal(Ref_InvId, InvTotal,Transportcharges,FinalTotal, Advancepayment,Paymentdue) VALUES ('" + oInvoiceDetail.Ref_InvId + "', '" + oInvoiceDetail.InvTotal + "','" + oInvoiceDetail.Transportcharges + "','" + oInvoiceDetail.FinalTotal + "','" + oInvoiceDetail.Advancepayment + "','" + oInvoiceDetail.Paymentdue + "')", oSQL.Con);
                    //oSQL.Cmd.Parameters.AddWithValue("@InvProdDetId", "");
                    //oSQL.Cmd.Parameters.AddWithValue("@Flag", oInvoiceDetail.Flag.Trim());
                    //oSQL.Cmd.Parameters.AddWithValue("@Ref_InvId", oInvoiceDetail.Ref_InvId);
                    //oSQL.Cmd.Parameters.AddWithValue("@InvTotal", oInvoiceDetail.InvTotal);
                    //oSQL.Cmd.Parameters.AddWithValue("@Transportcharges", oInvoiceDetail.Transportcharges);
                    //oSQL.Cmd.Parameters.AddWithValue("@Advancepayment", oInvoiceDetail.Advancepayment);
                }
                else if (oInvoiceDetail.Flag.Equals("delete_Invoiceproduct"))
                {
                    oSQL.Cmd = new SqlCommand("delete from InvoiceDetails where InvProdDetId=" + oInvoiceDetail.InvProdDetId, oSQL.Con);
                }
                else if (oInvoiceDetail.Flag.Equals("update_Invoiceproduct"))
                {
                    oSQL.Cmd = new SqlCommand("update InvoiceDetails set QtyType='" + oInvoiceDetail.QtyType + "', GrossQty='" + oInvoiceDetail.GrossQty + "', TotalQty='" + oInvoiceDetail.TotalQty + "', Rate='" + oInvoiceDetail.Rate + "', Paise='" + oInvoiceDetail.Paise + "', Total='" + oInvoiceDetail.Total + "',Amount='" + oInvoiceDetail.Amount + "' where InvProdDetId='" + oInvoiceDetail.InvProdDetId + "'", oSQL.Con);
                }
                oSQL.Cmd.Connection = oSQL.Con;

                oSQL.Con.Open();
                id = oSQL.Cmd.ExecuteNonQuery();

                //id = Convert.ToInt32(oSQL.Cmd.Parameters["@id"].Value);
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
            return id;
        }
        #endregion
    }
}