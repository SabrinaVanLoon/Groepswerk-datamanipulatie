//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework_DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class a_Veld
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public a_Veld()
        {
            this.a_Opdrachten = new HashSet<a_Opdracht>();
        }
    
        public int Id { get; set; }
        public Nullable<int> eigenaar_Id { get; set; }
        public int nummer { get; set; }
        public decimal oppervlakte { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<a_Opdracht> a_Opdrachten { get; set; }
        public virtual a_Speler a_Speler { get; set; }
    }
}
