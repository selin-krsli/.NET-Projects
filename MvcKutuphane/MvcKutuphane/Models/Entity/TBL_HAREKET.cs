//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcKutuphane.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_HAREKET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_HAREKET()
        {
            this.TBL_CEZALAR = new HashSet<TBL_CEZALAR>();
        }
    
        public int ID { get; set; }
        public Nullable<int> Kitap { get; set; }
        public Nullable<int> Uye { get; set; }
        public Nullable<int> Personel { get; set; }
        public Nullable<System.DateTime> AlısTarihi { get; set; }
        public Nullable<System.DateTime> IadeTarihi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_CEZALAR> TBL_CEZALAR { get; set; }
        public virtual TBL_KITAP TBL_KITAP { get; set; }
        public virtual TBL_UYELER TBL_UYELER { get; set; }
    }
}
