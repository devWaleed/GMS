//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ProductId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string ChalanNumber { get; set; }
        public string BillNumber { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string Type { get; set; }
        public Nullable<int> ReferenceRecordId { get; set; }
        public Nullable<int> financial_year { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
    }
}
