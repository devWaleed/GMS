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
    
    public partial class PurchaseOrder
    {
        public PurchaseOrder()
        {
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
        }
    
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int InvoiceNumber { get; set; }
        public System.DateTime InvoiceDate { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
        public string Description { get; set; }
        public string dispatch_document_number { get; set; }
        public string dispatched_through { get; set; }
        public string destination { get; set; }
        public string bale_numbers { get; set; }
    
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
