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
    
    public partial class TailorChalan
    {
        public TailorChalan()
        {
            this.TailorChalanDetails = new HashSet<TailorChalanDetail>();
            this.TailorChalanDetails1 = new HashSet<TailorChalanDetail>();
        }
    
        public int Id { get; set; }
        public int VendorId { get; set; }
        public System.DateTime ChalanDate { get; set; }
        public string ChalanNo { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string Description { get; set; }
        public string bill_number { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> financial_year { get; set; }
        public int CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual ICollection<TailorChalanDetail> TailorChalanDetails { get; set; }
        public virtual ICollection<TailorChalanDetail> TailorChalanDetails1 { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual User User { get; set; }
    }
}
