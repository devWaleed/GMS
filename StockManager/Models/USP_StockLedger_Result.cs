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
    
    public partial class USP_StockLedger_Result
    {
        public Nullable<int> SequenceNo { get; set; }
        public Nullable<int> ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string Particular { get; set; }
        public string DocType { get; set; }
        public string DocNo { get; set; }
        public Nullable<int> DocId { get; set; }
        public Nullable<decimal> IssuedQty { get; set; }
        public Nullable<decimal> ReceivedQty { get; set; }
    }
}
