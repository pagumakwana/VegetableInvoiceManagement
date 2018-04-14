using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InvoiceManagement.App_Code;

namespace InvoiceManagement.Logics
{
    public class BAL
    {
        DAL oDAL;
        //25/04/2017 Employee Register added by pragnesh
        public int UserMaster(UserMaster oUserMaster)
        {
            int id = 0; oDAL = new DAL();
            try
            {
                id = (oDAL.UserMaster(oUserMaster));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDAL = null;
            }
            return id;
        }

        //29/04/2017 UserLogin added by pragnesh
        public int UserLogin(UserMaster oUserMaster)
        {
            int id = 0; oDAL = new DAL();
            try
            {
                id = (oDAL.UserLogin(oUserMaster));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDAL = null;
            }
            return id;
        }

        //04/05/2017 ClientMasterDetails added by pragnesh
        public int ClientMasterDetails(ClientMaster oClientMaster)
        {
            int id = 0; oDAL = new DAL();
            try
            {
                id = (oDAL.ClientMasterDetails(oClientMaster));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDAL = null;
            }
            return id;
        }

        //07/05/2017 InvoiceMaster added by pragnesh
        public int InvoiceMaster(InvoiceMaster oInvoiceMaster)
        {
            int id = 0; oDAL = new DAL();
            try
            {
                id = (oDAL.InvoiceMaster(oInvoiceMaster));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDAL = null;
            }
            return id;
        }

        //07/05/2017 InvoiceDetail added by pragnesh
        public int InvoiceDetail(InvoiceDetail oInvoiceDetail)
        {
            int id = 0; oDAL = new DAL();
            try
            {
                id = (oDAL.InvoiceDetail(oInvoiceDetail));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDAL = null;
            }
            return id;
        }
    }
}