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
    
    public partial class a_Graanprijs
    {
        public int Id { get; set; }
        public int graansoort_Id { get; set; }
        public Nullable<System.DateTime> begintijd { get; set; }
        public Nullable<System.DateTime> eindtijd { get; set; }
        public Nullable<decimal> aankoopprijs { get; set; }
        public Nullable<decimal> verkoopprijs { get; set; }
    
        public virtual a_Graansoort a_Graansoort { get; set; }
    }
}
