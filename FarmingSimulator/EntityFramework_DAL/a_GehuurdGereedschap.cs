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
    
    public partial class a_GehuurdGereedschap
    {
        public int Id { get; set; }
        public int speler_Id { get; set; }
        public Nullable<int> gereedschap_Id { get; set; }
    
        public virtual a_Gereedschap a_Gereedschap { get; set; }
        public virtual a_Speler a_Speler { get; set; }
    }
}
