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
    
    public partial class BOND
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOND()
        {
            this.POSITION = new HashSet<POSITION>();
        }
    
        public string Issuer { get; set; }
        public decimal Coupon { get; set; }
        public string MatMonth { get; set; }
        public int MatYear { get; set; }
        public int SecurityId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POSITION> POSITION { get; set; }
    }
}
