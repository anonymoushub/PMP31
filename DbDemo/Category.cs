//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Items = new HashSet<Items>();
        }
    
        public int id_category { get; set; }
        public string c_name { get; set; }
    
        public virtual ICollection<Items> Items { get; set; }
    }
}
