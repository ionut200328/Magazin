//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Magazin.Models.EntytyLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bonuri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bonuri()
        {
            this.BonProdus = new HashSet<BonProdu>();
        }
    
        public int IDbon { get; set; }
        public System.DateTime emitere { get; set; }
        public int @operator { get; set; }
        public Nullable<decimal> total { get; set; }
        public bool active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BonProdu> BonProdus { get; set; }
        public virtual Utilizatori Utilizatori { get; set; }
    }
}
