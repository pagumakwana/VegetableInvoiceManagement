using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InvoiceManagement.App_Code
{
    //26/04/2017 SQL entity added by pragnesh
    #region UserMaster
    public class UserMaster
    {
        private string _Flag;
        private int _UserID;
        private string _FullName;
        private string _Email;
        private string _Pwd;
        private DateTime _CreatedOnUtc;
        private int _CreatedBy;
        private DateTime _UpdatedOnUtc;
        private int _UpdatedBy;
        private bool _IsActive;

        public string Flag { get { return this._Flag; } set { this._Flag = value; } }
        public int UserID { get { return this._UserID; } set { this._UserID = value; } }
        public string FullName { get { return this._FullName; } set { this._FullName = value; } }
        public string Email { get { return this._Email; } set { this._Email = value; } }
        public string Pwd { get { return this._Pwd; } set { this._Pwd = value; } }
        public DateTime CreatedOnUtc { get { return this._CreatedOnUtc; } set { this._CreatedOnUtc = value; } }
        public int CreatedBy { get { return this._CreatedBy; } set { this._CreatedBy = value; } }
        public DateTime UpdatedOnUtc { get { return this._UpdatedOnUtc; } set { this._UpdatedOnUtc = value; } }
        public int UpdatedBy { get { return this._UpdatedBy; } set { this._UpdatedBy = value; } }
        public bool IsActive { get { return this._IsActive; } set { this._IsActive = value; } }
    }
    #endregion

    //04/05/2017 SQL entity added by pragnesh
    #region ClientMaster
    public class ClientMaster
    {
        private string _Flag;
        private int _ClientID;
        private string _FullName;
        private string _Mobile;
        private DateTime _CreatedOnUtc;
        private int _CreatedBy;
        private DateTime _UpdatedOnUtc;
        private int _UpdatedBy;
        private bool _IsActive;

        public string Flag { get { return this._Flag; } set { this._Flag = value; } }
        public int ClientID { get { return this._ClientID; } set { this._ClientID = value; } }
        public string FullName { get { return this._FullName; } set { this._FullName = value; } }
        public string Mobile { get { return this._Mobile; } set { this._Mobile = value; } }
        public DateTime CreatedOnUtc { get { return this._CreatedOnUtc; } set { this._CreatedOnUtc = value; } }
        public int CreatedBy { get { return this._CreatedBy; } set { this._CreatedBy = value; } }
        public DateTime UpdatedOnUtc { get { return this._UpdatedOnUtc; } set { this._UpdatedOnUtc = value; } }
        public int UpdatedBy { get { return this._UpdatedBy; } set { this._UpdatedBy = value; } }
        public bool IsActive { get { return this._IsActive; } set { this._IsActive = value; } }
    }
    #endregion

    //04/06/2017 SQL entity added by pragnesh
    #region Invoice master
    public class InvoiceMaster
    {
        private string _Flag;
        private int _InvID;
        private string _InvDate;
        private string _InvTime;
        private int _Ref_ClientId;
        private string _Address;
        private DateTime _CreatedOnUtc;
        private int _CreatedBy;
        private DateTime _UpdatedOnUtc;
        private int _UpdatedBy;
        private bool _IsActive;
        private decimal _Transportcharges;
        private decimal _Advancepayment;
        private string _InvoiceFullpath;
        private string _InvPath;

        public string Flag { get { return this._Flag; } set { this._Flag = value; } }
        public int InvID { get { return this._InvID; } set { this._InvID = value; } }
        public string InvDate { get { return this._InvDate; } set { this._InvDate = value; } }
        public string InvTime { get { return this._InvTime; } set { this._InvTime = value; } }
        public int Ref_ClientId { get { return this._Ref_ClientId; } set { this._Ref_ClientId = value; } }
        public string Address { get { return this._Address; } set { this._Address = value; } }
        public DateTime CreatedOnUtc { get { return this._CreatedOnUtc; } set { this._CreatedOnUtc = value; } }
        public int CreatedBy { get { return this._CreatedBy; } set { this._CreatedBy = value; } }
        public DateTime UpdatedOnUtc { get { return this._UpdatedOnUtc; } set { this._UpdatedOnUtc = value; } }
        public int UpdatedBy { get { return this._UpdatedBy; } set { this._UpdatedBy = value; } }
        public bool IsActive { get { return this._IsActive; } set { this._IsActive = value; } }
        public string InvoiceFullpath { get { return this._InvoiceFullpath; } set { this._InvoiceFullpath = value; } }
        public string InvPath { get { return this._InvPath; } set { this._InvPath = value; } }
    }
    public class InvoiceDetail
    {
        private string _Flag;
        private int _InvProdDetId;
        private int _Ref_InvId;
        private int _Ref_ProductId;
        private string _GrossQty;
        private string _QtyType;
        private decimal _TotalQty;
        private int _Rate;
        private decimal _Paise;
        private decimal _Total;
        private bool _IsActive;
        private bool _IsDeleted;
        private decimal _Transportcharges;
        private decimal _Advancepayment;
        private decimal _InvTotal;
        private decimal _FinalTotal;
        private decimal _Paymentdue;
        private decimal _Amount;

        public string Flag { get { return this._Flag; } set { this._Flag = value; } }
        public int InvProdDetId { get { return this._InvProdDetId; } set { this._InvProdDetId = value; } }
        public int Ref_InvId { get { return this._Ref_InvId; } set { this._Ref_InvId = value; } }
        public int Ref_ProductId { get { return this._Ref_ProductId; } set { this._Ref_ProductId = value; } }
        public string GrossQty { get { return this._GrossQty; } set { this._GrossQty = value; } }
        public string QtyType { get { return this._QtyType; } set { this._QtyType = value; } }
        public decimal TotalQty { get { return this._TotalQty; } set { this._TotalQty = value; } }
        public int Rate { get { return this._Rate; } set { this._Rate = value; } }
        public decimal Paise { get { return this._Paise; } set { this._Paise = value; } }
        public decimal Total { get { return this._Total; } set { this._Total = value; } }
        public bool IsActive { get { return this._IsActive; } set { this._IsActive = value; } }
        public bool IsDeleted { get { return this._IsDeleted; } set { this._IsDeleted = value; } }
        public decimal Transportcharges { get { return this._Transportcharges; } set { this._Transportcharges = value; } }
        public decimal Advancepayment { get { return this._Advancepayment; } set { this._Advancepayment = value; } }
        public decimal InvTotal { get { return this._InvTotal; } set { this._InvTotal = value; } }
        public decimal FinalTotal { get { return this._FinalTotal; } set { this._FinalTotal = value; } }
        public decimal Paymentdue { get { return this._Paymentdue; } set { this._Paymentdue = value; } }
        public decimal Amount { get { return this._Amount; } set { this._Amount = value; } }
    }
    #endregion
}