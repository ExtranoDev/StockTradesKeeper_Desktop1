//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockTracking.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCT
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int StockAmount { get; set; }
        public int CategoryID { get; set; }
        public int Price { get; set; }
        public bool isDeleted { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
