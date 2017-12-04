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
    
    public partial class PrinterChalan
    {
        public PrinterChalan()
        {
            this.PrinterChalanDetails = new HashSet<PrinterChalanDetail>();
        }
    
        public int Id { get; set; }
        public int VendorId { get; set; }
        public System.DateTime ChalanDate { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string Description { get; set; }
        public Nullable<int> chalan_number { get; set; }
        public string dispatch_document_number { get; set; }
        public string dispatched_through { get; set; }
        public string bale_numbers { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> financial_year { get; set; }
        public int CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual FinancialYear FinancialYear { get; set; }
        public virtual ICollection<PrinterChalanDetail> PrinterChalanDetails { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual User User { get; set; }
    }
}
