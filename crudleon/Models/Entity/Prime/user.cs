//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace crudleon.Models.Entity.Prime
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Nullable<int> idState { get; set; }
        public Nullable<int> edad { get; set; }
    
        public virtual cstate cstate { get; set; }
    }
}
