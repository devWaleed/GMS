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
    
    public partial class USP_ProductWiseStock_Result
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public Nullable<int> OpeningStock { get; set; }
        public Nullable<decimal> TotalPurchase { get; set; }
        public Nullable<decimal> TotalProductGivenForPrinting { get; set; }
        public Nullable<decimal> Shrinkage { get; set; }
        public Nullable<decimal> TotalReceived { get; set; }
        public Nullable<int> TotalSales { get; set; }
        public Nullable<decimal> TotalTailorSend { get; set; }
        public Nullable<decimal> TotalTailorReceived { get; set; }
    }
}
