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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.InvoiceDetails = new HashSet<InvoiceDetail>();
            this.PrinterChalanDetails = new HashSet<PrinterChalanDetail>();
            this.PurchaseDetails = new HashSet<PurchaseDetail>();
            this.TailorChalanSendDetails = new HashSet<TailorChalanSendDetail>();
            this.TailorChalanDetails = new HashSet<TailorChalanDetail>();
            this.TailorMaterialDetails = new HashSet<TailorMaterialDetail>();
            this.Transactions = new HashSet<Transaction>();
            this.PrintJobWorkReceivedDetails = new HashSet<PrintJobWorkReceivedDetail>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> Unit { get; set; }
        public Nullable<decimal> SellingPrice { get; set; }
        public int CompanyId { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual MeasuringUnit MeasuringUnit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrinterChalanDetail> PrinterChalanDetails { get; set; }
        public virtual ProductType ProductType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TailorChalanSendDetail> TailorChalanSendDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TailorChalanDetail> TailorChalanDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TailorMaterialDetail> TailorMaterialDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrintJobWorkReceivedDetail> PrintJobWorkReceivedDetails { get; set; }
    }
}
