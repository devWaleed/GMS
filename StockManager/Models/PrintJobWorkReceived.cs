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
    
    public partial class PrintJobWorkReceived
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrintJobWorkReceived()
        {
            this.PrintJobWorkReceivedDetails = new HashSet<PrintJobWorkReceivedDetail>();
        }
    
        public int Id { get; set; }
        public int VendorId { get; set; }
        public System.DateTime ChalanDate { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string Description { get; set; }
        public int chalan_number { get; set; }
        public Nullable<int> created_by { get; set; }
        public Nullable<int> financial_year { get; set; }
        public Nullable<int> tenant_id { get; set; }
    
        public virtual FinancialYear FinancialYear { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrintJobWorkReceivedDetail> PrintJobWorkReceivedDetails { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual Tenant Tenant { get; set; }
        public virtual User User { get; set; }
    }
}
