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
    
    public partial class acc_transactions
    {
        public int id { get; set; }
        public int voucher_type { get; set; }
        public Nullable<int> voucher_no { get; set; }
        public System.DateTime voucher_date { get; set; }
        public string description { get; set; }
        public Nullable<int> company_id { get; set; }
        public Nullable<int> financial_year { get; set; }
    }
}