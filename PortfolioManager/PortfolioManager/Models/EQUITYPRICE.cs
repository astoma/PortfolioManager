//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PortfolioManager.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EQUITYPRICE
    {
        public string EquitySymbol { get; set; }
        public decimal LastSale { get; set; }
        public Nullable<decimal> MarketCap { get; set; }
        public System.DateTime ExDate { get; set; }
    }
}
